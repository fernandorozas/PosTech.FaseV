using FluentValidation;

namespace PosTech.FaseV.Application.UseCases.UpdateTransaction
{
    public class UpdateTransactionValidator : AbstractValidator<UpdateTransactionRequest>
    {
        public UpdateTransactionValidator()
        {
            RuleFor(x => x.Type).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PortfolioId).NotNull();
            RuleFor(x => x.AssetId).NotNull();
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
