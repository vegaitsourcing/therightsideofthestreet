using System;
using System.Runtime.CompilerServices;
using System.Web.Caching;
using TheRightSideOfTheStreet.Common.Extensions;

namespace TheRightSideOfTheStreet.Models.Extensions
{
	/// <summary>
	/// Cache entry.
	/// </summary>
	/// <typeparam name="T">Type of the cached value.</typeparam>
	public class CacheEntry<T>
	{
		/// <summary>
		/// Creates new cache entry without expiration (permanent cache entry).
		/// </summary>
		/// <param name="value">Value that will be cached.</param>
		public CacheEntry(T value) : this(value, Cache.NoAbsoluteExpiration)
		{ }

		/// <summary>
		/// Creates new cache entry that will expire on specified <paramref name="expiration"/>.
		/// </summary>
		/// <param name="value">Value that will be cached.</param>
		/// <param name="expiration">Expiration timestamp for the cached value.</param>
		public CacheEntry(T value, DateTime expiration)
		{
			Value = value;
			Expiration = expiration;
		}

		/// <summary>
		/// Creates new cache entry that has specified <paramref name="duration"/>.
		/// </summary>
		/// <param name="value">Value that will be cached.</param>
		/// <param name="duration">Duration of the cached value.</param>
		public CacheEntry(T value, TimeSpan duration) : this(value, DateTime.UtcNow + duration)
		{ }

		/// <summary>
		/// Value that will be cached.
		/// </summary>
		public T Value { get; }

		/// <summary>
		/// Expiration timestamp for the cached value.
		/// </summary>
		public DateTime Expiration { get; }
	}

	/// <summary>
	/// HTTP <see cref="Cache"/> extension methods.
	/// </summary>
	public static class HttpCacheExtensions
	{
		/// <summary>
		/// Returns value with given <paramref name="cacheKey"/> from the cache.
		/// If <paramref name="cacheKey"/> is not in the cache, specified <paramref name="valueFactory"/> will be invoked to return a value that will be cached under given <paramref name="cacheKey"/>.
		/// </summary>
		/// <typeparam name="T">Type of the cached value.</typeparam>
		/// <param name="cache">The cache.</param>
		/// <param name="valueFactory">Function that will be invoked if given <paramref name="cacheKey"/> is not in the cache.</param>
		/// <param name="cacheKey">The key that the value is (will be) stored under.</param>
		/// <returns>Value that is cached under given <paramref name="cacheKey"/>.</returns>
		public static T GetCachedValue<T>(this Cache cache, Func<T> valueFactory, [CallerMemberName] string cacheKey = null)
		{
			if (valueFactory == null) throw new ArgumentNullException(nameof(valueFactory));

			return cache.GetCachedValue(() => new CacheEntry<T>(valueFactory()), cacheKey);
		}

		/// <summary>
		/// Returns value with given <paramref name="cacheKey"/> from the cache.
		/// If <paramref name="cacheKey"/> is not in the cache, specified <paramref name="valueFactory"/> will be invoked to return a value that will be cached under given <paramref name="cacheKey"/>.
		/// </summary>
		/// <typeparam name="T">Type of the cached value.</typeparam>
		/// <param name="cache">The cache.</param>
		/// <param name="valueFactory">Function that will be invoked if given <paramref name="cacheKey"/> is not in the cache.</param>
		/// <param name="valueExpiration">Expiration timestamp for the cached value.</param>
		/// <param name="cacheKey">The key that the value is (will be) stored under.</param>
		/// <returns>Value that is cached under given <paramref name="cacheKey"/>.</returns>
		public static T GetCachedValue<T>(this Cache cache, Func<T> valueFactory, DateTime valueExpiration, [CallerMemberName] string cacheKey = null)
		{
			if (valueFactory == null) throw new ArgumentNullException(nameof(valueFactory));

			return cache.GetCachedValue(() => new CacheEntry<T>(valueFactory(), valueExpiration), cacheKey);
		}

		/// <summary>
		/// Returns value with given <paramref name="cacheKey"/> from the cache.
		/// If <paramref name="cacheKey"/> is not in the cache, specified <paramref name="valueFactory"/> will be invoked to return a value that will be cached under given <paramref name="cacheKey"/>.
		/// </summary>
		/// <typeparam name="T">Type of the cached value.</typeparam>
		/// <param name="cache">The cache.</param>
		/// <param name="valueFactory">Function that will be invoked if given <paramref name="cacheKey"/> is not in the cache.</param>
		/// <param name="valueDuration">Duration of the cached value.</param>
		/// <param name="cacheKey">The key that the value is (will be) stored under.</param>
		/// <returns>Value that is cached under given <paramref name="cacheKey"/>.</returns>
		public static T GetCachedValue<T>(this Cache cache, Func<T> valueFactory, TimeSpan valueDuration, [CallerMemberName] string cacheKey = null)
		{
			if (valueFactory == null) throw new ArgumentNullException(nameof(valueFactory));

			return cache.GetCachedValue(() => new CacheEntry<T>(valueFactory(), valueDuration), cacheKey);
		}

		/// <summary>
		/// Returns value with given <paramref name="cacheKey"/> from the cache.
		/// If <paramref name="cacheKey"/> is not in the cache, specified <paramref name="cacheEntryFactory"/> will be invoked to return a cache entry that will be stored under given <paramref name="cacheKey"/>.
		/// Value will be stored in the cache until returned expiration time.
		/// </summary>
		/// <typeparam name="T">Type of the cached value.</typeparam>
		/// <param name="cache">The cache.</param>
		/// <param name="cacheEntryFactory">Function that will be invoked if given <paramref name="cacheKey"/> is not in the cache.</param>
		/// <param name="cacheKey">The key that the value is (will be) stored under.</param>
		/// <returns>Value that is cached under given <paramref name="cacheKey"/>.</returns>
		public static T GetCachedValue<T>(this Cache cache, Func<CacheEntry<T>> cacheEntryFactory, [CallerMemberName] string cacheKey = null)
		{
			if (cacheEntryFactory == null) throw new ArgumentNullException(nameof(cacheEntryFactory));
			if (cacheKey.IsNullOrWhiteSpace()) throw new ArgumentException("Cache key value is mandatory!", nameof(cacheKey));

			// Cache is a global object, so locking is necessary to prevent racing condition
			lock (cacheGuard)
			{
				object cachedValue = cache[cacheKey];

				// Only non-null objects are treated as cached
				if (cachedValue != null)
				{
					return (T)cachedValue;
				}

				CacheEntry<T> entry = cacheEntryFactory();

				// WARNING: Insert will throw if entry.Value is null!
				cache.Insert(cacheKey, entry.Value, null, entry.Expiration, Cache.NoSlidingExpiration);

				return entry.Value;
			}
		}

		private static readonly object cacheGuard = new object();
	}
}
