using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PravaStranaUlice.Web.ViewModels
{
    public class BecomeMemberViewModel : PageViewModel
    {
        public BecomeMemberViewModel(IPageContext<IPage> context) : base(context)
        {
            Title = context.CurrentPage.Title;
        }

        public string Title { get; }
        public string IntroText { get; }
        IEnumerable<MembershipStatus> MembershipStatuses { get; }
    }
}