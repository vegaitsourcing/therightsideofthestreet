using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class ExerciseGroup
	{
		[ImplementPropertyType("image")]
		public Image Image => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("highlightBackgroundImage")]
		public Image HighlightBackgroundImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("exerciseCategory")]
		public ExerciseCategory ExerciseCategory => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.FirstOrDefault()?.OfType<ExerciseCategory>();

		[ImplementPropertyType("exerciseDetail")]
		public IEnumerable<ExerciseDetails> ExerciseDetail => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<ExerciseDetails>();
	}
}
