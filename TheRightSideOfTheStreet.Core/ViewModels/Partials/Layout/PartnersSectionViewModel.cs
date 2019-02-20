using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout
{
	public class PartnersSectionViewModel
	{
		public PartnersSectionViewModel(IPageContext<IPage> context)
		{
			SectionTitle = context.Home.SectionTitle;
			PartnerItems = context.Home.PartnerItems?.Select(sl => context.WithNestedContent(sl).AsViewModel<PartnersViewModel>()).AsList();

		}
		public string SectionTitle { get; }
		public IList<PartnersViewModel> PartnerItems { get; }
	}
}
