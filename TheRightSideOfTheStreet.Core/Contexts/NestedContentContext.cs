using System;
using System.Collections.Generic;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public class NestedContentContext<T> : INestedContentContext<T> where T : class, INestedContent
    {
        public NestedContentContext(T nestedContent, ISiteContext siteContext)
        {
            NestedContent = nestedContent ?? throw new ArgumentNullException(nameof(nestedContent));
            SiteContext = siteContext ?? throw new ArgumentNullException(nameof(siteContext));
        }

        public T NestedContent { get; }
        public IPage CurrentPage => SiteContext.CurrentPage;
        public Website Home => SiteContext.Home;
        public Settings Settings => SiteContext.Settings;
        public Repository Repository => SiteContext.Repository;
		public IEnumerable<Website> Languages => SiteContext.Languages;
		public LoginForm LoginForm => SiteContext.LoginForm;
		public IEnumerable<Crew> Crews => SiteContext.Crews;
		public ResetPasswordForm ResetPassword => SiteContext.ResetPassword;
		public AthleteForm AthleteForm => SiteContext.AthleteForm;
		public ForgottenPassword ForgottenPassword => SiteContext.ForgottenPassword;
		public SWleague League => SiteContext.League;



		private ISiteContext SiteContext { get; }
    }
}