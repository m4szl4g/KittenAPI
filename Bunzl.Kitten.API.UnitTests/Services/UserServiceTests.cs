using Bunzl.Kitten.API.Domain;
using Bunzl.Kitten.API.DTOs;
using Bunzl.Kitten.API.Infrastructure.Database;
using Bunzl.Kitten.API.Services;
using Moq;
using Xunit;

namespace Bunzl.Kitten.API.UnitTests
{
    public class UserServiceTests
    {
        private UserService _unit = null;
        private Mock<IUserDatabase> _userDbMock = null;

        public UserServiceTests()
        {
            _userDbMock = new Mock<IUserDatabase>();
            _unit = new(_userDbMock.Object);
        }

        [Fact]
        public void Create_UserIsNotInDb_ReturnsTrue()
        {
            UserCreationRequest data = new()
            {
                UserName = "johndoe",
                Password = "password"
            };

            _userDbMock.Setup(ud => ud.Get(data.UserName, data.Password)).Returns((ApplicationUser)null);

            bool result = _unit.Create(data);

            _userDbMock.Verify(ud => ud.Create(It.Is<ApplicationUser>(x => x.Password == data.Password && x.UserName == data.UserName)), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void Create_UserIsInDb_ReturnsFalse()
        {
            UserCreationRequest data = new()
            {
                UserName = "johndoe",
                Password = "password"
            };

            _userDbMock.Setup(ud => ud.Get(data.UserName, data.Password)).Returns(new ApplicationUser("johndoe", "password"));

            bool result = _unit.Create(data);
            Assert.False(result);
        }
    }
}
