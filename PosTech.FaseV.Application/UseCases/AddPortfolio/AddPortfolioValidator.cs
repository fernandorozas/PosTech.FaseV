using FluentValidation;

namespace PosTech.FaseV.Application.UseCases.AddPortfolio
{
    public class AddPortfolioValidator : AbstractValidator<AddPortfolioRequest>
    {
        public AddPortfolioValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(3).MaximumLength(150);
        }
    }
}
