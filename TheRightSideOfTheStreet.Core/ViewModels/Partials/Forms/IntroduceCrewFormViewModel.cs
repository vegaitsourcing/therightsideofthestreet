using System.Collections.Generic;
using System.Web;
using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class IntroduceCrewFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		public string CrewName { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		public string CrewStory { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		public string CrewCity { get; set; }

		public string CrewAchievements { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		[UmbracoDisplayName("BecomeMember.Email")]
		public string CrewEmail { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[ListFileSize(2, "UmbracoValidation.MultipleImageMaxSize")]
		[MultipleImagesExtensions(ErrorMessageDictionaryKey = "UmbracoValidation.ImageExtension")]
		public IList<HttpPostedFileBase> Images { get; set; }
	}
}
