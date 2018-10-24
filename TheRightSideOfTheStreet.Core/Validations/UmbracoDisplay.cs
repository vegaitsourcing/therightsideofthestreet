using System;
using System.ComponentModel;
using TheRightSideOfTheStreet.Core.Validations;

namespace TheRightSideOfTheStreet.Core.Validations
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class UmbracoDisplayName : DisplayNameAttribute
    {
        private readonly string _dictionaryKey;

        // This is a positional argument
        public UmbracoDisplayName(string dictionaryKey)
        {
            _dictionaryKey = dictionaryKey;
        }

        public override string DisplayName
        {
            get
            {
                return UmbracoValidationHelper.UmbracoHelper.GetDictionaryValue(_dictionaryKey);
            }
        }
    }
}
