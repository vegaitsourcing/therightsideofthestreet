using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.App_Start;
using TheRightSideOfTheStreet.Core.EmailSender;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Routing;

namespace TheRightSideOfTheStreet.Core
{
	public class ApplicationEventsHandler : ApplicationEventHandler
	{
		protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarting(umbracoApplication, applicationContext);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			ViewEngines.Engines.Add(new PartialViewEngine());
			ContentFinderResolver.Current.InsertType<AthleteMemberContentFinder>();
			ContentFinderResolver.Current.InsertType<AdminContentFinder>();
			ContentFinderResolver.Current.InsertTypeBefore<ContentFinderByNotFoundHandlers, My404ContentFinder>();
		}

		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			MemberService.Saving += MemberServiceSaving;
		}

		// Before a member is saved
		private void MemberServiceSaving(IMemberService sender, SaveEventArgs<IMember> e)
		{
			foreach (IMember member in e.SavedEntities)
			{
				//Member is not approved, dont send an email at all
				if (!member.IsApproved)
					continue;

				var currentMemberValues = ApplicationContext.Current.Services.MemberService.GetById(member.Id);

				if (currentMemberValues == null)
					continue;

				//Pull the old approval state from the member service, this is the value before the save has updated the cache.				
				if (currentMemberValues.IsApproved != member.IsApproved)
				{
					//Member wasn't approved before save but is now
					EmailHandler emailSender = new EmailHandler();

					emailSender.TrySendRegistrationMail(member, AppSettings.AdminEmailAdress);
				}
			}
		}
	}
}
