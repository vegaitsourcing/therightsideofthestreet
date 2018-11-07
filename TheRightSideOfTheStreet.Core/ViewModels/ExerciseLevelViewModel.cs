using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class ExerciseLevelViewModel : PageViewModel
	{
		public ExerciseLevelViewModel(IExerciseLevelContext context): base(context)
		{
			ExerciseGroup = context.ExerciseGroups.AsViewModel<ExerciseGroupPreviewViewModel>().ToList();
			ExerciseLevelPreviews = context.ExerciseLevels.AsViewModel<ExerciseLevelPreviewViewModel>().ToList();
			ExerciseCategories = context.Categories.AsViewModel<ExerciseCategoryViewModel>().ToList();
			LandingTitle = context.Page.Parent.OfType<Page>().Title;
			ActiveLevelId = context.Page.Id;
			HasGroups = context.ExerciseGroups?.Any() ?? false;
		}

		public IList<ExerciseGroupPreviewViewModel> ExerciseGroup { get; set; }
		public IList<ExerciseLevelPreviewViewModel> ExerciseLevelPreviews { get; }
		public IList<ExerciseCategoryViewModel> ExerciseCategories { get;  }
		public string LandingTitle { get; }
		public int ActiveLevelId { get; }
		public bool HasGroups { get; }
	}
}
