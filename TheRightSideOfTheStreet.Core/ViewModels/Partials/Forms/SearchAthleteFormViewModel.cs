using System.Collections.Generic;
using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class SearchAthleteFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		public string SearchQuery { get; set; }

	}
}
