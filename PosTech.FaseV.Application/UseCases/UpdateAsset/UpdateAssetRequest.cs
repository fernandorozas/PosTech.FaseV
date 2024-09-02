using MediatR;

namespace PosTech.FaseV.Application.UseCases.UpdateAsset
{
    public class UpdateAssetRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
        
    }
}