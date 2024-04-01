# Introduction

The code comes with a few sample project files:
1. **sample_net8.proj** - targets .NET 8
1. **sample_net472_sdk.proj** - an SDK style project targeting the .NET Framework version 4.7.2
1. **sample_net472_legacy.proj** - a legacy style project (non SDK) targeting the .NET Framework version 4.7.2

By default sample_net472_legacy.proj is parsed. To parse another project pass its path on the command line.

The runs where done with Visual Studio 2022 version 17.9.5 and .NET 8 CLI:
```
Microsoft Visual Studio Professional 2022
Version 17.9.5
VisualStudio.17.Release/17.9.5+34723.18
Microsoft .NET Framework
Version 4.8.04161
```
```
C:\work\test_load_msbuild_project> dotnet --version
8.0.202
C:\work\test_load_msbuild_project> msbuild --version
MSBuild version 17.9.8+b34f75857 for .NET Framework
17.9.8.16306
C:\work\test_load_msbuild_project [master +10 ~0 -0 ~]>
```

# Run environments
## From within Visual Studio 2022
**sample_net472_legacy.proj**
```
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = "sample_net472_legacy.proj"
MSBuildExtensionsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\amd64
VSToolsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Microsoft\VisualStudio\v17.0
TargetPath = C:\work\test_load_msbuild_project\bin\Debug\net8\Bin\xyz.dll
```
**sample_net472_sdk.proj**
```
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = "sample_net472_sdk.proj"
MSBuildExtensionsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\amd64
VSToolsPath =
TargetPath = C:\work\test_load_msbuild_project\bin\Debug\net8\bin\Debug\net472\sample_net472_sdk.dll
```
**sample_net8.proj**
```
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = "sample_net8.proj"
MSBuildExtensionsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\amd64
VSToolsPath =
TargetPath = C:\work\test_load_msbuild_project\bin\Debug\net8\bin\Debug\net8\sample_net8.dll
```
## From a shell with Visual Studio Development environment
**sample_net472_legacy.proj**
```
C:\work\test_load_msbuild_project> .\bin\Debug\net8\test_load_msbuild_project.exe
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = "sample_net472_legacy.proj"
MSBuildExtensionsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\amd64
VSToolsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Microsoft\VisualStudio\v17.0
TargetPath = C:\work\test_load_msbuild_project\Bin\xyz.dll
C:\work\test_load_msbuild_project>
```
**sample_net472_sdk.proj**
```
C:\work\test_load_msbuild_project> .\bin\Debug\net8\test_load_msbuild_project.exe .\sample_net472_sdk.proj
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = ".\sample_net472_sdk.proj"
MSBuildExtensionsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\amd64
VSToolsPath =
TargetPath = C:\work\test_load_msbuild_project\bin\Debug\net472\sample_net472_sdk.dll
C:\work\test_load_msbuild_project>
```
**sample_net8.proj**
```
C:\work\test_load_msbuild_project> .\bin\Debug\net8\test_load_msbuild_project.exe .\sample_net8.proj
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = ".\sample_net8.proj"
MSBuildExtensionsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\amd64
VSToolsPath =
TargetPath = C:\work\test_load_msbuild_project\bin\Debug\net8\sample_net8.dll
C:\work\test_load_msbuild_project>
```
## From a bare shell (no VS dev environment)
**sample_net472_legacy.proj**
```
PS C:\work\test_load_msbuild_project> .\bin\Debug\net8\test_load_msbuild_project.exe
msbuildDir == null
csprojFileName = "sample_net472_legacy.proj"
Unhandled exception. Microsoft.Build.Exceptions.InvalidProjectFileException: The imported project "C:\Program Files\dotnet\sdk\8.0.202\Microsoft\VisualStudio\v17.0\WebApplications\Microsoft.WebApplication.targets" was not found. Confirm that the expression in the Import declaration "C:\Program Files\dotnet\sdk\8.0.202\Microsoft\VisualStudio\v17.0\WebApplications\Microsoft.WebApplication.targets" is correct, and that the file exists on disk.  C:\work\test_load_msbuild_project\sample_net472_legacy.proj
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject[T1,T2](IElementLocation elementLocation, String resourceName, T1 arg0, T2 arg1)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpression(String directoryOfImportingFile, ProjectImportElement importElement, String unescapedExpression, Boolean throwOnFileNotExistsError, List`1& imports)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpressionConditioned(String directoryOfImportingFile, ProjectImportElement importElement, List`1& projects, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImports(String directoryOfImportingFile, ProjectImportElement importElement, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, Project project, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, IDirectoryCacheFactory directoryCacheFactory, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Reevaluate(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Initialize(IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, IDirectoryCacheFactory directoryCacheFactory, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile)
   at Program.Run(String csprojFileName) in C:\work\test_load_msbuild_project\Program.cs:line 33
   at Program.Main(String[] args) in C:\work\test_load_msbuild_project\Program.cs:line 24
PS C:\work\test_load_msbuild_project>
```
This is expected, because Microsoft.WebApplication.targets does not exist in .NET 8. If we comment that import, then it would work:
```
PS C:\work\test_load_msbuild_project> .\bin\Debug\net8\test_load_msbuild_project.exe
msbuildDir == null
csprojFileName = "sample_net472_legacy.proj"
MSBuildExtensionsPath = C:\Program Files\dotnet\sdk\8.0.202
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\dotnet\sdk\8.0.202
VSToolsPath = C:\Program Files\dotnet\sdk\8.0.202\Microsoft\VisualStudio\v17.0
TargetPath = C:\work\test_load_msbuild_project\Bin\xyz.dll
PS C:\work\test_load_msbuild_project>
```
**sample_net472_sdk.proj**
```
PS C:\work\test_load_msbuild_project> .\bin\Debug\net8\test_load_msbuild_project.exe .\sample_net472_sdk.proj
msbuildDir == null
csprojFileName = ".\sample_net472_sdk.proj"
MSBuildExtensionsPath = C:\Program Files\dotnet\sdk\8.0.202
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\dotnet\sdk\8.0.202
VSToolsPath =
TargetPath = C:\work\test_load_msbuild_project\bin\Debug\net472\sample_net472_sdk.dll
PS C:\work\test_load_msbuild_project>
```
**sample_net8.proj**
```
PS C:\work\test_load_msbuild_project> .\bin\Debug\net8\test_load_msbuild_project.exe .\sample_net8.proj
msbuildDir == null
csprojFileName = ".\sample_net8.proj"
MSBuildExtensionsPath = C:\Program Files\dotnet\sdk\8.0.202
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\dotnet\sdk\8.0.202
VSToolsPath =
TargetPath = C:\work\test_load_msbuild_project\bin\Debug\net8\sample_net8.dll
PS C:\work\test_load_msbuild_project>
```
