using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Domain;
using System.Diagnostics;

namespace PosTech.FaseV.Application.UseCases.AddTransaction
{
    public class AddTransactionRequestHandler : RequestHandlerBase, IRequestHandler<AddTransactionRequest>
    {
        private readonly IValidator<AddTransactionRequest> _validator;
        private readonly IRepositoryTransaction _repositoryTransaction;
        private readonly IRepositoryPortfolio _repositoryPortfolio;
        private readonly IRepositoryAsset _repositoryAsset;

        public AddTransactionRequestHandler(IRepositoryTransaction repositoryTransaction, IValidator<AddTransactionRequest> validator, INotificator notificator, IRepositoryPortfolio repositoryPortfolio, IRepositoryAsset repositoryAsset) : base(notificator)
        {
            _repositoryTransaction = repositoryTransaction;
            _validator = validator;
            _repositoryPortfolio = repositoryPortfolio;
            _repositoryAsset = repositoryAsset;
        }

        public async Task Handle(AddTransactionRequest request, CancellationToken cancellationToken)
        {
            if (!ExecValidation(_validator, request)) return;

            var portfolio = await _repositoryPortfolio.GetByIdAsync(request.PortfolioId);
            if (portfolio == null)
            {
                _notificator.AddNotification("Portfolio not found");
                return;
            }
            var asset = await _repositoryAsset.GetByIdAsync(request.AssetId);
            if (asset == null)
            {
                _notificator.AddNotification("Asset not found");
                return;
            }
            var transaction = new Transaction(request.Type, request.Amount, request.Price, portfolio, asset);
            await _repositoryTransaction.AddAsync(transaction);
        }
    }
}
