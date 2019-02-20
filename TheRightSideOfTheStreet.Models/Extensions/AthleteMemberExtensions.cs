using System.Text.RegularExpressions;

namespace TheRightSideOfTheStreet.Models.Extensions
{
	public static class AthleteMemberExtensions
	{
		public static string GetScreenName(this AthleteMember athleteMember)
		{
			if(athleteMember == null)
			{
				return string.Empty;
			}

			string name = athleteMember.Name;

			return Regex.Replace(name, "[^a-zA-Z0-9]", "").ToLower();
		}

		public static string GetScreenNameAdmin(this Admin admin)
		{
			if (admin == null)
			{
				return string.Empty;
			}

			string name = admin.Name;

			return Regex.Replace(name, "[^a-zA-Z0-9]", "").ToLower();
		}
	}
}
