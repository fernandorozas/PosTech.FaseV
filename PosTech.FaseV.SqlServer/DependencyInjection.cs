using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.SqlServer.Interceptors;
using PosTech.FaseV.SqlServer.Repositories;

namespace PosTech.FaseV.SqlServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
           
            
            services.AddSingleton(TimeProvider.System);

            services.AddScoped<IRepositoryAsset, RepositoryAsset>();

            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
