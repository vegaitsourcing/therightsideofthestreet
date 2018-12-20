using System.ComponentModel.DataAnnotations;
using System.Web;
using TheRightSideOfTheStreet.Core.Validations;
using TheRightSideOfTheStreet.Models.Extensions;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class BecomeMemberFormViewModel
	{
		
		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Name { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Surname { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Dob { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Nationality { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Address { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string MblNumber { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		[UmbracoDisplayName("BecomeMember.Email")]
		public string Email { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[ImageExtensions(ErrorMessageDictionaryKey = "UmbracoValidation.ImageExtension")]
		[FileSize(1.5,"UmbracoValidation.ImageMaxSize")]
		public HttpPostedFileBase Picture { get; set; }

		public string Status { get; set; }
	}
}
