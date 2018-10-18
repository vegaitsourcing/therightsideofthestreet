using System;

namespace TheRightSideOfTheStreet.Models.DocumentTypes
{
	public interface IBlogPage : IPage
    {
        DateTime Date { get; }
    }
}
