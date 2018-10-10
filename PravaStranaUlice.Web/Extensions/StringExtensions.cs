using System.Web.Mvc;
using PravaStranaUlice.Common.Extensions;

namespace PravaStranaUlice.Web.Extensions
{
	/// <summary>
	/// <see cref="string"/> extension methods.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Returns <paramref name="controllerName"/> string after stripping "Controller" suffix from it.
		/// </summary>
		/// <param name="controllerName">The name of the controller class.</param>
		/// <returns>Name without "Controller" suffix.</returns>
		public static string RemoveControllerSuffix(this string controllerName)
		{
			return controllerName.RemoveSuffix(nameof(Controller));
		}

        /// <summary>
		/// Returns <paramref name="viewModelName"/> string after stripping "ViewModel" suffix from it.
		/// </summary>
		/// <param name="viewModelName">The name of the view model class.</param>
		/// <returns>Name without "ViewModel" suffix.</returns>
		public static string RemoveViewModelSuffix(this string viewModelName)
            => viewModelName.RemoveSuffix("ViewModel");
    }
}
