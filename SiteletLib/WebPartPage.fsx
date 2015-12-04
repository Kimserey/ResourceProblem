namespace SiteLib.Configuration

#load "References.fsx"

open WebSharper
open WebSharper.Sitelets
open System.IO
open SiteletLib
open WebSharper.UI.Next.Html
open WebSharper.Resources

// Comment here this section
// This section add a bootstrap link in the header of the page
// If this section is commented, the RPC in this file will not work anymore
//module Resources =
//    
//    type BootstrapResource() =
//        inherit BaseResource("//maxcdn.bootstrapcdn.com/bootstrap/3.3.5", "css/bootstrap.min.css")
//
//    [<assembly:Require(typeof<BootstrapResource>)>]
//    do()
// <---------------------------------------------------------------------->

module WebPartPage =

    module Server =
        [<Rpc>]
        let test () =
            async {
                return "Hello from webpart"
            }

    [<JavaScript>]
    module Client =
        open WebSharper.JavaScript
        open WebSharper.UI.Next.Client
        
        let styledDiv = divAttr [ attr.style "margin:10px;padding:10px;border:solid 1px black;" ]

        let showAlert() = 
            async {
                let! msg = Server.test()
                do JS.Alert msg
            } 

        let main() =
            styledDiv [ h1 [text "Web part"]; h2 [text "Main"]
                        div [ Doc.Button "Test" [] (fun () -> showAlert() |> Async.Start) ] ]

        let inspections() =
            styledDiv [ h1 [text "Web part"]; h2 [text "Inspections"]]

    module Site =
        open WebSharper.UI.Next.Server
    
        let getCompiledWebParts root = 
            CompiledWebParts.Compile(root, 
                [ Route "", client <@ Client.main() @>
                  Route "inspections", client <@ Client.inspections() @> ])