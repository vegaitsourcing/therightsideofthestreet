using System.Linq;
using System.Web;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Web;

namespace PravaStranaUlice.Web
{
	/// <summary>
	/// Route constraint that allows only existing languages in the route.
	/// </summary>
	public class ExistingLanguagesRouteConstraint : IRouteConstraint    // TODO: Remove on single-language site.
	{
		public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
		{
			string language = values[parameterName].ToString();
			if (string.IsNullOrWhiteSpace(language))
			{
				return false;
			}

			// Checks if there is appropriate Umbraco domain for specified language, based on current request URL
			return ApplicationContext.Current.Services.DomainService.GetAll(false)
									 .Where(d => d.DomainName.Contains($"{httpContext.Request.Url.Host}/{language}"))
									 .Any();
		}
	}
}
