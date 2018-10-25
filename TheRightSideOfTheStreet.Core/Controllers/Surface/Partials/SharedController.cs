using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Partials
{
	public class SharedController: BasePartialController
	{
		[ChildActionOnly]
		public ActionResult Banner(BannerViewModel viewModel)
		{
			return PartialView(viewModel);
		}
	}
}
