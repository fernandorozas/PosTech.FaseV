using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.DeleteAsset
{
    public class DeleteAssetValidator : AbstractValidator<DeleteAssetRequest>
    {
        public DeleteAssetValidator()
        {
            RuleFor(x => x.AssetId).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
