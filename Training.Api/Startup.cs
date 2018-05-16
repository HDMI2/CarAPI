using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Training.Api.Models;
using Training.Api.Services;
using AutoMapper;

namespace Training.Api
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

            services.AddDbContext<CarAPIContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });


            //Automapper
            services.AddAutoMapper();


            //HttpClient Factory
            services.AddHttpClient<GitHubClient>(client =>
            {
                client.BaseAddress = new Uri("http://api.github.de");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd,guthub.vs+json");
                client.DefaultRequestHeaders.Add("User-Agent", "Testing.API");
            }
            );

            //IoC Service

            services.AddScoped<ICarRepository,CarRepository>(); //nach jedem HTTP Request eine neue Instanz erstellen

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
