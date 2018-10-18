using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Partials
{
	public class BasePartialController : BaseSurfaceController
	{
		public ISiteContext CreateSiteContext()
			=> Umbraco.CreateSiteContext();
	}
}