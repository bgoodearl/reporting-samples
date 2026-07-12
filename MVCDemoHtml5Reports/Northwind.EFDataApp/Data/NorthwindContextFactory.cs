using Northwind.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace MACRIS2.Core.EFDataApp.Data
{
    public class NorthwindContextFactory : IDesignTimeDbContextFactory<NorthwindContext>
    {
        public NorthwindContext CreateDbContext(string[] args)
        {
            const string connectionStringPath = "ConnectionStrings:NorthwindContext";
            var config = ConfigHelper.GetConfiguration();
            var connectionString = config[connectionStringPath];
            if (string.IsNullOrWhiteSpace(connectionString)) throw new InvalidOperationException($"{connectionStringPath} not found");
            var optionsBuilder = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<NorthwindContext>(), connectionString);
            return new NorthwindContext(optionsBuilder.Options);
        }
    }
}
