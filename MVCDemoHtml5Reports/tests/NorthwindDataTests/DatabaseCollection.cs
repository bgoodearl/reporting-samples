using System.Threading.Tasks;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace NorthwindDataTests
{
    [CollectionDefinition(TestFixture.DbCollectionName)]
    public class DatabaseCollection : TestBed<TestFixture>
    {
        public DatabaseCollection(ITestOutputHelper testOutputHelper, TestFixture fixture)
            : base(testOutputHelper, fixture)
        {
        }

        protected override void Clear()
        {
        }

        protected override ValueTask DisposeAsyncCore()
            => new();
    }
}
