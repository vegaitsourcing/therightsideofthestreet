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
			return members.Select(m => _umbracoHelper.TypedMember(m.Id)?.OfType<AthleteMember>()).Where(m => m != null && m.UmbracoMemberApproved);
		}

		private ISearchCriteria GetSearchCriteria()
		{
			var criteria = _searchProvider.CreateSearchCriteria(IndexTypes.Member);
			criteria.NodeTypeAlias(AthleteMember.ModelTypeAlias);

			return criteria;
		}

		//ADMIN
		private ISearchCriteria GetSearchCriteriaAdmin()
		{
			var criteria = _searchProvider.CreateSearchCriteria(IndexTypes.Member);
			criteria.NodeTypeAlias(Admin.ModelTypeAlias);

			return criteria;
		}

		private IEnumerable<Admin> GetSearchResultsAdmin(ISearchCriteria criteria)
		{
			var members = _searchProvider.Search(criteria);
			return members.Select(m => _umbracoHelper.TypedMember(m.Id)?.OfType<Admin>()).Where(m => m != null && m.UmbracoMemberApproved);
		}

		public IEnumerable<Admin> GetAdmin()
		{
			var criteria = GetSearchCriteriaAdmin();
			var admin = GetSearchResultsAdmin(criteria);

			return admin;
		}

		public IEnumerable<Admin> GetAdmins(string query)
		{
			if (string.IsNullOrWhiteSpace(query)) return Enumerable.Empty<Admin>();

			var criteria = GetSearchCriteriaAdmin();

			var words = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var boostedExamineValue = query.Boost(2);
			var wordExamineValues = words.Select(w => w.Escape());

			criteria.GroupedOr(new[] { "fullName" }, wordExamineValues.Concat(boostedExamineValue).ToArray());

			var members = GetSearchResultsAdmin(criteria);

			return members.AsList();
		}
	}
}
