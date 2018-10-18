using System.Collections.Generic;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.Extensions;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout
{
	public class PrimaryNavigationItemViewModel
	{
		public PrimaryNavigationItemViewModel(IPage page)
		{
			Title = page.Title;
			Url = page.Url;
			IsActive = page.IsActive();
			Level = page.Level;
			Children = page.GetNavigationItems<IPage>().AsNavigationViewModel().AsList();
		}

		public string Title { get; }
		public string Url { get; }
		public bool IsActive { get; }
		public int Level { get; }
		public IList<PrimaryNavigationItemViewModel> Children { get; }
	}
}