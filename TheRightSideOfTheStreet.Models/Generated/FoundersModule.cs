using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;

namespace TheRightSideOfTheStreet.Models
{
	public partial class FoundersModule : IModuleNestedContent
	{
		[ImplementPropertyType("founders")]
		public IEnumerable<Founders> Founders => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<Founders>();
	}
}
