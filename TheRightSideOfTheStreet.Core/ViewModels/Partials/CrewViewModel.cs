using System;
using System.Collections.Generic;
using System.Linq;
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
			Images = content.Images.AsViewModel<ImageViewModel>().ToList();
			Text = content.Text;
			Key = content.GetKey();
			ParentKey = content.Parent.GetKey();
		}

		public string CrewName { get; }
		public ImageViewModel Logo { get; }
		public IList<ImageViewModel> Images { get; }
		public IHtmlString Text { get; }
		public Guid Key { get; }
		public Guid ParentKey { get; }
	}
}
