using FluentValidation;
using PosTech.FaseV.Domain;

namespace PosTech.FaseV.Application.UseCases.AddTransaction
{
    public class AddTransactionValidator : AbstractValidator<AddTransactionRequest>
    {
        public AddTransactionValidator()
        {
            RuleFor(x => x.Type).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PortfolioId).NotNull();
            RuleFor(x => x.AssetId).NotNull();
        }
    }
}
