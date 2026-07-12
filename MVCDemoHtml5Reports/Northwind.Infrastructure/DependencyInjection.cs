using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Common.Interfaces;
using Northwind.Infrastructure.Interfaces;
using NIP = Northwind.Infrastructure.Persistence;
using NIR = Northwind.Infrastructure.Repositories;

namespace Northwind.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNorthwindInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            const string NorthwindContextKey = "ConnectionStrings:NorthwindContext";
            string northwindEfConnStr = configuration[NorthwindContextKey];
            Guard.Against.NullOrWhiteSpace(northwindEfConnStr, $"configuration[{NorthwindContextKey}]");

            services.AddSingleton<INorthwindContextFactory>(sp => new NIP.NorthwindContextFactory(northwindEfConnStr));

            services.AddScoped<INorthwindContext>(sp => sp.GetRequiredService<INorthwindContextFactory>().GetNorthwindContext());

            services.AddSingleton<INorthwindRepositoryFactory>(sp =>
                new NIR.NorthwindRepositoryFactory(sp.GetRequiredService<INorthwindContextFactory>()));

            return services;
        }
    }
}
