using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Metadata;
using System.Web.Mvc;
using ModelMetadata = System.Web.Mvc.ModelMetadata;

namespace Deviation.Web.Models.CustomValidators
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {

        public string OtherProperty { get; set; }
        public string OtherPropertyDisplayName { get; set; }

        public DateGreaterThanAttribute(string otherProperty) : base("{0} måste komma efter {1}")
        {
            OtherProperty = otherProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, OtherPropertyDisplayName);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var firstComparable = value as IComparable;
            var secondComparable = GetSecondComparable(validationContext);
            if (firstComparable != null && secondComparable != null)
            {
                if (firstComparable.CompareTo(secondComparable) < 1)
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

        private IComparable GetSecondComparable(ValidationContext validationContext)
        {
            SetOtherPropertyDisplayName(validationContext);
            var propertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (propertyInfo == null)
                return null;
            var value = propertyInfo.GetValue(validationContext.ObjectInstance, null);
            return value as IComparable;
        }

        private void SetOtherPropertyDisplayName(ValidationContext validationContext)
        {
            var metadata = ModelMetadataProviders.Current.GetMetadataForProperty(
                null, validationContext.ObjectType, OtherProperty);
            if (metadata != null)
                OtherPropertyDisplayName = metadata.GetDisplayName();
            
        }
    }
}