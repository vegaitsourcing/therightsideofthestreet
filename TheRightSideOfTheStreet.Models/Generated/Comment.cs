using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial  class Comment
	{
		[ImplementPropertyType("member")]
		public AthleteMember Member => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.FirstOrDefault()?.OfType<AthleteMember>();
	}
}
