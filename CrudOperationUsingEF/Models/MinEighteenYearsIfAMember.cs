using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOperationUsingEF.Models
{
    public class MinEighteenYearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId==MembershipType.One||
               customer.MembershipTypeId==MembershipType.Zero)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required.");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer Should be at least 18 years old to go on a membership.");
        }
    }
}