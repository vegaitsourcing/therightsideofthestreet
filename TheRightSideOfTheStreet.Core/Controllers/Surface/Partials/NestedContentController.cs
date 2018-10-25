using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Partials
{
	public class NestedContentController : BasePartialController
	{
		public ActionResult Index(INestedContentViewModel nestedContentViewModel)
		{
			string partialView = nestedContentViewModel.GetType().Name.RemoveViewModelSuffix();

			return PartialView(partialView, nestedContentViewModel);
		}
	}
}
