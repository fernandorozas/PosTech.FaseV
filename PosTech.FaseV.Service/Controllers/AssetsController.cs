using MediatR;
using Microsoft.AspNetCore.Mvc;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Application.UseCases.AddAsset;

namespace PosTech.FaseV.Service.Controllers
{
    [Route("api/assets")]
    [ApiController]
    public class AssetsController : MainController
    {
        private readonly IRepositoryAsset _repositoryAsset;
        private readonly IMediator _mediator;

        public AssetsController(INotificator notificator, IRepositoryAsset repositoryAsset,
            IMediator mediator) : base(notificator)
        {
            _repositoryAsset = repositoryAsset;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assets = await _repositoryAsset.GetAllAsync();
            return CustomResponse(assets);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asset = await _repositoryAsset.GetByIdAsync(id);
            return CustomResponse(asset);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddAssetRequest request)
        {
            await _mediator.Send(request);
            return CustomResponse();
        }

    }
}
