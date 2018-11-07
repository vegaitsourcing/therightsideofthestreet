using System;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public partial class ExerciseStepViewModel : INestedContentViewModel
	{
		public ExerciseStepViewModel(INestedContentContext<ExerciseStep> context)
		{
			Image = context.NestedContent.Image.AsViewModel();
			Text = context.NestedContent.Text;
			StepKey = context.CurrentPage.Parent.GetKey();
		}
		public ImageViewModel Image { get; }
		public string Text { get; }
		public Guid StepKey { get; }
	}
}
