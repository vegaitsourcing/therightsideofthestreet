using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.Extensions;
using Umbraco.Web.Mvc;

namespace PravaStranaUlice.Web.Controllers.RenderMvc
{
    public class BlogPageController<T> : BasePageController<T> where T: class, IBlogPage
    {
        public IBlogPageContext<T> CreateBlogPageContext(T page) => Umbraco.CreateBlogPageContext(page);
    }
}