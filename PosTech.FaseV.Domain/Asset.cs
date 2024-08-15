using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Domain
{
    public class Asset : BaseAuditableEntity
    {
        protected Asset() {}
        public Asset(string name, int assetType, string code)
        {
            Name = name;
            AssetType = (AssetType)assetType;
            Code = code;
        }

        [MaxLength(100)]
        public string Name { get; set; }

        public AssetType AssetType { get; set; }

        [MaxLength(6)]
        public string Code { get; set; }
    }
}
