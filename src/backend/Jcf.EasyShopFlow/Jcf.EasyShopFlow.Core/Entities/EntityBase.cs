using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jcf.EasyShopFlow.Core.Entities
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public bool IsActive { get; private set; } = true;

        public DateTime CreateAt { get; private set; } = DateTime.Now;

        public User? UserCreate { get; private set; } 

        public DateTime? UpdateAt { get; private set; }

        public User? UserUpdate { get; private set; }
        
        public EntityBase() { }
    }
}
