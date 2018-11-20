using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.Search;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class AthleteLandingViewModel : PageViewModel
	{

		public AthleteLandingViewModel(IPageContext<AthleteLanding> context, string query) : base(context)
		{
			AthleteMembers = GetAthletes(context, query);
			RegisterForm = context.AthleteForm.Url;
		}
		
		public IList<AthleteMemberPreviewViewModel> AthleteMembers { get; set; }

		private IList<AthleteMemberPreviewViewModel> GetAthletes(IPageContext<AthleteLanding> context, string query)
		{
			var searcher = new AthleteMembersSearch();
			if (string.IsNullOrWhiteSpace(query))
			{
				return searcher.GetAthletes().Select(am => new AthleteMemberPreviewViewModel(context.WithAthleteMember(am))).AsList();
			}

			return searcher.GetAthletes(query).Select(am => new AthleteMemberPreviewViewModel(context.WithAthleteMember(am))).AsList();
		}

		public string RegisterForm { get; set; }
	}
}


