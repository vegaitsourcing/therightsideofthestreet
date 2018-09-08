using PravaStranaUlice.Models.Extensions;
using Umbraco.Core.Models.PublishedContent;

namespace PravaStranaUlice.Models
{
	public partial class DonationsAndMembership : PublishedContentModel, IPage
	{
		public string EmbedVideo 
		{
			get { return this.GetPropertyValue<string>("video").Replace("watch?v=","embed/"); }
		}
	}
}
