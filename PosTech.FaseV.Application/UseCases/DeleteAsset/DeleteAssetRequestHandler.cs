using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Application.UseCases.AddAsset;
using PosTech.FaseV.Domain;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.DeleteAsset
{
    public class DeleteAssetRequestHandler : RequestHandlerBase, IRequestHandler<DeleteAssetRequest>
    {
        private readonly IRepositoryAsset _repositoryAsset;
        private readonly IValidator<DeleteAssetRequest> _validator;

        public DeleteAssetRequestHandler(IRepositoryAsset repositoryAsset, IValidator<DeleteAssetRequest> validator, INotificator notificator) : base(notificator)
        {
            _repositoryAsset = repositoryAsset;
            _validator = validator;
        }

        public async Task Handle(DeleteAssetRequest request, CancellationToken cancellationToken)
        {
           if (!ExecValidation(_validator, request)) return;

            var asset = await _repositoryAsset.GetByIdAsync(request.AssetId);
            if (asset == null)
            {
                _notificator.AddNotification("Asset not found");
                return;
            }
         
            await _repositoryAsset.RemoveAsync(request.AssetId);
        }
    }
}