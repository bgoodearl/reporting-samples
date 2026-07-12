
namespace Northwind.Infrastructure.Interfaces
{
    public interface INorthwindContextFactory
    {
        string GetConnectionString();
        INorthwindContext GetNorthwindContext();
    }
}
