using System.ComponentModel.DataAnnotations;
using FluentValidation;
using static PosTech.FaseV.Domain.Transaction;

namespace PosTech.FaseV.Domain
{
    public class Portfolio : BaseAuditableEntity
    {
        protected Portfolio() { }
        public Portfolio(string userId, string name, string description)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }

        [MaxLength(100)]
        public string UserId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }


        protected override void Validate()
        {
            ValidationResult = new ValidatorPortfolioValido().Validate(this);
        }

    }


    public class ValidatorPortfolioValido : AbstractValidator<Portfolio>
    {
        public ValidatorPortfolioValido()
        {
            RuleFor(x => x.UserId)
              .NotEmpty()
              .WithMessage("UserId é obrigatório.")
              .MaximumLength(100)
              .WithMessage("UserId deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name é obrigatório.")
                .MaximumLength(50)
                .WithMessage("Name deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(150)
                .WithMessage("Description deve ter no máximo 150 caracteres.");

            // Garantir que Name não contenha caracteres inválidos
            RuleFor(x => x.Name)
                .Matches("^[a-zA-Z0-9 ]*$")
                .WithMessage("Name deve conter apenas caracteres alfanuméricos e espaços.");

            // Garantir que Description seja uma descrição significativa se fornecida
            RuleFor(x => x.Description)
                .Must(description => description == null || !description.Trim().Equals(""))
                .WithMessage("Description não pode ser apenas espaços em branco.");
        }
    }
}
