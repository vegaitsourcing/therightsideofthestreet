using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using System.Linq;
using Umbraco.Web;

namespace PravaStranaUlice.Web.Contexts
{
    public class BlogPageContext<T> : PageContext<T>, IBlogPageContext<T> where T : class, IBlogPage
    {
        public BlogPageContext(T page, UmbracoHelper umbracoHelper) : base(page, umbracoHelper)
        {
            Landing = page.Ancestor(BlogLanding.ModelTypeAlias)?.OfType<BlogLanding>();
            Previous = GetPrevious();
            Next = GetNext();
            
        }

        public BlogLanding Landing { get; }

        public IBlogPage Previous { get; }

        public IBlogPage Next { get; }

        

        //todo refactor this
        private IBlogPage GetPrevious()
        {
            if (Landing == null) return default(IBlogPage);

            string xpath = $"//{Landing.DocumentTypeAlias} [@isDoc and @id='{Landing.Id}']//{PravaStranaUlice.Models.BlogDetails.ModelTypeAlias}";
            var items = UmbracoHelper.TypedContentAtXPath(xpath).OfType<BlogDetails>().OrderBy(bd => bd.Date);

            return items.FirstOrDefault(bd => bd.Date > Page.Date);
        }

        private IBlogPage GetNext()
        {
            if (Landing == null) return default(IBlogPage);

            string xpath = $"//{Landing.DocumentTypeAlias} [@isDoc and @id='{Landing.Id}']//{PravaStranaUlice.Models.BlogDetails.ModelTypeAlias}";
            var items = UmbracoHelper.TypedContentAtXPath(xpath).OfType<BlogDetails>().OrderByDescending(bd => bd.Date);

            return items.FirstOrDefault(bd => bd.Date < Page.Date);
        }
    }
}