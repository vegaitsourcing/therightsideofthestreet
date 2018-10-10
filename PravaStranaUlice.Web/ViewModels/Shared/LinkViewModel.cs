using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.Extensions;
using RJP.MultiUrlPicker.Models;

namespace PravaStranaUlice.Web.ViewModels.Shared
{
    public class LinkViewModel
    {
        public LinkViewModel(string url, string content, string target = null)
        {
            Url = url;
            Content = content;
            Target = target;
        }

        public LinkViewModel(Link link) : this(link.Url, link.Name, link.Target)
        { }

        public LinkViewModel(IPage node, string target = null) : this(node.HasTemplate() ? node.Url : string.Empty, node.Title, target)
        { }

        public string Url { get; }
        public string Content { get; }
        public string Target { get; }
    }
}