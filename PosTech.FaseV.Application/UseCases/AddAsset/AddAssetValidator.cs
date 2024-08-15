using FluentValidation;

namespace PosTech.FaseV.Application.UseCases.AddAsset
{
    public class AddAssetValidator : AbstractValidator<AddAssetRequest>
    {
        public AddAssetValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Code).NotEmpty().MinimumLength(3).MaximumLength(6);
            RuleFor(x => x.Type).GreaterThanOrEqualTo(1).LessThanOrEqualTo(3);
        }
    }
}
