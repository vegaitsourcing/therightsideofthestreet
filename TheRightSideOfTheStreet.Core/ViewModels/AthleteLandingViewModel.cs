using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.Search;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class AthleteLandingViewModel : PageViewModel
	{

		public AthleteLandingViewModel(IPageContext<AthleteLanding> context) : base(context)
		{
			AthleteMembers = new AthleteMembersSearch().GetAthletes().Select(am => new AthleteMemberPreviewViewModel(context.WithAthleteMember(am))).AsList();
		}

		public IList<AthleteMemberPreviewViewModel> AthleteMembers { get; }
	}
}


