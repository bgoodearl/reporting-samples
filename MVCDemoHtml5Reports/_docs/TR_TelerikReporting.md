# Telerik Reporting with .NET 10

[Telerik Reporting - Release History](https://www.telerik.com/support/whats-new/reporting/release-history)

## Report Designer

[Standalone Report Designer Overview](https://docs.telerik.com/reporting/designing-reports/report-designer-tools/desktop-designers/standalone-report-designer/overview)

[Extending Report Designer to Recognize Custom Assemblies](https://docs.telerik.com/reporting/designing-reports/report-designer-tools/desktop-designers/standalone-report-designer/configuration/extending-report-designer)

[Standalone Report Designer Configuration File](https://docs.telerik.com/reporting/designing-reports/report-designer-tools/desktop-designers/standalone-report-designer/configuration/overview)

[Troubleshooting Standalone Report Designer](https://docs.telerik.com/reporting/designing-reports/report-designer-tools/desktop-designers/standalone-report-designer/standalone-report-designer-problems)

### .NET 10 Report Designer

Per Telerik Support - needed to add assemblies to the Report Designer executable folder and to the .config file.
Also, needed to add appsettings.json file with connection string for Northwind.Infrastructure

### Set Up Report Designer

After building the demo code in `...\reporting-samples\MVCDemoHtml5Reports`
and setting up the database `Northwind-Full`...

1) Find folder where Report Designer was installed `...\Progress\Telerik Reporting 2026 Q2\Report Designer` and make a copy of the `.NET` folder to `.NET_demo`.

2) Copy the files from `...\reporting-samples\MVCDemoHtml5Reports\NorthwindConsole\bin\Debug\net10.0` to `.NET_demo` except:
```txt
Do not copy NorthwindConsole.*
Copy \Debug\net10.0\runtimes\win\lib\net9.0\Microsoft.Data.SqlClient.dll to .NET_demo
    (replacing the smaller file copied from \Debug\net10.0)
```
3) Create the folder `config` in `.NET_demo`

4) Copy `...\reporting-samples\MVCDemoHtml5Reports\_ConfigSource\.NET_demo\config\appsettings.json` to `.NET_demo\config` and edit connection string as necessary.

## EF Core in Telerik Reporting

[Using EFCore in Telerik Reporting](https://docs.telerik.com/reporting/knowledge-base/use-reporting-in-dotnetcore-with-entity-framework-core)

## ReportsController

[Inject custom dependency in the ReportsController of a .NET Core application](https://docs.telerik.com/reporting/knowledge-base/how-to-inject-custom-dependency-in-reports-controller-of-dot-net-core-application)
