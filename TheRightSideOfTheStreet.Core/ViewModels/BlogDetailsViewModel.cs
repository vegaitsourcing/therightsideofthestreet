using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class BlogDetailsViewModel : PageViewModel
	{
		public BlogDetailsViewModel(IBlogPageContext<BlogDetails> context) : base(context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			Image = context.Page.Image.AsViewModel();
			Text = context.Page.Text;
			Date = context.Page.Date;
			BlogLanding = context.Landing.Url;
			Prevoius = context.Previous?.Url;
			Next = context.Next?.Url;
			Comment = context.Page.Children.AsViewModel<CommentViewModel>().ToList();
			LoginUrl = context.LoginForm.Url;
			
		}

		public ImageViewModel Image { get; }
		public IHtmlString Text { get; }
		public DateTime Date { get; }
		public string BlogLanding { get; }
		public string Prevoius { get; }
		public string Next { get; }
		public IList<CommentViewModel> Comment { get; set; }
		public string LoginUrl { get; }
		
	}
}
