using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class Location : INestedContent
	{
		[ImplementPropertyType("parkLocation")]
		public IEnumerable<ParkLocation> ParkLocation => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<ParkLocation>();
	}
}
