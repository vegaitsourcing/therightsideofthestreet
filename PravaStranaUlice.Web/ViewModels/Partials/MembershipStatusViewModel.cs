using PravaStranaUlice.Models;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Shared;
using PravaStranaUlice.Web.Extensions;

namespace PravaStranaUlice.Web.ViewModels.Partials
{
    public class MembershipStatusViewModel 
    {
        public MembershipStatusViewModel(MembershipStatus content)
        {
            Icon = content.Icon.AsViewModel();
            Status = content.Status;
            Details = content.Details;
            Link = content.Link;
            Image = content.Image.AsViewModel();
        }

        public ImageViewModel Icon { get; }
        public string Status { get; }
        public string  Details { get; }
        public string Link { get; }
        public ImageViewModel Image { get; }
    }
}