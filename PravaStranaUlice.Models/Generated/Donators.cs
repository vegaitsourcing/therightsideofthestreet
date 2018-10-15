using PravaStranaUlice.Models.DocumentTypes.Nodes.Items.NestedContent;
using PravaStranaUlice.Models.Extensions;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;


namespace PravaStranaUlice.Models
{
	public partial class Donators : INestedContent
	{
		[ImplementPropertyType("image")]
		public Image Image => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();
	}
}
