# Northwind Migration Notes - .NET 8


## Testing Package Manager Console

Package Manager Console - get info about commands:
```powershell
get-help about_EntityFrameworkCore
```
Package Manger Console - check migrations and database connection string
```powershell
Get-Migration  -Project Northwind.Infrastructure -StartupProject Northwind.EFDataApp -Context NorthwindContext
```
Note: run with ` -verbose` added at the end to get additional information, including SQL instance and database name.<br/>

To remove the most recent migration:
```powershell
Remove-Migration  -Project Northwind.Infrastructure -StartupProject Northwind.EFDataApp -Context NorthwindContext
```

### First Migration - NWSchema1aa_ExistingSchema

```powershell
# NWSchema1aa_ExistingSchema

Add-Migration -Project Northwind.Infrastructure -StartupProject Northwind.EFDataApp NWSchema1aa_ExistingSchema
Script-Migration -Project Northwind.Infrastructure -StartupProject Northwind.EFDataApp -From 0 -To NWSchema1aa_ExistingSchema -output .\SqlScripts\_Schema\NWSchema1aa_ExistingSchema_idempotent.sql -Idempotent
Script-Migration -Project Northwind.Infrastructure -StartupProject Northwind.EFDataApp -From 0 -To NWSchema1aa_ExistingSchema -output .\SqlScripts\_Schema\NWSchema1aa_ExistingSchema.sql
```
