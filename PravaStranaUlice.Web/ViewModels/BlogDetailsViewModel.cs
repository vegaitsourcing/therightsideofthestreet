using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Web.Extensions;

namespace PravaStranaUlice.Web.ViewModels
{
    public class BlogDetailsViewModel 
    {
        public BlogDetailsViewModel(IPageContext<IPage> context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            Image = context.BlogDetails.Image.AsViewModel();
            BlogTitle = context.BlogDetails.Title;
            Description = context.BlogDetails.Text.ToString();
            Date = context.BlogDetails.Date;
        }

        public ImageViewModel Image { get; }
        public string BlogTitle { get; }
        public string Description { get; }
        public DateTime Date { get; }

    }
}
