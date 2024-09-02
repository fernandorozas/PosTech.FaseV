using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Application.UseCases.AddAsset;
using PosTech.FaseV.Application.UseCases.AddTransaction;
using PosTech.FaseV.Domain;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.UpdateTransaction
{
    public class UpdateTransactionRequestHandler : RequestHandlerBase, IRequestHandler<UpdateTransactionRequest>
    {
        private readonly IValidator<UpdateTransactionRequest> _validator;
        private readonly IRepositoryTransaction _repositoryTransaction;
        private readonly IRepositoryPortfolio _repositoryPortfolio;
        private readonly IRepositoryAsset _repositoryAsset;

        public UpdateTransactionRequestHandler(IRepositoryTransaction repositoryTransaction, IValidator<UpdateTransactionRequest> validator, INotificator notificator, IRepositoryPortfolio repositoryPortfolio, IRepositoryAsset repositoryAsset) : base(notificator)
        {
            _repositoryTransaction = repositoryTransaction;
            _validator = validator;
            _repositoryPortfolio = repositoryPortfolio;
            _repositoryAsset = repositoryAsset;
        }

        public async Task Handle(UpdateTransactionRequest request, CancellationToken cancellationToken)
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

            var transaction = await _repositoryTransaction.GetByIdAsync(request.Id);
            if (transaction == null)
            {
                _notificator.AddNotification("Transaction not found");
                return;
            }
            transaction.TransactionType = (TransactionType)request.Type;
            transaction.Amount = request.Amount;
            transaction.Price = request.Price;
            transaction.Portfolio = portfolio;
            transaction.Asset = asset;
         
            await _repositoryTransaction.UpdateAsync(transaction);
        }
    }
}