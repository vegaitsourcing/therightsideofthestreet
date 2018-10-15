using PravaStranaUlice.Models;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Shared;
using PravaStranaUlice.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PravaStranaUlice.Web.ViewModels.Partials.NestedContent
{
	public class DonatorViewModel
	{
		public DonatorViewModel(INestedContentContext<Donators> context)
		{
			DonatorName = context.NestedContent.DonatorName;
			Image = context.NestedContent.Image.AsViewModel();
			City = context.NestedContent.City;
		}

		public string DonatorName { get; }
		public ImageViewModel Image {get;}
		public string City { get; }
	}
}