using System.Collections.Generic;
using Umbraco.Web;

namespace PravaStranaUlice.Models.Extensions
{
	/// <summary>
	/// <see cref="Folder"/> extension methods.
	/// </summary>
	public static class FolderExtensions
	{
		/// <summary>
		/// Retrieves <seealso cref="Image"/> collection from the provided <paramref name="folder"/>.
		/// </summary>
		/// <param name="folder">Folder model.</param>
		/// <returns><seealso cref="Image"/> collection from the provided <paramref name="folder"/>.</returns>
		public static IEnumerable<Image> GetImages(this Folder folder)
			=> folder.Children<Image>();

		/// <summary>
		/// Retrieves <seealso cref="File"/> collection from the provided <paramref name="folder"/>.
		/// </summary>
		/// <param name="folder">Folder model.</param>
		/// <returns><seealso cref="File"/> collection from the provided <paramref name="folder"/>.</returns>
		public static IEnumerable<File> GetFiles(this Folder folder)
			=> folder.Children<File>();

		/// <summary>
		/// Retrieves <seealso cref="Folder"/> collection from the provided <paramref name="folder"/>.
		/// </summary>
		/// <param name="folder">Folder model.</param>
		/// <returns><seealso cref="Folder"/> collection from the provided <paramref name="folder"/>.</returns>
		public static IEnumerable<Folder> GetSubFolders(this Folder folder)
			=> folder.Children<Folder>();
	}
}
