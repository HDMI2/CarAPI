using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental
{
    public class Startup
    {
        //demo
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //In Memory DB
            services.AddDbContext<CarRentalDBContext>(options =>
            {
                options.UseInMemoryDatabase("CarRental");
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //1.General Exception
                app.UseExceptionHandler("/Home/Error");

                //2. Status CodePages
                // app.UseStatusCodePages();


                //3. Custom Error Page for Statuscode
                app.UseStatusCodePagesWithReExecute("/Home/ErrorCustom", "?StatusCode={0}");

                // app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            //1.default MvcWithDefaultRoute
            //app.UseMvcWithDefaultRoute();

            //2.


            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Cars", action = "Index" });

                //PArams
                routes.MapRoute(
                    name: "carRoute",
                    template: "{controller}/{id?}/{action}/",
                    defaults: new { controller = "Cars", action = "Index" });

                //constrains
                routes.MapRoute(
                  name: "carRoute1",
                  template: "{controller}/{id:alpha}/{action}/",
                  defaults: new { controller = "Cars", action = "Test" });


            });



        }
    }
}
