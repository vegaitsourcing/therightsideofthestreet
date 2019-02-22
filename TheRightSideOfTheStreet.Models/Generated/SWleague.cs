using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class SWleague
	{
		[ImplementPropertyType("competitors")]
		public IEnumerable<RankingTable> Competitors => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<RankingTable>();

		[ImplementPropertyType("tableBackgroundImage")]
		public Image TableBackgroundImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();
	}
}
