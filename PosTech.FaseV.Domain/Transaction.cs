using System.ComponentModel.DataAnnotations.Schema;

namespace PosTech.FaseV.Domain
{
    public class Transaction : BaseAuditableEntity
    {
        protected Transaction() { }
        public Transaction(TrasactionType trasactionType, decimal amount, decimal price, Portfolio portfolio, Asset asset)
        {
            TrasactionType = trasactionType;
            Amount = amount;
            Price = price;
            Portfolio = portfolio;
            Asset = asset;
        }

        public TrasactionType TrasactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("PortfolioId")]
        public virtual Portfolio Portfolio { get; set; }

        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; }

    }
}
