using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using TheRightSideOfTheStreet.Models.MemberTypes;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class AthleteMember : IAthleteMember
	{
		[ImplementPropertyType("profileImage")]
		public Image ProfileImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("images")]
		public IEnumerable<Image> Images => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<Image>();

		[ImplementPropertyType("status")]
		public MembershipStatus Status => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.FirstOrDefault()?.OfType<MembershipStatus>();

		[ImplementPropertyType("crew")]
		public Crew Crew => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.FirstOrDefault()?.OfType<Crew>();

		[ImplementPropertyType("previewImage")]
		public Image PreviewImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();
		
	}
}
