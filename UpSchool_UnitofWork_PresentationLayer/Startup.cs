using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_UnitofWork_BussinessLayer.Abstract;
using UpSchool_UnitofWork_BussinessLayer.Concrete;
using UpSchool_UnitofWork_DataAccessLayer.Abstract;
using UpSchool_UnitofWork_DataAccessLayer.Concrete;
using UpSchool_UnitofWork_DataAccessLayer.EntityFramework;
using UpSchool_UnitofWork_DataAccessLayer.UnitofWork;

namespace UpSchool_UnitofWork_PresentationLayer
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
            services.AddScoped<IAccountDal, EFAccountDal>();
            services.AddScoped<IAccounService, AccountManager>();
            services.AddScoped<IProcessDetailDal, EFProcessDetailDal>();
            services.AddScoped<IProcessDetailService, ProcessDetailManager>();
            services.AddScoped<IUoWDal,UoWDal>();

            services.AddDbContext<Context>();
            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
