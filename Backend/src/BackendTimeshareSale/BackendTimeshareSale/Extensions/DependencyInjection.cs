using BackendshareSale.Repo.Interfaces;
using BackendshareSale.Repo.Implements;
using BackendshareSale.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTimeshareSale.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            string str = GetConnectionString();
            services.AddDbContext<TimeSharing2024DBContext>(options => options.UseSqlServer(GetConnectionString()));
            return services;
        }
        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:Database"];

            return strConn;
        }
    }
}
