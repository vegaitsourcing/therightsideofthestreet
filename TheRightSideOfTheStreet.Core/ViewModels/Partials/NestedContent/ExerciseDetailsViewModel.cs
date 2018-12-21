using System;
using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public partial class ExerciseDetailsViewModel : INestedContentViewModel
	{
		public ExerciseDetailsViewModel(INestedContentContext<ExerciseDetails> context)
		{
			Title = context.NestedContent.Title;
			Steps = context.NestedContent.Steps?.Select(st => context.WithNestedContent(st).AsViewModel<ExerciseStepViewModel>()).AsList();
			HighlightVideo = context.NestedContent.HighlightVideo;
			HighlightTitle = context.NestedContent.HighlightTitle;
			HighlightBackgroundImage = context.NestedContent.HighlightBackgroundImage.AsViewModel();
			DetailKey = Guid.NewGuid();
		}

		public string Title { get; }
		public IList<ExerciseStepViewModel> Steps { get; }
		public string HighlightVideo { get; }
		public string HighlightTitle { get; }
		public ImageViewModel HighlightBackgroundImage { get; }
		public Guid DetailKey { get; } 
	}
}
