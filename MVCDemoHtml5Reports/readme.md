# ASP.NET MVC web app w/HTML5 Report Viewer

Demo app with Telerik Reports and ASP.NET 10 MVC

Updated for Telerik Reporting 2026 Q2 (20.1.26.707)

From Telerik Report Samples: `...\reporting-samples\MVCDemoHtml5Reports`

2 reports - one uses SQL query, the other uses Entity Framework Core

Rebuild of Telerik Reports project created in 2021 - updated to .NET 10 in 2026

Uses Node 24.18.0, npm 11.16.0 via nvm (1.2.2)<br/>
[nvm-windows](https://github.com/coreybutler/nvm-windows)<br/>

Uses Gulp...

## Telerik License

Copy your telerik-license.txt to `...\MVCDemo`

## When First Setting Up to build

(This section is not necessary if files already exist in `...\MVCDemo\wwwroot\css`, css2, js and js2.)

run `npm install` in the root of MVCDemo and again in the ClientApp folder, then close and re-open the solution.

Then run the tasks `copy3rdPartyMinCss` and `copy3rdPartyMinJs` in Task Runner Explorer

### appsettings

Copy `appsettings.json` from `...\_ConfigSource\MVCDemo` to	`...\MVCDemo`

Copy `appsettings.migrations.json` from `...\_ConfigSource\Northwind.EFDataApp` to `...\Northwind.EFDataApp`

Copy `appsettings.LocalTesting.json` from `...\_ConfigSource\tests\NorthwindDataTests` to `...\tests\NorthwindDataTests`

Update connection strings as needed.

### Northwind Database from Microsoft

This demo app uses the Northwind database.

[Northwind on GitHub](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs)
(c. Nov 2018)

Create the database `Northwind-Full` and add content using the script above from GitHub.

If you want to look at how the EF Core migrations were created, create the database `Northwind_dn10dev` and run the SQL script from `...\MVCDemoHtml5Reports\SqlScripts\_Schema\NWSchema1aa_ExistingSchema_idempotent.sql`.

And look at the file `...\MVCDemoHtml5Reports\Northwind.Infrastructure\NorthwindMigrationNotes.md`.

## Report Designer

See [_docs - TR_TelerikReporting.md](./_docs/TR_TelerikReporting.md)

