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
            // Arrange & Act
            User entity = new (_nameUser, _emailUser, _passwordUser, _loginUser);

            // Assert
            Assert.NotEqual(Guid.Empty, entity.Id);
            Assert.True(entity.IsActive);
            Assert.Equal(DateTime.Now.Date, entity.CreateAt.Date);
            Assert.Null(entity.UserCreate);
            Assert.Null(entity.UpdateAt);
            Assert.Null(entity.UserUpdate);
        }
    }
}
