using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class Crew 
	{
		[ImplementPropertyType("logo")]
		public Image Logo => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("images")]
		public IEnumerable<Image> Images => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<Image>();
	}
}
