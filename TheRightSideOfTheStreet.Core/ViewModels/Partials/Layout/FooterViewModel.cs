using RJP.MultiUrlPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout
{
	public class FooterViewModel
	{
		public FooterViewModel(IPageContext<IPage> context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			InfoImage = context.Home.InfoImage.AsViewModel();
			InfoTitle = context.Home.InfoTitle;
			InfoText = context.Home.InfoText;
			HygieneLinksGroup = GetHygieneLinksGroups(context.Home.HygieneLinks);
			ContactEmail = context.Home.ContactEmail;
			SocialLinks = context.Home.SocialLinks?.Select(sl => context.WithNestedContent(sl).AsViewModel<SocialLinkViewModel>()).AsList();
			NewsLetter = new NewsletterFormViewModel(); 
		}

		public ImageViewModel InfoImage { get; }
		public string InfoTitle { get; }
		public string InfoText { get; }
		public IList<IEnumerable<LinkViewModel>> HygieneLinksGroup { get; }
		public string ContactEmail { get; }
		public IList<SocialLinkViewModel> SocialLinks { get; }
		public NewsletterFormViewModel NewsLetter { get; }

		private static IList<IEnumerable<LinkViewModel>> GetHygieneLinksGroups(IEnumerable<Link> links)
		{
			if (links == null) return new List<IEnumerable<LinkViewModel>>();

			IList<LinkViewModel> linksList = links.Select(lnk => lnk.AsViewModel()).AsList();
			const int numberOfGroups = 2;

			return linksList.Split((int)Math.Ceiling((double)linksList.Count / numberOfGroups)).ToList();
		}

	}
}