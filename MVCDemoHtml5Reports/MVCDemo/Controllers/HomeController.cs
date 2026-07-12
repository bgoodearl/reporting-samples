using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Models.Home;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVCDemo.Controllers
{
    [Route("[Controller]/[Action]")]
    public class HomeController : Controller
    {
        [Route("~/")]
        public IActionResult Index()
        {
            List<ReportTest> tests = GetReportTests();
            HomeViewModel model = new HomeViewModel
            {
                HaveReportTests = tests.Count > 0
            };
            return View(model);
        }
        public ActionResult ReportTests()
        {
            ReportTestsViewModel model = new ReportTestsViewModel
            {
                ReportTests = GetReportTests()
            };
            return View(model);
        }

        protected List<ReportTest> GetReportTests()
        {
            List<ReportTest> tests = new List<ReportTest>();

            // Hard coded for now
            tests.Add(new ReportTest
            {
                ReportName = "Suppliers",
                ReportMethod = "Suppliers"
            });
            tests.Add(new ReportTest
            {
                ReportName = "CompanyOrders",
                ReportMethod = "CompanyOrders"
            });
            return tests;
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
