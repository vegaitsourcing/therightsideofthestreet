using System;
using System.Collections.Generic;

namespace TheRightSideOfTheStreet.Common.Helpers
{
	/// <summary>
	/// <see cref="Enum"/> helper class.
	/// </summary>
	public static class EnumHelper
	{
		/// <summary>
		///	Returns the name that is associated with given enumeration <paramref name="value"/>.
		/// </summary>
		/// <typeparam name="T">Enumeration type.</typeparam>
		/// <param name="value">Enumeration value.</param>
		/// <returns>Name that is associated with given enumeration <paramref name="value"/>.</returns>
		public static string GetName<T>(T value)
			=> Enum.GetName(typeof(T), value);

		/// <summary>
		///	Returns all names defined in specified enumeration type.
		/// </summary>
		/// <typeparam name="T">Enumeration type.</typeparam>
		/// <returns>All names defined in specified enumeration type.</returns>
		public static IEnumerable<string> GetNames<T>()
			=> Enum.GetNames(typeof(T));

		/// <summary>
		///	Returns all values defined in specified enumeration type.
		/// </summary>
		/// <typeparam name="T">Enumeration type.</typeparam>
		/// <returns>All values defined in specified enumeration type.</returns>
		public static IEnumerable<T> GetValues<T>()
			=> (T[])Enum.GetValues(typeof(T));
	}
}
