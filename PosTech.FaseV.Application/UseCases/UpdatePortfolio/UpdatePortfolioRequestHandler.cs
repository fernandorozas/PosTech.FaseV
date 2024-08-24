using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Domain;

namespace PosTech.FaseV.Application.UseCases.UpdatePortfolio
{
    public class UpdatePortfolioRequestHandler : RequestHandlerBase, IRequestHandler<UpdatePortfolioRequest>
    {
        private readonly IRepositoryPortfolio _repositoryPortfolio;
        private readonly IValidator<UpdatePortfolioRequest> _validator;

        public UpdatePortfolioRequestHandler(IRepositoryPortfolio repositoryPortfolio, IValidator<UpdatePortfolioRequest> validator, INotificator notificator) : base(notificator)
        {
            _repositoryPortfolio = repositoryPortfolio;
            _validator = validator;
        }

        public async Task Handle(UpdatePortfolioRequest request, CancellationToken cancellationToken)
        {
            if (!ExecValidation(_validator, request)) return;

            var portfolio = await _repositoryPortfolio.GetByIdAsync(request.Id);
            if (portfolio == null)
            {
                _notificator.AddNotification("Portfolio not found");
                return;
            }
            portfolio.UserId = request.UserId;
            portfolio.Name = request.Name;
            portfolio.Description = request.Description;

            await _repositoryPortfolio.UpdateAsync(portfolio);
        }
    }
}