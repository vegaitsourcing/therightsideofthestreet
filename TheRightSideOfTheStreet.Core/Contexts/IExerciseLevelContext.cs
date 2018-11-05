using System.Collections.Generic;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public interface IExerciseLevelContext : IPageContext<ExerciseLevel>
	{
		IList<ExerciseLevel> ExerciseLevels { get; }
		IList<ExerciseCategory> Categories { get; }
		IList<ExerciseGroup> ExerciseGroups { get; }
	}
}
