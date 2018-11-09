using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;

namespace TheRightSideOfTheStreet.Models
{
	public partial class ExerciseLevel
	{
		[ImplementPropertyType("exerciseGroup")]
		public IEnumerable<ExerciseGroup> ExerciseGroups => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<ExerciseGroup>();
	}
}
