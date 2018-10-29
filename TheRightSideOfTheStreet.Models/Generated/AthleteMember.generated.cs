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
	/// <summary>Athlete Member</summary>
	[PublishedContentModel("athleteMember")]
	public partial class AthleteMember : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "athleteMember";
		public new const PublishedItemType ModelItemType = PublishedItemType.Member;
#pragma warning restore 0109

		public AthleteMember(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<AthleteMember, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
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
		/// Biography
		///</summary>
		[ImplementPropertyType("biography")]
		public string Biography
		{
			get { return this.GetPropertyValue<string>("biography"); }
		}

		///<summary>
		/// City
		///</summary>
		[ImplementPropertyType("city")]
		public string City
		{
			get { return this.GetPropertyValue<string>("city"); }
		}

		///<summary>
		/// Country
		///</summary>
		[ImplementPropertyType("country")]
		public string Country
		{
			get { return this.GetPropertyValue<string>("country"); }
		}

		///<summary>
		/// Facebook Profile
		///</summary>
		[ImplementPropertyType("facebookProfile")]
		public string FacebookProfile
		{
			get { return this.GetPropertyValue<string>("facebookProfile"); }
		}

		///<summary>
		/// Full Name
		///</summary>
		[ImplementPropertyType("fullName")]
		public string FullName
		{
			get { return this.GetPropertyValue<string>("fullName"); }
		}

		///<summary>
		/// Instagram Profile
		///</summary>
		[ImplementPropertyType("instagramProfile")]
		public string InstagramProfile
		{
			get { return this.GetPropertyValue<string>("instagramProfile"); }
		}

		///<summary>
		/// Preview Facebook Profile
		///</summary>
		[ImplementPropertyType("previewFacebookProfile")]
		public string PreviewFacebookProfile
		{
			get { return this.GetPropertyValue<string>("previewFacebookProfile"); }
		}

		///<summary>
		/// Preview Full Name
		///</summary>
		[ImplementPropertyType("previewFullName")]
		public string PreviewFullName
		{
			get { return this.GetPropertyValue<string>("previewFullName"); }
		}

		///<summary>
		/// Preview Instagram Profile
		///</summary>
		[ImplementPropertyType("previewInstagramProfile")]
		public string PreviewInstagramProfile
		{
			get { return this.GetPropertyValue<string>("previewInstagramProfile"); }
		}

		///<summary>
		/// Preview Youtube Profile
		///</summary>
		[ImplementPropertyType("previewYoutubeProfile")]
		public string PreviewYoutubeProfile
		{
			get { return this.GetPropertyValue<string>("previewYoutubeProfile"); }
		}

		///<summary>
		/// Is Approved
		///</summary>
		[ImplementPropertyType("umbracoMemberApproved")]
		public bool UmbracoMemberApproved
		{
			get { return this.GetPropertyValue<bool>("umbracoMemberApproved"); }
		}

		///<summary>
		/// Comments
		///</summary>
		[ImplementPropertyType("umbracoMemberComments")]
		public string UmbracoMemberComments
		{
			get { return this.GetPropertyValue<string>("umbracoMemberComments"); }
		}

		///<summary>
		/// Failed Password Attempts
		///</summary>
		[ImplementPropertyType("umbracoMemberFailedPasswordAttempts")]
		public string UmbracoMemberFailedPasswordAttempts
		{
			get { return this.GetPropertyValue<string>("umbracoMemberFailedPasswordAttempts"); }
		}

		///<summary>
		/// Last Lockout Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastLockoutDate")]
		public string UmbracoMemberLastLockoutDate
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastLockoutDate"); }
		}

		///<summary>
		/// Last Login Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastLogin")]
		public string UmbracoMemberLastLogin
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastLogin"); }
		}

		///<summary>
		/// Last Password Change Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastPasswordChangeDate")]
		public string UmbracoMemberLastPasswordChangeDate
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastPasswordChangeDate"); }
		}

		///<summary>
		/// Is Locked Out
		///</summary>
		[ImplementPropertyType("umbracoMemberLockedOut")]
		public bool UmbracoMemberLockedOut
		{
			get { return this.GetPropertyValue<bool>("umbracoMemberLockedOut"); }
		}

		///<summary>
		/// Password Answer
		///</summary>
		[ImplementPropertyType("umbracoMemberPasswordRetrievalAnswer")]
		public string UmbracoMemberPasswordRetrievalAnswer
		{
			get { return this.GetPropertyValue<string>("umbracoMemberPasswordRetrievalAnswer"); }
		}

		///<summary>
		/// Password Question
		///</summary>
		[ImplementPropertyType("umbracoMemberPasswordRetrievalQuestion")]
		public string UmbracoMemberPasswordRetrievalQuestion
		{
			get { return this.GetPropertyValue<string>("umbracoMemberPasswordRetrievalQuestion"); }
		}

		///<summary>
		/// Vision
		///</summary>
		[ImplementPropertyType("vision")]
		public string Vision
		{
			get { return this.GetPropertyValue<string>("vision"); }
		}

		///<summary>
		/// Youtube Profile
		///</summary>
		[ImplementPropertyType("youtubeProfile")]
		public string YoutubeProfile
		{
			get { return this.GetPropertyValue<string>("youtubeProfile"); }
		}
	}
}
