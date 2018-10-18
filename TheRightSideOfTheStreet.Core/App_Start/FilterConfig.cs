using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using WebMarkupMin.AspNet4.Mvc;

namespace TheRightSideOfTheStreet.Core
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
