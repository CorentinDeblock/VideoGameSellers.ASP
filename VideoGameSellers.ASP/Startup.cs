using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Models;
using VideoGameSellers.ASP.Models.Form;
using VideoGameSellers.ASP.Services;
using VideoGameSellers.ASP.Services.Bases;

namespace VideoGameSellers.ASP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession((SessionOptions options) =>
            {
                options.Cookie.HttpOnly = true;
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });

            services.AddControllersWithViews();

            services.AddSingleton(new AppEnv(Configuration.GetSection("Endpoint")["Url"]));

            services.AddScoped<BaseService<SaleModel, SaleForm>, SaleService>();
            services.AddScoped<BaseService<UserModel, UserForm>, UserService>();
            services.AddScoped<BaseService<PlatformModel, PlatformForm>, PlatformService>();
            services.AddScoped<BaseService<CompanyModel, CompanyForm>, CompanyService>();
            services.AddScoped<BaseService<GameModel, GameForm>, GameService>();
            services.AddScoped<BaseService<SaleModel, SaleForm>, SaleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "User",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
