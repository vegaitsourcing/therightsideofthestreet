using System.Collections.Generic;
using System.Linq;
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
			Boxes = context.NestedContent.Boxes.AsViewModel<BlogDetailsPreviewViewModel>().ToList();
		}

		public string Title { get; }
		public IList<BlogDetailsPreviewViewModel> Boxes { get; }
	}
}
