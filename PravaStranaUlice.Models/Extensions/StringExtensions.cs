using PravaStranaUlice.Common.Extensions;
using System.Web.Mvc;

namespace PravaStranaUlice.Models.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Returns name of the controller class after stripping "controller" suffix from it.
		/// </summary>
		/// <param name="controllerName">The name of the controller class.</param>
		/// <returns>Name without "controller" suffix.</returns>
		public static string RemoveControllerSuffix(this string controllerName)
		{
			return controllerName.RemoveSuffix(nameof(Controller));
		}
	}
}
