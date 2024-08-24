using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.UpdateAsset
{
    public class UpdateAssetValidator : AbstractValidator<UpdateAssetRequest>
    {
        public UpdateAssetValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Code).NotEmpty().MinimumLength(3).MaximumLength(6);
            RuleFor(x => x.Type).GreaterThanOrEqualTo(1).LessThanOrEqualTo(3);
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
