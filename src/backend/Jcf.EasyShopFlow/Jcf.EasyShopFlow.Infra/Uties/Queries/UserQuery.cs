namespace Jcf.EasyShopFlow.Infra.Uties.Queries
{
    public static class UserQuery
    {
        public static readonly string GET_ALL = "SELECT * FROM users WHERE IsActive = 1";
        public static readonly string GET = "SELECT * FROM users WHERE Id = @Id AND IsActive = 1";
    }
}
