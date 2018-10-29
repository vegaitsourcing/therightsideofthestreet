using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.MemberTypes;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public interface IAthleteMemberContext<out T> : ISiteContext where T : class, IAthleteMember
	{
		T Member { get; }
		AthleteLanding Landing { get; }
	} 
	
}
