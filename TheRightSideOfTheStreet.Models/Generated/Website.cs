using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;

namespace TheRightSideOfTheStreet.Models
{
	public partial class Website : IHomePage, IDomainRoot, IRootNode
    {
		[ImplementPropertyType("logo")]
		public Image Logo => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

        [ImplementPropertyType("infoImage")]
        public Image InfoImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

        [ImplementPropertyType("socialLinks")]
		public IEnumerable<SocialLink> SocialLinks => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<SocialLink>();

		[ImplementPropertyType("partnerItems")]
		public IEnumerable<Partners> PartnerItems => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<Partners>();

		[ImplementPropertyType("modules")]
		public IEnumerable<IModuleNestedContent> Modules => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<IModuleNestedContent>();

	}
}
