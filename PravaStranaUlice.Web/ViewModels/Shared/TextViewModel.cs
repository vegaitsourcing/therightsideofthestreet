using PravaStranaUlice.Models.DocumentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PravaStranaUlice.Web.ViewModels.Shared
{
	public class TextViewModel
	{
		public TextViewModel(string text)
		{
			Text = text;
		}

		public string Text { get; }
	}
}