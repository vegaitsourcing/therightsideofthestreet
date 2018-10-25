using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class ImageModuleViewModel : IModulesNestedContentViewModel
	{
		public ImageModuleViewModel(INestedContentContext<ImageModule> context)
		{
			Image = context.NestedContent.Image.AsViewModel();
		}

		public ImageViewModel Image { get; } 
	}
}
