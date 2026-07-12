USE Northwind_dn8dev;
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Categories] (
        [CategoryID] int NOT NULL IDENTITY,
        [CategoryName] nvarchar(15) NOT NULL,
        [Description] ntext NULL,
        [Picture] image NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [CustomerDemographics] (
        [CustomerTypeID] nchar(10) NOT NULL,
        [CustomerDesc] ntext NULL,
        CONSTRAINT [PK_CustomerDemographics] PRIMARY KEY ([CustomerTypeID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Customers] (
        [CustomerID] nchar(5) NOT NULL,
        [CompanyName] nvarchar(40) NOT NULL,
        [ContactName] nvarchar(30) NULL,
        [ContactTitle] nvarchar(30) NULL,
        [Address] nvarchar(60) NULL,
        [City] nvarchar(15) NULL,
        [Region] nvarchar(15) NULL,
        [PostalCode] nvarchar(10) NULL,
        [Country] nvarchar(15) NULL,
        [Phone] nvarchar(24) NULL,
        [Fax] nvarchar(24) NULL,
        [Total] decimal(6,2) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Employees] (
        [EmployeeID] int NOT NULL IDENTITY,
        [LastName] nvarchar(20) NOT NULL,
        [FirstName] nvarchar(10) NOT NULL,
        [Title] nvarchar(30) NULL,
        [TitleOfCourtesy] nvarchar(25) NULL,
        [BirthDate] datetime NULL,
        [HireDate] datetime NULL,
        [Address] nvarchar(60) NULL,
        [City] nvarchar(15) NULL,
        [Region] nvarchar(15) NULL,
        [PostalCode] nvarchar(10) NULL,
        [Country] nvarchar(15) NULL,
        [HomePhone] nvarchar(24) NULL,
        [Extension] nvarchar(4) NULL,
        [Photo] image NULL,
        [Notes] ntext NULL,
        [ReportsTo] int NULL,
        [PhotoPath] nvarchar(255) NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Region] (
        [RegionID] int NOT NULL,
        [RegionDescription] nchar(50) NOT NULL,
        CONSTRAINT [PK_Region] PRIMARY KEY ([RegionID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Shippers] (
        [ShipperID] int NOT NULL IDENTITY,
        [CompanyName] nvarchar(40) NOT NULL,
        [Phone] nvarchar(24) NULL,
        CONSTRAINT [PK_Shippers] PRIMARY KEY ([ShipperID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Suppliers] (
        [SupplierID] int NOT NULL IDENTITY,
        [CompanyName] nvarchar(40) NOT NULL,
        [ContactName] nvarchar(30) NULL,
        [ContactTitle] nvarchar(30) NULL,
        [Address] nvarchar(60) NULL,
        [City] nvarchar(15) NULL,
        [Region] nvarchar(15) NULL,
        [PostalCode] nvarchar(10) NULL,
        [Country] nvarchar(15) NULL,
        [Phone] nvarchar(24) NULL,
        [Fax] nvarchar(24) NULL,
        [HomePage] ntext NULL,
        CONSTRAINT [PK_Suppliers] PRIMARY KEY ([SupplierID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [CustomerCustomerDemographic] (
        [CustomerDemographicsCustomerTypeID] nchar(10) NOT NULL,
        [CustomersCustomerID] nchar(5) NOT NULL,
        CONSTRAINT [PK_CustomerCustomerDemographic] PRIMARY KEY ([CustomerDemographicsCustomerTypeID], [CustomersCustomerID]),
        CONSTRAINT [FK_CustomerCustomerDemographic_CustomerDemographics_CustomerDemographicsCustomerTypeID] FOREIGN KEY ([CustomerDemographicsCustomerTypeID]) REFERENCES [CustomerDemographics] ([CustomerTypeID]) ON DELETE CASCADE,
        CONSTRAINT [FK_CustomerCustomerDemographic_Customers_CustomersCustomerID] FOREIGN KEY ([CustomersCustomerID]) REFERENCES [Customers] ([CustomerID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Territories] (
        [TerritoryID] nvarchar(20) NOT NULL,
        [TerritoryDescription] nchar(50) NOT NULL,
        [RegionID] int NOT NULL,
        CONSTRAINT [PK_Territories] PRIMARY KEY ([TerritoryID]),
        CONSTRAINT [FK_Territories_Region_RegionID] FOREIGN KEY ([RegionID]) REFERENCES [Region] ([RegionID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Orders] (
        [OrderID] int NOT NULL IDENTITY,
        [CustomerID] nchar(5) NOT NULL,
        [EmployeeID] int NULL,
        [OrderDate] datetime NULL,
        [RequiredDate] datetime NULL,
        [ShippedDate] datetime NULL,
        [ShipVia] int NULL,
        [Freight] money NULL,
        [ShipName] nvarchar(40) NULL,
        [ShipAddress] nvarchar(60) NULL,
        [ShipCity] nvarchar(15) NULL,
        [ShipRegion] nvarchar(15) NULL,
        [ShipPostalCode] nvarchar(10) NULL,
        [ShipCountry] nvarchar(15) NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
        CONSTRAINT [FK_Orders_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([CustomerID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Orders_Employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees] ([EmployeeID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Orders_Shippers_ShipVia] FOREIGN KEY ([ShipVia]) REFERENCES [Shippers] ([ShipperID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Products] (
        [ProductID] int NOT NULL IDENTITY,
        [ProductName] nvarchar(40) NOT NULL,
        [SupplierID] int NULL,
        [CategoryID] int NOT NULL,
        [QuantityPerUnit] nvarchar(20) NULL,
        [UnitPrice] money NULL,
        [UnitsInStock] smallint NULL,
        [UnitsOnOrder] smallint NULL,
        [ReorderLevel] smallint NULL,
        [Discontinued] bit NOT NULL,
        [DiscontinuedDate] date NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),
        CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Products_Suppliers_SupplierID] FOREIGN KEY ([SupplierID]) REFERENCES [Suppliers] ([SupplierID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [EmployeeTerritory] (
        [EmployeesEmployeeID] int NOT NULL,
        [TerritoriesTerritoryID] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_EmployeeTerritory] PRIMARY KEY ([EmployeesEmployeeID], [TerritoriesTerritoryID]),
        CONSTRAINT [FK_EmployeeTerritory_Employees_EmployeesEmployeeID] FOREIGN KEY ([EmployeesEmployeeID]) REFERENCES [Employees] ([EmployeeID]) ON DELETE CASCADE,
        CONSTRAINT [FK_EmployeeTerritory_Territories_TerritoriesTerritoryID] FOREIGN KEY ([TerritoriesTerritoryID]) REFERENCES [Territories] ([TerritoryID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE TABLE [Order Details] (
        [OrderID] int NOT NULL,
        [ProductID] int NOT NULL,
        [UnitPrice] money NOT NULL,
        [Quantity] smallint NOT NULL,
        [Discount] real NOT NULL,
        CONSTRAINT [PK_Order Details] PRIMARY KEY ([OrderID], [ProductID]),
        CONSTRAINT [FK_Order Details_Orders_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [Orders] ([OrderID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Order Details_Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_CustomerCustomerDemographic_CustomersCustomerID] ON [CustomerCustomerDemographic] ([CustomersCustomerID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_EmployeeTerritory_TerritoriesTerritoryID] ON [EmployeeTerritory] ([TerritoriesTerritoryID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_Order Details_ProductID] ON [Order Details] ([ProductID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_Orders_CustomerID] ON [Orders] ([CustomerID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_Orders_EmployeeID] ON [Orders] ([EmployeeID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_Orders_ShipVia] ON [Orders] ([ShipVia]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_Products_CategoryID] ON [Products] ([CategoryID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_Products_SupplierID] ON [Products] ([SupplierID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    CREATE INDEX [IX_Territories_RegionID] ON [Territories] ([RegionID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240728182402_NWSchema1aa_ExistingSchema'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240728182402_NWSchema1aa_ExistingSchema', N'8.0.7');
END;
GO

COMMIT;
GO

