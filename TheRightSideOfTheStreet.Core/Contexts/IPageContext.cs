using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.Contexts
{
    public interface IPageContext<out T> : ISiteContext where T : class, IPage
    {
        T Page { get; }
    }
}
