using MediatR;

namespace PosTech.FaseV.Application.UseCases.DeleteTransaction
{
    public class DeleteTransactionRequest : IRequest
    {
        public int TransactionId { get; set; }

        public DeleteTransactionRequest(int transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
