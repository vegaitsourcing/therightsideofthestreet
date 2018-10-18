using Umbraco.ModelsBuilder;
using Umbraco.Web;
using TheRightSideOfTheStreet.Models.MediaTypes;

namespace TheRightSideOfTheStreet.Models
{
	/// <summary>
	/// File media type model.
	/// </summary>
	[RenamePropertyType("umbracoExtension", "Type")]
	[RenamePropertyType("umbracoFile", "Filename")]
	public partial class File : MediaBase
	{
		///<summary>
		/// Size (in bytes)
		///</summary>
		[ImplementPropertyType("umbracoBytes")]
		public decimal Size => decimal.Parse(this.GetPropertyValue<string>("umbracoBytes", "0"));
	}
}
