using System.Globalization;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Partials
{
	public class NestedContentController : BasePartialController
	{
		public ActionResult Index(INestedContentViewModel nestedContentViewModel)
		{
			string partialView = nestedContentViewModel.GetType().Name.RemoveViewModelSuffix();

			if (partialView.Equals(nameof(WorkoutParksModule)) && CultureInfo.CurrentCulture.TwoLetterISOLanguageName.Equals("sr"))
			{
				CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
			}
			return PartialView(partialView, nestedContentViewModel);
		}

		public ActionResult BlogEntry(BlogDetailsViewModel blogEntry)
		{
			return PartialView(blogEntry);
		}
	}
}