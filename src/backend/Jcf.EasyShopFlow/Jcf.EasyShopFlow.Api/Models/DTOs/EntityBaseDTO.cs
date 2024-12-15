using Jcf.EasyShopFlow.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jcf.EasyShopFlow.Api.Models.DTOs
{
    public class EntityBaseDTO
    {
        public Guid Id { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(UserCreateId))]
        public User? UserCreate { get; set; }
        public Guid? UserCreateId { get; set; }

        public DateTime? UpdateAt { get; set; }

        [ForeignKey(nameof(UserUpdateId))]
        public User? UserUpdate { get; set; }
        public Guid? UserUpdateId { get; set; }

        public EntityBaseDTO() { }
    }
}
