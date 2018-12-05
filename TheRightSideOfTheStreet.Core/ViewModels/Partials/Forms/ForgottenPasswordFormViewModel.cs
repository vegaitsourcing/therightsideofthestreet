using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class ForgottenPasswordFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		[UmbracoDisplayName("BecomeMember.Email")]
		public string Email { get; set; }
	}
}
