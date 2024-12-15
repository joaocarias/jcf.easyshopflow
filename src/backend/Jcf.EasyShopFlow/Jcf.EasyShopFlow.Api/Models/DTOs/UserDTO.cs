using System.ComponentModel.DataAnnotations;

namespace Jcf.EasyShopFlow.Api.Models.DTOs
{
    public class UserDTO : EntityBaseDTO
    {
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Login { get; set; }

        [Required]
        [StringLength(15)]
        public string Role { get; set; }

        public UserDTO(): base() { }
    }
}
