using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.DeleteTransaction
{
    public class DeleteTransactionValidator : AbstractValidator<DeleteTransactionRequest>
    {
        public DeleteTransactionValidator()
        {
            RuleFor(x => x.TransactionId).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
