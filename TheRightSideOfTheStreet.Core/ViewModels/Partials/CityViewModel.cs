using System;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials
{
	public class CityViewModel
	{
		public CityViewModel(City content)
		{
			CityName = content.Name;
			Country = content.Parent.Name;
			Key = content.GetKey();
		}

		public string CityName { get; set; }
		public string Country { get; }
		public Guid Key { get; }
	}
}
