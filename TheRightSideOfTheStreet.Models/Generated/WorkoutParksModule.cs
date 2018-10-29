using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class WorkoutParksModule : PublishedContentModel, IModuleNestedContent
	{
		[ImplementPropertyType("locations")]
		public IEnumerable<Location> Locations => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<Location>();
	}
}
