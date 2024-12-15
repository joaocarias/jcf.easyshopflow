namespace Jcf.EasyShopFlow.Api.Models.Records
{
    public record PostUser
    (
        string Name, 
        string Email,
        string Password,
        string Login,
        Guid? UserCreateId
    );
}
