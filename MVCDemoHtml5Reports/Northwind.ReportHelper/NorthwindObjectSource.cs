using Microsoft.Extensions.Configuration;
using Northwind.Common.Interfaces;
using Northwind.Entities2.ReportEntities;
using Northwind.Infrastructure.Interfaces;
using Northwind.ReportHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using NIP = Northwind.Infrastructure.Persistence;
using NIR = Northwind.Infrastructure.Repositories;

namespace Northwind.ReportHelper
{
    [DataObject]
    public class NorthwindObjectSource
    {
        //internal static string[] ConfigurationFiles =
        //{
        //    "appsettings.json",
        //    "appsettings.LocalTesting.json"
        //};
        protected IConfigurationRoot GetConfiguration()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("config\\appsettings.json", true)
                .AddJsonFile("appsettings.json", true)
                .Build();
            return config;
        }

        protected INorthwindRepositoryFactory NorthwindRepositoryFactory { get; }


        public NorthwindObjectSource()
        {
            IConfigurationRoot config = GetConfiguration();
            const string NorthwindContextKey = "ConnectionStrings:NorthwindContext";
            string northwindEfConnStr = config[NorthwindContextKey];
            INorthwindContextFactory northwindContextFactory = new NIP.NorthwindContextFactory(northwindEfConnStr);
            NorthwindRepositoryFactory = new NIR.NorthwindRepositoryFactory(northwindContextFactory);
        }

        private INorthwindRepository GetRepository()
        {
            return NorthwindRepositoryFactory.GetRepository();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<string> GetContactTitles()
        {
            using (INorthwindRepository repo = GetRepository())
            {
                return repo.GetCustomerContactTitles();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Company> GetCustomerCompaniesAndOrders(string contactTitle)
        {
            using (INorthwindRepository repo = GetRepository())
            {
                return repo.GetCustomerCompaniesAndOrders(contactTitle, null);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Company> GetCustomerCompaniesAndOrdersInfo(string contactTitle)
        {
            CustomerCompaniesAndOrdersInfo info = new CustomerCompaniesAndOrdersInfo();


            using (INorthwindRepository repo = GetRepository())
            {
                return repo.GetCustomerCompaniesAndOrders(contactTitle, null);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public CustomerCompaniesAndOrdersInfo GetCustomerCompanyInfo(string contactTitle)
        {
            CustomerCompaniesAndOrdersInfo info = new CustomerCompaniesAndOrdersInfo();

            using (INorthwindRepository repo = GetRepository())
            {
                info.Companies = repo.GetCustomerCompaniesAndOrders(contactTitle, null);
                info.ReportInfoList.Clear();
                info.ReportInfoList.Add(new CustomerCompaniesReportInfo
                {
                    ContactTitle = contactTitle,
                    ReportRunTime = DateTime.Now
                });
            }
            return info;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Company> GetCustomerCompaniesAndOrdersWithCountryFilter(string country)
        {
            using (INorthwindRepository repo = GetRepository())
            {
                return repo.GetCustomerCompaniesAndOrders(null, country);
            }
        }    
    }
}
