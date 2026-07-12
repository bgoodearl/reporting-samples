using Northwind.Entities2;
using System;
using System.Collections.Generic;
using System.Linq;
using NER = Northwind.Entities2.ReportEntities;

namespace Northwind.Common.Interfaces
{
    public interface INorthwindRepository : IDisposable
    {
        Product AddProduct(Product product);
        void DeleteProduct(int productId);
        List<NER.Company> GetCustomerCompanies(string contactTitleFilter, string countryFilter);
        List<NER.Company> GetCustomerCompaniesAndOrders(string contactTitleFilter, string countryFilter);
        List<string> GetCustomerContactTitles();
        IQueryable<Employee> GetEmployees();
        IQueryable<Product> GetProducts();
        IEnumerable<NER.SalesSubtotal> GetSalesSubtotals(DateTime? startDate, DateTime? endDate);
        Product UpdateProduct(Product product);
    }
}
