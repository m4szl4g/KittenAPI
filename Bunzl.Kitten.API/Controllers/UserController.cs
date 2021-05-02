using Bunzl.Kitten.API.Authentication;
using Bunzl.Kitten.API.DTOs;
using Bunzl.Kitten.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bunzl.Kitten.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthorization]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get user info by userName
        /// </summary>
        /// <param name="userName">User name</param>
        /// <response code="200">Returns the info of specific user</response>
        [HttpGet]
        [ProducesResponseType(typeof(UserGetResponse), 200)]
        public IActionResult Get(string userName)
        {
            return Ok(_userService.Get(userName));
        }

        /// <summary>
        /// Creates new user in the database
        /// </summary>
        /// <param name="user">Data contains user information</param>
        /// <response code="200">User is created in database</response>
        /// <response code="400">User could not be created</response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] UserCreationRequest user)
        {
            bool isCreated = _userService.Create(user);

            if (isCreated)
                return Ok();
            else
                return BadRequest(new ErrorResponse { Message = "User could not be created!" });
        }
    }
}
