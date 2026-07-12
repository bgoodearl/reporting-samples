using Microsoft.EntityFrameworkCore;
using Northwind.Entities2;

namespace Northwind.Infrastructure.Persistence
{
    public partial class NorthwindContext //NorthwindContext_OnModelCreating.cs
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Categories");
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.ToTable("Customers");
                e.Property(x => x.CustomerID).HasColumnType("nchar(5)").HasMaxLength(5).IsRequired();
                e.Property(x => x.Total).HasColumnType("decimal").HasPrecision(6,2).IsRequired(false);

                e.HasMany(x => x.CustomerDemographics).WithMany(y => y.Customers);
            });

            modelBuilder.Entity<CustomerDemographic>(e =>
            {
                e.ToTable("CustomerDemographics");
                e.Property(x => x.CustomerTypeID).HasColumnType("nchar(10)").HasMaxLength(10).IsRequired();
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("Employees");
                e.Property(em => em.BirthDate).HasColumnType("datetime").IsRequired(false);
                e.Property(em => em.HireDate).HasColumnType("datetime").IsRequired(false);

                e.HasMany(x => x.Territories).WithMany(y => y.Employees);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.Property(em => em.OrderDate).HasColumnType("datetime").IsRequired(false);
                e.Property(em => em.RequiredDate).HasColumnType("datetime").IsRequired(false);
                e.Property(em => em.ShippedDate).HasColumnType("datetime").IsRequired(false);

                e.HasOne(x => x.Customer).WithMany(y => y.Orders).HasForeignKey(x => x.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired(false);
                e.HasOne(x => x.Employee).WithMany(y => y.Orders).HasForeignKey(x => x.EmployeeID)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired(false);
                e.HasOne(x => x.Shipper).WithMany(y => y.Orders).HasForeignKey(x => x.ShipVia)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired(false);
            });

            modelBuilder.Entity<Order_Detail>(e =>
            {
                e.ToTable("Order Details");
                e.HasKey(x => new { x.OrderID, x.ProductID });

                e.HasOne(x => x.Order).WithMany(y => y.Order_Details).HasForeignKey(x => x.OrderID)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired();
                e.HasOne(x => x.Product).WithMany(y => y.Order_Details).HasForeignKey(x => x.ProductID)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired();
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Products");

                e.HasOne(x => x.Category).WithMany(y => y.Products).HasForeignKey(x => x.CategoryID)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired();
                e.HasOne(x => x.Supplier).WithMany(y => y.Products).HasForeignKey(x => x.SupplierID)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired(false);
            });

            modelBuilder.Entity<Region>(e =>
            {
                e.ToTable("Region");
                e.HasKey(x => x.RegionID);
                e.Property(x => x.RegionDescription).HasColumnType("nchar");
            });

            modelBuilder.Entity<Shipper>(e =>
            {
                e.ToTable("Shippers");
            });

            modelBuilder.Entity<Supplier>(e =>
            {
                e.ToTable("Suppliers");
            });

            modelBuilder.Entity<Territory>(e =>
            {
                e.ToTable("Territories");
                e.HasKey(x => x.TerritoryID);
                e.HasOne(x => x.Region).WithMany(y => y.Territories).HasForeignKey(x => x.RegionID)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired();
                e.Property(x => x.TerritoryDescription).HasColumnType("nchar").HasMaxLength(50).IsRequired();
            });
        }
    }
}
