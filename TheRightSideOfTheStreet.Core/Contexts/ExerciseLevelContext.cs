using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public class ExerciseLevelContext : IExerciseLevelContext
	{
		public ExerciseLevelContext(IPageContext<ExerciseLevel> pageContext)
		{
			PageContext = pageContext;
			ExerciseGroups = Page.Children<ExerciseGroup>().AsList();
			Categories = ExerciseGroups.Where(eg => eg.ExerciseCategory != null).Select(g => g.ExerciseCategory).DistinctBy(ec => ec.Id).AsList();
			ExerciseLevels = Page.Ancestor<ExerciseLanding>().Children<ExerciseLevel>().AsList();
		}

		public IList<ExerciseLevel> ExerciseLevels { get; }

		public IList<ExerciseCategory> Categories { get; }

		public IList<ExerciseGroup> ExerciseGroups { get; }

		public ExerciseLevel Page => PageContext.Page;

		public IPage CurrentPage => PageContext.CurrentPage;

		public Website Home => PageContext.Home;

		public Settings Settings => PageContext.Settings;

		public Repository Repository => PageContext.Repository;

		public IEnumerable<Website> Languages => PageContext.Languages;

		public LoginForm LoginForm => PageContext.LoginForm;

		private IPageContext<ExerciseLevel> PageContext { get; }
	}
}
