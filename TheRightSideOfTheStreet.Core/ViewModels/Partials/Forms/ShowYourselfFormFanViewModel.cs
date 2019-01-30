using System.Web;
using TheRightSideOfTheStreet.Core.Validations;
using UmbracoValidationAttributes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class ShowYourselfFormFanViewModel
	{

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Name { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Surname { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[ImageExtensions(ErrorMessageDictionaryKey = "UmbracoValidation.ImageExtension")]
		[FileSize(2, "UmbracoValidation.ImageMaxSize")]
		public HttpPostedFileBase ProfilePicture { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		[UmbracoDisplayName("BecomeMember.Email")]
		public string Email { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoRegularExpression("UmbracoValidation.PasswordFormat", Constants.Constants.PaswordRegex)]
		public string Password { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoCompare("UmbracoValidation.PasswordMatch", "Password")]
		public string ConfirmPassword { get; set; }


	}
}
