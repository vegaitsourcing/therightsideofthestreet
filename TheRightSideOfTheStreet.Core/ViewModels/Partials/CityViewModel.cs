using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials
{
	public class CityViewModel
	{
		public CityViewModel(City content)
		{
			CityName = content.CityName;
			Country = content.Parent.Name;
		}

		public string CityName { get; set; }
		public string Country { get; }
	}
}
