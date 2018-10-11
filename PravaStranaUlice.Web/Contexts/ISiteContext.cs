using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using System.Collections.Generic;

namespace PravaStranaUlice.Web.Contexts
{
    public interface ISiteContext
    {
        IPage CurrentPage { get; }
        Website Home { get; }
        Settings Settings { get; }
        Repository Repository { get; }
		IEnumerable<Website> Languages { get; }
    }
}
