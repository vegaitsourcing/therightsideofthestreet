using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class NewsletterFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 50)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		public string EmailAddress { get; set; }
	}
}
