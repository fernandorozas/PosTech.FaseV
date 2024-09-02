using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Results;

namespace PosTech.FaseV.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }
        protected virtual void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
