using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class CrewsModuleViewModel : IModulesNestedContentViewModel
	{
		public CrewsModuleViewModel(INestedContentContext<CrewsModule> context)
		{
			Crews = context.Crews.AsViewModel<CrewViewModel>().ToList();
			Cities = helper.TypedContentAtXPath($"//{City.ModelTypeAlias}")?.OfType<City>().AsViewModel<CityViewModel>().Where(m => HasCrew(m.Key)).ToList();
			Countries = Cities.Select(x => x.Country).Distinct().ToList();
			Title = context.NestedContent.Title;
			Text = context.NestedContent.Text;
			CityKeys = Crews.Where(m => m.ParentKey != Guid.Empty).Select(m => m.ParentKey).Distinct().ToList();
		}

		public string Title { get; }
		public IHtmlString Text { get; }
		public IList<CityViewModel> Cities { get; }
		public IList<string> Countries { get; }
		public IList<CrewViewModel> Crews { get; }
		public IReadOnlyList<Guid> CityKeys { get; set; }

		public IReadOnlyList<CrewViewModel> GetCrewByParentKey(Guid parentKey)
		{
			return Crews.Where(m => m.ParentKey != Guid.Empty && Equals(m.ParentKey, parentKey)).ToList();
		}

		private bool HasCrew(Guid cityKey)
		{
			bool hasCrew = false;
			foreach(CrewViewModel crew in Crews)
			{
				if(crew.ParentKey == cityKey)
				{
					hasCrew = true;
				}
			}
			return hasCrew;
		}

		private UmbracoHelper helper = new UmbracoHelper(UmbracoContext.Current);
	}
}
