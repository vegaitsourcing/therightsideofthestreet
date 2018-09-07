using System;
using System.Globalization;

namespace PravaStranaUlice.Common.Extensions
{
	/// <summary>
	/// <see cref="DateTime"/> extension methods.
	/// </summary>
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Returns string representing elapsed time since specified <paramref name="dateTime"/>.
		/// </summary>
		/// <param name="dateTime">Date and time to calculate elapsed time from.</param>
		/// <returns>String representing elapsed time since specified <paramref name="dateTime"/>.</returns>
		public static string ElapsedTime(this DateTime dateTime)
		{
			TimeSpan subtract = DateTime.Now.Subtract(dateTime);
			if (subtract.Days > 0)
			{
				return subtract.Days.ToString() + "d";
			}
			else if (subtract.Hours > 0)
			{
				return subtract.Hours.ToString() + "h";
			}
			else if (subtract.Minutes > 0)
			{
				return subtract.Minutes.ToString() + "m";
			}
			else if (subtract.Seconds > 0)
			{
				return subtract.Seconds.ToString() + "s";
			}

			return string.Empty;
		}

		/// <summary>
		/// Calculates week number that given <paramref name="date"/> belongs to, according to current culture.
		/// </summary>
		/// <param name="date">Date to calculate week number of.</param>
		/// <returns>Week number that given <paramref name="date"/> belongs to.</returns>
		public static int WeekOfYear(this DateTime date)
			=> WeekOfYear(date, CultureInfo.CurrentCulture);

		/// <summary>
		/// Calculates week number that given <paramref name="date"/> belongs to, according to specified <paramref name="cultureInfo"/>.
		/// </summary>
		/// <param name="date">Date to calculate week number of.</param>
		/// <returns>Week number that given <paramref name="date"/> belongs to.</returns>
		public static int WeekOfYear(this DateTime date, CultureInfo cultureInfo)
		{
			DateTimeFormatInfo dfi = cultureInfo.DateTimeFormat;

			return dfi.Calendar.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
		}

		/// <summary>
		/// Calculates Unix timestamp based on specified <paramref name="dateTime"/>.
		/// </summary>
		/// <remarks>Unix timestamp represents number of seconds passed since 1.1.1970. 00:00.</remarks>
		/// <remarks>From .NET Framework v4.6 there is built-in support for this conversion: DateTimeOffset.ToUnixTimeSeconds.</remarks>
		/// <param name="dateTime">Date and time to calculate Unix timestamp from.</param>
		/// <returns>Unix timestamp calculated based on specified <paramref name="dateTime"/>.</returns>
		public static long ToUnixTimestamp(this DateTime dateTime)
			=> (long)(dateTime.ToUniversalTime() - UnixEpoch).TotalSeconds;

		/// <summary>
		/// Converts <paramref name="unixTimestamp"/> to DateTime instance.
		/// </summary>
		/// <remarks>Unix timestamp represents number of seconds passed since 1.1.1970. 00:00.</remarks>
		/// <remarks>From .NET Framework v4.6 there is built-in support for this conversion: DateTimeOffset.FromUnixTimeSeconds.</remarks>
		/// <param name="unixTimestamp">Unix timestamp.</param>
		/// <returns>DateTime instance created from <paramref name="unixTimestamp"/>.</returns>
		public static DateTime FromUnixTimestamp(this long unixTimestamp)
			=> UnixEpoch.AddSeconds(unixTimestamp);

		private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
	}
}
