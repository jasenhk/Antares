using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Antares.Data;
using Antares.Web.Common;

namespace Antares.Web
{
    public static class UnityConfig
    {
        public static void Initialise(UnityConfigParameters parameters)
        {
            var container = BuildUnityContainer(parameters);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            FilterConfig.RegisterGlobalFilters(parameters.Filters, container);
        }

        private static IUnityContainer BuildUnityContainer(UnityConfigParameters parameters)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterInstance<IAppSettings>(AppSettings.Current);
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor(parameters.ConnectionString));


            //container.RegisterType<IUserProfileRepository, UserProfileRepository>();

            return container;
        }
    }

    public class UnityConfigParameters
    {
        public string ConnectionString { get; set; }
        public GlobalFilterCollection Filters { get; set; }
    }
}