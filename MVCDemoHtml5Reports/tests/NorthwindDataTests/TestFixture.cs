using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Common.Interfaces;
using Northwind.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace NorthwindDataTests
{
    public class TestFixture : TestBedFixture
    {
        public const string DbCollectionName = "DatabaseCollection";
        private static int fixtureInstanceCount = 0;

        public TestFixture()
        {
            ++fixtureInstanceCount;
        }


        #region Data Factory methods

        internal INorthwindRepositoryFactory GetNorthwindRepositoryFactory(ITestOutputHelper testOutputHelper)
        {
            testOutputHelper.Should().NotBeNull();
            INorthwindRepositoryFactory repositoryFactory = GetService<INorthwindRepositoryFactory>(testOutputHelper);
            repositoryFactory.Should().NotBeNull();
            if (repositoryFactory != null)
            {
                return repositoryFactory;
            }
            throw new InvalidOperationException("GetNorthwindRepositoryFactory - invalid configuration");
        }

        #endregion Data Factory methods


        #region TestBed

        protected override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            if (configuration != null)
            {
                services.AddNorthwindInfrastructure(configuration);
            }
        }

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            List<TestAppSettings> appSettingsFiles = new List<TestAppSettings>();
            foreach (string file in TestBase.ConfigurationFiles)
            {
                appSettingsFiles.Add(new TestAppSettings
                {
                    Filename = file,
                    IsOptional = false
                });
            }
            return appSettingsFiles;
        }

        protected override ValueTask DisposeAsyncCore()
            => new();

        #endregion TestBed
    }
}
