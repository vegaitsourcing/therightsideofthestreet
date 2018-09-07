using PravaStranaUlice.Models.Helpers;

namespace PravaStranaUlice.Models.Extensions
{
	/// <summary>
	/// <see cref="File"/> extension methods.
	/// </summary>
	public static class FileExtensions
	{
		/// <summary>
		/// Returns <paramref name="file"/> size expressed in KB or MB.
		/// </summary>
		/// <param name="file">File model.</param>
		/// <returns><paramref name="file"/> size expressed in KB or MB.</returns>
		public static string GetFormattedSize(this File file)
			=> MediaHelper.GetFormattedSize(file.Size);

		/// <summary>
		/// Returns MIME type associated with given <paramref name="file"/> extension.
		/// </summary>
		/// <param name="file">File model.</param>
		/// <returns>MIME type associated with given <paramref name="file"/> extension.</returns>
		public static string GetMimeType(this File file)
			=> MediaHelper.GetMimeType(file.Type);
	}
}
