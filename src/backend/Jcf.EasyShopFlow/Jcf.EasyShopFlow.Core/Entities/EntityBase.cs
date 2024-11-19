using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jcf.EasyShopFlow.Core.Entities
{
    public abstract class EntityBase
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public bool IsActive { get; private set; } = true;

        [Required]
        public DateTime CreateAt { get; private set; } = DateTime.Now;

        [ForeignKey(nameof(UserCreateId))]
        public User? UserCreate { get; private set; } 
        public Guid? UserCreateId { get; private set; }

        public DateTime? UpdateAt { get; private set; }

        [ForeignKey(nameof(UserUpdateId))]
        public User? UserUpdate { get; private set; }
        public Guid? UserUpdateId { get; private set; }

        public EntityBase() { }

        public void Delete(Guid? userUpdateId = null)
        {
            UpdateAt = DateTime.UtcNow;
            IsActive = false;
            UserUpdateId = userUpdateId;
        }
    }
}
