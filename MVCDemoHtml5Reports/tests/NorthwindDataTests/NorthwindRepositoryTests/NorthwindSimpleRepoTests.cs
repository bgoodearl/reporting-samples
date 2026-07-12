using FluentAssertions;
using Northwind.Common.Interfaces;
using Northwind.Entities2;
using Northwind.Entities2.ReportEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindDataTests.NorthwindRepositoryTests
{
    [Collection(TestFixture.DbCollectionName)]
    public class NorthwindSimpleRepoTests : DbTestBase
    {
        public NorthwindSimpleRepoTests(ITestOutputHelper testOutputHelper, TestFixture fixture)
            : base(testOutputHelper, fixture)
        {
        }

        [Fact]
        public void CanGetCustomerContactTitles()
        {
            using (INorthwindRepository repo = _fixture.GetNorthwindRepositoryFactory(_testOutputHelper).GetRepository())
            {
                IList<string> items = repo.GetCustomerContactTitles();
                items.Should().NotBeNull();
                int fullItemCount = items.Count();
                _testOutputHelper.WriteLine($"Contact Titles count = {fullItemCount}");
                _testOutputHelper.WriteLine("");
                foreach(string item in items)
                {
                    _testOutputHelper.WriteLine($"\t[{item}]");
                }
            }
        }

        [Fact]
        public void CanGetEmployees()
        {
            using (INorthwindRepository repo = _fixture.GetNorthwindRepositoryFactory(_testOutputHelper).GetRepository())
            {
                IQueryable<Employee> qitems = repo.GetEmployees();
                qitems.Should().NotBeNull();
                int fullItemCount = qitems.Count();
                _testOutputHelper.WriteLine($"Employees count = {fullItemCount}");
                List<Employee> itemList = qitems.ToList();
                itemList.Should().NotBeNull();
            }
        }

        [Fact]
        public void CanGetProducts()
        {
            using (INorthwindRepository repo = _fixture.GetNorthwindRepositoryFactory(_testOutputHelper).GetRepository())
            {
                IQueryable<Product> pitems = repo.GetProducts();
                pitems.Should().NotBeNull();
                int fullItemCount = pitems.Count();
                _testOutputHelper.WriteLine($"Product count = {fullItemCount}");
                List<Product> itemList = pitems.ToList();
                itemList.Should().NotBeNull();
            }
        }

        [Fact]
        public void CanGetSalesSubtotalsFor1998April()
        {
            using (INorthwindRepository repo = _fixture.GetNorthwindRepositoryFactory(_testOutputHelper).GetRepository())
            {
                DateTime startDate = new DateTime(1998, 4, 1);
                DateTime endDate = startDate.AddMonths(1);
                IEnumerable<SalesSubtotal> ssitems = repo.GetSalesSubtotals(startDate, endDate);
                int fullItemCount = ssitems.Count();
                _testOutputHelper.WriteLine($"Sales Subtotal count = {fullItemCount}");
                List<SalesSubtotal> itemList = ssitems.ToList();
                itemList.Should().NotBeNull();
            }
        }
    }
}
