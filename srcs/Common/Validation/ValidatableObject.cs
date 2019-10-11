using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Common.Validation
{
    public abstract class ValidatableObject : IValidatableObject
    {
        [NotMapped]
        public bool IsValid => !this.ValidationResults.Any();

        [NotMapped]
        public IEnumerable<ValidationResult> ValidationResults => this.Validate();

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        private IEnumerable<ValidationResult> Validate()
        {
            return this.Validate(new ValidationContext(this));
        }
    }
}
