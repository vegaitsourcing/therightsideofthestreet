using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class FoundersModuleViewModel : IModulesNestedContentViewModel
	{
		public FoundersModuleViewModel(INestedContentContext<FoundersModule> context)
		{
			Title = context.NestedContent.Title;
			Founders = context.NestedContent.Founders?.Select(fo => context.WithNestedContent(fo).AsViewModel<FoundersViewModel>()).ToList();
			InnerTitle = context.NestedContent.InnerTitle;
			InnerText = context.NestedContent.InnerText;
		}

		public string Title { get; }
		public IList<FoundersViewModel> Founders { get; }
		public string InnerTitle { get; }
		public IHtmlString InnerText { get; }
	}
}
