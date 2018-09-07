using System;
using System.Runtime.CompilerServices;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace PravaStranaUlice.Models.Extensions
{
	/// <summary>
	/// <see cref="IPublishedContent"/> extension methods for property access.
	/// </summary>
	public static class IPublishedContentPropertyExtensions
	{
		/// <summary>
		/// Returns property with given <paramref name="propertyName"/> from the <paramref name="source"/>.
		/// </summary>
		/// <remarks>
		/// This method is exactly the same as Umbraco's own <see cref="IPublishedContent.GetProperty(string)"/>,
		/// except this one will deduce property name from the caller's context, if name is omitted.
		/// </remarks>
		/// <param name="source">The source.</param>
		/// <param name="propertyName">Property name.</param>
		/// <returns>Property with given <paramref name="propertyName"/>.</returns>
		public static IPublishedProperty GetProperty(this IPublishedContent source, [CallerMemberName] string propertyName = null)
			=> source.GetProperty(propertyName);

		/// <summary>
		/// Checks if <paramref name="source"/> has a value for the property with given <paramref name="propertyName"/>.
		/// </summary>
		/// <remarks>
		/// This method is exactly the same as Umbraco's own <see cref="PublishedContentExtensions.HasValue(IPublishedContent, string)"/>,
		/// except this one will deduce property name from the caller's context, if name is omitted.
		/// </remarks>
		/// <param name="source">The source.</param>
		/// <param name="propertyName">Property name.</param>
		/// <returns><c>true</c> if <paramref name="source"/> has a value for the property with given <paramref name="propertyName"/>, otherwise <c>false</c>.</returns>
		public static bool HasValue(this IPublishedContent source, [CallerMemberName] string propertyName = null)
			=> Umbraco.Web.PublishedContentExtensions.HasValue(source, propertyName);

		/// <summary>
		/// Returns value of the property with given <paramref name="propertyName"/> from the <paramref name="source"/>.
		/// </summary>
		/// <remarks>
		/// This method is exactly the same as Umbraco's own <see cref="PublishedContentExtensions.GetPropertyValue(IPublishedContent, string)"/>,
		/// except this one will deduce property name from the caller's context, if name is omitted.
		/// </remarks>
		/// <param name="source">The source.</param>
		/// <param name="propertyName">Property name.</param>
		/// <returns>Value of the property with given <paramref name="propertyName"/>.</returns>
		public static object GetPropertyValue(this IPublishedContent source, [CallerMemberName] string propertyName = null)
			=> Umbraco.Web.PublishedContentExtensions.GetPropertyValue(source, propertyName);

		/// <summary>
		/// Returns value of the property with given <paramref name="propertyName"/> from the <paramref name="source"/>.
		/// </summary>
		/// <remarks>
		/// This method is exactly the same as Umbraco's own <see cref="PublishedContentExtensions.GetPropertyValue{T}(IPublishedContent, string)"/>,
		/// except this one will deduce property name from the caller's context, if name is omitted.
		/// </remarks>
		/// <typeparam name="T">Expected type of the property value.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="propertyName">Property name.</param>
		/// <returns>Value of the property with given <paramref name="propertyName"/>.</returns>
		public static T GetPropertyValue<T>(this IPublishedContent source, [CallerMemberName] string propertyName = null)
			=> Umbraco.Web.PublishedContentExtensions.GetPropertyValue<T>(source, propertyName);

		/// <summary>
		/// Returns value of the property with given <paramref name="propertyName"/> from the <paramref name="source"/>,
		/// or provided <paramref name="defaultValue"/> if property is not found or value is not assigned to it.
		/// </summary>
		/// <remarks>
		/// This method is exactly the same as Umbraco's own <see cref="PublishedContentExtensions.GetPropertyValue{T}(IPublishedContent, string, T)"/>,
		/// except this one will deduce property name from the caller's context, if name is omitted.
		/// </remarks>
		/// <typeparam name="T">Expected type of the property value.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="defaultValue">Default value that will be returned if property or its value are not found.</param>
		/// <param name="propertyName">Property name.</param>
		/// <returns>Value of the property with given <paramref name="propertyName"/> or <paramref name="defaultValue"/> if property or its value are not found.</returns>
		public static T GetPropertyWithDefaultValue<T>(this IPublishedContent source, T defaultValue, [CallerMemberName] string propertyName = null)
			=> source.GetPropertyValue<T>(propertyName, defaultValue);

		/// <summary>
		/// Returns value of the property with given <paramref name="propertyName"/> from the <paramref name="source"/>,
		/// or creates default value by using provided <paramref name="defaultValueFactory"/> if property is not found or value is not assigned to it.
		/// </summary>
		/// <typeparam name="T">Expected type of the property value.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="defaultValueFactory">Default value factory that will be used if property or its value are not found.</param>
		/// <param name="propertyName">Property name.</param>
		/// <returns>Value of the property with given <paramref name="propertyName"/> or value returned by <paramref name="defaultValueFactory"/> if property or its value are not found.</returns>
		public static T GetPropertyWithDefaultValue<T>(this IPublishedContent source, Func<T> defaultValueFactory, [CallerMemberName] string propertyName = null)
			=> source.HasValue(propertyName) ? source.GetPropertyValue<T>(propertyName) : defaultValueFactory();
	}
}
