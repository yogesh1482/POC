using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using PCF_POC.DAL.Contracts;
using PCF_POC.DAL.Implementations;
using PCF_POC.BL.Contracts;
using System.Web.Http;
using PCF_POC.BL.Implementations;
using PCF_POC.Repository;

namespace PCF_POC.Common.DI
{
 
        public static class UnityConfig
        {
            private static IUnityContainer _unityContainer;

            public static IUnityContainer DIContainer
            {
                get { return _unityContainer; }
            }

            public static void Start()
            {
                _unityContainer = BuildUnityContainer();
                DependencyResolver.SetResolver(new UnityDependencyResolver(_unityContainer));


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(_unityContainer));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(_unityContainer);

        }

            private static IUnityContainer BuildUnityContainer()
            {
                _unityContainer = new UnityContainer();

                _unityContainer.BindInRequestScope<IDatabaseFactory, DatabaseFactory>();
                _unityContainer.BindInRequestScope<IUnitOfWork, UnitOfWork>();
            _unityContainer.BindInRequestScope<IPackageService, PackageService>();
            _unityContainer.BindInRequestScope<IPackageRepository, PackageRepository>();
            _unityContainer.BindInRequestScope<IEquipmentService, EquipmentService>();
            _unityContainer.BindInRequestScope<IPackageEquipmentMappingService, PackageEquipmentMappingService>();
            _unityContainer.BindInRequestScope<IEquipmentRepository, EquipmentRepository>();
            _unityContainer.BindInRequestScope<IPackageEquipmentMappingRepository, PackageEquipmentMappingRepository>();
            
            


            return _unityContainer;
            }
        }

        public static class IocExtensions
        {
            public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
            {
                container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
            }

            public static void BindInSingletonScope<T1, T2>(this IUnityContainer container) where T2 : T1
            {
                container.RegisterType<T1, T2>(new ContainerControlledLifetimeManager());
            }
        }
    
}