using TheRightSideOfTheStreet.Models.DocumentTypes.Compositions;

namespace TheRightSideOfTheStreet.Core.Contexts
{
    public interface ICompositionContext<out T> : ISiteContext where T : ICompositions
    {
        T Composition { get; }
    }
}
