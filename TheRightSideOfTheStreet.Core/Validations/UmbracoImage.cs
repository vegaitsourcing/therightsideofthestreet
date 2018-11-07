using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;

namespace TheRightSideOfTheStreet.Core.Validations
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class ImageExtensionsAttribute : ValidationAttribute, IClientValidatable
	{
		private static readonly string regex = AppSettings.ImageExtensions;
		private static Regex _regex = new Regex(regex, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

		/// <summary>
		/// 
		/// </summary>
		public string ErrorMessageDictionaryKey { get; set; }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			HttpPostedFileBase file = value as HttpPostedFileBase;
			var imageName = file.FileName;
			if (!string.IsNullOrEmpty(imageName))
			{
				//Test the regex
				var result = _regex.Match(imageName).Length > 0;

				//If no matches then email NOT valid
				if (!result)
				{
					//Get the error message to return
					var error = UmbracoValidationHelper.FormatErrorMessage(validationContext.DisplayName, ErrorMessageDictionaryKey);

					//Return error
					return new ValidationResult(error);
				}
			}

			//All good :)
			return ValidationResult.Success;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			var error = UmbracoValidationHelper.FormatErrorMessage(metadata.DisplayName, ErrorMessageDictionaryKey);
			var rule = new ModelClientValidationRule
			{
				ErrorMessage = error,
				ValidationType = "imagevalid"
			};

			rule.ValidationParameters["imageregex"] = _regex.ToString();

			yield return rule;

		}
	}

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class FileSizeAttribute : ValidationAttribute, IClientValidatable
	{
		private double? MaxMB { get; set; }
		private const int denumerator = 1048576;
		public string _errorMessageDictionaryKey { get; set; }

		public FileSizeAttribute(double maxMB, string errorMessageDictionaryKey)
			: base("Please upload a supported file.")
		{
			MaxMB = maxMB * denumerator;// convert to Mb
			_errorMessageDictionaryKey = errorMessageDictionaryKey;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			HttpPostedFileBase file = value as HttpPostedFileBase;

			if (file != null)
			{
				if (file.ContentLength > MaxMB.Value)
				{
					//Get the error message to return
					var error = UmbracoValidationHelper.FormatErrorMessage(validationContext.DisplayName, _errorMessageDictionaryKey);

					//Return error
					return new ValidationResult(error);
				}
			}

			return ValidationResult.Success;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metaData, ControllerContext context)
		{
			var error = UmbracoValidationHelper.FormatErrorMessage((MaxMB / denumerator).ToString(), _errorMessageDictionaryKey);

			var rule = new ModelClientValidationRule
			{
				ValidationType = "filesize",
				ErrorMessage = error
			};
			rule.ValidationParameters["maxsize"] = MaxMB;
			yield return rule;
		}
	}

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
	public class ListFileSizeAttribute : ValidationAttribute, IClientValidatable
	{
		private double? MaxMB { get; set; }
		private const int denumerator = 1048576;
		public string _errorMessageDictionaryKey { get; set; }

		public ListFileSizeAttribute(double maxMB, string errorMessageDictionaryKey)
			: base("Please upload a supported file.")
		{
			MaxMB = maxMB * denumerator;// convert to Mb
			_errorMessageDictionaryKey = errorMessageDictionaryKey;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			IEnumerable<HttpPostedFileBase> files = value as IEnumerable<HttpPostedFileBase>;

			foreach (HttpPostedFileBase file in files)
			{

				if (file != null)
				{
					if (file.ContentLength > MaxMB.Value)
					{
						//Get the error message to return
						var error = UmbracoValidationHelper.FormatErrorMessage(validationContext.DisplayName, _errorMessageDictionaryKey);

						//Return error
						return new ValidationResult(error);
					}
				}
			}
			return ValidationResult.Success;

		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metaData, ControllerContext context)
		{
			var error = UmbracoValidationHelper.FormatErrorMessage((MaxMB / denumerator).ToString(), _errorMessageDictionaryKey);

			var rule = new ModelClientValidationRule
			{
				ValidationType = "filesize",
				ErrorMessage = error
			};
			rule.ValidationParameters["maxsize"] = MaxMB;
			yield return rule;
		}
	}
}