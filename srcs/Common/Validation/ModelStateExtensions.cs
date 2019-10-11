using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Common.Validation
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrorsFrom(this ModelStateDictionary dictionary, IEnumerable<ValidationResult> results)
        {
            foreach (var error in results)
            {
                dictionary.AddModelError(error.MemberNames.First(), error.ErrorMessage);
            }
        }
    }
}
