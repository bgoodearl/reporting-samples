using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;

namespace MVCDemo.Controllers.API
{
  [Route("api/reports")]
  [ApiController]
  public class ReportsController : ReportsControllerBase
  {
    public ReportsController(IReportServiceConfiguration reportServiceConfiguration)
        : base(reportServiceConfiguration)
    {
    }

  }
}
