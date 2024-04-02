# Introduction

This README shows the result of running the tool in 3 different environments x 2 different target frameworks x 3 kinds of projects to be parsed:

**3 different run environments**:
1. From within VS IDE
2. On a shell with VS Dev environment loaded
3. On a bare shell without any VS Dev environment

**2 different target frameworks** (for which the tool is compiled):
1. .NET 8
2. .NET Framework 4.7.2

**3 kinds of projects to be parsed**:
1. Legacy style project targeting .NET Framework 4.7.2 - **sample_net472_legacy.proj**
2. SDK style project targeting .NET Framework 4.7.2 - **sample_net472_sdk.proj**
3. A project targeting .NET 8 (SDK style, of course) - **sample_net8.proj**

By default **sample_net472_legacy.proj** is parsed. To parse another project pass its path on the command line.

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

# Runs
## Visual Studio 2022 IDE
### .NET 8
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
### .NET Framework 4.7.2
**sample_net472_legacy.proj**
```
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = "sample_net472_legacy.proj"
MSBuildExtensionsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\amd64
VSToolsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Microsoft\VisualStudio\v17.0
TargetPath = C:\work\test_load_msbuild_project\bin\Debug\net472\Bin\xyz.dll
```
**sample_net472_sdk.proj**
```
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = "sample_net472_sdk.proj"

Unhandled Exception: Microsoft.Build.Exceptions.InvalidProjectFileException: SDK Resolver Failure: "The SDK resolver "Microsoft.DotNet.MSBuildSdkResolver" failed while attempting to resolve the SDK "Microsoft.NET.Sdk". Exception: "System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
File name: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   at Microsoft.NET.Sdk.WorkloadMSBuildSdkResolver.CachingWorkloadResolver.Resolve(String sdkReferenceName, String dotnetRootPath, String sdkVersion, String userProfileDir, String globalJsonPath)
   at Microsoft.DotNet.MSBuildSdkResolver.DotNetMSBuildSdkResolver.Resolve(SdkReference sdkReference, SdkResolverContext context, SdkResultFactory factory)
   at Microsoft.Build.BackEnd.SdkResolution.SdkResolverService.TryResolveSdkUsingSpecifiedResolvers(IReadOnlyList`1 resolvers, Int32 submissionId, SdkReference sdk, LoggingContext loggingContext, ElementLocation sdkReferenceLocation, String solutionPath, String projectPath, Boolean interactive, Boolean isRunningInVisualStudio, SdkResult& sdkResult, IEnumerable`1& errors, IEnumerable`1& warnings)

=== Pre-bind state information ===
LOG: DisplayName = System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
 (Fully-specified)
LOG: Appbase = file:///C:/work/test_load_msbuild_project/bin/Debug/net472/
LOG: Initial PrivatePath = NULL
Calling assembly : System.Collections.Immutable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a.
===
LOG: This bind starts in LoadFrom load context.
WRN: Native image will not be probed in LoadFrom context. Native image will only be probed in default load context, like with Assembly.Load().
LOG: Using application configuration file: C:\work\test_load_msbuild_project\bin\Debug\net472\test_load_msbuild_project.exe.Config
LOG: Using host configuration file:
LOG: Using machine configuration file from C:\Windows\Microsoft.NET\Framework64\v4.0.30319\config\machine.config.
LOG: Post-policy reference: System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.EXE.
""  C:\work\test_load_msbuild_project\bin\Debug\net472\sample_net472_sdk.proj
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpressionConditioned(String directoryOfImportingFile, ProjectImportElement importElement, List`1& projects, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImports(String directoryOfImportingFile, ProjectImportElement importElement, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, Project project, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, IDirectoryCacheFactory directoryCacheFactory, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Reevaluate(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Initialize(IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, IDirectoryCacheFactory directoryCacheFactory, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile)
   at Program.Run(String csprojFileName) in C:\work\test_load_msbuild_project\Program.cs:line 33
   at Program.Main(String[] args) in C:\work\test_load_msbuild_project\Program.cs:line 24
```
**sample_net8.proj**
```
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = "sample_net8.proj"

Unhandled Exception: Microsoft.Build.Exceptions.InvalidProjectFileException: SDK Resolver Failure: "The SDK resolver "Microsoft.DotNet.MSBuildSdkResolver" failed while attempting to resolve the SDK "Microsoft.NET.Sdk". Exception: "System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
File name: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   at Microsoft.NET.Sdk.WorkloadMSBuildSdkResolver.CachingWorkloadResolver.Resolve(String sdkReferenceName, String dotnetRootPath, String sdkVersion, String userProfileDir, String globalJsonPath)
   at Microsoft.DotNet.MSBuildSdkResolver.DotNetMSBuildSdkResolver.Resolve(SdkReference sdkReference, SdkResolverContext context, SdkResultFactory factory)
   at Microsoft.Build.BackEnd.SdkResolution.SdkResolverService.TryResolveSdkUsingSpecifiedResolvers(IReadOnlyList`1 resolvers, Int32 submissionId, SdkReference sdk, LoggingContext loggingContext, ElementLocation sdkReferenceLocation, String solutionPath, String projectPath, Boolean interactive, Boolean isRunningInVisualStudio, SdkResult& sdkResult, IEnumerable`1& errors, IEnumerable`1& warnings)

=== Pre-bind state information ===
LOG: DisplayName = System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
 (Fully-specified)
LOG: Appbase = file:///C:/work/test_load_msbuild_project/bin/Debug/net472/
LOG: Initial PrivatePath = NULL
Calling assembly : System.Collections.Immutable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a.
===
LOG: This bind starts in LoadFrom load context.
WRN: Native image will not be probed in LoadFrom context. Native image will only be probed in default load context, like with Assembly.Load().
LOG: Using application configuration file: C:\work\test_load_msbuild_project\bin\Debug\net472\test_load_msbuild_project.exe.Config
LOG: Using host configuration file:
LOG: Using machine configuration file from C:\Windows\Microsoft.NET\Framework64\v4.0.30319\config\machine.config.
LOG: Post-policy reference: System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.EXE.
""  C:\work\test_load_msbuild_project\bin\Debug\net472\sample_net8.proj
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpressionConditioned(String directoryOfImportingFile, ProjectImportElement importElement, List`1& projects, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImports(String directoryOfImportingFile, ProjectImportElement importElement, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, Project project, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, IDirectoryCacheFactory directoryCacheFactory, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Reevaluate(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Initialize(IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, IDirectoryCacheFactory directoryCacheFactory, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile)
   at Program.Run(String csprojFileName) in C:\work\test_load_msbuild_project\Program.cs:line 33
   at Program.Main(String[] args) in C:\work\test_load_msbuild_project\Program.cs:line 24
```
### Summary
| Target Framework | Project | Environment | Result |
| --- | --- | --- | --- |
| .NET 8 | sample_net472_legacy.proj | Visual Studio 2022 IDE | OK |
| .NET 8 | sample_net472_sdk.proj | Visual Studio 2022 IDE | OK |
| .NET 8 | sample_net8.proj | Visual Studio 2022 IDE | OK |
| .NET Framework 4.7.2 | sample_net472_legacy.proj | Visual Studio 2022 IDE | OK |
| .NET Framework 4.7.2 | sample_net472_sdk.proj | Visual Studio 2022 IDE | Error |
| .NET Framework 4.7.2 | sample_net8.proj | Visual Studio 2022 IDE | Error |

## Visual Studio 2022 Dev Shell
### .NET 8
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
### .NET Framework 4.7.2
**sample_net472_legacy.proj**
```
C:\work\test_load_msbuild_project> .\bin\Debug\net472\test_load_msbuild_project.exe
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
C:\work\test_load_msbuild_project> .\bin\Debug\net472\test_load_msbuild_project.exe .\sample_net472_sdk.proj
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = ".\sample_net472_sdk.proj"

Unhandled Exception: Microsoft.Build.Exceptions.InvalidProjectFileException: SDK Resolver Failure: "The SDK resolver "Microsoft.DotNet.MSBuildSdkResolver" failed while attempting to resolve the SDK "Microsoft.NET.Sdk". Exception: "System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
File name: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   at Microsoft.NET.Sdk.WorkloadMSBuildSdkResolver.CachingWorkloadResolver.Resolve(String sdkReferenceName, String dotnetRootPath, String sdkVersion, String userProfileDir, String globalJsonPath)
   at Microsoft.DotNet.MSBuildSdkResolver.DotNetMSBuildSdkResolver.Resolve(SdkReference sdkReference, SdkResolverContext context, SdkResultFactory factory)
   at Microsoft.Build.BackEnd.SdkResolution.SdkResolverService.TryResolveSdkUsingSpecifiedResolvers(IReadOnlyList`1 resolvers, Int32 submissionId, SdkReference sdk, LoggingContext loggingContext, ElementLocation sdkReferenceLocation, String solutionPath, String projectPath, Boolean interactive, Boolean isRunningInVisualStudio, SdkResult& sdkResult, IEnumerable`1& errors, IEnumerable`1& warnings)

=== Pre-bind state information ===
LOG: DisplayName = System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
 (Fully-specified)
LOG: Appbase = file:///C:/work/test_load_msbuild_project/bin/Debug/net472/
LOG: Initial PrivatePath = NULL
Calling assembly : System.Collections.Immutable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a.
===
LOG: This bind starts in LoadFrom load context.
WRN: Native image will not be probed in LoadFrom context. Native image will only be probed in default load context, like with Assembly.Load().
LOG: Using application configuration file: C:\work\test_load_msbuild_project\bin\Debug\net472\test_load_msbuild_project.exe.Config
LOG: Using host configuration file:
LOG: Using machine configuration file from C:\Windows\Microsoft.NET\Framework64\v4.0.30319\config\machine.config.
LOG: Post-policy reference: System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.EXE.
""  C:\work\test_load_msbuild_project\sample_net472_sdk.proj
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpressionConditioned(String directoryOfImportingFile, ProjectImportElement importElement, List`1& projects, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImports(String directoryOfImportingFile, ProjectImportElement importElement, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, Project project, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, IDirectoryCacheFactory directoryCacheFactory, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Reevaluate(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Initialize(IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, IDirectoryCacheFactory directoryCacheFactory, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile)
   at Program.Run(String csprojFileName) in C:\work\test_load_msbuild_project\Program.cs:line 33
   at Program.Main(String[] args) in C:\work\test_load_msbuild_project\Program.cs:line 24
C:\work\test_load_msbuild_project>
```
**sample_net8.proj**
```
C:\work\test_load_msbuild_project> .\bin\Debug\net472\test_load_msbuild_project.exe .\sample_net8.proj
msbuildDir == "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\"
csprojFileName = ".\sample_net8.proj"

Unhandled Exception: Microsoft.Build.Exceptions.InvalidProjectFileException: SDK Resolver Failure: "The SDK resolver "Microsoft.DotNet.MSBuildSdkResolver" failed while attempting to resolve the SDK "Microsoft.NET.Sdk". Exception: "System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
File name: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   at Microsoft.NET.Sdk.WorkloadMSBuildSdkResolver.CachingWorkloadResolver.Resolve(String sdkReferenceName, String dotnetRootPath, String sdkVersion, String userProfileDir, String globalJsonPath)
   at Microsoft.DotNet.MSBuildSdkResolver.DotNetMSBuildSdkResolver.Resolve(SdkReference sdkReference, SdkResolverContext context, SdkResultFactory factory)
   at Microsoft.Build.BackEnd.SdkResolution.SdkResolverService.TryResolveSdkUsingSpecifiedResolvers(IReadOnlyList`1 resolvers, Int32 submissionId, SdkReference sdk, LoggingContext loggingContext, ElementLocation sdkReferenceLocation, String solutionPath, String projectPath, Boolean interactive, Boolean isRunningInVisualStudio, SdkResult& sdkResult, IEnumerable`1& errors, IEnumerable`1& warnings)

=== Pre-bind state information ===
LOG: DisplayName = System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
 (Fully-specified)
LOG: Appbase = file:///C:/work/test_load_msbuild_project/bin/Debug/net472/
LOG: Initial PrivatePath = NULL
Calling assembly : System.Collections.Immutable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a.
===
LOG: This bind starts in LoadFrom load context.
WRN: Native image will not be probed in LoadFrom context. Native image will only be probed in default load context, like with Assembly.Load().
LOG: Using application configuration file: C:\work\test_load_msbuild_project\bin\Debug\net472\test_load_msbuild_project.exe.Config
LOG: Using host configuration file:
LOG: Using machine configuration file from C:\Windows\Microsoft.NET\Framework64\v4.0.30319\config\machine.config.
LOG: Post-policy reference: System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.EXE.
""  C:\work\test_load_msbuild_project\sample_net8.proj
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpressionConditioned(String directoryOfImportingFile, ProjectImportElement importElement, List`1& projects, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImports(String directoryOfImportingFile, ProjectImportElement importElement, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, Project project, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, IDirectoryCacheFactory directoryCacheFactory, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Reevaluate(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Initialize(IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, IDirectoryCacheFactory directoryCacheFactory, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile)
   at Program.Run(String csprojFileName) in C:\work\test_load_msbuild_project\Program.cs:line 33
   at Program.Main(String[] args) in C:\work\test_load_msbuild_project\Program.cs:line 24
C:\work\test_load_msbuild_project>
```
### Summary
| Target Framework | Project | Environment | Result |
| --- | --- | --- | --- |
| .NET 8 | sample_net472_legacy.proj | Visual Studio 2022 Dev Shell | OK |
| .NET 8 | sample_net472_sdk.proj | Visual Studio 2022 Dev Shell | OK |
| .NET 8 | sample_net8.proj | Visual Studio 2022 Dev Shell | OK |
| .NET Framework 4.7.2 | sample_net472_legacy.proj | Visual Studio 2022 Dev Shell | OK |
| .NET Framework 4.7.2 | sample_net472_sdk.proj | Visual Studio 2022 Dev Shell | Error |
| .NET Framework 4.7.2 | sample_net8.proj | Visual Studio 2022 Dev Shell | Error |

## Bare shell (no VS dev environment)
### .NET 8
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
### .NET Framework 4.7.2
**sample_net472_legacy.proj**
```
PS C:\work\test_load_msbuild_project> .\bin\Debug\net472\test_load_msbuild_project.exe
msbuildDir == null
csprojFileName = "sample_net472_legacy.proj"
MSBuildExtensionsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild
MSBuildToolsVersion = Current
MSBuildBinPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\amd64
VSToolsPath = C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Microsoft\VisualStudio\v17.0
TargetPath = C:\work\test_load_msbuild_project\Bin\xyz.dll
PS C:\work\test_load_msbuild_project>
```
**sample_net472_sdk.proj**
```
PS C:\work\test_load_msbuild_project> .\bin\Debug\net472\test_load_msbuild_project.exe .\sample_net472_sdk.proj
msbuildDir == null
csprojFileName = ".\sample_net472_sdk.proj"

Unhandled Exception: Microsoft.Build.Exceptions.InvalidProjectFileException: SDK Resolver Failure: "The SDK resolver "Microsoft.DotNet.MSBuildSdkResolver" failed while attempting to resolve the SDK "Microsoft.NET.Sdk". Exception: "System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
File name: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   at Microsoft.NET.Sdk.WorkloadMSBuildSdkResolver.CachingWorkloadResolver.Resolve(String sdkReferenceName, String dotnetRootPath, String sdkVersion, String userProfileDir, String globalJsonPath)
   at Microsoft.DotNet.MSBuildSdkResolver.DotNetMSBuildSdkResolver.Resolve(SdkReference sdkReference, SdkResolverContext context, SdkResultFactory factory)
   at Microsoft.Build.BackEnd.SdkResolution.SdkResolverService.TryResolveSdkUsingSpecifiedResolvers(IReadOnlyList`1 resolvers, Int32 submissionId, SdkReference sdk, LoggingContext loggingContext, ElementLocation sdkReferenceLocation, String solutionPath, String projectPath, Boolean interactive, Boolean isRunningInVisualStudio, SdkResult& sdkResult, IEnumerable`1& errors, IEnumerable`1& warnings)

=== Pre-bind state information ===
LOG: DisplayName = System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
 (Fully-specified)
LOG: Appbase = file:///C:/work/test_load_msbuild_project/bin/Debug/net472/
LOG: Initial PrivatePath = NULL
Calling assembly : System.Collections.Immutable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a.
===
LOG: This bind starts in LoadFrom load context.
WRN: Native image will not be probed in LoadFrom context. Native image will only be probed in default load context, like with Assembly.Load().
LOG: Using application configuration file: C:\work\test_load_msbuild_project\bin\Debug\net472\test_load_msbuild_project.exe.Config
LOG: Using host configuration file:
LOG: Using machine configuration file from C:\Windows\Microsoft.NET\Framework64\v4.0.30319\config\machine.config.
LOG: Post-policy reference: System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.EXE.
""  C:\work\test_load_msbuild_project\sample_net472_sdk.proj
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpressionConditioned(String directoryOfImportingFile, ProjectImportElement importElement, List`1& projects, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImports(String directoryOfImportingFile, ProjectImportElement importElement, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, Project project, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, IDirectoryCacheFactory directoryCacheFactory, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Reevaluate(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Initialize(IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, IDirectoryCacheFactory directoryCacheFactory, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile)
   at Program.Run(String csprojFileName) in C:\work\test_load_msbuild_project\Program.cs:line 33
   at Program.Main(String[] args) in C:\work\test_load_msbuild_project\Program.cs:line 24
PS C:\work\test_load_msbuild_project>
```
**sample_net8.proj**
```
PS C:\work\test_load_msbuild_project> .\bin\Debug\net472\test_load_msbuild_project.exe .\sample_net8.proj
msbuildDir == null
csprojFileName = ".\sample_net8.proj"

Unhandled Exception: Microsoft.Build.Exceptions.InvalidProjectFileException: SDK Resolver Failure: "The SDK resolver "Microsoft.DotNet.MSBuildSdkResolver" failed while attempting to resolve the SDK "Microsoft.NET.Sdk". Exception: "System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
File name: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   at Microsoft.NET.Sdk.WorkloadMSBuildSdkResolver.CachingWorkloadResolver.Resolve(String sdkReferenceName, String dotnetRootPath, String sdkVersion, String userProfileDir, String globalJsonPath)
   at Microsoft.DotNet.MSBuildSdkResolver.DotNetMSBuildSdkResolver.Resolve(SdkReference sdkReference, SdkResolverContext context, SdkResultFactory factory)
   at Microsoft.Build.BackEnd.SdkResolution.SdkResolverService.TryResolveSdkUsingSpecifiedResolvers(IReadOnlyList`1 resolvers, Int32 submissionId, SdkReference sdk, LoggingContext loggingContext, ElementLocation sdkReferenceLocation, String solutionPath, String projectPath, Boolean interactive, Boolean isRunningInVisualStudio, SdkResult& sdkResult, IEnumerable`1& errors, IEnumerable`1& warnings)

=== Pre-bind state information ===
LOG: DisplayName = System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
 (Fully-specified)
LOG: Appbase = file:///C:/work/test_load_msbuild_project/bin/Debug/net472/
LOG: Initial PrivatePath = NULL
Calling assembly : System.Collections.Immutable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a.
===
LOG: This bind starts in LoadFrom load context.
WRN: Native image will not be probed in LoadFrom context. Native image will only be probed in default load context, like with Assembly.Load().
LOG: Using application configuration file: C:\work\test_load_msbuild_project\bin\Debug\net472\test_load_msbuild_project.exe.Config
LOG: Using host configuration file:
LOG: Using machine configuration file from C:\Windows\Microsoft.NET\Framework64\v4.0.30319\config\machine.config.
LOG: Post-policy reference: System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.EXE.
""  C:\work\test_load_msbuild_project\sample_net8.proj
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpressionConditioned(String directoryOfImportingFile, ProjectImportElement importElement, List`1& projects, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImports(String directoryOfImportingFile, ProjectImportElement importElement, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, Project project, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, IDirectoryCacheFactory directoryCacheFactory, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Reevaluate(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Initialize(IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, IDirectoryCacheFactory directoryCacheFactory, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile)
   at Program.Run(String csprojFileName) in C:\work\test_load_msbuild_project\Program.cs:line 33
   at Program.Main(String[] args) in C:\work\test_load_msbuild_project\Program.cs:line 24
PS C:\work\test_load_msbuild_project>
```
### Summary
| Target Framework | Project | Environment | Result |
| --- | --- | --- | --- |
| .NET 8 | sample_net472_legacy.proj | Bare shell | OK |
| .NET 8 | sample_net472_sdk.proj | Bare shell | OK |
| .NET 8 | sample_net8.proj | Bare shell | OK |
| .NET Framework 4.7.2 | sample_net472_legacy.proj | Bare shell | OK |
| .NET Framework 4.7.2 | sample_net472_sdk.proj | Bare shell | Error |
| .NET Framework 4.7.2 | sample_net8.proj | Bare shell | Error |

# Summary
The code must target .NET 8 in order to be able to parse both SDK and non SDK style projects targeting .NET or .NET Framework.
When targeting .NET Framework 4.7.2 only legacy style projects can be parsed.

| Target Framework | Project | Environment | Result |
| --- | --- | --- | --- |
| .NET 8 | All | All | OK |
| .NET Framework 4.7.2 | legacy | All | OK |
| .NET Framework 4.7.2 | SDK style | All | Error |

All the errors are the same one:
```
Unhandled Exception: Microsoft.Build.Exceptions.InvalidProjectFileException: SDK Resolver Failure: "The SDK resolver "Microsoft.DotNet.MSBuildSdkResolver" failed while attempting to resolve the SDK "Microsoft.NET.Sdk". Exception: "System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
File name: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   at Microsoft.NET.Sdk.WorkloadMSBuildSdkResolver.CachingWorkloadResolver.Resolve(String sdkReferenceName, String dotnetRootPath, String sdkVersion, String userProfileDir, String globalJsonPath)
   at Microsoft.DotNet.MSBuildSdkResolver.DotNetMSBuildSdkResolver.Resolve(SdkReference sdkReference, SdkResolverContext context, SdkResultFactory factory)
   at Microsoft.Build.BackEnd.SdkResolution.SdkResolverService.TryResolveSdkUsingSpecifiedResolvers(IReadOnlyList`1 resolvers, Int32 submissionId, SdkReference sdk, LoggingContext loggingContext, ElementLocation sdkReferenceLocation, String solutionPath, String projectPath, Boolean interactive, Boolean isRunningInVisualStudio, SdkResult& sdkResult, IEnumerable`1& errors, IEnumerable`1& warnings)

=== Pre-bind state information ===
LOG: DisplayName = System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
 (Fully-specified)
LOG: Appbase = file:///C:/work/test_load_msbuild_project/bin/Debug/net472/
LOG: Initial PrivatePath = NULL
Calling assembly : System.Collections.Immutable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a.
===
LOG: This bind starts in LoadFrom load context.
WRN: Native image will not be probed in LoadFrom context. Native image will only be probed in default load context, like with Assembly.Load().
LOG: Using application configuration file: C:\work\test_load_msbuild_project\bin\Debug\net472\test_load_msbuild_project.exe.Config
LOG: Using host configuration file:
LOG: Using machine configuration file from C:\Windows\Microsoft.NET\Framework64\v4.0.30319\config\machine.config.
LOG: Post-policy reference: System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/work/test_load_msbuild_project/bin/Debug/net472/System.Runtime/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.DLL.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime.EXE.
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/SdkResolvers/Microsoft.DotNet.MSBuildSdkResolver/System.Runtime/System.Runtime.EXE.
""  C:\work\test_load_msbuild_project\sample_net8.proj
   at Microsoft.Build.Shared.ProjectErrorUtilities.ThrowInvalidProject(String errorSubCategoryResourceName, IElementLocation elementLocation, String resourceName, Object[] args)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImportsFromUnescapedImportExpressionConditioned(String directoryOfImportingFile, ProjectImportElement importElement, List`1& projects, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.ExpandAndLoadImports(String directoryOfImportingFile, ProjectImportElement importElement, SdkResult& sdkResult)
   at Microsoft.Build.Evaluation.Evaluator`4.EvaluateImportElement(String directoryOfImportingFile, ProjectImportElement importElement)
   at Microsoft.Build.Evaluation.Evaluator`4.PerformDepthFirstPass(ProjectRootElement currentProjectOrImport)
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate()
   at Microsoft.Build.Evaluation.Evaluator`4.Evaluate(IEvaluatorData`4 data, Project project, ProjectRootElement root, ProjectLoadSettings loadSettings, Int32 maxNodeCount, PropertyDictionary`1 environmentProperties, ILoggingService loggingService, IItemFactory`2 itemFactory, IToolsetProvider toolsetProvider, IDirectoryCacheFactory directoryCacheFactory, ProjectRootElementCacheBase projectRootElementCache, BuildEventContext buildEventContext, ISdkResolverService sdkResolverService, Int32 submissionId, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Reevaluate(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(ILoggingService loggingServiceForEvaluation, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.ReevaluateIfNecessary(EvaluationContext evaluationContext)
   at Microsoft.Build.Evaluation.Project.ProjectImpl.Initialize(IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile, IDictionary`2 globalProperties, String toolsVersion, String subToolsetVersion, ProjectCollection projectCollection, ProjectLoadSettings loadSettings, EvaluationContext evaluationContext, IDirectoryCacheFactory directoryCacheFactory, Boolean interactive)
   at Microsoft.Build.Evaluation.Project..ctor(String projectFile)
   at Program.Run(String csprojFileName) in C:\work\test_load_msbuild_project\Program.cs:line 33
   at Program.Main(String[] args) in C:\work\test_load_msbuild_project\Program.cs:line 24
```

# Root cause
The folder **C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\SdkResolvers\Microsoft.DotNet.MSBuildSdkResolver** on my machine had a file which did not belong there - System.Collections.Immutable.dll. I must have copied it to workaround an issue and never removed it.
