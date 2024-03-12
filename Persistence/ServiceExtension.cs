using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestDasignoContext>(options => options.UseSqlServer(
             configuration.GetConnectionString("DefaultConnection")
            ));

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryDbAsync<>));
            #endregion
            return services;
        }
    }
}
