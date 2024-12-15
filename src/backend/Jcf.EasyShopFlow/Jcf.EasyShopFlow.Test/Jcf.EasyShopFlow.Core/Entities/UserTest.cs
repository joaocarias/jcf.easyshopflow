using Jcf.EasyShopFlow.Core.Entities;

namespace Jcf.EasyShopFlow.Test.Jcf.EasyShopFlow.Core.Entities
{
    public class UserTest
    {
        private readonly string _nameUser = "JC França";
        private readonly string _passwordUser = "10203040";
        private readonly string _emailUser = "jfranca@gmail.com";
        private readonly string _loginUser = "jfranca";

        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            User entity = new (_nameUser, _emailUser, _passwordUser, _loginUser, "BASIC");
            
            Assert.True(entity.IsActive);
            Assert.Equal(DateTime.Now.Date, entity.CreateAt.Date);           
        }
    }
}
