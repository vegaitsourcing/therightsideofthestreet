using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class BlogLandingViewModel : PageViewModel
	{

		public BlogLandingViewModel(IPageContext<BlogLanding> context) : base(context)
		{
			Blogs = context.Page.Descendants<BlogDetails>().OrderByDescending(b => b.Date).AsViewModel<BlogDetailsPreviewViewModel>().ToList();
		
		}
		public IEnumerable<BlogDetailsPreviewViewModel> Blogs { get; }
		

	}
}
