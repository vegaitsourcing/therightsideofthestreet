using PravaStranaUlice.Models.DocumentTypes;

namespace PravaStranaUlice.Web.ViewModels.Shared
{
	public class LanguageLinkViewModel : LinkViewModel
	{
		public LanguageLinkViewModel(IPage page, string language) : base(page.Url, language)
		{
		}
	}
}