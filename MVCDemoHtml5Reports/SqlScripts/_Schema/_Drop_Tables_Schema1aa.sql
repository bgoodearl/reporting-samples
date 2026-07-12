USE Northwind_dn8dev;
GO

DECLARE @DropTables bit SET @DropTables = 0;
--DECLARE @DropTables bit SET @DropTables = 1;	--********* START HERE TO DELETE TABLES *********

Declare @DbName nvarchar(128); Select @DbName = DB_NAME();
Declare @MachineName nvarchar(128); Select @MachineName = CONVERT(nvarchar,SERVERPROPERTY('ComputerNamePhysicalNetBIOS'));
Declare @InstanceName nvarchar(128); Select @InstanceName = CONVERT(nvarchar,SERVERPROPERTY('InstanceName'));

IF ISNULL(@DbName,'x') != 'Northwind_dn8dev' Begin
	Set @DropTables = 0;
End Else Begin
	If (ISNULL(@MachineName,'x') != 'RGWS026') and (ISNULL(@MachineName,'x') != 'CHRISPELS57E0') and (ISNULL(@MachineName,'x') != 'JUNE-2018') Begin
		Set @DropTables = 0;
	End Else Begin
		If (ISNULL(@InstanceName,'x') != 'SQL2019') and (ISNULL(@InstanceName,'x') != 'SQLEXPRESS') and (ISNULL(@InstanceName,'x') != 'SQL2022') Begin
			Set @DropTables = 0;
		End;
	End;
End;

Print '_Drop_S7aa_Tables.sql on ' + ISNULL(@MachineName,'??') + '\' + ISNULL(@InstanceName,'??') + ' - ' + ISNULL(@DbName,'??');
Print 'DropTables = ' + ISNULL(Convert(varchar,@DropTables),'?');

IF ISNULL(@DropTables,0) = 1 BEGIN

	DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512), @KeyName nvarchar(128);

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'CustomerCustomerDemographic'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'EmployeeTerritory'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Order Details'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE [' + @TableName + ']';
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table [' + @TableName + '] not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Orders'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Employees'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Customers'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Customers'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Products'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Categories'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Territories'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Region'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'CustomerDemographics'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Shippers'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'Suppliers'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

	--DECLARE @TableName NVARCHAR(128), @SqlCmd nvarchar(512)
	SET @TableName = N'__EFMigrationsHistory'
	IF (EXISTS (SELECT name FROM sysobjects WHERE (name = @TableName) AND (type = 'U'))) BEGIN
		Set @SqlCmd = N'DROP TABLE ' + @TableName
		EXEC sp_executesql @SqlCmd
		PRINT 'dropped table ' + @TableName
	END ELSE BEGIN
		PRINT 'table ' + @TableName + ' not found for drop.'
	END

END;
GO
