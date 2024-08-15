using MediatR;

namespace PosTech.FaseV.Application.UseCases.AddAsset
{
    public class AddAssetRequest : IRequest
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
    }
}
