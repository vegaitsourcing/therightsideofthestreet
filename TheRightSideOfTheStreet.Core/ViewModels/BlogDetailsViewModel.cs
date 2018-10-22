using System;
using System.Web;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class BlogDetailsViewModel : PageViewModel
	{
		public BlogDetailsViewModel(IBlogPageContext<BlogDetails> context) : base(context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			Image = context.Page.Image.AsViewModel();
			Description = context.Page.Text;
			Date = context.Page.Date;
			BlogLanding = context.Landing.Url;
			Prevoius = context.Previous?.Url;
			Next = context.Next?.Url;

		}

		public ImageViewModel Image { get; }
		public IHtmlString Description { get; }
		public DateTime Date { get; }
		public string BlogLanding { get; }
		public string Prevoius { get; }
		public string Next { get; }

	}
}
