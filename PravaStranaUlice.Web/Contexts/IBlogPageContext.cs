using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;

namespace PravaStranaUlice.Web.Contexts
{
    public interface IBlogPageContext<out T> : IPageContext<T> where T : class, IBlogPage
    {
        BlogLanding Landing { get; }
        IBlogPage Previous { get;}
        IBlogPage Next { get; }
        

    }
}