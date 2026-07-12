using Ardalis.GuardClauses;
using Northwind.Infrastructure.Interfaces;

namespace Northwind.Infrastructure.Persistence
{
    public class NorthwindContextFactory : INorthwindContextFactory
    {
        protected string ConnectionString { get; }

        public NorthwindContextFactory(string connectionString)
        {
            Guard.Against.NullOrWhiteSpace(connectionString, nameof(connectionString));
            ConnectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return ConnectionString;
        }

        public INorthwindContext GetNorthwindContext()
        {
            return new NorthwindContext(NorthwindContext.GetOptions(ConnectionString));
        }

    }
}
