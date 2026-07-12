using FluentAssertions;
using Northwind.Entities2.ReportEntities;
using Northwind.ReportHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindDataTests.NorthwindRepositoryTests
{
    [Collection(TestFixture.DbCollectionName)]
    public class NorthwindHelperTests : DbTestBase
    {
        public NorthwindHelperTests(ITestOutputHelper testOutputHelper, TestFixture fixture)
            : base(testOutputHelper, fixture)
        {
        }

        [Fact]
        public void CanGetCustomerCompaniesAndOrders_All()
        {
            NorthwindObjectSource objectSource = new NorthwindObjectSource();

            IList<Company> items = objectSource.GetCustomerCompaniesAndOrders("");
            items.Should().NotBeNull();
            int fullItemCount = items.Count();
            _testOutputHelper.WriteLine($"Company count = {fullItemCount}");
            int ordersMissingCount = 0;
            int noOrdersCount = 0;
            int maxOrdersCount = 0;
            Company cmaxo = null;
            Dictionary<string, int> contactTitleCompanyCountDict = new Dictionary<string, int>();
            foreach (Company c in items)
            {
                if (c.Orders == null)
                {
                    ordersMissingCount++;
                }
                else if (c.Orders.Count < 1)
                {
                    noOrdersCount++;
                }
                else
                {
                    if (c.Orders.Count > maxOrdersCount)
                    {
                        maxOrdersCount = c.Orders.Count;
                        cmaxo = c;
                    }
                    if (!string.IsNullOrWhiteSpace(c.ContactTitle))
                    {
                        if (!contactTitleCompanyCountDict.ContainsKey(c.ContactTitle))
                        {
                            contactTitleCompanyCountDict.Add(c.ContactTitle, 1);
                        }
                        else
                        {
                            contactTitleCompanyCountDict[c.ContactTitle]++;
                        }
                    }
                }
            }
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine($"Company contact title count = {contactTitleCompanyCountDict.Count}");
            foreach (KeyValuePair<string, int> kv in contactTitleCompanyCountDict)
            {
                _testOutputHelper.WriteLine($"[{kv.Key}]: count = {kv.Value}");
            }
            _testOutputHelper.WriteLine("");

            _testOutputHelper.WriteLine($"Companies without Orders count = {ordersMissingCount}, with no Orders count = {noOrdersCount}, max Orders count = {maxOrdersCount}");
            _testOutputHelper.WriteLine("");
            if (cmaxo != null)
            {
                _testOutputHelper.WriteLine($"[{cmaxo.CompanyName}] has {cmaxo.Orders.Count} orders");
                _testOutputHelper.WriteLine("");
                Dictionary<int, Dictionary<int, ReportOrder>> productOrdersDict = new Dictionary<int, Dictionary<int, ReportOrder>>();

                foreach (var o in cmaxo.Orders)
                {
                    if (!productOrdersDict.ContainsKey(o.ProductID))
                    {
                        Dictionary<int, ReportOrder> orderDict = new Dictionary<int, ReportOrder>();
                        orderDict.Add(o.OrderId, o);
                        productOrdersDict.Add(o.ProductID, orderDict);
                    }
                    else
                    {
                        productOrdersDict[o.ProductID].Add(o.OrderId, o);
                    }
                }
                _testOutputHelper.WriteLine($"Distinct Product count = {productOrdersDict.Count}");
            }
        }

        [Fact]
        public void CanGetCustomerCompaniesAndOrders_Sales_Rep()
        {
            string contactTitle = "Sales Representative";
            NorthwindObjectSource objectSource = new NorthwindObjectSource();

            IList<Company> items = objectSource.GetCustomerCompaniesAndOrders(contactTitle);
            items.Should().NotBeNull();
            int fullItemCount = items.Count();
            _testOutputHelper.WriteLine($"Company count = {fullItemCount} for contact title [{contactTitle}]");

            int contactTitleMissingCount = 0;
            int contactTitleMismatchCount = 0;
            foreach (Company c in items)
            {
                if (string.IsNullOrWhiteSpace(c.ContactTitle))
                {
                    contactTitleMissingCount++;
                }
                else if (c.ContactTitle != contactTitle)
                {
                    contactTitleMismatchCount++;
                }
            }

            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine($"Companies w/missing Contact Title count = {contactTitleMissingCount}, w/Contact Title mismatch = {contactTitleMismatchCount}");
        }

        [Fact]
        public void CanGetCustomerContactTitles()
        {
            NorthwindObjectSource objectSource = new NorthwindObjectSource();

            IList<string> items = objectSource.GetContactTitles();
            items.Should().NotBeNull();
            int fullItemCount = items.Count();
            _testOutputHelper.WriteLine($"Contact Titles count = {fullItemCount}");
            _testOutputHelper.WriteLine("");
            foreach (string item in items)
            {
                _testOutputHelper.WriteLine($"\t[{item}]");
            }
        }

    }
}
