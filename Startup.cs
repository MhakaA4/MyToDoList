using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MitchelleList.Infrastructure;

namespace MitchelleList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // allows for services to be addded to container
        public void ConfigureServices(IServiceCollection services)
        {//Specified Cookie Handler: Produces Implementation of IAuthentication
            //services.AddAuthentication("CookieAuth")
             //   .AddCookie("CookieAuth", config =>
               // {
                 //   config.Cookie.Name = "Mitchelles.Cookie";
                   // config.LoginPath = "/Home/Authenticate";
             //   });//
            services.AddControllersWithViews();
            services.AddDbContext<MitchelleListContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MitchelleListContext")));
           // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //   .AddEntityFrameworkStores<MitchelleListContext>();

            services.AddRazorPages();

        }

        //allows for the HTTP request pipeline to be configured
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

           
           //app.UseAuthentication();

            
           app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=todo}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
            });
        }
    }
}
