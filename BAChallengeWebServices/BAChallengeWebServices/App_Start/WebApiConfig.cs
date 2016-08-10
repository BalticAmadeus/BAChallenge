using System.Net.Http.Headers;
using System.Web.Http;
using BAChallengeWebServices.Utility;
using Newtonsoft.Json.Converters;
using System.Web.Http.ExceptionHandling;

namespace BAChallengeWebServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );
            
            config.Services.Replace(typeof(IExceptionHandler), new ExceptionHandling());
        }

        public static void RegisterFormatters(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new CustomTimeConverter());
        }
    }
}
