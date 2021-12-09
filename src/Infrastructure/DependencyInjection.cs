using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Serrvices;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //SQLSERVER
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SQLConnection"))
                , ServiceLifetime.Transient
            );

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Services =====================================================
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
