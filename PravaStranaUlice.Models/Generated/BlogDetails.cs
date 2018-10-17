using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace PravaStranaUlice.Models
{
    public partial class BlogDetails : Page, IBlogPage
    {
        [ImplementPropertyType("image")]
        public Image Image => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

    }
}
