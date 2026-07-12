using Northwind.Entities2.ReportEntities;
using System.Collections.Generic;

namespace Northwind.ReportHelper.Models
{
    public class CustomerCompaniesAndOrdersInfo
    {
        public CustomerCompaniesAndOrdersInfo()
        {
            Companies = new List<Company>();
            ReportInfoList = new List<CustomerCompaniesReportInfo>();
        }

        public List<Company> Companies { get; set; }
        public List<CustomerCompaniesReportInfo> ReportInfoList { get; set; }
    }
}
