using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers;

[Route("[Controller]/[Action]")]
public class ReportsController : Controller
{
    
    public ActionResult Suppliers(string townCode)
    {
        return View("Suppliers");
    }
    public ActionResult CompanyOrders(string townCode)
    {
        return View("CompanyOrders");
    }
}
