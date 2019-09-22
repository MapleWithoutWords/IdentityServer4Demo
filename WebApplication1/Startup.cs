using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Entity;
using Test.Service;
using WebApplication1.Settings;

namespace WebApplication1
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddAuthentication("Bearer")
            //         .AddIdentityServerAuthentication(options =>
            //         {
            //             options.Authority = "http://localhost:9500";//identity server 地址
            //             options.RequireHttpsMetadata = false;
            //         });
            string conStr = Configuration["connectionString"];
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseMySql(conStr);
            });


            ///依赖注入Service层
            AddSigletons(services);

            #region ID4服务配置
            var id4Build = services.AddIdentityServer()
                        .AddDeveloperSigningCredential()
                        .AddInMemoryIdentityResources(Config.GetIdentityResources());
            //加载apiresource
            id4Build.Services.AddTransient<IResourceStore, TestReourceStore>();
            //加载client
            id4Build.Services.AddTransient<IClientStore, TestClientStore>();
            //登录验证
            id4Build.Services.AddTransient<IResourceOwnerPasswordValidator, TestResourceOwnerPasswordValidator>();
            //加载profile。profile是用来获取用户信息的
            id4Build.Services.AddTransient<IProfileService, ProfileService>();
            #endregion


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


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
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //插入id4中间件
            app.UseIdentityServer();
            //app.UseAuthentication();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});


        }
    }
}
