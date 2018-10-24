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
	/// <summary>Blog Details</summary>
	[PublishedContentModel("blogDetails")]
	public partial class BlogDetails
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "blogDetails";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public BlogDetails(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<BlogDetails, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Date
		///</summary>
		[ImplementPropertyType("date")]
		public DateTime Date
		{
			get { return this.GetPropertyValue<DateTime>("date"); }
		}

		///<summary>
		/// Preview Text
		///</summary>
		[ImplementPropertyType("previewText")]
		public string PreviewText
		{
			get { return this.GetPropertyValue<string>("previewText"); }
		}

		///<summary>
		/// Text: Blog details
		///</summary>
		[ImplementPropertyType("text")]
		public IHtmlString Text
		{
			get { return this.GetPropertyValue<IHtmlString>("text"); }
		}
	}
}
