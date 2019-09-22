using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Test.Entity;
using Test.Service;

namespace WebApplication3
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
            services.AddAuthentication("Bearer")
                     .AddIdentityServerAuthentication(options =>
                     {
                         options.Authority = "http://localhost:9500";//identity server 地址
                         options.RequireHttpsMetadata = false;
                     });
            string conStr = Configuration["connectionString"];
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseMySql(conStr);
            });


            ///依赖注入Service层
            AddSigletons(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void AddSigletons(IServiceCollection services)
        {
            var assem = Assembly.Load("Test.Service");
            var list = assem.GetTypes().Where(e => e.IsAbstract == false && typeof(ISignFac).IsAssignableFrom(e));
            foreach (var instanType in list)
            {
                foreach (var item in instanType.GetInterfaces())
                {
                    services.AddSingleton(item, instanType);
                }
            }
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
