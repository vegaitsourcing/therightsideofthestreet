using System;
using System.Web;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials
{
	public class CrewViewModel
	{
		public CrewViewModel(Crew content)
		{
			CrewName = content.CrewName;
			Logo = content.Logo.AsViewModel();
			Image = content.Image.AsViewModel();
			Text = content.Text;
			Key = content.GetKey();
		}

		public string CrewName { get; }
		public ImageViewModel Logo { get; }
		public ImageViewModel Image { get; }
		public IHtmlString Text { get; }
		public Guid Key { get; }
	}
}
