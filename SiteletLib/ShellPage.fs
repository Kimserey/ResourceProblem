namespace SiteletLib

open WebSharper
open WebSharper.Sitelets
open WebSharper.UI.Next
open WebSharper.UI.Next.Html

module ShellPage =

    module Server =
        [<Rpc>]
        let getMessage() =
            async { 
                return "Hello from Shell"
            }

    [<JavaScript>]
    module Client =
        open WebSharper.JavaScript
        open WebSharper.UI.Next.Client
    
        let main() =
            divAttr [attr.style "background-color: blue;"] [
                text "Some navbar here"
                Doc.Button "Test" [] (fun () -> 
                    async { 
                        let! msg = Server.getMessage () 
                        do JS.Alert msg
                    } |> Async.Start)
            ]