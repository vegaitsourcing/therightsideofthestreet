using System.ComponentModel.DataAnnotations;
using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class WorkoutParksFormViewModel
	{
		[Url]
		[UmbracoRequired("UmbracoValidation.Required")]
		public string Url { get; set; }
	}
}
