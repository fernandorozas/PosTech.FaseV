
using TestProjectPostech.FaseV.Config;
using PosTech.FaseV.Domain;
using FluentAssertions;

namespace TestProjectPostech.FaseV.Domain
{
    [Collection(nameof(PosTechFaseVCollectionTransaction))]
    public class TransactionTest
    {
        private readonly TransactionFixture _fixtures;
        public TransactionTest(TransactionFixture fixtures) => _fixtures = fixtures;

        [Trait("Categoria", "Transaction Válido")]
        [Fact]
        public void Criar_Transaction_Valida()
        {
            // Arrange
            var transaction = _fixtures.Gerar_Transaction_Valida();
            var validator = new Transaction.ValidatorTransactionValido();

            // Act
            var validationResult = validator.Validate(transaction);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeTrue("Transaction foi gerada com dados válidos");
            validationResult.Errors.Should().BeEmpty("não deve haver erros de validação para uma transaction válida");
        }

        [Trait("Categoria", "Transaction Inválido")]
        [Fact]
        public void Criar_Transaction_TransactionTypeInvalido()
        {
            // Arrange
            var transaction = _fixtures.Gerar_Transaction_TransactionTypeInvalido();
            var validator = new Transaction.ValidatorTransactionValido();

            // Act
            var validationResult = validator.Validate(transaction);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Transaction não foi gerada corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "TransactionType deve ser um valor válido de TransactionType.");
        }

        [Trait("Categoria", "Transaction Inválido")]
        [Fact]
        public void Criar_Transaction_AmountInvalido()
        {
            // Arrange
            var transaction = _fixtures.Gerar_Transaction_AmountInvalido();
            var validator = new Transaction.ValidatorTransactionValido();

            // Act
            var validationResult = validator.Validate(transaction);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Transaction não foi gerada corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Amount deve ser maior que zero.");
        }

        [Trait("Categoria", "Transaction Inválido")]
        [Fact]
        public void Criar_Transaction_PriceInvalido()
        {
            // Arrange
            var transaction = _fixtures.Gerar_Transaction_PriceInvalido();
            var validator = new Transaction.ValidatorTransactionValido();

            // Act
            var validationResult = validator.Validate(transaction);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Transaction não foi gerada corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Price deve ser maior que zero.");
        }

        [Trait("Categoria", "Transaction Inválido")]
        [Fact]
        public void Criar_Transaction_PortfolioNulo()
        {
            // Arrange
            var transaction = _fixtures.Gerar_Transaction_PortfolioNulo();
            var validator = new Transaction.ValidatorTransactionValido();

            // Act
            var validationResult = validator.Validate(transaction);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Transaction não foi gerada corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Portfolio é obrigatório.");
        }

        [Trait("Categoria", "Transaction Inválido")]
        [Fact]
        public void Criar_Transaction_AssetNulo()
        {
            // Arrange
            var transaction = _fixtures.Gerar_Transaction_AssetNulo();
            var validator = new Transaction.ValidatorTransactionValido();

            // Act
            var validationResult = validator.Validate(transaction);
            var isValid = validationResult.IsValid;

            // Assert
            isValid.Should().BeFalse("Transaction não foi gerada corretamente");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Asset é obrigatório.");
        }
    }
}
