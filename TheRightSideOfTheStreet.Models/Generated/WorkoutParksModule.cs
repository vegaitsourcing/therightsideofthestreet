using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class WorkoutParksModule : IModuleNestedContent
	{
		[ImplementPropertyType("locations")]
		public IEnumerable<Location> Locations => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<Location>();
	}
}
