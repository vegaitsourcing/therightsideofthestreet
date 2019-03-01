using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using TheRightSideOfTheStreet.Models.MemberTypes;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial  class Comment
	{
		[ImplementPropertyType("member")]
		public IAthleteMember Member => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.FirstOrDefault()?.OfType<IAthleteMember>();
	}
}
