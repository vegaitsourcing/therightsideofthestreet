using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using Umbraco.Web.Mvc;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class BasePageController<T> : RenderMvcController where T : class, IPage
    {
        public IPageContext<T> CreatePageContext(T page) => Umbraco.CreatePageContext(page);
    }
}