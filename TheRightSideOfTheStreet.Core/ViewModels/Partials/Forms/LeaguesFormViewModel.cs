using System;
using System.Collections.Generic;
using System.Web;
using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class LeaguesFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		[ImageExtensions(ErrorMessageDictionaryKey = "UmbracoValidation.ImageExtension")]
		[FileSize(2, "UmbracoValidation.ImageMaxSize")]
		public HttpPostedFileBase ProfilePicture { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Name { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Surname { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		[UmbracoDisplayName("BecomeMember.Email")]
		public string Email { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string City { get; set; }

		public Guid? Crew { get; set; }
		public IList<CrewViewModel> Crews { get; set; }

	}
}
