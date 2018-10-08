using System.Text;

namespace PravaStranaUlice.Common.Extensions
{
	/// <summary>
	/// <see cref="StringBuilder"/> extension methods.
	/// </summary>
	public static class StringBuilderExtensions
	{
		/// <summary>
		/// Appends given <paramref name="value"/> to the <paramref name="source"/> as a new line.
		/// </summary>
		/// <param name="source">The source builder.</param>
		/// <param name="value">The value.</param>
		/// <returns>Updated <paramref name="source"/>.</returns>
		public static StringBuilder AppendLine(this StringBuilder source, object value)
			=> value != null ? source.AppendLine(value.ToString()) : source;
	}
}
