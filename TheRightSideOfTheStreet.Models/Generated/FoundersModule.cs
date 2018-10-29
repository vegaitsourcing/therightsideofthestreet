using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;

namespace TheRightSideOfTheStreet.Models
{
	public partial class FoundersModule : PublishedContentModel, IModuleNestedContent
	{
		[ImplementPropertyType("founders")]
		public IEnumerable<Founders> Founders => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<Founders>();
	}
}
