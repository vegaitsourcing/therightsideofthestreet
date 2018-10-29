using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;

namespace TheRightSideOfTheStreet.Models
{
	public partial class AthleteModule : PublishedContentModel, IModuleNestedContent
	{
		[ImplementPropertyType("athlete")]
		public IEnumerable<AthleteMember> Athlete => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.Where(am => am != null).OfType<AthleteMember>().Where(am => am.UmbracoMemberApproved);
	}
}