using System.Collections.Generic;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public interface ISiteContext
    {
        IPage CurrentPage { get; }
        Website Home { get; }
        Settings Settings { get; }
        Repository Repository { get; }
		IEnumerable<Website> Languages { get; }
		LoginForm LoginForm { get; }
		IEnumerable<Crew> Crews { get; }
		ResetPasswordForm ResetPassword { get; }
		AthleteForm AthleteForm { get; }
		SWleague League { get; }
		ForgottenPassword ForgottenPassword { get; }
    }
}
