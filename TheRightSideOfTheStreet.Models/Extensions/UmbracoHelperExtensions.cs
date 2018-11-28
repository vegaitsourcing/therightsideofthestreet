using TheRightSideOfTheStreet.Models.DocumentTypes;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;
using System;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Models;

namespace TheRightSideOfTheStreet.Models.Extensions
{
	/// <summary>
	/// <see cref="UmbracoHelper"/> extension methods.
	/// </summary>
	public static class UmbracoHelperExtensions
	{
		/// <summary>
		/// Returns Site root node.
		/// </summary>
		/// <typeparam name="T">Type of Site root node to return.</typeparam>
		/// <param name="helper">Umbraco helper.</param>
		/// <returns>Site root node.</returns>
		public static T GetRoot<T>(this UmbracoHelper helper) where T : class, IRootNode
			=> helper?.TypedContentAtRoot().OfType<T>().FirstOrDefault();

		/// <summary>
		/// Returns Site domain node.
		/// </summary>
		/// <typeparam name="T">Type of Site domain node to return.</typeparam>
		/// <param name="helper">Umbraco helper.</param>
		/// <returns>Site domain node.</returns>
		public static T GetDomain<T>(this UmbracoHelper helper) where T : class, IDomainRoot
			=> helper?.TypedContentAtDomainRoot<T>();

		/// <summary>
		/// Returns Home Page.
		/// </summary>
		/// <typeparam name="T">Type of Home Page node to return.</typeparam>
		/// <param name="helper">Umbraco helper.</param>
		/// <returns>Home Page.</returns>
		public static T GetHome<T>(this UmbracoHelper helper) where T : class, IHomePage
			=> helper?.UmbracoContext.PublishedContentRequest.PublishedContent.Site().OfType<T>();

		public static T GetPage<T>(this UmbracoHelper helper) where T : class, IPage
			=> helper?.UmbracoContext.PublishedContentRequest.PublishedContent.Site().OfType<T>();

		/// <summary>
		/// Returns Settings node.
		/// </summary>
		/// <param name="helper">Umbraco helper.</param>
		/// <returns>Settings node.</returns>
		public static Settings GetSettings(this UmbracoHelper helper, int siteId)
			=> helper?.TypedContentSingleAtXPath($"//{Website.ModelTypeAlias} [@id='{siteId}']//{Settings.ModelTypeAlias}").OfType<Settings>();

		/// <summary>
		///	Returns Repository node.
		/// </summary>
		/// <param name="helper">Umbraco helper.</param>
		/// <returns>Repository node.</returns>
		public static Repository GetRepository(this UmbracoHelper helper)
			=> helper?.TypedContentSingleAtXPath($"//{Models.Repository.ModelTypeAlias}").OfType<Repository>();

		public static IEnumerable<Website> GetLanguages(this UmbracoHelper helper)
			=> helper?.TypedContentAtRoot().Where(c => c.DocumentTypeAlias == Website.ModelTypeAlias).OfType<Website>() ?? Enumerable.Empty<Website>();

		public static IEnumerable<AthleteLanding> GetAthleteLanding(this UmbracoHelper helper)
			=> helper?.TypedContentAtXPath($"//{AthleteLanding.ModelTypeAlias}").OfType<AthleteLanding>() ?? Enumerable.Empty<AthleteLanding>();

		public static AthleteLanding GetAthleteLanding(this UmbracoHelper helper, int siteId)
			=> helper?.TypedContentSingleAtXPath($"//{Website.ModelTypeAlias}[@id='{siteId}']//{AthleteLanding.ModelTypeAlias}")?.OfType<AthleteLanding>();

		public static LoginForm GetLoginPage(this UmbracoHelper helper, int siteId)
			=> helper?.TypedContentSingleAtXPath($"//{Website.ModelTypeAlias}[@id='{siteId}']//{LoginForm.ModelTypeAlias}")?.OfType<LoginForm>();

		public static T GetPage<T>(this UmbracoHelper helper, int siteId) where T : PublishedContentModel
			=> helper?.TypedContentSingleAtXPath(GetXpath(typeof(T),siteId))?.OfType<T>();

		private static string GetXpath(Type t, int siteId)
		{
			return $"//{Website.ModelTypeAlias}[@id='{siteId}']//*[@isDoc and translate(name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '{t.Name.ToLower()}']";
		}

	}
}
