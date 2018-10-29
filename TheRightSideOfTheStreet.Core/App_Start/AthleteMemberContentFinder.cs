using Examine;
using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Search;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;
using Umbraco.Web.Routing;
using UmbracoExamine;

namespace TheRightSideOfTheStreet.Core
{
	public class AthleteMemberContentFinder : IContentFinder
	{
		
		public bool TryFindContent(PublishedContentRequest contentRequest)
		{
			UmbracoHelper umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
			IEnumerable<AthleteLanding> landingPages = umbracoHelper.GetAthleteLanding();
			AthleteLanding landing = landingPages.FirstOrDefault(al => contentRequest.Uri.AbsolutePath.StartsWith(al.Url));

			if (landing == null)
			{
				return false;
			}

			var searcher = new AthleteMembersSearch();
			string memberName = contentRequest.Uri.Segments.Last();
			var member = searcher.GetAthletes().FirstOrDefault(m => m.GetScreenName() == memberName);
			if(member == null)
			{
				return false;
			}

			landing.AthleteMember = member;
			contentRequest.PublishedContent = landing;

			return true;
		}
	}
}
