using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.Search;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class AthleteModuleViewModel : IModulesNestedContentViewModel
	{
		public AthleteModuleViewModel(INestedContentContext<AthleteModule> context)
		{
			Title = context.NestedContent.Title;
			Athletes = new AthleteMembersSearch().GetAthletes().Select(am => new AthleteMemberPreviewViewModel(context.WithAthleteMember(am))).Where( m => m.PreviewImage != null).AsList();
			Admins = new AthleteMembersSearch().GetAdmin().Select(adm => new AdminPreviewViewModel(context.WithAthleteMember(adm))).Where(m => m.PreviewImage != null).AsList();
		}

		public string Title { get; }
		public IList<AthleteMemberPreviewViewModel> Athletes { get; }
		public IList<AdminPreviewViewModel> Admins { get; }
		
	}
}
