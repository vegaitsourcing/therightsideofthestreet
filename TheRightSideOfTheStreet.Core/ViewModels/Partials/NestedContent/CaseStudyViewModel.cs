using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class CaseStudyViewModel : INestedContentViewModel
	{
		public CaseStudyViewModel(INestedContentContext<CaseStudy> context)
		{
			Title = context.NestedContent.Title;
			Text = context.NestedContent.Text;
			Image = context.NestedContent.Image.AsViewModel();
		}

		public string Title { get; }
		public string Text { get; }
		public ImageViewModel Image { get; }
	}
}
