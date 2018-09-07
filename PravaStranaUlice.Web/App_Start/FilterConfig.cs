using System.Web.Mvc;
using PravaStranaUlice.Common;
using WebMarkupMin.AspNet4.Mvc;

namespace PravaStranaUlice.Web
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			if (AppSettings.DisableHttpCompression != true)
			{
				filters.Add(new CompressContentAttribute());
			}

			filters.Add(new MinifyHtmlAttribute());
		}
	}
}
