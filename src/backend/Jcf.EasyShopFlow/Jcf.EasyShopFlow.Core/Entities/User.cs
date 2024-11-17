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

        public User(string name, string email, string password, string login)
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;
        }

        private User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Login = string.Empty;
        }
    }
}
