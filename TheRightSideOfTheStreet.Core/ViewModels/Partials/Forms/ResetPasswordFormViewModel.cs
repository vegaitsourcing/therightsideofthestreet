using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class ResetPasswordFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		[UmbracoDisplayName("BecomeMember.Email")]
		public string Email { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string NewPassword { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string ConfirmNewPassword { get; set; }
	}
}
