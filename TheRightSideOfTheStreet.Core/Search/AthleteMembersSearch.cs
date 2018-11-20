using Examine;
using Examine.LuceneEngine.SearchCriteria;
using Examine.Providers;
using Examine.SearchCriteria;
using System;
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
			var criteria = GetSearchCriteria();
			var members = GetSearchResults(criteria);

			return members.AsList();
		}

		public IEnumerable<AthleteMember> GetAthletes(string query)
		{
			if (string.IsNullOrWhiteSpace(query)) return Enumerable.Empty<AthleteMember>();

			var criteria = GetSearchCriteria();

			var words = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var boostedExamineValue = query.Boost(2);
			var wordExamineValues = words.Select(w => w.Escape());

			criteria.GroupedOr(new[] { "fullName" }, wordExamineValues.Concat(boostedExamineValue).ToArray());

			var members = GetSearchResults(criteria);

			return members.AsList();
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
		
		private IEnumerable<AthleteMember> GetSearchResults(ISearchCriteria criteria)
		{
			var members = _searchProvider.Search(criteria);
			return members.Select(m => _umbracoHelper.TypedMember(m.Id)?.OfType<AthleteMember>()).Where(m => m != null);
		}

		private ISearchCriteria GetSearchCriteria()
		{
			var criteria = _searchProvider.CreateSearchCriteria(IndexTypes.Member);
			criteria.NodeTypeAlias(AthleteMember.ModelTypeAlias);

			return criteria;
		}
	}
}
