using Bunzl.Kitten.API.Controllers;
using Bunzl.Kitten.API.DTOs;
using Bunzl.Kitten.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Bunzl.Kitten.API.UnitTests.Controllers
{
    public class UserControllerTests
    {
        private UserController _unit = null;
        private Mock<IUserService> _userServiceMock = null;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _unit = new(_userServiceMock.Object);
        }

        [Fact]
        public void Create_CreationWasSuccessful_ReturnsOk()
        {
            UserCreationRequest request = new()
            {
                Password = "password1",
                UserName = "johndoe"
            };

            _userServiceMock.Setup(x => x.Create(request)).Returns(true);

            var actionResult = _unit.Create(request);

            Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public void Create_CreationWasNotSuccessful_ReturnsBadRequest()
        {
            UserCreationRequest request = new()
            {
                Password = "password1",
                UserName = "johndoe"
            };

            _userServiceMock.Setup(x => x.Create(request)).Returns(false);

            var actionResult = _unit.Create(request);

            Assert.IsType<BadRequestObjectResult>(actionResult);
        }
    }
}
