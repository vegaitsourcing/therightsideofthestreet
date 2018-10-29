using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

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
		}

		public string CrewName { get; }
		public ImageViewModel Logo { get; }
		public ImageViewModel Image { get; }
		public IHtmlString Text { get; }

	}
}
