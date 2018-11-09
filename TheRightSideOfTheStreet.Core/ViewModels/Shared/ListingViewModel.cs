using System.Collections.Generic;

namespace TheRightSideOfTheStreet.Core.ViewModels.Shared
{
	public class ListingViewModel<T> where T : class
	{
		public ListingViewModel(IList<T> items, int currentPage, int totalPages)
		{
			Items = items;
			CurrentPage = currentPage;
			TotalPages = totalPages;
		}

		public IList<T> Items { get; }
		public int CurrentPage { get; }
		public int TotalPages { get; }
	}
}