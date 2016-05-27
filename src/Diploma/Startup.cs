using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Diploma.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;

namespace Diploma
{
    //public class CustomAuthorizedAttribute: AuthorizeAttribute
    //{
    //    protected override AuthorizeCore
    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {

    //        base.OnAuthorization(filterContext);

    //        // this is overriden for kendo menus to hide 
    //        var ctrl = filterContext.RequestContext.RouteData.GetRequiredString("controller");
    //        var action = filterContext.ActionDescriptor.ActionName;

    //    [custom authorization logic on action/ctrl]

    //    // useful to determine if it's authorizing current controller path or menu links
    //    var path = filterContext.HttpContext.Request.PhysicalPath;
    //    _authorizingCurrentPath = path.Contains(ctrl) || path.EndsWith("WebUI") ;


    //    if (userAuth<requiredAuth)
    //        HandleUnauthorizedRequest(filterContext);
    //}


    //protected override void HandleUnauthorizedRequest(AuthorizationContext ctx)
    //{
    //    if (!ctx.HttpContext.User.Identity.IsAuthenticated)
    //        base.HandleUnauthorizedRequest(ctx);
    //    else {
    //        if (_authorizingCurrentPath)
    //        {
    //            // handle controller access
    //            ctx.Result = new ViewResult { ViewName = "Unauthorized" };
    //            ctx.HttpContext.Response.StatusCode = 403;
    //        }
    //        else {
    //            // handle menu links
    //            ctx.Result = new HttpUnauthorizedResult();
    //            ctx.HttpContext.Response.StatusCode = 403;
    //        }
    //    }
    //}



    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddIdentity<User, UserRoles>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 6;                    
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<DashboardContext>();
                        
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DashboardContext>();

            services.AddTransient<InitiateDB>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, InitiateDB seed)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<DashboardContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseStaticFiles();
            
            app.UseIdentity();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index"}
                );
            });

            await seed.SeedTestDataAsync();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
