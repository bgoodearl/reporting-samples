using System.Collections.Generic;

namespace MVCDemo.Models.Home;

public class ReportTestsViewModel
{
    public ReportTestsViewModel()
    {
        ReportTests = new List<ReportTest>();
    }

    public List<ReportTest> ReportTests { get; set; }
}
