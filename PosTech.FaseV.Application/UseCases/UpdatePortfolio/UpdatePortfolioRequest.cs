using MediatR;

namespace PosTech.FaseV.Application.UseCases.UpdatePortfolio
{
    public class UpdatePortfolioRequest : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}