using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class Partners :INestedContent
	{
		[ImplementPropertyType("partnersLogo")]
		public Image PartnersLogo => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();
	}
}
