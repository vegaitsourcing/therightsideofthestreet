using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;
using PravaStranaUlice.Web.Extensions;
using System.Collections.Generic;

namespace PravaStranaUlice.Web.ViewModels.Partials.Layout
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