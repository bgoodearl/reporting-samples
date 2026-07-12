using FluentAssertions;
using System;

namespace NorthwindDataTests
{
    public class DbTestBase
    {
        public DbTestBase(ITestOutputHelper testOutputHelper, TestFixture fixture)
        {
            fixture.Should().NotBeNull();
            testOutputHelper.Should().NotBeNull();
            if (fixture != null && testOutputHelper != null)
            {
                _fixture = fixture;
                _testOutputHelper = testOutputHelper;
            }
            else
            {
                throw new InvalidOperationException("DbTestBase - _fixture or _testOutputHelper is null");
            }
        }


        #region read only variables

        internal ITestOutputHelper _testOutputHelper { get; }
        internal TestFixture _fixture { get; }

        #endregion read only variables

    }
}
