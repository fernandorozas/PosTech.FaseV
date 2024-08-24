using MediatR;

namespace PosTech.FaseV.Application.UseCases.UpdateTransaction
{
    public class UpdateTransactionRequest : IRequest
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int PortfolioId { get; set; }
        public int AssetId { get; set; }
    }
}