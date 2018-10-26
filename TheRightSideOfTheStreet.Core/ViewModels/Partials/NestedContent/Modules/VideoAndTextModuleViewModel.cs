using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class VideoAndTextModuleViewModel : IModulesNestedContentViewModel
	{
		public VideoAndTextModuleViewModel(INestedContentContext<VideoAndTextModule> context)
		{
			Title = context.NestedContent.Title;
			Text = context.NestedContent.Text;
			VideoUrl = context.NestedContent.VideoUrl;
			IsVideoRight = context.NestedContent.IsVideoRight;
			Buttons = context.NestedContent.Buttons.Select(b => b.AsViewModel()).AsList();

		}

		public string Title { get; }
		public IHtmlString Text { get; }
		public string VideoUrl { get; }
		public bool IsVideoRight { get; }
		public IList<LinkViewModel> Buttons {get;}
	}
}
