using PravaStranaUlice.Models.DocumentTypes.Compositions;

namespace PravaStranaUlice.Web.Contexts
{
    public interface ICompositionContext<out T> : ISiteContext where T : ICompositions
    {
        T Composition { get; }
    }
}
