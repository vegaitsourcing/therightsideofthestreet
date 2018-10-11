using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace PravaStranaUlice.Models
{
	public partial class Website : IHomePage, IDomainRoot, IRootNode
    {
		[ImplementPropertyType("logo")]
		public Image Logo => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("socialLinks")]
		public IEnumerable<SocialLink> SocialLinks => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<SocialLink>();
    }
}
