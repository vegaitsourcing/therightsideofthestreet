using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.Extensions;
using PravaStranaUlice.Web.ViewModels.Partials;
using System.Collections.Generic;
using System.Linq;

namespace PravaStranaUlice.Web.ViewModels
{
    public class BecomeMemberViewModel : PageViewModel
    {
        public BecomeMemberViewModel(IPageContext<BecomeMember> context) : base(context)
        {
            IntroText = context.Page.IntroText;
            MembershipLevels = context.Page.MembershipLevels.Where(ml => ml.Image != null).AsViewModel<MembershipStatusViewModel>().AsList();
        }

        public string IntroText { get; }
        public IList<MembershipStatusViewModel> MembershipLevels { get; }
    }
}