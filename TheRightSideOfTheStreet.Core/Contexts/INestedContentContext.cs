using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;

namespace TheRightSideOfTheStreet.Core.Contexts
{
    public interface INestedContentContext<out T> : ISiteContext where T : INestedContent
    {
        T NestedContent { get; }
    }
}
