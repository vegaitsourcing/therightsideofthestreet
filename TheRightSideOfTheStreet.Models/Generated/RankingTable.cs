using System.Linq;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class RankingTable :INestedContent
	{
		[ImplementPropertyType("athleteImage")]
		public Image AthleteImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("crewLogo")]
		public Image CrewLogo => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();
	}
}
