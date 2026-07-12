using Microsoft.EntityFrameworkCore;
using Northwind.Entities2;
using System;

namespace Northwind.Infrastructure.Interfaces
{
    public interface INorthwindContext : IDisposable
    {
        DbSet<Category> Categories { get; }
        DbSet<CustomerDemographic> CustomerDemographics { get; }
        DbSet<Customer> Customers { get; }
        DbSet<Employee> Employees { get; }
        DbSet<Order_Detail> Order_Details { get; }
        DbSet<Order> Orders { get; }
        DbSet<Product> Products { get; }
        DbSet<Region> Regions { get; }
        DbSet<Shipper> Shippers { get; }
        DbSet<Supplier> Suppliers { get; }
        DbSet<Territory> Territories { get; }
    }
}
