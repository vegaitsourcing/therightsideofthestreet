//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace TheRightSideOfTheStreet.Models
{
	/// <summary>Page</summary>
	[PublishedContentModel("page")]
	public partial class Page
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "page";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Page, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Canonical Link
		///</summary>
		[ImplementPropertyType("canonicalLink")]
		public RJP.MultiUrlPicker.Models.Link CanonicalLink
		{
			get { return this.GetPropertyValue<RJP.MultiUrlPicker.Models.Link>("canonicalLink"); }
		}

		///<summary>
		/// OG Description: short text used when sharing a page  The description should be at least 100 characters long in order to be displayed on LinkedIn.
		///</summary>
		[ImplementPropertyType("oGDescription")]
		public string OGdescription
		{
			get { return this.GetPropertyValue<string>("oGDescription"); }
		}

		///<summary>
		/// OG Title: title used when sharing a page
		///</summary>
		[ImplementPropertyType("oGTitle")]
		public string OGtitle
		{
			get { return this.GetPropertyValue<string>("oGTitle"); }
		}

		///<summary>
		/// Seo Description: The page SEO description.
		///</summary>
		[ImplementPropertyType("seoDescription")]
		public string SeoDescription
		{
			get { return this.GetPropertyValue<string>("seoDescription"); }
		}

		///<summary>
		/// Seo Title: The page SEO title.
		///</summary>
		[ImplementPropertyType("seoTitle")]
		public string SeoTitle
		{
			get { return this.GetPropertyValue<string>("seoTitle"); }
		}

		///<summary>
		/// Umbraco Redirect
		///</summary>
		[ImplementPropertyType("umbracoRedirect")]
		public IPublishedContent UmbracoRedirect
		{
			get { return this.GetPropertyValue<IPublishedContent>("umbracoRedirect"); }
		}

		///<summary>
		/// Umbraco Url Alias
		///</summary>
		[ImplementPropertyType("umbracoUrlAlias")]
		public string UmbracoUrlAlias
		{
			get { return this.GetPropertyValue<string>("umbracoUrlAlias"); }
		}

		///<summary>
		/// Umbraco Url Name
		///</summary>
		[ImplementPropertyType("umbracoUrlName")]
		public string UmbracoUrlName
		{
			get { return this.GetPropertyValue<string>("umbracoUrlName"); }
		}
	}
}
