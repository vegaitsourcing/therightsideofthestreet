using System.Linq;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models.Extensions
{
	public static class BannerExtensions
	{
		public static Image GetBannerImage(this IBanner banner)
		{
			return banner.BannerImage?.OfType<Image>();
		}
	}
}
