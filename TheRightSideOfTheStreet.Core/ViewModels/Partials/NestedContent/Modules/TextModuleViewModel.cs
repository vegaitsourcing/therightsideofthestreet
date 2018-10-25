using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class TextModuleViewModel : IModulesNestedContentViewModel
	{
		public TextModuleViewModel(INestedContentContext<TextModule> context)
		{
			Text = context.NestedContent.Text;
		}

		public IHtmlString Text { get; }
	}
}
