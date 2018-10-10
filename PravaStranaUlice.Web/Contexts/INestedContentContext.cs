using PravaStranaUlice.Models.DocumentTypes.Nodes.Items.NestedContent;

namespace PravaStranaUlice.Web.Contexts
{
    public interface INestedContentContext<out T> : ISiteContext where T : INestedContent
    {
        T NestedContent { get; }
    }
}
