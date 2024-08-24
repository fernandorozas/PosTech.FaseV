using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.DeletePortfolio
{
    public class DeletePortfolioValidator : AbstractValidator<DeletePortfolioRequest>
    {
        public DeletePortfolioValidator()
        {
            RuleFor(x => x.PortfolioId).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
