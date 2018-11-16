using System.Collections.Generic;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.Extensions;
using TheRightSideOfTheStreet.Models.MemberTypes;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public class AthleteMemberContext<T> : IAthleteMemberContext<T> where T: class, IAthleteMember
	{
		public AthleteMemberContext(T member, ISiteContext siteContext)
		{
			Member = member;
			SiteContext = siteContext; 
			Landing = new UmbracoHelper(UmbracoContext.Current).GetAthleteLanding(Home.Id);
		}

		public T Member { get; }

		public AthleteLanding Landing { get; }

		public IPage CurrentPage => SiteContext.CurrentPage;

		public Website Home => SiteContext.Home;

		public Settings Settings => SiteContext.Settings;

		public Repository Repository => SiteContext.Repository;

		public IEnumerable<Website> Languages => SiteContext.Languages;

		public LoginForm LoginForm => SiteContext.LoginForm;

		public IEnumerable<Crew> Crews => SiteContext.Crews;

		private ISiteContext SiteContext { get;  }
	}
}
