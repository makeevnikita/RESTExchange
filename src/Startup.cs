using Microsoft.EntityFrameworkCore;
using src.Models;
using src.Interfaces;
using src.Repositories;
using src.Middlewares;



namespace src
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("PostgresConnection");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddTransient<INetworkRepository, EFNetworkRepository>();
            services.AddTransient<IPaymentMethodRepository, EFPaymentMethodRepository>();
            services.AddTransient<IClientCurrencyRepository, EFClientCurrencyRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {   
                endpoints.MapControllers();
            });

            
        }
    }
}