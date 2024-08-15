using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Domain
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTimeOffset Created { get; set; }

        [MaxLength(30)]
        public string CreatedBy { get; set; }
        public DateTimeOffset LastModified { get; set; }

        [MaxLength(30)]
        public string LastModifiedBy { get; set; }
    }
}
