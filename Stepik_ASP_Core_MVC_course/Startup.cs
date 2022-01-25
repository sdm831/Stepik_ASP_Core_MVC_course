using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.db;
using Serilog;

namespace Stepik_ASP_Core_MVC_course
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
            string connection = Configuration.GetConnectionString("online_shop");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            
            services.AddTransient<IProductsRepository, ProductsDbRepository>();

            services.AddSingleton<ICartsRepository, CartsInMemoryRepository>();
            services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
            services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
            services.AddSingleton<IUsersManager, UsersManager>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();   // dir wwwroot

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{area:exists}/{controller=home}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");                               
            });
        }
    }
}
