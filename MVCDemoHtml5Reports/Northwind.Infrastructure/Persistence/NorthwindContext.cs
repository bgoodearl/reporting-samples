using Microsoft.EntityFrameworkCore;
using Northwind.Entities2;
using Northwind.Infrastructure.Interfaces;

namespace Northwind.Infrastructure.Persistence
{
    public partial class NorthwindContext : DbContext, INorthwindContext //NorthwindContext.cs
    {
        public NorthwindContext()
            : base()
        {

        }

        public NorthwindContext(DbContextOptions options)
            : base (options)
        {
            ContextInstance = ++contextInstanceSeed;
            InitializeDbSets();
        }

        internal static DbContextOptions<NorthwindContext> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<NorthwindContext>(), connectionString).Options;
        }


        //*************************
        #region read-only variables

        private static int contextInstanceSeed = 0;
        protected int ContextInstance { get; }

        #endregion read-only variables

        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}
