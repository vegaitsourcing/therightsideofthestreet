using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class DonationsContent
	{
		[ImplementPropertyType("image")]
		public Image Image => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("donators")]
		public IEnumerable<Donators> Donators => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<Donators>();

		[ImplementPropertyType("donatorsItemsPerPage")]
		public int DonatorsItemsPerPage => this.GetPropertyWithDefaultValue(AppSettings.DonatorsPerPage);
	}
}
