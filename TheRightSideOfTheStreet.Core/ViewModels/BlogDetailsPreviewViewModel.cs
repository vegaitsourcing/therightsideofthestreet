using System;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class BlogDetailsPreviewViewModel
	{
		public BlogDetailsPreviewViewModel(BlogDetails blogDetails)
		{
			Title = blogDetails.Title;
			PreviewImage = blogDetails.PreviewImage.AsViewModel();
			PreviewText = blogDetails.PreviewText;
			Date = blogDetails.Date;
			Url = blogDetails.Url;

		}		
		public ImageViewModel PreviewImage { get; }
		public string PreviewText { get; }
		public DateTime Date { get; }
		public string Title { get; }
		public string Url { get; }
				
	}
}
