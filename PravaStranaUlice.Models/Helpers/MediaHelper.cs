using Microsoft.Win32;
using System.Globalization;

namespace PravaStranaUlice.Models.Helpers
{
	/// <summary>
	/// <see cref="PravaStranaUlice.Models.MediaTypes.MediaBase"/> helper class.
	/// </summary>
	public static class MediaHelper
	{
		/// <summary>
		/// Returns <paramref name="fileSize"/> expressed in KB or MB.
		/// </summary>
		/// <param name="fileSize">The file size.</param>
		/// <returns><paramref name="fileSize"/> expressed in KB or MB.</returns>
		public static string GetFormattedSize(decimal fileSize)
			=> GetFormattedSize(fileSize, CultureInfo.InvariantCulture);

		/// <summary>
		/// Returns <paramref name="fileSize"/> expressed in KB or MB, using given <paramref name="cultureInfo"/> for formatting.
		/// </summary>
		/// <param name="fileSize">The file size.</param>
		/// <param name="cultureInfo">Culture used for formatting.</param>
		/// <returns><paramref name="fileSize"/> expressed in KB or MB.</returns>
		public static string GetFormattedSize(decimal fileSize, CultureInfo cultureInfo)
		{
			const int sizeUnit = 1024;
			string sizeSymbol = "KB";

			decimal size = fileSize / sizeUnit;
			if (size >= sizeUnit)
			{
				size = fileSize / sizeUnit;
				sizeSymbol = "MB";
			}

			return $"{size.ToString("N", cultureInfo)}{sizeSymbol}";
		}

		/// <summary>
		/// Returns MIME type associated with given <paramref name="fileExtension"/>.
		/// </summary>
		/// <param name="fileExtension">The file extension.</param>
		/// <returns>MIME type associated with given <paramref name="fileExtension"/>.</returns>
		public static string GetMimeType(string fileExtension)
		{
			if (!fileExtension.StartsWith("."))
			{
				fileExtension = $".{fileExtension}";
			}

			string mimeType = Registry.ClassesRoot.OpenSubKey(fileExtension, false)?.GetValue("Content Type")?.ToString();

			return !string.IsNullOrWhiteSpace(mimeType) ? mimeType : "application/octet-stream";
		}
	}
}
