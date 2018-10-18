using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Models.Helpers;

namespace TheRightSideOfTheStreet.Models.Extensions
{
	/// <summary>
	/// <see cref="Image"/> extension methods.
	/// </summary>
	public static class ImageExtensions
	{
		/// <summary>
		/// Returns <paramref name="image"/> size expressed in KB or MB.
		/// </summary>
		/// <param name="image">Image model.</param>
		/// <returns><paramref name="image"/> size expressed in KB or MB.</returns>
		public static string GetFormattedSize(this Image image)
			=> MediaHelper.GetFormattedSize(image.Size);

		/// <summary>
		/// Returns MIME type associated with given <paramref name="image"/> extension.
		/// </summary>
		/// <param name="image">Image model.</param>
		/// <returns>MIME type associated with given <paramref name="image"/> extension.</returns>
		public static string GetMimeType(this Image image)
			=> MediaHelper.GetMimeType(image.Type);

		/// <summary>
		/// Returns <paramref name="image"/> alternate text or <paramref name="image"/> name if alternate text is not specified.
		/// </summary>
		/// <param name="image">Image model.</param>
		/// <returns><paramref name="image"/> alternate text or <paramref name="image"/> name if alternate text is not specified.</returns>
		public static string GetAlternateText(this Image image)
			=> !image.AlternateText.IsNullOrEmpty() ? image.AlternateText : image.Name;
	}
}
