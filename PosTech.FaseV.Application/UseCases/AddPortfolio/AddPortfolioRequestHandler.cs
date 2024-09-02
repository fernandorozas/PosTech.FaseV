using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Domain;

namespace PosTech.FaseV.Application.UseCases.AddPortfolio
{
    public class AddPortfolioRequestHandler : RequestHandlerBase, IRequestHandler<AddPortfolioRequest>
    {

        private readonly IRepositoryPortfolio _repositoryPortfolio;
        private readonly IValidator<AddPortfolioRequest> _validator;

        public AddPortfolioRequestHandler(IRepositoryPortfolio repositoryPortfolio, IValidator<AddPortfolioRequest> validator, INotificator notificator) : base(notificator) 
        {
            _repositoryPortfolio = repositoryPortfolio;
            _validator = validator;
        }

        public async Task Handle(AddPortfolioRequest request, CancellationToken cancellationToken)
        {
            if (!ExecValidation(_validator, request)) return;
            var portfolio = new Portfolio(request.UserId, request.Name, request.Description);
            await _repositoryPortfolio.AddAsync(portfolio);
        }
    }
}
