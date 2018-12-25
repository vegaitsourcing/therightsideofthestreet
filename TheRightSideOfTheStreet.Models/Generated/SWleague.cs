using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;

namespace TheRightSideOfTheStreet.Models
{
	public partial class SWleague
	{
		[ImplementPropertyType("competitors")]
		public IEnumerable<RankingTable> Competitors => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<RankingTable>();
	}
}
