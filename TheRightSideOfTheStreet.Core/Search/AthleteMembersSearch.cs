using Examine;
using Examine.Providers;
using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;
using UmbracoExamine;

namespace TheRightSideOfTheStreet.Core.Search
{
	public class AthleteMembersSearch
	{
		private readonly UmbracoHelper _umbracoHelper;
		private readonly BaseSearchProvider _searchProvider;
		
		public AthleteMembersSearch()
		{
			_umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
			_searchProvider = ExamineManager.Instance.SearchProviderCollection["InternalMemberSearcher"];
		}

		public IEnumerable<AthleteMember> GetAthletes()
		{
			var criteria = _searchProvider.CreateSearchCriteria(IndexTypes.Member);
			criteria.NodeTypeAlias("athleteMember");

			var members = _searchProvider.Search(criteria);
			var member = members.Select(m => _umbracoHelper.TypedMember(m.Id)?.OfType<AthleteMember>()).Where(m=> m != null && m.UmbracoMemberApproved);

			return member.AsList();
		}

		public AthleteMember GetAthlete(int athleteId)
		{
			var member = _umbracoHelper.TypedMember(athleteId)?.OfType<AthleteMember>();
			if(member == null)
			{
				return default(AthleteMember);
			}

			return member;
		}
		
	}
}
