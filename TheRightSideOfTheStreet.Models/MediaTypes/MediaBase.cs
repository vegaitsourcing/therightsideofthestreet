using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using TheRightSideOfTheStreet.Models.Extensions;

namespace TheRightSideOfTheStreet.Models.MediaTypes
{
	/// <summary>
	/// Base media type model.
	/// </summary>
	public abstract class MediaBase : PublishedContentModel
	{
		protected MediaBase(IPublishedContent content) : base(content)
		{ }

		/// <summary>
		/// Returns full (absolute) URL to the media.
		/// </summary>
		/// <remarks>
		/// This is replacement for IPublishedContent.UrlAbsolute() which is not working for media types.
		/// </remarks>
		public string FullUrl => UmbracoContext.Current?.HttpContext?.Request.GetAbsoluteUrl(Url);
	}
}
