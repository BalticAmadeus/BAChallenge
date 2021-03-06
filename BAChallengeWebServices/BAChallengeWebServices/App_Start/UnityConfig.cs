using Microsoft.Practices.Unity;
using System.Web.Http;
using BAChallengeWebServices.Repository;
using Unity.WebApi;
using BAChallengeWebServices.Models;
using BAChallengeWebServices.DataTransferModels;

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
            container.RegisterType<IRepository<Result>, ResultRepository>();
            container.RegisterType<IActivityParticipantRepository, ActivityParticipantRepository>();
            container.RegisterType<IRepository<Participant>, ParticipantRepository>();
            container.RegisterType<IExceptionRepository<ExceptionModel>, ExceptionRepository>();

            // e.g. container.RegisterType<ITestService, TestService>();

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}