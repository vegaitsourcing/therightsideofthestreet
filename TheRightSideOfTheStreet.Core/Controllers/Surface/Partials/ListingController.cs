using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
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

			int itemsPerPage = donatorsContent.DonatorsItemsPerPage;

			int totalPages = (int)Math.Ceiling((double)donators.Count / itemsPerPage);

			ISiteContext siteContext = CreateSiteContext();

			return PartialView(
				new ListingViewModel<DonatorsViewModel>(
					donators.Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
							.Select(d => siteContext.WithNestedContent(d).AsViewModel<DonatorsViewModel>())
							.ToList(), 
					page, 
					totalPages));
		}
	}
}