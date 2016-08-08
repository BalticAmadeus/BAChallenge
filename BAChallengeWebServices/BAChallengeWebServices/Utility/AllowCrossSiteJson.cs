using System.Web.Http.Filters;

namespace BAChallengeWebServices.Utility
{
    /// <summary>
    /// Filter that adds a header, required to allow work for others.
    /// </summary>
    public class AllowCrossSiteJson : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response?.Headers.Add("Access-Control-Allow-Origin", "*");

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
