using MediatR;
using Microsoft.AspNetCore.Mvc;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Application.UseCases.AddPortfolio;
using PosTech.FaseV.Application.UseCases.DeleteAsset;
using PosTech.FaseV.Application.UseCases.DeletePortfolio;
using PosTech.FaseV.Application.UseCases.UpdateAsset;
using PosTech.FaseV.Application.UseCases.UpdatePortfolio;

namespace PosTech.FaseV.Service.Controllers
{
    [Route("api/portfolios")]
    [ApiController]
    public class PortfoliosController : MainController
    {
        private readonly IRepositoryPortfolio _repositoryPortfolio;
        private readonly IMediator _mediator;

        public PortfoliosController(INotificator notificator, IRepositoryPortfolio repositoryPortfolio,
            IMediator mediator) : base(notificator)
        {
            _repositoryPortfolio = repositoryPortfolio;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var portfolios = await _repositoryPortfolio.GetAllAsync();
            return CustomResponse(portfolios);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var portfolio = await _repositoryPortfolio.GetByIdAsync(id);
            return CustomResponse(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddPortfolioRequest request)
        {
            await _mediator.Send(request);
            return CustomResponse();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeletePortfolioRequest request)
        {
            await _mediator.Send(request);
            return CustomResponse();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdatePortfolioRequest request)
        {
            await _mediator.Send(request);
            return CustomResponse();
        }
    }
}
