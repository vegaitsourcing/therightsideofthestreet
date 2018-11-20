using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class LoginFormViewModel
	{
		
		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		[UmbracoDisplayName("BecomeMember.Email")]
		public string Email { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Password { get; set; }

		public string ResetPasswordUrl { get; set; }
		public string RegisterFormUrl { get; set; }
	}
}
