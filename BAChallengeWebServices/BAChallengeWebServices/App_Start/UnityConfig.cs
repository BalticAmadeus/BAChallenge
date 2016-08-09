using Microsoft.Practices.Unity;
using System.Web.Http;
using BAChallengeWebServices.Repository;
using Unity.WebApi;

namespace BAChallengeWebServices
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IActivityRepository, ActivityRepository>();
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}