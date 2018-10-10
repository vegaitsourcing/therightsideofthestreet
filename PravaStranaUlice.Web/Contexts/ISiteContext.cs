using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;

namespace PravaStranaUlice.Web.Contexts
{
    public interface ISiteContext
    {
        IPage CurrentPage { get; }
        Website Home { get; }
        Settings Settings { get; }
        Repository Repository { get; }
    }
}
