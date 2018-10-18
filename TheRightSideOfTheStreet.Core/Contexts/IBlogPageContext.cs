using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public interface IBlogPageContext<out T> : IPageContext<T> where T : class, IBlogPage
	{
		BlogLanding Landing { get; }
		IBlogPage Previous { get; }
		IBlogPage Next { get; }
	}
}