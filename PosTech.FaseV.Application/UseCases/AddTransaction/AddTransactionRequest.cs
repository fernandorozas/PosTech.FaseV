using MediatR;
using PosTech.FaseV.Domain;

namespace PosTech.FaseV.Application.UseCases.AddTransaction
{
    public class AddTransactionRequest : IRequest
    {
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int PortfolioId { get; set; }
        public int AssetId { get; set; }
    }
}
