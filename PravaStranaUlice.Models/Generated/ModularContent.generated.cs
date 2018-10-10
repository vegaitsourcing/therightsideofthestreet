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
	/// <summary>Modular Content</summary>
	[PublishedContentModel("modularContent")]
	public partial class ModularContent : Page, IBanner
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "modularContent";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ModularContent(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ModularContent, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Modules
		///</summary>
		[ImplementPropertyType("modules")]
		public IEnumerable<IPublishedContent> Modules
		{
			get { return this.GetPropertyValue<IEnumerable<IPublishedContent>>("modules"); }
		}

		///<summary>
		/// Banner Image: Note: Image dimensions should be
		///</summary>
		[ImplementPropertyType("bannerImage")]
		public IPublishedContent BannerImage
		{
			get { return PravaStranaUlice.Models.Banner.GetBannerImage(this); }
		}

		///<summary>
		/// Banner Link
		///</summary>
		[ImplementPropertyType("bannerLink")]
		public RJP.MultiUrlPicker.Models.Link BannerLink
		{
			get { return PravaStranaUlice.Models.Banner.GetBannerLink(this); }
		}

		///<summary>
		/// Banner Title
		///</summary>
		[ImplementPropertyType("bannerTitle")]
		public string BannerTitle
		{
			get { return PravaStranaUlice.Models.Banner.GetBannerTitle(this); }
		}
	}
}
