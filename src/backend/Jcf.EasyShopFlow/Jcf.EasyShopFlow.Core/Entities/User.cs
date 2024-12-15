using System.ComponentModel.DataAnnotations;

namespace Jcf.EasyShopFlow.Core.Entities
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }

        [Required]
        [StringLength(255)]
        public string Email { get; private set; }

        [Required]
        [StringLength(255)]
        public string Password { get; private set; }

        [Required]
        [StringLength(255)]
        public string Login {  get; private set; }

        [Required]
        [StringLength(15)]
        public string? Role { get; set; }

        public User(string name, string email, string password, string login, string role) : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;
            Role = role;
        }

        public User(string name, string email, string password, string login, string role, Guid? userCreateId) : base(userCreateId)
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;            
            Role = role;
        }

        private User() : base()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Login = string.Empty;
        }
    }
}
