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
			Path = level.Path;
		}
		public int Id { get;  }
		public string Title { get; }
		public string Url { get; }
		public string Path { get; }
	}
}
