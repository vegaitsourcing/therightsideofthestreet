using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;

namespace PravaStranaUlice.Web.ViewModels
{
    public class WebsiteViewModel : PageViewModel
    {
        public WebsiteViewModel(IPageContext<IPage> context) : base(context)
        {
        }
    }
}