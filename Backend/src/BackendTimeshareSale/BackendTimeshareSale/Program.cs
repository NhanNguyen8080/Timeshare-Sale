using AutoMapper;
using BackendTimeshareSale.Extensions;
using BackendTimeshareSale.Helper;
using BackendTimeshareSale.Service.IServices;
using BackendTimeshareSale.Service.ServiceImp;

namespace BackendTimeshareSale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDatabase();
            builder.Services.AddUnitOfWork();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IContractService, ContractService>();
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IInvestorService, InvestorService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IStaffService, StaffService>();



            builder.Services.AddElasticSearch();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            /* builder.Services.AddSession(options =>
             {
                 options.IdleTimeout = TimeSpan.FromMinutes(30);
                 options.Cookie.HttpOnly = true;
                 options.Cookie.IsEssential = true;
             });*/
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();
            /*app.UseSession();*/
            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}