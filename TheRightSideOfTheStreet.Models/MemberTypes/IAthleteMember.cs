using Umbraco.Core.Models;

namespace TheRightSideOfTheStreet.Models.MemberTypes
{
	public interface IAthleteMember : IPublishedContent
	{
		Image ProfileImage { get; }
		string FullName { get; }
	}
}
