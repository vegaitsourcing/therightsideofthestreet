using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class DonatorsViewModel : INestedContentViewModel
	{
		public DonatorsViewModel(INestedContentContext<Donators> context)
		{
			DonatorName = context.NestedContent.DonatorName;
			Image = context.NestedContent.Image.AsViewModel();
			City = context.NestedContent.City;
		}

		public string DonatorName { get; }
		public ImageViewModel Image { get; } //TODO : implementation after FE corrections
		public string City { get; }
	}
}