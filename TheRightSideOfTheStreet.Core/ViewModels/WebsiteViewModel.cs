using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class WebsiteViewModel : PageViewModel
    {
        public WebsiteViewModel(IPageContext<IPage> context) : base(context)
        {
        }
    }
}