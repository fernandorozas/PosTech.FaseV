using System.ComponentModel.DataAnnotations;

namespace PosTech.FaseV.Domain
{
    public class Portfolio : BaseAuditableEntity
    {
        protected Portfolio() { }
        public Portfolio(string userId, string name, string description)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }

        [MaxLength(100)]
        public string UserId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
    }
}
