using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.db;
using OnlineShop.db.Models;
using Serilog;
using System;

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
            
            // Add DB connection
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            // Add Identity
                // for MsSql
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));
                // for Postgres
            //services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connection));

            services.AddIdentity<UserDb, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            // cookies
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            services.AddTransient<IOrdersRepository,   DbRepositoryOrders>();
            services.AddTransient<IProductsRepository, DbRepositoryProducts>();
            services.AddTransient<ICartsRepository,    DbRepositoryCarts>();
            services.AddTransient<IFavoriteRepository, DbRepositoryFavorite>();
            
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();   

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

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
