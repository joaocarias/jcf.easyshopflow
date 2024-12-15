using System.Security.Cryptography.X509Certificates;

namespace Jcf.EasyShopFlow.Api.Models.DTOs
{
    public class LoginResponseDTO
    {
        public bool IsAuth = false;
        public UserDTO? User { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }    

        public LoginResponseDTO(bool isAuth, UserDTO user, string token, string message) 
        {
            User = user;
            Token = token;
            IsAuth = isAuth;
            Message = message;
        }

        public LoginResponseDTO() { }
    }
}
