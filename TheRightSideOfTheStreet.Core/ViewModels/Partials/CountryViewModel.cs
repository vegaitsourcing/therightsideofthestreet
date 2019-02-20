using System;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials
{
	public class CountryViewModel
	{
		public CountryViewModel(Country content)
		{
			CountryName = content.Name;
			Key = content.GetKey();
		}

		public string CountryName { get; }
		public Guid Key { get; }
	}
}
