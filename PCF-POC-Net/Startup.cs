using Microsoft.Owin;
using Owin;
using Microsoft.Extensions.DependencyInjection;
using PCF_POC.Services;
using PCF_POC.Interfaces;
using System.Web.Services.Description;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(PCF_POC_Net.Startup))]
namespace PCF_POC_Net
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        protected IServiceProvider serviceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.serviceProvider.GetServices(serviceType);
        }
    }

    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
           IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            ConfigureAuth(app);
            //ConfigureServices(services);

            //var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            //DependencyResolver.SetResolver(resolver);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<IISOptions>(options =>
            //{
            //    options.AutomaticAuthentication = true;
            //});
            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add functionality to inject IOptions<T>
            //services.AddOptions();

            //// Add our Config object so it can be injected
            //services.Configure<AppSettings>(Configuration.GetSection("MustHaveAppSettings"));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            //services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IAppInfoService, EquipmentService>();
            services.AddTransient<IAppInfoService, PackageService>();
            services.AddSingleton<IBaseService, BaseService>();

            //services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
            //.Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
            //.Where(t => typeof(IController).IsAssignableFrom(t) 
            //    || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        //    loggerFactory.AddDebug();

        //    app.UseApplicationInsightsRequestTelemetry();

        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseDatabaseErrorPage();
        //        app.UseBrowserLink();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //    }

        //    app.UseApplicationInsightsExceptionTelemetry();

        //    app.UseStaticFiles();

        //    app.UseIdentity();

        //    // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(
        //            name: "default",
        //            template: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
    }
}
