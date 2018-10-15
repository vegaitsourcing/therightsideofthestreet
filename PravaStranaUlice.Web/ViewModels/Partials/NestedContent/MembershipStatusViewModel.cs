using PravaStranaUlice.Models;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Shared;
using PravaStranaUlice.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PravaStranaUlice.Web.ViewModels.Partials.NestedContent
{
    public class MembershipStatusViewModel : INestedContentViewModel
    {
        public MembershipStatusViewModel(INestedContentContext<MembershipStatus> context)
        {
            Icon = context.NestedContent.Icon.AsViewModel();
            Status = context.NestedContent.Status;
            Details = context.NestedContent.Details;
            Link = context.NestedContent.Link;
            Image = context.NestedContent.Image.AsViewModel();
        }

        public ImageViewModel Icon { get; }
        public string Status { get; }
        public string  Details { get; }
        public string Link { get; }
        public ImageViewModel Image { get; }
    }
}