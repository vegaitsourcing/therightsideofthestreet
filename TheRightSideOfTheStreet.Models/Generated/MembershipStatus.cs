using TheRightSideOfTheStreet.Models.Extensions;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;


namespace TheRightSideOfTheStreet.Models
{
    public partial class MembershipStatus : PublishedContentModel
    {
        [ImplementPropertyType("icon")]
        public Image Icon => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

        [ImplementPropertyType("image")]
        public Image Image => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

    }
}
