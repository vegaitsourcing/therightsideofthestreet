using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Core;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Partials
{
	public class ListingController : BasePartialController
	{
		public ActionResult Donators(Guid pageKey, int page)
		{
			if (page < 1) throw new ArgumentOutOfRangeException(nameof(page));

			DonationsContent donatorsContent = Umbraco.TypedContent(pageKey)?.OfType<DonationsContent>();
			if (donatorsContent == null) return new EmptyResult();

			IList<Donators> donators = donatorsContent.Donators.AsList();

			if (!donators.Any()) return new EmptyResult();

			int itemsPerGroup = 6;

			int itemsPerPage = donatorsContent.DonatorsItemsPerPage;

			int totalPages = (int)Math.Ceiling((double)donators.Count / itemsPerPage);

			ISiteContext siteContext = CreateSiteContext();

			return PartialView(
				new ListingViewModel<IEnumerable<DonatorsViewModel>>(
					donators.Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
							.Select(d => siteContext.WithNestedContent(d).AsViewModel<DonatorsViewModel>())
							.InGroupsOf(itemsPerGroup)
							.ToList(),
					page,
					totalPages));
		}

		public ActionResult ExerciseGroups(Guid pageKey, int page, Guid? categoryKey)
		{
			ExerciseLevel level = Umbraco.TypedContent(pageKey)?.OfType<ExerciseLevel>();
			if (level == null) return new EmptyResult();

			IList<ExerciseGroupPreviewViewModel> exerciseGroups = new List<ExerciseGroupPreviewViewModel>();

			if (categoryKey != null)
			{
				exerciseGroups = level.Children<ExerciseGroup>().Where(ec => ec.ExerciseCategory?.GetKey() == categoryKey).AsViewModel<ExerciseGroupPreviewViewModel>().AsList();
			}
			else
			{
				exerciseGroups = level.Children.AsViewModel<ExerciseGroupPreviewViewModel>().AsList();
			}

			if (!exerciseGroups.Any()) return new EmptyResult();

			if (page < 1) throw new ArgumentOutOfRangeException(nameof(page));

			int itemsPerPage = 3;

			int totalPages = (int)Math.Ceiling((double)exerciseGroups.Count / itemsPerPage);

			ISiteContext siteContext = CreateSiteContext();

			return PartialView(
				new ListingViewModel<ExerciseGroupPreviewViewModel>(
					exerciseGroups.Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
							.ToList(),
					page,
					totalPages));
		}
	}
}