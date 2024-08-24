using MediatR;

namespace PosTech.FaseV.Application.UseCases.DeletePortfolio
{
    public class DeletePortfolioRequest : IRequest
    {
        public int PortfolioId { get; set; }

        public DeletePortfolioRequest(int portfolioId)
        {
            PortfolioId = portfolioId;
        }
    }
}
