using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class CaseStudiesModuleViewModel : IModulesNestedContentViewModel
	{
		public CaseStudiesModuleViewModel(INestedContentContext<CaseStudiesModule> context)
		{
			Title = context.NestedContent.Title;
			Boxes = context.NestedContent.Boxes?.Select(fo => context.WithNestedContent(fo).AsViewModel<CaseStudyViewModel>()).ToList();
		}

		public string Title { get; }
		public IList<CaseStudyViewModel> Boxes { get; }
	}
}
