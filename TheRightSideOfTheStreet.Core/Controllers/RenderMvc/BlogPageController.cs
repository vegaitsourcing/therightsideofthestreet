using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class BlogPageController<T> : BasePageController<T> where T: class, IBlogPage
    {
        public IBlogPageContext<T> CreateBlogPageContext(T page) => Umbraco.CreateBlogPageContext(page);
    }
}