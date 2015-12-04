namespace SiteletLib

open WebSharper
open WebSharper.Sitelets
open WebSharper.UI.Next
open WebSharper.UI.Next.Html
open WebSharper.UI.Next.Server
open System.Collections.Generic

module Main =

    let sitelet httproot =
        let compiledPages = 
            FsiExec.evaluateFsx<CompiledWebParts> "WebPartPage.fsx" (sprintf "SiteLib.Configuration.WebPartPage.Site.getCompiledWebParts \"%s\"" httproot)
        
        match compiledPages with
        | FsiExec.Success compiled -> 
            let sitelet =
                compiled.WebParts
                |> List.map (
                    fun (Route route, webpart) -> 
                        Sitelet.Content route route (fun _ -> 
                            Content.Page(
                                Title = route, 
                                Body = [ client <@ ShellPage.Client.main() @>
                                         webpart ])))
                |> Sitelet.Sum
                    
            sitelet, compiled.Metadata

        | _ -> failwith "Fail to compile fsx"