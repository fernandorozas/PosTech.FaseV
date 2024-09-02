using MediatR;

namespace PosTech.FaseV.Application.UseCases.DeleteAsset
{
    public class DeleteAssetRequest : IRequest
    {
        public int AssetId { get; set; }

        public DeleteAssetRequest(int assetId)
        {
            AssetId = assetId;
        }
    }
}
