﻿using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Models.Extensions;
using TheRightSideOfTheStreet.Models.MemberTypes;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class Admin : IAthleteMember
	{
		[ImplementPropertyType("profileImage")]
		public Image ProfileImage => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();

		[ImplementPropertyType("crew")]
		public Crew Crew => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.FirstOrDefault()?.OfType<Crew>();
	}
}
