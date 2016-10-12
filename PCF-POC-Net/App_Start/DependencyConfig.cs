using Autofac;
using Autofac.Integration.Mvc;
using PCF_POC.Interfaces;
using PCF_POC.Services;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;

namespace PCF_POC_Net
{
    public class DependencyConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            builder.RegisterType<AuthMessageSender>().As<IEmailSender>();
            builder.RegisterType<AuthMessageSender>().As<ISmsSender>();
            builder.RegisterType<EquipmentService>().As<IAppInfoService>();
            builder.RegisterType<PackageService>().As<IAppInfoService>();
            builder.RegisterType<BaseService>().As<IBaseService>();

            // Add our Config object so it can be injected
            builder.Register(c => ConfigurationManager.GetSection("MustHaveAppSettings") as AppSettings).As<AppSettings>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}