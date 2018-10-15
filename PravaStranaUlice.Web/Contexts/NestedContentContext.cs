using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.DocumentTypes.Nodes.Items.NestedContent;
using System;
using System.Collections.Generic;

namespace PravaStranaUlice.Web.Contexts
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
        public BecomeMember BecomeMember => SiteContext.BecomeMember;

		private ISiteContext SiteContext { get; }
    }
}