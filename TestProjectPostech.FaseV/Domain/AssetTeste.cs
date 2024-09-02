using PosTech.FaseV.Domain;
using TestProjectPostech.FaseV.Config;
using FluentAssertions;


namespace TestProjectPostech.FaseV.Domain
{
    [Collection(nameof(PosTechFaseVCollectionAsset))]
    public class AssetTest
    {
        private readonly AssetFixture _fixtures;
        public AssetTest(AssetFixture fixtures) => _fixtures = fixtures;

        [Trait("Categoria", "Asset Válido")]
        [Fact]
        public void Criar_Asset_Valido()
        {
            // Arrange
            var asset = _fixtures.Gerar_Asset_Valido();
            var validator = new Asset.ValidatorAssetValido();

            // Act
            var validationResult = validator.Validate(asset);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeTrue("Asset foi gerado com dados válidos");
            validationResult.Errors.Should().BeEmpty("não deve haver erros de validação para um asset válido");
        }

        [Trait("Categoria", "Asset Inválido")]
        [Fact]
        public void Criar_Asset_NameEmpty_Invalido()
        {
            // Arrange
            var asset = _fixtures.Gerar_Asset_NameEmpty_Invalido();
            var validator = new Asset.ValidatorAssetValido();

            // Act
            var validationResult = validator.Validate(asset);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Asset não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Name é obrigatório.");
        }

        [Trait("Categoria", "Asset Inválido")]
        [Fact]
        public void Criar_Asset_CodeEmpty_Invalido()
        {
            // Arrange
            var asset = _fixtures.Gerar_Asset_CodeEmpty_Invalido();
            var validator = new Asset.ValidatorAssetValido();

            // Act
            var validationResult = validator.Validate(asset);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Asset não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Code é obrigatório.");
        }

        [Trait("Categoria", "Asset Inválido")]
        [Fact]
        public void Criar_Asset_CodeInvalido_Invalido()
        {
            // Arrange
            var asset = _fixtures.Gerar_Asset_CodeInvalido_Invalido();
            var validator = new Asset.ValidatorAssetValido();

            // Act
            var validationResult = validator.Validate(asset);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Asset não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Code deve conter apenas caracteres alfanuméricos.");
        }

        [Trait("Categoria", "Asset Inválido")]
        [Fact]
        public void Criar_Asset_CodMax6Caracteres_Invalido()
        {
            // Arrange
            var asset = _fixtures.Gerar_Asset_CodeMax6Caracteres_Invalido();
            var validator = new Asset.ValidatorAssetValido();

            // Act
            var validationResult = validator.Validate(asset);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Asset não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Code deve ter no máximo 6 caracteres.");
        }


        [Trait("Categoria", "Asset Inválido")]
        [Fact]
        public void Criar_Asset_AssetTypeInvalido_Invalido()
        {
            // Arrange
            var asset = _fixtures.Gerar_Asset_AssetTypeInvalido_Invalido();
            var validator = new Asset.ValidatorAssetValido();

            // Act
            var validationResult = validator.Validate(asset);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Asset não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "AssetType deve ser um valor válido de AssetType.");
        }
    }
}