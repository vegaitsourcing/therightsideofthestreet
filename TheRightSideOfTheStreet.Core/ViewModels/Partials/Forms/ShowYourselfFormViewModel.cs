
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TheRightSideOfTheStreet.Core.Validations;
using UmbracoValidationAttributes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class ShowYourselfFormViewModel
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
		public string Password { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoCompare("UmbracoValidation.PasswordMatch", "Password")]
		public string ConfirmPassword { get; set; }

		public Guid Crew { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string Country { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 24)]
		public string City { get; set; }
		
		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 100)]
		public string DescribeYourself { get; set; }

		[UmbracoStringLength("UmbracoValidation.StringLength", 100)]
		public string VisionOfSport { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		public string ImportantAchievements { get; set; }

		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		public string FacebookProfile { get; set; }

		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		public string InstagramProfile { get; set; }

		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		public string YouTubeChannel { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		//[FileSize(2, "UmbracoValidation.ImageSize")]
		public IList<HttpPostedFileBase> Images { get; set; }

		public IList<CrewViewModel> Crews { get; set; }
	}
}
