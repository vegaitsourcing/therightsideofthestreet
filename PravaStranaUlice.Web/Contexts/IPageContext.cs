using PravaStranaUlice.Models.DocumentTypes;

namespace PravaStranaUlice.Web.Contexts
{
    public interface IPageContext<out T> : ISiteContext where T : class, IPage
    {
        T Page { get; }
    }
}
