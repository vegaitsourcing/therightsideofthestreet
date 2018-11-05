using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TheRightSideOfTheStreet.Core.Validations
{
    public class UmbracoStringLength : StringLengthAttribute, IClientValidatable
    {
        private readonly string _errorMessageDictionaryKey;


        public UmbracoStringLength(string errorMessageDictionaryKey, int maximumLength) : base(maximumLength)
        {
            _errorMessageDictionaryKey = errorMessageDictionaryKey;
        }

		public UmbracoStringLength(string errorMessageDictionaryKey, int maximumLength, int minimumLength) : base(maximumLength)
		{
			_errorMessageDictionaryKey = errorMessageDictionaryKey;
		}


		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(_errorMessageDictionaryKey);

            var error   = FormatErrorMessage(metadata.DisplayName);
            var rule    = new ModelClientValidationStringLengthRule(error, MinimumLength, MaximumLength);

            yield return rule;
        }
    }
}
