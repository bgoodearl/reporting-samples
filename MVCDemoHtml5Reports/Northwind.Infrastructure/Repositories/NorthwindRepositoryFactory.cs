using Ardalis.GuardClauses;
using Northwind.Common.Interfaces;
using Northwind.Infrastructure.Interfaces;

namespace Northwind.Infrastructure.Repositories
{
    public class NorthwindRepositoryFactory : INorthwindRepositoryFactory
    {
        public NorthwindRepositoryFactory(INorthwindContextFactory northwindContextFactory)
        {
            Guard.Against.Null(northwindContextFactory, nameof(northwindContextFactory));
            NorthwindContextFactory = northwindContextFactory;
        }

        #region read-only variables

        private INorthwindContextFactory NorthwindContextFactory { get; }

        #endregion read-only variables

        public INorthwindRepository GetRepository()
        {
            return new NorthwindRepository(NorthwindContextFactory);
        }

    }
}
