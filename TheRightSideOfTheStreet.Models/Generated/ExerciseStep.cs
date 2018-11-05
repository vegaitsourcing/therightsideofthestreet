﻿using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models
{
	public partial class ExerciseStep : INestedContent
	{
		[ImplementPropertyType("image")]
		public Image Image => this.GetPropertyValue<IPublishedContent>()?.OfType<Image>();
	}
}
