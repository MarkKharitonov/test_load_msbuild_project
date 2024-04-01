using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;
using System;
using System.Diagnostics;
using System.IO;

internal class Program
{
    private static int Main(string[] args)
    {
        var msbuildDir = GetMSBuildDir();

        if (string.IsNullOrEmpty(msbuildDir))
        {
            Console.WriteLine("msbuildDir == null");
            MSBuildLocator.RegisterDefaults();
        }
        else
        {
            Console.WriteLine($"msbuildDir == \"{msbuildDir}\"");
            MSBuildLocator.RegisterMSBuildPath(msbuildDir);
        }

        Run(args.Length == 0 ? "sample_net472_legacy.proj" : args[0]);
        return 0;
    }

    private static void Run(string csprojFileName)
    {
        Console.WriteLine($"csprojFileName = \"{csprojFileName}\"");
        Debug.Assert(File.Exists(csprojFileName));

        var project = new Project(csprojFileName);
        Console.WriteLine($"MSBuildExtensionsPath = {project.GetPropertyValue("MSBuildExtensionsPath")}");
        Console.WriteLine($"MSBuildToolsVersion = {project.GetPropertyValue("MSBuildToolsVersion")}");
        Console.WriteLine($"MSBuildBinPath = {project.GetPropertyValue("MSBuildBinPath")}");
        Console.WriteLine($"VSToolsPath = {project.GetPropertyValue("VSToolsPath")}");
        Console.WriteLine($"TargetPath = {project.GetPropertyValue("TargetPath")}");
    }

    private static string GetMSBuildDir()
    {
#if true
        var vsInstallDir = Environment.GetEnvironmentVariable("VSINSTALLDIR");
        if (vsInstallDir == null)
        {
            vsInstallDir = Environment.GetEnvironmentVariable("VSAPPIDDIR");
            if (!string.IsNullOrEmpty(vsInstallDir))
            {
                vsInstallDir = Path.GetFullPath(vsInstallDir + "\\..\\..\\");
            }
        }
        if (!string.IsNullOrEmpty(vsInstallDir))
        {
            vsInstallDir += "MSBuild\\Current\\Bin\\";
        }

        return vsInstallDir;
#else
        return "c:\\work\\msbuild\\artifacts\\bin\\bootstrap\\net472\\MSBuild\\Current\\Bin\\";
#endif
    }
}