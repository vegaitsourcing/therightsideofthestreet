using System;
using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class ExerciseGroupViewModel : PageViewModel
	{
		public ExerciseGroupViewModel(IPageContext<ExerciseGroup> context) : base(context)
		{
			Image = context.Page.Image.AsViewModel();
			ExerciseCategory = context.Page.ExerciseCategory.AsViewModel();
			ExerciseDetails = context.Page.ExerciseDetail?.Select(ed => context.WithNestedContent(ed).AsViewModel<ExerciseDetailsViewModel>()).ToList();
			MasterTitle = context.Page.Parent.Parent.Name;
			SettingsKey = context.Settings.GetKey();
			LoginUrl = context.LoginForm.Url;
			LeagueUrl = context.League.Url;
		}

		public ImageViewModel Image { get; }
		public ExerciseCategoryViewModel ExerciseCategory { get; }
		public IList<ExerciseDetailsViewModel> ExerciseDetails { get; }
		public string MasterTitle { get; }
		public Guid SettingsKey { get; }
		public string LoginUrl { get; }
		public string LeagueUrl { get; }
	}
}
