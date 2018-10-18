using System;
using System.Collections.Generic;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.DocumentTypes.Compositions;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public class CompositionContext<T> : ICompositionContext<T> where T : class, ICompositions
	{
		public CompositionContext(T composition, ISiteContext siteContext)
		{
			Composition = composition ?? throw new ArgumentNullException(nameof(composition));
			SiteContext = siteContext ?? throw new ArgumentNullException(nameof(siteContext));
		}

		public T Composition { get; }

		public IPage CurrentPage => SiteContext.CurrentPage;

		public Website Home => SiteContext.Home;

		public Settings Settings => SiteContext.Settings;

		public Repository Repository => SiteContext.Repository;

		public IEnumerable<Website> Languages => SiteContext.Languages;

		private ISiteContext SiteContext { get; }
	}
}