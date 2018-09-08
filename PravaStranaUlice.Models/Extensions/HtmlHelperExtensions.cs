using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Umbraco.Core.Models;

namespace PravaStranaUlice.Models.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static void RenderAppropriatePartial<T>(this HtmlHelper source, IPublishedContent module) where T : IPublishedContent
        {
            if (module is T)
            {
                string partialPath = module.GetModulePartialViewPath();

                source.RenderPartial(partialPath, (T)module);
            }

        }
    }
}
