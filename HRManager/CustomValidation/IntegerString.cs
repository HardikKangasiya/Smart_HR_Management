using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HRManager.CustomValidation
{
    public class IntegerStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int i;
            var isValid = int.TryParse(Convert.ToString(value), out i);
            return (isValid);
        }
    }

    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string phoneNumber = value.ToString();
                // This pattern checks for exactly 10 digits.
                string pattern = @"^\d{10}$";
                Regex regex = new Regex(pattern);
                if (!regex.IsMatch(phoneNumber))
                {
                    return new ValidationResult("Invalid phone number. Phone number must be exactly 10 digits.");
                }
            }
            return ValidationResult.Success;
        }
    }

}