using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Leaf.Core.Infrastructure;
using Microsoft.Extensions.Logging;
using Leaf.Core.Configuration;
using Leaf.Data;
using Microsoft.EntityFrameworkCore;

namespace Leaf.Web2
{
    //public class Startup
    //{
    //    public IEngine Engine { get; private set; }

    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;

    //        //获取引擎上下文实例
    //        this.Engine = EngineContext.Current;
    //    }

    //    public IConfiguration Configuration { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        var conn = Configuration.GetConnectionString("default");

    //        services.AddMvc();
    //        services.AddCors();

    //        this.Engine.ConfigureServices(services);
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //            app.UseBrowserLink();
    //        }
    //        else
    //        {
    //            app.UseExceptionHandler("/Home/Error");
    //        }

    //        app.UseStaticFiles();

    //        app.UseCors(builder => builder.WithOrigins("*")
    //                              .AllowAnyHeader().AllowAnyMethod());

    //        app.UseMvc(routes =>
    //        {
    //            routes.MapRoute(
    //                name: "default",
    //                template: "{controller=Home}/{action=Index}/{id?}");
    //        });

    //        this.Engine.Configure(app, env);
    //    }
    //}


    public class Startup
    {

        public IEngine Engine { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //获取引擎上下文实例
            this.Engine = EngineContext.Current;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddSingleton(_ => Configuration);

            var conn = Configuration.GetConnectionString("default");

            //services.AddDbContext<LeafObjectContext>(options =>
            //    options.UseSqlServer(conn));
            LeafConfig.connStr = conn;

            // services.AddDbContext<LsyiObjectContext>(options => options.UseSqlServer(conn));
            services.AddCors();

            services.AddAuthentication("mycookieauth")
                .AddCookie("mycookieauth", options => {
                    options.AccessDeniedPath = "/admin/error/";
                    options.LoginPath = "/Login/";
                    options.LogoutPath = "/Logout/";
                });

            
            return this.Engine.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors(builder => builder.WithOrigins("*")
                                  .AllowAnyHeader().AllowAnyMethod());

            app.UseStaticFiles();
            app.UseAuthentication();


            

            app.UseStatusCodePages();//使用默认状态页

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //this.Engine.Configure(app, env, loggerFactory);
        }
    }
}
