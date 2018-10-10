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
	/// <summary>Video And Text Module</summary>
	[PublishedContentModel("videoAndTextModule")]
	public partial class VideoAndTextModule : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "videoAndTextModule";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public VideoAndTextModule(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<VideoAndTextModule, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Buttons
		///</summary>
		[ImplementPropertyType("buttons")]
		public IEnumerable<RJP.MultiUrlPicker.Models.Link> Buttons
		{
			get { return this.GetPropertyValue<IEnumerable<RJP.MultiUrlPicker.Models.Link>>("buttons"); }
		}

		///<summary>
		/// Is Video Right
		///</summary>
		[ImplementPropertyType("isVideoRight")]
		public bool IsVideoRight
		{
			get { return this.GetPropertyValue<bool>("isVideoRight"); }
		}

		///<summary>
		/// Text
		///</summary>
		[ImplementPropertyType("text")]
		public IHtmlString Text
		{
			get { return this.GetPropertyValue<IHtmlString>("text"); }
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
		/// Video Url
		///</summary>
		[ImplementPropertyType("videoUrl")]
		public string VideoUrl
		{
			get { return this.GetPropertyValue<string>("videoUrl"); }
		}
	}
}
