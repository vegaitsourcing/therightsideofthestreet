using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class ExerciseDetailsPreviewViewModel
	{
		public ExerciseDetailsPreviewViewModel(ExerciseDetails exerciseDetails)
		{
			Id = exerciseDetails.Id;
			Title = exerciseDetails.Title;
			Url = exerciseDetails.Url;
		}

		public int Id { get; }
		public string Title { get; }
		public string Url { get; }
	}
}
