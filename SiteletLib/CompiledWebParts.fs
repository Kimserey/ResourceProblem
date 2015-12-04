namespace SiteletLib

open WebSharper
open WebSharper.UI.Next
open WebSharper.Sitelets
open System.Reflection

type CompiledWebParts = {
    WebParts: List<WebPart>
    Metadata: Core.Metadata.Info
} with 
    static member Compile(httpRoot, webParts) = 
        let asm = Assembly.GetCallingAssembly()
        let metadata = WebSharperCompiler.compileAndUnpack asm httpRoot
        { WebParts = webParts; Metadata = metadata }
and WebPart = Route * Doc
and Route = Route of string