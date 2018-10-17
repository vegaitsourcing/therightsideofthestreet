using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Models;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.Extensions;
using PravaStranaUlice.Web.ViewModels.Partials.NestedContent;
using PravaStranaUlice.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;

namespace PravaStranaUlice.Web.Controllers.Surface.Partials
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