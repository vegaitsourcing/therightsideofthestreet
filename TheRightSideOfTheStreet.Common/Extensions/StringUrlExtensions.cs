namespace TheRightSideOfTheStreet.Common.Extensions
{
	/// <summary>
	/// <see cref="string"/> extension methods for URL manipulations.
	/// </summary>
	public static class StringUrlExtensions
	{
		/// <summary>
		/// Normalizes (replaces %20 chars with spaces) the <paramref name="queryParam"/> string.
		/// </summary>
		/// <param name="queryParam">The URL query parameter.</param>
		/// <returns>Normalized <paramref name="queryParam"/> string.</returns>
		public static string NormalizeQueryParam(string queryParam)
			=> queryParam.Replace("%20", " ");
	}
}
