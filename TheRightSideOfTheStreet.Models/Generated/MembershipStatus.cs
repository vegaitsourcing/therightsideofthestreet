using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class MembershipStatus : PublishedContentModel
	{
		[ImplementPropertyType("image")]
        public Image Image => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

    }
}
