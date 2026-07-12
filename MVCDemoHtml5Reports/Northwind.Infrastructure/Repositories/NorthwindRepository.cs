using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Northwind.Common.Interfaces;
using Northwind.Entities2;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using NER = Northwind.Entities2.ReportEntities;

namespace Northwind.Infrastructure.Repositories
{
    public class NorthwindRepository : INorthwindRepository
    {
        protected INorthwindContext _context { get; }

        public NorthwindRepository(INorthwindContextFactory northwindContextFactory)
        {
            Guard.Against.Null(northwindContextFactory, nameof(northwindContextFactory));
            _context = northwindContextFactory.GetNorthwindContext();
        }


        #region INorthwindRepository

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            return product;
        }

        public void DeleteProduct(int productId)
        {
            Product product = _context.Products.Where(p => p.ProductID == productId).Single();
            _context.Products.Remove(product);
        }

        public List<NER.Company> GetCustomerCompanies(string contactTitleFilter, string countryFilter)
        {
            IQueryable<Customer> rawCustomers = _context.Customers;
            if (!string.IsNullOrWhiteSpace(contactTitleFilter))
                rawCustomers = rawCustomers.Where(c => c.ContactTitle != null && c.ContactTitle.StartsWith(contactTitleFilter));
            if (!string.IsNullOrWhiteSpace(countryFilter))
                rawCustomers = rawCustomers.Where(c => c.Country != null && c.Country.Equals(countryFilter, StringComparison.CurrentCultureIgnoreCase));
            List<NER.Company> companyList = rawCustomers
                .OrderBy(c => c.ContactTitle)
                .ThenBy(c => c.Country)
            .ThenBy(c => c.CompanyName)
                .Select(c => new NER.Company
                {
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Country = c.Country,
                    CustomerId = c.CustomerID,
                    Phone = c.Phone
                })
                .ToList();
            return companyList;
        }

        public List<NER.Company> GetCustomerCompaniesAndOrders(string contactTitleFilter, string countryFilter)
        {
            List<NER.Company> companyList = GetCustomerCompanies(contactTitleFilter, countryFilter);

            IQueryable<Order_Detail> rawOrderDetails = _context.Order_Details;

            List<NER.ReportOrder> orderList = rawOrderDetails
                .OrderBy(od => od.OrderID)
                .ThenBy(od => od.Order.OrderDate)
                .ThenBy(od => od.Product.ProductName)
                .Select(od => new NER.ReportOrder
                {
                    CustomerId = od.Order.CustomerID,
                    OrderDate = od.Order.OrderDate,
                    OrderId = od.OrderID,
                    ProductID = od.ProductID,
                    ProductName = od.Product.ProductName,
                    Quantity = od.Quantity
                })
                .ToList();

            foreach (NER.Company company in companyList)
            {
                company.Orders = orderList
                    .Where(o => o.CustomerId == company.CustomerId)
                    .ToList();
            }

            return companyList;
        }

        public List<string> GetCustomerContactTitles()
        {
            return _context.Customers.Where(x => x.ContactTitle != null).Select(x => x.ContactTitle).Distinct().OrderBy(x => x).ToList();
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        public IEnumerable<NER.SalesSubtotal> GetSalesSubtotals(DateTime? startDate, DateTime? endDate)
        {
            DateTime? firstDate = null;
            DateTime? lastDate = null;
            if (!endDate.HasValue)
            {
                Order o1 = _context.Orders
                    .OrderByDescending(o => o.OrderDate).FirstOrDefault();
                if (o1 != null)
                {
                    lastDate = o1.OrderDate;
                    endDate = lastDate.Value.Date.AddDays(1);
                }
            }
            if (!startDate.HasValue)
            {
                Order o1 = _context.Orders.OrderBy(o => o.OrderDate).FirstOrDefault();
                if (o1 != null)
                {
                    firstDate = o1.OrderDate;
                    startDate = firstDate;
                }
            }
            List<NER.SalesSubtotal> result = new List<NER.SalesSubtotal>();
            if (startDate.HasValue && endDate.HasValue)
            {
                try
                {
                    List<Order> orders = _context.Orders
                                .Include(x => x.Customer)
                                .Include(x => x.Employee)
                                .Include(x => x.Order_Details)
                                .Where(o => o.OrderDate >= startDate.Value && o.OrderDate < endDate)
                                .ToList();

                    foreach (Order o in orders)
                    {
                        NER.SalesSubtotal ss = new NER.SalesSubtotal
                        {
                            CompanyName = o.Customer != null ? o.Customer.CompanyName : $"C_{o.CustomerID}",
                            Country = o.Employee.Country,
                            FirstName = o.Employee != null ? o.Employee.FirstName : "",
                            LastName = o.Employee != null ? o.Employee.LastName : $"E_{o.EmployeeID}",
                            OrderDate = o.OrderDate,
                            OrderID = o.OrderID,
                            ShippedDate = o.ShippedDate
                        };
                        Decimal subtotal = 0;
                        foreach (Order_Detail od in o.Order_Details)
                        {
                            subtotal += (Decimal)(od.UnitPrice * od.Quantity);
                        }
                        ss.Subtotal = subtotal;
                        result.Add(ss);
                    }
                }
                catch (Exception ex)
                {
                    string foo = ex.Message;
                }
            }

            return result;
        }

        public Product UpdateProduct(Product product)
        {
            Product dbProduct = _context.Products.Where(p => p.ProductID == product.ProductID).Single();
            dbProduct.ProductName = product.ProductName;
            return dbProduct;
        }

        #endregion INorthwindRepository


        //*****************
        #region IDisposable
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion IDisposable

    }
}
