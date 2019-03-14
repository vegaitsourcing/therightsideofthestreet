using System.ComponentModel.DataAnnotations;
using TheRightSideOfTheStreet.Core.Validations;
using UmbracoValidationAttributes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class WorkoutParksFormViewModel
	{
		[UmbracoDataType(DataType.Url, "WorkoutParks.ErrorMessage")]
		[UmbracoRequired("UmbracoValidation.Required")]
		public string Url { get; set; }
	}
}
