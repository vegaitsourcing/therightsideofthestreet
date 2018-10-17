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
    public class BlogDetailsViewModel : PageViewModel
    {
        public BlogDetailsViewModel(IBlogPageContext<BlogDetails> context) : base(context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            Image = context.Page.Image.AsViewModel();
            Description = context.Page.Text.ToString();         
            Date = context.Page.Date;
            BlogLanding = context.Landing.Url;
            Prevoius = context.Previous?.Url;
            Next = context.Next?.Url;

        }
        
        public ImageViewModel Image { get; }
        public string Description { get; }
        public DateTime Date { get; }
        public string BlogLanding { get; }
        public string Prevoius { get; }
        public string Next { get; }

    }
}
