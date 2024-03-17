using BackendshareSale.Repo.Interfaces;
using BackendshareSale.Repo.Implements;
using BackendshareSale.Repo.Models;
using Microsoft.EntityFrameworkCore;
using Nest;
using BackendTimeshareSale.Service.IServices;
using BackendTimeshareSale.Service.ServiceImp;

namespace BackendTimeshareSale.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IElasticsearchService<Property>, ElasticsearchService<Property>>();
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

        public static void AddElasticSearch(this IServiceCollection services)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200/"))
                            .DefaultIndex("properties")
                            .BasicAuthentication("nhannq", "nhan13042002");

            var client = new ElasticClient(settings);

            services.AddSingleton(client);
        }
    }
}
