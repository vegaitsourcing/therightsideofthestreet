using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PravaStranaUlice.Web.ViewModels.Shared
{
	public class ListingViewModel<T> where T: class
	{
		public ListingViewModel(IReadOnlyList<T> items, int currentPage, int totalPages)
		{
			Items = items;
			CurrentPage = currentPage;
			TotalPages = totalPages;
		}

		public IReadOnlyList<T> Items { get; }
		public int CurrentPage { get; }
		public int TotalPages { get; }
	}
}