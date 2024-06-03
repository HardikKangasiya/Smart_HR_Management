using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
}