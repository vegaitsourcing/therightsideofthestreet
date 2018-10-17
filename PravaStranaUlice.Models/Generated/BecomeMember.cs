using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace PravaStranaUlice.Models
{
    public partial class BecomeMember
    {
        [ImplementPropertyType("membershipLevels")]
        public IEnumerable<MembershipStatus> MembershipLevels => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<MembershipStatus>();
    }
}
