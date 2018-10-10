using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.Extensions;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
    public class BasePageController<T> : RenderMvcController where T : class, IPage
    {
        public IPageContext<T> CreatePageContext(T page) => Umbraco.CreatePageContext(page);
    }
}