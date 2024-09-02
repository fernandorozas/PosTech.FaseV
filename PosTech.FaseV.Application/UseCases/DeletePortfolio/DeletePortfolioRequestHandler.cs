using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;

namespace PosTech.FaseV.Application.UseCases.DeletePortfolio
{
    public class DeletePortfolioRequestHandler : RequestHandlerBase, IRequestHandler<DeletePortfolioRequest>
    {
        private readonly IRepositoryPortfolio _repositoryPortfolio;
        private readonly IValidator<DeletePortfolioRequest> _validator;

        public DeletePortfolioRequestHandler(IRepositoryPortfolio repositoryPortfolio, IValidator<DeletePortfolioRequest> validator, INotificator notificator) : base(notificator)
        {
            _repositoryPortfolio = repositoryPortfolio;
            _validator = validator;
        }

        public async Task Handle(DeletePortfolioRequest request, CancellationToken cancellationToken)
        {
           if (!ExecValidation(_validator, request)) return;

            var portfolio = await _repositoryPortfolio.GetByIdAsync(request.PortfolioId);
            if (portfolio == null)
            {
                _notificator.AddNotification("Portfolio not found");
                return;
            }
         
            await _repositoryPortfolio.RemoveAsync(request.PortfolioId);
        }
    }
}