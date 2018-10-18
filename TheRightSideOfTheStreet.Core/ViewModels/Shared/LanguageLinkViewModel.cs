using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Shared
{
	public class LanguageLinkViewModel : LinkViewModel
	{
		public LanguageLinkViewModel(IPage page, string language) : base(page.Url, language)
		{
		}
	}
}