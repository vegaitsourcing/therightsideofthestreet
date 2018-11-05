using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class BecomeMember
    {
        [ImplementPropertyType("membershipLevels")]
        public IEnumerable<MembershipStatus> MembershipLevels => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<MembershipStatus>();
    }
}
