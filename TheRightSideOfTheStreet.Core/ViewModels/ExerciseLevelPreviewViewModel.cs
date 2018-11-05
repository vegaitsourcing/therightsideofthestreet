using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class ExerciseLevelPreviewViewModel
	{
		public ExerciseLevelPreviewViewModel(ExerciseLevel level)
		{
			Id = level.Id;
			Title = level.Title;
			Url = level.Url;
		}
		public int Id { get;  }
		public string Title { get; }
		public string Url { get; }
	}
}
