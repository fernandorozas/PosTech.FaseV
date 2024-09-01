using PosTech.FaseV.Domain;
using TestProjectPostech.FaseV.Config;
using FluentAssertions;

namespace TestProjectPostech.FaseV.Domain
{
    [Collection(nameof(PosTechFaseVCollectionPortfolio))]
    public class PortfolioTeste
    {
        private readonly PortfolioFixture _fixtures;
        public PortfolioTeste(PortfolioFixture fixtures) => _fixtures = fixtures;

        [Trait("Categoria", "Portfolio Válido")]
        [Fact]
        public void Criar_Portfolio_Valido()
        {
            // Arrange
            var portfolio = _fixtures.Gerar_Portfolio_Valido();
            var validator = new ValidatorPortfolioValido();

            // Act
            var validationResult = validator.Validate(portfolio);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeTrue("Portfolio foi gerado com dados válidos");
            validationResult.Errors.Should().BeEmpty("não deve haver erros de validação para um portfolio válido");
        }

        [Trait("Categoria", "Portfolio Inválido")]
        [Fact]
        public void Criar_Portfolio_UserIdEmpty_Invalido()
        {
            // Arrange
            var portfolio = _fixtures.Gerar_Portfolio_UserIdEmpty_Invalido();
            var validator = new ValidatorPortfolioValido();

            // Act
            var validationResult = validator.Validate(portfolio);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Portfolio não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "UserId é obrigatório.");
        }

        [Trait("Categoria", "Portfolio Inválido")]
        [Fact]
        public void Criar_Portfolio_NameEmpty_Invalido()
        {
            // Arrange
            var portfolio = _fixtures.Gerar_Portfolio_NameEmpty_Invalido();
            var validator = new ValidatorPortfolioValido();

            // Act
            var validationResult = validator.Validate(portfolio);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Portfolio não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Name é obrigatório.");
        }

        [Trait("Categoria", "Portfolio Inválido")]
        [Fact]
        public void Criar_Portfolio_NameInvalido_Invalido()
        {
            // Arrange
            var portfolio = _fixtures.Gerar_Portfolio_NameInvalido_Invalido();
            var validator = new ValidatorPortfolioValido();

            // Act
            var validationResult = validator.Validate(portfolio);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Portfolio não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Name deve conter apenas caracteres alfanuméricos e espaços.");
        }

        [Trait("Categoria", "Portfolio Inválido")]
        [Fact]
        public void Criar_Portfolio_DescriptionMax150_Invalido()
        {
            // Arrange
            var portfolio = _fixtures.Gerar_Portfolio_DescriptionMax150_Invalido();
            var validator = new ValidatorPortfolioValido();

            // Act
            var validationResult = validator.Validate(portfolio);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Portfolio não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Description deve ter no máximo 150 caracteres.");
        }

        [Trait("Categoria", "Portfolio Inválido")]
        [Fact]
        public void Criar_Portfolio_DescriptionEspacos_Invalido()
        {
            // Arrange
            var portfolio = _fixtures.Gerar_Portfolio_DescriptionEspacos_Invalido();
            var validator = new ValidatorPortfolioValido();

            // Act
            var validationResult = validator.Validate(portfolio);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Portfolio não foi gerado corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Description não pode ser apenas espaços em branco.");
        }
    }
}
