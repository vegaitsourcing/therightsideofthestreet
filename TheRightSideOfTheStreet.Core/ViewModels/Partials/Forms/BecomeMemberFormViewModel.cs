using System.ComponentModel.DataAnnotations;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms
{
	public class BecomeMemberFormViewModel
	{
		[Required]
		[StringLength(24)]
		public string Name { get; set; }

		[Required]
		[StringLength(24)]
		public string Surname { get; set; }

		[Required]
		[StringLength(24)]
		public string Dob { get; set; }

		[Required]
		[StringLength(24)]
		public string Nationality { get; set; }

		[Required]
		[StringLength(24)]
		public string Adress { get; set; }

		[Required]
		[StringLength(24)]
		public string MblNumber { get; set; }

		[Required]
		[StringLength(24)]
		public string Email { get; set; }
	}
}
