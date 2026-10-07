///////////////////////////////////////////////////////////////////////////////
///
/// File: ArchiInjector.cs
/// Revision: 1
/// Author: JRoeseph
/// Description: Simple injector to inject a harmony patch into SoG
/// 
///////////////////////////////////////////////////////////////////////////////
using System.Reflection;

public class ArchiInjector
{
    public static void Main(string[] args)
    {
        var gameAssembly = Assembly.LoadFrom("Secrets Of Grindea.exe");
        Grindapelago.Init();
        gameAssembly.EntryPoint.Invoke(null, new object[] { args });
    }
}
