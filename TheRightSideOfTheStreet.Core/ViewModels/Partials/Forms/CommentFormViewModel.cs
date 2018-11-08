using System;
using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class CommentFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		public string Comment { get; set; }

	}
}
