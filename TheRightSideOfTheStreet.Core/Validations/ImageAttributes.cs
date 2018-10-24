using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;

namespace TheRightSideOfTheStreet.Core.Validations
{
	public class ImageExtensionsAttribute : ValidationAttribute, IClientValidatable
	{
		private List<string> AllowedExtensions { get; set; }

		public ImageExtensionsAttribute()
		{
			string fileExtensions = AppSettings.ImageExtensions;
			AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
		}

		public override bool IsValid(object value)
		{
			HttpPostedFileBase file = value as HttpPostedFileBase;

			if (file != null)
			{
				var fileName = file.FileName;
				ErrorMessage = string.Format("Only image file allowed");
				return AllowedExtensions.Any(y => fileName.EndsWith(y));
			}

			return true;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			var error = FormatErrorMessage(metadata.DisplayName);
			var rule = new ModelClientValidationRule
			{
				ErrorMessage = error,
				ValidationType = "imageextensions"
			};

			yield return rule;
		}
	}

	public class MaxFileSizeAttribute : ValidationAttribute, IClientValidatable
	{
		private double MaxFileSize { get; set; }
		private const int denumerator = 1048576;

		public MaxFileSizeAttribute(double fileSize)
		{
			MaxFileSize = fileSize * 1024 * 1024;
		}

		public override bool IsValid(object value)
		{
			HttpPostedFileBase file = value as HttpPostedFileBase;

			if (file != null)
			{
				ErrorMessage = string.Format("File is too large, maximum allowed is: {0:0.0} MB", Math.Ceiling((decimal)MaxFileSize / denumerator));
				return file.ContentLength <= MaxFileSize;
			}

			return true;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			var error = FormatErrorMessage(metadata.DisplayName);
			var rule = new ModelClientValidationRule
			{
				ErrorMessage = error,
				ValidationType = "maxfilesize"
			};

			yield return rule;
		}
	}
}