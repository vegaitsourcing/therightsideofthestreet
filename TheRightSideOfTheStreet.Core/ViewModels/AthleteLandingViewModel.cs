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
			Admin = GetAdmin(context, query);
			Query = query;
		}
		
		public IList<AthleteMemberPreviewViewModel> AthleteMembers { get; set; }
		public IList<AdminPreviewViewModel> Admin { get; set; }

		public string RegisterForm { get; set; }
		public string Query { get; }

		private static IList<AthleteMemberPreviewViewModel> GetAthletes(IPageContext<AthleteLanding> context, string query)
		{
			var searcher = new AthleteMembersSearch();
			if (string.IsNullOrWhiteSpace(query))
			{
				return searcher.GetAthletes().Select(am => new AthleteMemberPreviewViewModel(context.WithAthleteMember(am))).AsList();
			}

			return searcher.GetAthletes(query).Select(am => new AthleteMemberPreviewViewModel(context.WithAthleteMember(am))).AsList();
		}

		private static IList<AdminPreviewViewModel> GetAdmin(IPageContext<AthleteLanding> context, string query)
		{
			var searcher = new AthleteMembersSearch();

			if (string.IsNullOrWhiteSpace(query))
			{
				return searcher.GetAdmin().Select(a => new AdminPreviewViewModel(context.WithAthleteMember(a))).AsList();
			}

			return searcher.GetAdmins(query).Select(a => new AdminPreviewViewModel(context.WithAthleteMember(a))).AsList();
		}
	}
}


