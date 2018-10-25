using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class BecomeMemberViewModel : PageViewModel
	{
		public BecomeMemberViewModel(IPageContext<BecomeMember> context) : base(context)
		{
			IntroText = context.Page.IntroText;
			MembershipLevels = context.Page.MembershipLevels.Where(ml => ml != null && ml.Image != null).AsViewModel<MembershipStatusViewModel>().AsList();
		}

		public string IntroText { get; }
		public IList<MembershipStatusViewModel> MembershipLevels { get; }

		public BecomeMemberFormViewModel BecomeMemberForm { get; }
	}
}