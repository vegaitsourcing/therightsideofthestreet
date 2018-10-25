using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class TextAndImageModuleViewModel : IModulesNestedContentViewModel
	{
		public TextAndImageModuleViewModel(INestedContentContext<TextAndImageModule> context)
		{
			Title = context.NestedContent.Title;
			Text = context.NestedContent.Text;
			Link = context.NestedContent.Link.AsViewModel();
			Image = context.NestedContent.Image.AsViewModel();
			IsImageLeft = context.NestedContent.IsImageLeft;
		}

		public string Title { get; }
		public IHtmlString Text { get; }
		public LinkViewModel Link { get; }
		public ImageViewModel Image { get; }
		public bool IsImageLeft { get; }
	}
}
