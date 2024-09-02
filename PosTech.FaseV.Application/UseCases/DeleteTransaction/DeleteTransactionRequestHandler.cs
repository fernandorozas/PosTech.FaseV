using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Application.UseCases.AddAsset;
using PosTech.FaseV.Domain;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.DeleteTransaction
{
    public class DeleteTransactionRequestHandler : RequestHandlerBase, IRequestHandler<DeleteTransactionRequest>
    {
        private readonly IRepositoryTransaction _repositoryTransaction;
        private readonly IValidator<DeleteTransactionRequest> _validator;

        public DeleteTransactionRequestHandler(IRepositoryTransaction repositoryTransaction, IValidator<DeleteTransactionRequest> validator, INotificator notificator) : base(notificator)
        {
            _repositoryTransaction = repositoryTransaction;
            _validator = validator;
        }

        public async Task Handle(DeleteTransactionRequest request, CancellationToken cancellationToken)
        {
           if (!ExecValidation(_validator, request)) return;

            var transaction = await _repositoryTransaction.GetByIdAsync(request.TransactionId);
            if (transaction == null)
            {
                _notificator.AddNotification("Transaction not found");
                return;
            }
         
            await _repositoryTransaction.RemoveAsync(request.TransactionId);
        }
    }
}