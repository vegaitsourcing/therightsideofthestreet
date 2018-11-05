﻿using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class LoginViewModel : PageViewModel
	{
		public LoginViewModel(IPageContext<LoginForm> context) : base(context)
		{

		}
	}
}
