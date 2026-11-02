# ASP.NET MVC 5: .NET Framework 4.8 CI sample

Minimal classic, non-SDK-style web application and MSTest project targeting .NET Framework 4.8. Dependencies use `packages.config`.

## Validation status

**Not compiled or executed.** This sample was prepared on Linux without installing packages or build tools. A Windows GitHub Actions run must establish whether restore, compilation, test discovery and packaging succeed. No passing build is claimed.

## Run in GitHub Actions

Place this directory's contents at the root of a GitHub repository using the `main` branch. The workflow runs on pushes, pull requests or manual dispatch. It selects `windows-2022`, restores the solution with NuGet, builds with Visual Studio MSBuild, runs VSTest and requests a web deployment package using `DeployOnBuild=true` and `DeployTarget=Package`.

The workflow follows the corrected article: `actions/checkout@v7`, `microsoft/setup-msbuild@v3`, `NuGet/setup-nuget@v4` and `actions/upload-artifact@v7`. Action references use major tags; NuGet itself uses `latest`.

Expected artifacts are `legacy-mvc-package` and `legacy-mvc-test-results`. There is no deployment job.

## Application and tests

The default route selects `HomeController.Index`. Its view displays a welcome message. Two controller tests check that the action returns the conventional view and supplies the expected message. They do not render Razor or exercise IIS.

## Package selection

NuGet flat-container indexes and package contents were consulted with curl on November 2, 2026. Selected stable versions:

| Package | Version | Inspected framework assets |
| --- | --- | --- |
| Microsoft.AspNet.Mvc | 5.3.0 | net45 |
| Microsoft.AspNet.Razor | 3.3.0 | net45 |
| Microsoft.AspNet.WebPages | 3.3.0 | net45 |
| Microsoft.Web.Infrastructure | 2.0.1 | net40 |
| MSTest.TestFramework | 4.5.2 | net462 |
| MSTest.TestAdapter | 4.5.2 | net462 build assets |

Package asset inspection supports the selection; it does not establish that this assembled sample builds or runs. Transitive versions are listed explicitly in the test project's `packages.config`.

Official version indexes: [MVC](https://api.nuget.org/v3-flatcontainer/microsoft.aspnet.mvc/index.json), [Razor](https://api.nuget.org/v3-flatcontainer/microsoft.aspnet.razor/index.json), [WebPages](https://api.nuget.org/v3-flatcontainer/microsoft.aspnet.webpages/index.json), [Infrastructure](https://api.nuget.org/v3-flatcontainer/microsoft.web.infrastructure/index.json), [MSTest framework](https://api.nuget.org/v3-flatcontainer/mstest.testframework/index.json), [MSTest adapter](https://api.nuget.org/v3-flatcontainer/mstest.testadapter/index.json).

## Checks still required

- Restore every declared package and confirm dependency compatibility.
- Build both classic projects in Release on `windows-2022`.
- Confirm adapter discovery and exactly two passing tests in the TRX report; the copied workflow only rejects a zero-test result.
- Confirm that `LegacyMvc.zip` and its companion deployment files are generated and uploaded. Inspect their contents.
- Run the application under IIS or IIS Express and verify routing and Razor rendering.

Unit tests alone do not validate hosting, view compilation or deployment.

## References

[Windows runner inventory](https://github.com/actions/runner-images/blob/main/images/windows/Windows2022-Readme.md), [setup-msbuild](https://github.com/microsoft/setup-msbuild), [setup-nuget](https://github.com/NuGet/setup-nuget), [NuGet restore](https://learn.microsoft.com/en-us/nuget/reference/cli-reference/cli-ref-restore), [web application packaging](https://learn.microsoft.com/en-us/aspnet/web-forms/overview/deployment/web-deployment-in-the-enterprise/building-and-packaging-web-application-projects), [VSTest options](https://learn.microsoft.com/en-us/visualstudio/test/vstest-console-options?view=vs-2022).

MIT License. Copyright (c) 2026 Martin Pisacreta. See LICENSE. Third-party packages retain their respective licenses.

https://www.upwork.com/services/product/2117249840584640174
