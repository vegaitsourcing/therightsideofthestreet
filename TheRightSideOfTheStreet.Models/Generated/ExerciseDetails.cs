using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class ExerciseDetails : INestedContent
	{
		[ImplementPropertyType("steps")]
		public IEnumerable<ExerciseStep> Steps => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<ExerciseStep>();

		[ImplementPropertyType("highlightBackgroundImage")]
		public Image HighlightBackgroundImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();
	}
}
