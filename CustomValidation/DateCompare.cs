using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoManagment.CustomValidation
{
    public class DateCompare(string VDateFrom) : ValidationAttribute
    {
        private readonly string _VDateFrom = VDateFrom;
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_VDateFrom);

            var comparisonValue = propertyInfo?.GetValue(validationContext.ObjectInstance) as DateTime?;

            if (value is DateTime dateValue && comparisonValue.HasValue)
            {
                if (dateValue > comparisonValue)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage ?? $"The {validationContext.DisplayName} must be greater than {_VDateFrom}");
                }
            }
            return new ValidationResult($"Invalid comparison");
        }
    }
}