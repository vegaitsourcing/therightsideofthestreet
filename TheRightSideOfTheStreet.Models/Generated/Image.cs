using Umbraco.ModelsBuilder;
using Umbraco.Web;
using TheRightSideOfTheStreet.Models.Extensions;
using TheRightSideOfTheStreet.Models.MediaTypes;

namespace TheRightSideOfTheStreet.Models
{
	/// <summary>
	/// Image media type model.
	/// </summary>
	[RenamePropertyType("umbracoExtension", "Type")]
	[RenamePropertyType("umbracoFile", "Cropper")]
	[RenamePropertyType("umbracoHeight", "Height")]
	[RenamePropertyType("umbracoWidth", "Width")]
	public partial class Image : MediaBase
	{
		///<summary>
		/// Size (in bytes)
		///</summary>
		[ImplementPropertyType("umbracoBytes")]
		public decimal Size => decimal.Parse(this.GetPropertyValue<string>("umbracoBytes", "0"));
	}
}
