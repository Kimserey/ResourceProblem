# WebSharper resource problem

Attempt to solve the BaseResource issue.

When a BaseResource is not present in the .fsx file, all Rpc calls will not work and yield the following error:

    http://localhost:9000/? Failed to load resource: the server responded with a status of 500 (Internal Server Error)
    WebSharper.Main.min.js:1 WebSharper: Uncaught asynchronous exception Error: Response status is not 200: 500(…)

    ...Response...
    System.IO.FileNotFoundException: Could not load file or assembly 'FSI-ASSEMBLY, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
    File name: 'FSI-ASSEMBLY, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
       at System.RuntimeTypeHandle.GetTypeByName(String name, Boolean throwOnError, Boolean ignoreCase, Boolean reflectionOnly, StackCrawlMarkHandle stackMark, IntPtr pPrivHostBinder, Boolean loadTypeFromPartialName, ObjectHandleOnStack type)
       at System.RuntimeTypeHandle.GetTypeByName(String name, Boolean throwOnError, Boolean ignoreCase, Boolean reflectionOnly, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean loadTypeFromPartialName)
       at System.RuntimeType.GetType(String typeName, Boolean throwOnError, Boolean ignoreCase, Boolean reflectionOnly, StackCrawlMark& stackMark)
       at System.Type.GetType(String typeName, Boolean throwOnError)
       at WebSharper.Core.Reflection.Method.Load(FSharpOption`1 generics)
       at WebSharper.Core.Remoting.Server.getConverter(MethodHandle m)
       at WebSharper.Core.Remoting.Server.getCachedConverter(MethodHandle m)
       at WebSharper.Core.Remoting.Server.HandleRequest(Request req)
       at WebSharper.Web.RemotingExtensions.Server.HandleRequest(Server this, Request req, IContext context)
       at <StartupCode$WebSharper-Owin>.$Owin.Sitelets.Invoke@418-3.Invoke(String _arg2)
       at Microsoft.FSharp.Control.AsyncBuilderImpl.args@835-1.Invoke(a a)

    WRN: Assembly binding logging is turned OFF.
    To enable assembly bind failure logging, set the registry value [HKLM\Software\Microsoft\Fusion!EnableLog] (DWORD) to 1.
    Note: There is some performance penalty associated with assembly bind failure logging.
    To turn this feature off, remove the registry value [HKLM\Software\Microsoft\Fusion!EnableLog].
