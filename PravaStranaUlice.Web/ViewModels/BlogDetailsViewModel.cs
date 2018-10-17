using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Web.Extensions;
using PravaStranaUlice.Models;

namespace PravaStranaUlice.Web.ViewModels
{
    public class BlogDetailsViewModel 
    {
        public BlogDetailsViewModel(IPageContext<BlogDetails> context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            Image = context.Page.Image.AsViewModel();
            BlogTitle = context.Page.Title;
            Description = context.Page.Text.ToString();
            Date = context.Page.Date;
        }

        public ImageViewModel Image { get; }
        public string BlogTitle { get; }
        public string Description { get; }
        public DateTime Date { get; }

    }
}
