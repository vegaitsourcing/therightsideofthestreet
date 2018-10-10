using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.Extensions;

namespace PravaStranaUlice.Web.Controllers.Surface.Partials
{
    public class BasePartialController : BaseSurfaceController
    {
        public ISiteContext CreateSiteContext()
            => Umbraco.CreateSiteContext();
    }
}