using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.UpdatePortfolio
{
    public class UpdatePortfolioValidator : AbstractValidator<UpdatePortfolioRequest>
    {
        public UpdatePortfolioValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(3).MaximumLength(150);
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
