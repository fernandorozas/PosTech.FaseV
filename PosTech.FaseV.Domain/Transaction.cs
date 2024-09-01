using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosTech.FaseV.Domain
{
    public class Transaction : BaseAuditableEntity
    {
        protected Transaction() { }
        public Transaction(int transactionType, decimal amount, decimal price, Portfolio portfolio, Asset asset)
        {
            TransactionType = (TransactionType)transactionType;
            Amount = amount;
            Price = price;
            Portfolio = portfolio;
            Asset = asset;
        }

        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("PortfolioId")]
        public virtual Portfolio Portfolio { get; set; }

        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; }

       /* protected override void Validate()
        {
            ValidationResult = new ValidatorTransactionValido().Validate(this);
        } */

        public class ValidatorTransactionValido : AbstractValidator<Transaction>
        {
            public ValidatorTransactionValido()
            {
                RuleFor(x => x.TransactionType)
                    .IsInEnum()
                    .WithMessage("TransactionType deve ser um valor válido de TransactionType.");

                RuleFor(x => x.Amount)
                    .GreaterThan(0)
                    .WithMessage("Amount deve ser maior que zero.");

                RuleFor(x => x.Price)
                    .GreaterThan(0)
                    .WithMessage("Price deve ser maior que zero.");

                RuleFor(x => x.Portfolio)
                    .NotNull()
                    .WithMessage("Portfolio é obrigatório.");

                RuleFor(x => x.Asset)
                    .NotNull()
                    .WithMessage("Asset é obrigatório.");
            }
        }



    }
}
