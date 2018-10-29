using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class BlogsModuleViewModel : IModulesNestedContentViewModel
	{
		public BlogsModuleViewModel(INestedContentContext<BlogsModule> context)
		{
			Title = context.NestedContent.Title;
			Items = context.NestedContent.Items.AsViewModel<BlogDetailsPreviewViewModel>().ToList();
		}

		public string Title { get; }
		public IList<BlogDetailsPreviewViewModel> Items { get; }
	}
}
