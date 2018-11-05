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
	/// <summary>Exercise Group</summary>
	[PublishedContentModel("exerciseGroup")]
	public partial class ExerciseGroup : Page
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "exerciseGroup";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ExerciseGroup(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ExerciseGroup, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Highlight Title
		///</summary>
		[ImplementPropertyType("highlightTitle")]
		public string HighlightTitle
		{
			get { return this.GetPropertyValue<string>("highlightTitle"); }
		}

		///<summary>
		/// Highlight Video: ensure the URL contains embed rather watch as the /embed
		///</summary>
		[ImplementPropertyType("highlightVideo")]
		public string HighlightVideo
		{
			get { return this.GetPropertyValue<string>("highlightVideo"); }
		}
	}
}
