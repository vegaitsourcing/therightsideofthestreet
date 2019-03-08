using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class FoundersViewModel: INestedContentViewModel
	{
		public FoundersViewModel(INestedContentContext<Founders> context)
		{
			Title = context.NestedContent.Title;
			Text = context.NestedContent.Text;
			Image = context.NestedContent.Image.AsViewModel();
			IsImageLeft = context.NestedContent.IsImageLeft;
		}

		public string Title { get; }
		public string Text { get; }
		public ImageViewModel Image { get; }
		public bool IsImageLeft { get; }
	}
}
