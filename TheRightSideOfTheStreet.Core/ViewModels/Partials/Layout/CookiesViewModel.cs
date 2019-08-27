using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout
{
	public class CookiesViewModel
	{
		public CookiesViewModel(IPageContext<IPage> context)
		{
			Title = context.Settings.CookiesTitle;
			Text = context.Settings.CookiesText;
		}

		public string Title { get; }
		public string Text { get; }
	}
}
