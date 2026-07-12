using Northwind.Entities2;

namespace Northwind.Infrastructure.Persistence
{
    public partial class NorthwindContext //NorthwindContext_InitializeDbSets.cs
    {
        private void InitializeDbSets()
        {
            if (Categories == null) Categories = Set<Category>();
            if (CustomerDemographics == null) CustomerDemographics = Set<CustomerDemographic>();
            if (Customers == null) Customers = Set<Customer>();
            if (Employees == null) Employees = Set<Employee>();
            if (Order_Details == null) Order_Details = Set<Order_Detail>();
            if (Orders == null) Orders = Set<Order>();
            if (Products == null) Products = Set<Product>();
            if (Regions == null) Regions = Set<Region>();
            if (Shippers == null) Shippers = Set<Shipper>();
            if (Suppliers == null) Suppliers = Set<Supplier>();
            if (Territories == null) Territories = Set<Territory>();
        }
    }
}
