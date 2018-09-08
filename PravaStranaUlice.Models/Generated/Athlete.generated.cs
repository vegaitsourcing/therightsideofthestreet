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

namespace PravaStranaUlice.Models
{
	/// <summary>Athlete</summary>
	[PublishedContentModel("athlete")]
	public partial class Athlete : PublishedContentModel, IPage
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "athlete";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Athlete(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Athlete, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// About
		///</summary>
		[ImplementPropertyType("about")]
		public string About
		{
			get { return this.GetPropertyValue<string>("about"); }
		}

		///<summary>
		/// Achievements
		///</summary>
		[ImplementPropertyType("achievements")]
		public IEnumerable<string> Achievements
		{
			get { return this.GetPropertyValue<IEnumerable<string>>("achievements"); }
		}

		///<summary>
		/// Facebook Url
		///</summary>
		[ImplementPropertyType("facebookUrl")]
		public string FacebookUrl
		{
			get { return this.GetPropertyValue<string>("facebookUrl"); }
		}

		///<summary>
		/// Images
		///</summary>
		[ImplementPropertyType("images")]
		public IEnumerable<IPublishedContent> Images
		{
			get { return this.GetPropertyValue<IEnumerable<IPublishedContent>>("images"); }
		}

		///<summary>
		/// Instagram Url
		///</summary>
		[ImplementPropertyType("instagramUrl")]
		public string InstagramUrl
		{
			get { return this.GetPropertyValue<string>("instagramUrl"); }
		}

		///<summary>
		/// Profile Image
		///</summary>
		[ImplementPropertyType("profileImage")]
		public IPublishedContent ProfileImage
		{
			get { return this.GetPropertyValue<IPublishedContent>("profileImage"); }
		}

		///<summary>
		/// Sport Vision
		///</summary>
		[ImplementPropertyType("sportVision")]
		public string SportVision
		{
			get { return this.GetPropertyValue<string>("sportVision"); }
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return this.GetPropertyValue<string>("title"); }
		}

		///<summary>
		/// YouTube Url
		///</summary>
		[ImplementPropertyType("youTubeUrl")]
		public string YouTubeUrl
		{
			get { return this.GetPropertyValue<string>("youTubeUrl"); }
		}

		///<summary>
		/// External Redirect
		///</summary>
		[ImplementPropertyType("externalRedirect")]
		public string ExternalRedirect
		{
			get { return PravaStranaUlice.Models.Page.GetExternalRedirect(this); }
		}

		///<summary>
		/// Facebook Image
		///</summary>
		[ImplementPropertyType("facebookImage")]
		public IPublishedContent FacebookImage
		{
			get { return PravaStranaUlice.Models.Page.GetFacebookImage(this); }
		}

		///<summary>
		/// Page Title
		///</summary>
		[ImplementPropertyType("pageTitle")]
		public string PageTitle
		{
			get { return PravaStranaUlice.Models.Page.GetPageTitle(this); }
		}

		///<summary>
		/// Seo Author
		///</summary>
		[ImplementPropertyType("seoAuthor")]
		public string SeoAuthor
		{
			get { return PravaStranaUlice.Models.Page.GetSeoAuthor(this); }
		}

		///<summary>
		/// Seo Description
		///</summary>
		[ImplementPropertyType("seoDescription")]
		public string SeoDescription
		{
			get { return PravaStranaUlice.Models.Page.GetSeoDescription(this); }
		}

		///<summary>
		/// Seo Keywords
		///</summary>
		[ImplementPropertyType("seoKeywords")]
		public string SeoKeywords
		{
			get { return PravaStranaUlice.Models.Page.GetSeoKeywords(this); }
		}

		///<summary>
		/// Seo Title
		///</summary>
		[ImplementPropertyType("seoTitle")]
		public string SeoTitle
		{
			get { return PravaStranaUlice.Models.Page.GetSeoTitle(this); }
		}

		///<summary>
		/// Hide From External Search: This property will hide pages from external search when they are set to true.
		///</summary>
		[ImplementPropertyType("umbracoExternalSearchHide")]
		public bool UmbracoExternalSearchHide
		{
			get { return PravaStranaUlice.Models.Page.GetUmbracoExternalSearchHide(this); }
		}

		///<summary>
		/// Hide From Site Navigation: This property will hide pages from the navigation when they are set to true.
		///</summary>
		[ImplementPropertyType("umbracoNavigationHide")]
		public bool UmbracoNavigationHide
		{
			get { return PravaStranaUlice.Models.Page.GetUmbracoNavigationHide(this); }
		}

		///<summary>
		/// Umbraco Redirect: Choose a node that you want the page to redirect to
		///</summary>
		[ImplementPropertyType("umbracoRedirect")]
		public IPublishedContent UmbracoRedirect
		{
			get { return PravaStranaUlice.Models.Page.GetUmbracoRedirect(this); }
		}

		///<summary>
		/// Umbraco Url Alias
		///</summary>
		[ImplementPropertyType("umbracoUrlAlias")]
		public string UmbracoUrlAlias
		{
			get { return PravaStranaUlice.Models.Page.GetUmbracoUrlAlias(this); }
		}

		///<summary>
		/// Umbraco Url Name
		///</summary>
		[ImplementPropertyType("umbracoUrlName")]
		public string UmbracoUrlName
		{
			get { return PravaStranaUlice.Models.Page.GetUmbracoUrlName(this); }
		}

		///<summary>
		/// Hide From XML Sitemap
		///</summary>
		[ImplementPropertyType("umbracoXmlSitemapHide")]
		public bool UmbracoXmlSitemapHide
		{
			get { return PravaStranaUlice.Models.Page.GetUmbracoXmlSitemapHide(this); }
		}
	}
}
