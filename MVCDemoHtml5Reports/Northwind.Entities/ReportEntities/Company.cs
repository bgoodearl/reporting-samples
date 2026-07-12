using System.Collections.Generic;

namespace Northwind.Entities2.ReportEntities
{
    public class Company
    {
        public string ContactTitle { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string CustomerId { get; set; }
        public List<ReportOrder> Orders { get; set; }
        public string Phone { get; set; }
    }
}
