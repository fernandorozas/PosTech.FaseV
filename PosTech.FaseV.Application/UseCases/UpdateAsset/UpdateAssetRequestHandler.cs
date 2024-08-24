using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Application.UseCases.AddAsset;
using PosTech.FaseV.Domain;
using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Application.UseCases.UpdateAsset
{
    public class UpdateAssetRequestHandler : RequestHandlerBase, IRequestHandler<UpdateAssetRequest>
    {
        private readonly IRepositoryAsset _repositoryAsset;
        private readonly IValidator<UpdateAssetRequest> _validator;

        public UpdateAssetRequestHandler(IRepositoryAsset repositoryAsset, IValidator<UpdateAssetRequest> validator, INotificator notificator) : base(notificator)
        {
            _repositoryAsset = repositoryAsset;
            _validator = validator;
        }

        public async Task Handle(UpdateAssetRequest request, CancellationToken cancellationToken)
        {
           if (!ExecValidation(_validator, request)) return;

            var asset = await _repositoryAsset.GetByIdAsync(request.Id);
            if (asset == null)
            {
                _notificator.AddNotification("Asset not found");
                return;
            }
            asset.Name = request.Name;
            asset.AssetType = (AssetType)request.Type;
            asset.Code = request.Code;
                     
            await _repositoryAsset.UpdateAsync(asset);
        }
    }
}