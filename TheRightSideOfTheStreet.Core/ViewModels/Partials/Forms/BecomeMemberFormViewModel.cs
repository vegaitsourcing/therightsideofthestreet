using System.ComponentModel.DataAnnotations;
using System.Web;
using TheRightSideOfTheStreet.Core.Validations;
using TheRightSideOfTheStreet.Models.Extensions;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class BecomeMemberFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoDisplayName("BecomeMember.Name")]
		[StringLength(24)]
		public string Name { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[StringLength(24)]
		[UmbracoDisplayName("BecomeMember.Surname")]
		public string Surname { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[StringLength(24)]
		[UmbracoDisplayName("BecomeMember.Dob")]
		public string Dob { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[StringLength(24)]
		[UmbracoDisplayName("BecomeMember.Nationality")]
		public string Nationality { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[StringLength(24)]
		[UmbracoDisplayName("BecomeMember.Address")]
		public string Address { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[StringLength(24)]
		[UmbracoDisplayName("BecomeMember.MblNumber")]
		public string MblNumber { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[StringLength(24)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		[UmbracoDisplayName("BecomeMember.Email")]
		public string Email { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[ImageExtensions]
		[MaxFileSize(1.5)]
		[UmbracoDisplayName("BecomeMember.Picture")]
		public HttpPostedFileBase Picture { get; set; }
	}
}
