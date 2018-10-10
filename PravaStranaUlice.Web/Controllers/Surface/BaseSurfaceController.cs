using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.Surface
{
    public class BaseSurfaceController : SurfaceController
    {
        /// <summary>
        /// Called when an unhandled exception occurs on a controller level (during action processing).
        /// </summary>
        /// <param name="filterContext">Information about the current request.</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            LogHelper.Error(GetType(), $"An unhandled exception occurred on surface controller action '{filterContext.RouteData.Values["action"]}'!", filterContext.Exception);

            // Return empty result, to prevent the whole page failure.
            filterContext.Result = new EmptyResult();
            filterContext.ExceptionHandled = true;
        }
    }
}