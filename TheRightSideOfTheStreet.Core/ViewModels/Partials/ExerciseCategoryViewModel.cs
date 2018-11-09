using System;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials
{
	public partial class ExerciseCategoryViewModel
	{
		public ExerciseCategoryViewModel(ExerciseCategory exerciseCategory)
		{
			Title = exerciseCategory.Name;
			Id = exerciseCategory.Id;
			CategoryKey = exerciseCategory.GetKey();
		}

		public string Title { get; }
		public int Id { get; }
		public Guid CategoryKey { get; } 
	}
}
