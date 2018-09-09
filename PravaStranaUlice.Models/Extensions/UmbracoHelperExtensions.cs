using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;

namespace PravaStranaUlice.Models.Extensions
{
	/// <summary>
	/// <see cref="UmbracoHelper"/> extension methods.
	/// </summary>
	public static class UmbracoHelperExtensions
	{
		/// <summary>
		/// Returns Settings node.
		/// </summary>
		/// <param name="helper">Umbraco helper.</param>
		/// <returns>Settings node.</returns>
		public static Settings GetSettings(this UmbracoHelper helper)
			=> helper?.TypedContentSingleAtXPath($"//{Models.Settings.ModelTypeAlias}").OfType<Settings>();

		/// <summary>
		///	Returns Repository node.
		/// </summary>
		/// <param name="helper">Umbraco helper.</param>
		/// <returns>Repository node.</returns>
		public static Repository GetRepository(this UmbracoHelper helper)
			=> helper?.TypedContentSingleAtXPath($"//{Models.Repository.ModelTypeAlias}").OfType<Repository>();

        public static Home GetHome(this UmbracoHelper helper) => helper.TypedContentSingleAtXPath($"//{Models.Home.ModelTypeAlias}").OfType<Home>();

        public static List<Language> GetLanguages(this UmbracoHelper helper) => helper.TypedContentAtRoot().OfType<Language>().ToList();
    }
}
