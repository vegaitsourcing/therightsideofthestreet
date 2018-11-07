using System;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class ExerciseGroupPreviewViewModel
	{
		public ExerciseGroupPreviewViewModel(ExerciseGroup exerciseGroup)
		{
			Title = exerciseGroup.Title;
			Url = exerciseGroup.Url;
			Image = exerciseGroup.Image.AsViewModel();
			ExerciseCategory = exerciseGroup.ExerciseCategory.AsViewModel();
			PageKey = exerciseGroup.GetKey();
		}

		public ImageViewModel Image { get; }
		public string Title { get; set; }
		public string Url { get; }
		public ExerciseCategoryViewModel ExerciseCategory { get;}
		public Guid PageKey { get; }
	}
}
