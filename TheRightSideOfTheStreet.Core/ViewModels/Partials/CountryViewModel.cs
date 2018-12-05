using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials
{
	public class CountryViewModel
	{
		public CountryViewModel(Country content)
		{
			CountryName = content.Name;
		}

		public string CountryName { get; }
	}
}
