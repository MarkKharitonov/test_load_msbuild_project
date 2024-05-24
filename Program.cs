using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

internal class Program
{
    private static int Main(string[] args)
    {
        var msbuildDir = GetMSBuildDir();

        if (string.IsNullOrEmpty(msbuildDir))
        {
            Console.WriteLine("msbuildDir\t\t= null");
            MSBuildLocator.RegisterDefaults();
        }
        else
        {
            Console.WriteLine($"msbuildDir\t\t= \"{msbuildDir}\"");
            MSBuildLocator.RegisterMSBuildPath(msbuildDir);
        }

        Run(args.Length == 0 ? "sample_net472_legacy.proj" : args[0]);
        return 0;
    }

    private static void Run(string csprojFileName)
    {
        Console.WriteLine($"InformationalVersion\t= {typeof(Project).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}");
        Console.WriteLine($"csprojFileName\t\t= \"{csprojFileName}\"");
        Debug.Assert(File.Exists(csprojFileName));

        var project = new Project(csprojFileName);
        Console.WriteLine($"MSBuildExtensionsPath\t= {project.GetPropertyValue("MSBuildExtensionsPath")}");
        Console.WriteLine($"MSBuildToolsVersion\t= {project.GetPropertyValue("MSBuildToolsVersion")}");
        Console.WriteLine($"MSBuildBinPath\t\t= {project.GetPropertyValue("MSBuildBinPath")}");
        Console.WriteLine($"VSToolsPath\t\t= {project.GetPropertyValue("VSToolsPath")}");
        Console.WriteLine($"TargetPath\t\t= {project.GetPropertyValue("TargetPath")}");
    }

    private static string GetMSBuildDir()
    {
#if false
        var vsInstallDir = Environment.GetEnvironmentVariable("VSINSTALLDIR");
        if (vsInstallDir == null)
        {
            vsInstallDir = Environment.GetEnvironmentVariable("VSAPPIDDIR");
            if (!string.IsNullOrEmpty(vsInstallDir))
            {
                vsInstallDir = Path.GetFullPath(vsInstallDir + @"\..\..\");
            }
        }
        if (!string.IsNullOrEmpty(vsInstallDir))
        {
            vsInstallDir += @"MSBuild\Current\Bin\";
        }

        return vsInstallDir;
#else
        return @"c:\work\msbuild\artifacts\bin\bootstrap\net472\MSBuild\Current\Bin\";
#endif
    }
}