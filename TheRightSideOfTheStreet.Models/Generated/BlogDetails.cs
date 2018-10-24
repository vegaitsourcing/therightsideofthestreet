using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.Extensions;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
    public partial class BlogDetails : Page, IBlogPage
    {
        [ImplementPropertyType("image")]
        public Image Image => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("previewImage")]
		public Image PreviewImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

	}
}
