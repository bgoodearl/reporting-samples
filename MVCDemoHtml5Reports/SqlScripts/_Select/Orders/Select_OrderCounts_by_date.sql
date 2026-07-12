USE [Northwind-Full];
GO

Select
	Convert(date,o.OrderDate) [OrderDate]
	,COUNT(Distinct o.OrderID) [OrderCount]
From dbo.Orders o
Group by
	Convert(date,o.OrderDate)
Order by
	Convert(date,o.OrderDate)
;

GO
