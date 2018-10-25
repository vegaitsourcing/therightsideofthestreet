using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;

namespace TheRightSideOfTheStreet.Models
{
	public partial class CaseStudiesModule : IModuleNestedContent
	{
		[ImplementPropertyType("boxes")]
		public IEnumerable<CaseStudy> Boxes => this.GetPropertyValue <IEnumerable<IPublishedContent>>()?.OfType<CaseStudy>();
	}
}
