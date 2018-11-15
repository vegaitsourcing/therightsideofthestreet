using System;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials
{
	public class MembershipStatusViewModel
	{
		public MembershipStatusViewModel(MembershipStatus content)
		{

			Icon = content.Icon;
			Status = content.Status;


			Details = new UmbracoHelper(UmbracoContext.Current).GetDictionaryValue(content.Details).Split('\n');
			Image = content.Image.AsViewModel();
			Key = content.GetKey();
		}


		public string Icon { get; }
		public string Status { get; }
		public string[] Details { get; }
		public ImageViewModel Image { get; }
		public Guid Key { get; }
	}
}