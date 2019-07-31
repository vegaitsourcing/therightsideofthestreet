﻿using RJP.MultiUrlPicker.Models;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace TheRightSideOfTheStreet.Models.DocumentTypes
{
	/// <summary>
	/// Marks document type model classes that represent site pages.
	/// </summary>
	public interface IPage : IPublishedContent
	{
        string Title { get; }
		string SeoTitle { get; }
		string SeoDescription { get; }
		Link CanonicalLink { get; }
		IEnumerable<IPage> AlternatePages { get; }
		string OGtitle { get; }
		string OGdescription { get; }
		Image OGimage { get; }
        
        bool HideFromSiteNavigation { get; }
        bool HideFromSearchEngines { get; }
		string SitemapChangeFrequency { get; }
		string SitemapPriority { get; }
	}
}
