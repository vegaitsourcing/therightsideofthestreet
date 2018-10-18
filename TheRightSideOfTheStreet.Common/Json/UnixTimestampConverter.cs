using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using TheRightSideOfTheStreet.Common.Extensions;

namespace TheRightSideOfTheStreet.Common.Json
{
	/// <summary>
	/// JSON value converter for Unix timestamp to/from DateTime values.
	/// </summary>
	/// <remarks>From Newtonsoft.Json v11.x there is built in UnixDateTimeConverter class that should be used instead of this one.</remarks>
	public class UnixTimestampConverter : DateTimeConverterBase
	{
		/// <summary>
		/// Writes DateTime <paramref name="value"/> to JSON in Unix timestamp format.
		/// </summary>
		/// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
		/// <param name="value">DateTime value.</param>
		/// <param name="serializer">The <see cref="JsonSerializer"/> that should be used if needed.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (!(value is DateTime)) throw new ArgumentException("Expected DateTime value!", nameof(value));

			writer.WriteValue(((DateTime)value).ToUnixTimestamp());
		}

		/// <summary>
		/// Reads Unix timestamp value from JSON and converts it to DateTime format.
		/// </summary>
		/// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing value of object being read.</param>
		/// <param name="serializer">The <see cref="JsonSerializer"/> that should be used if needed.</param>
		/// <returns>DateTime value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Integer)
			{
				return ((long)reader.Value).FromUnixTimestamp();
			}
			else if (reader.TokenType == JsonToken.String)
			{
				return long.Parse((string)reader.Value).FromUnixTimestamp();
			}

			throw new ArgumentException("Unsupported Token type!", nameof(reader));
		}
	}
}
