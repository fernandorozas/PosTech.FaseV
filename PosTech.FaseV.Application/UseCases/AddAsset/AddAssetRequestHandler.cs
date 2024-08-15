using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Domain;

namespace PosTech.FaseV.Application.UseCases.AddAsset
{
    public class AddAssetRequestHandler : RequestHandlerBase, IRequestHandler<AddAssetRequest>
    {

        private readonly IRepositoryAsset _repositoryAsset;
        private readonly IValidator<AddAssetRequest> _validator;

        public AddAssetRequestHandler(IRepositoryAsset repositoryAsset, IValidator<AddAssetRequest> validator, INotificator notificator) : base(notificator) 
        {
            _repositoryAsset = repositoryAsset;
            _validator = validator;
        }

        public async Task Handle(AddAssetRequest request, CancellationToken cancellationToken)
        {
            if (!ExecValidation(_validator, request)) return;
            var asset = new Asset(request.Name, request.Type, request.Code);
            await _repositoryAsset.AddAsync(asset);
        }
    }
}
