using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Domain
{
    public class Asset : BaseAuditableEntity
    {
        protected Asset() {}
        public Asset(string name, int assetType, string code)
        {
            Name = name;
            AssetType = (AssetType)assetType;
            Code = code;
        }

        [MaxLength(100)]
        public string Name { get; set; }

        public AssetType AssetType { get; set; }

        [MaxLength(6)]
        public string Code { get; set; }


        public class ValidatorAssetValido : AbstractValidator<Asset>
        {
            public ValidatorAssetValido()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Name é obrigatório.")
                    .MaximumLength(100)
                    .WithMessage("Name deve ter no máximo 100 caracteres.")
                    .Matches("^[a-zA-Z0-9 ]*$")
                    .WithMessage("Name deve conter apenas caracteres alfanuméricos e espaços.");

                RuleFor(x => x.AssetType)
                    .IsInEnum()
                    .WithMessage("AssetType deve ser um valor válido de AssetType.");

                RuleFor(x => x.Code)
                    .NotEmpty()
                    .WithMessage("Code é obrigatório.")
                    .MaximumLength(6)
                    .WithMessage("Code deve ter no máximo 6 caracteres.")
                    .Matches("^[a-zA-Z0-9]*$")
                    .WithMessage("Code deve conter apenas caracteres alfanuméricos.");
            }
        }

    }
}
