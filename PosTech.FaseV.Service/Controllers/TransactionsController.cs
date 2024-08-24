using MediatR;
using Microsoft.AspNetCore.Mvc;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Application.UseCases.AddTransaction;
using PosTech.FaseV.Application.UseCases.DeleteTransaction;
using PosTech.FaseV.Application.UseCases.UpdateAsset;
using PosTech.FaseV.Application.UseCases.UpdateTransaction;

namespace PosTech.FaseV.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryTransaction _repositoryTransaction;
        private readonly IRepositoryPortfolio _repositoryPortfolio;
        private readonly IRepositoryAsset _repositoryAsset;

        public TransactionsController(INotificator notificator, IMediator mediator, IRepositoryTransaction repositoryTransaction, IRepositoryPortfolio repositoryPortfolio, IRepositoryAsset repositoryAsset) : base(notificator)
        {
            _mediator = mediator;
            _repositoryTransaction = repositoryTransaction;
            _repositoryPortfolio = repositoryPortfolio;
            _repositoryAsset = repositoryAsset;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _repositoryTransaction.GetAllAsync();
            return CustomResponse(transactions);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _repositoryTransaction.GetByIdAsync(id);
            return CustomResponse(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddTransactionRequest request)
        {
            await _mediator.Send(request);
            return CustomResponse();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteTransactionRequest request)
        {
            await _mediator.Send(request);
            return CustomResponse();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateTransactionRequest request)
        {
            await _mediator.Send(request);
            return CustomResponse();
        }
    }
}
