using MediatR;

namespace PosTech.FaseV.Application.UseCases.AddPortfolio
{
    public class AddPortfolioRequest : IRequest
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
