using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class CommentViewModel
	{

		public CommentViewModel(Comment comment)
		{
			MemberImage = comment.Member?.ProfileImage.AsViewModel();
			MemberName = comment.Member?.FullName;
			Comments = comment.Comments;
		}

		public ImageViewModel MemberImage { get; set; }
		public string MemberName { get; set; }
		public string Comments { get; set; }
	}


}

