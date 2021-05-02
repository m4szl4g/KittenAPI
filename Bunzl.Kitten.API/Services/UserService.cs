using Bunzl.Kitten.API.Domain;
using Bunzl.Kitten.API.DTOs;
using Bunzl.Kitten.API.Infrastructure.Database;

namespace Bunzl.Kitten.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDatabase _db;

        public UserService(IUserDatabase db)
        {
            _db = db;
        }

        public bool Create(UserCreationRequest userDto)
        {
            if (_db.Get(userDto.UserName, userDto.Password) != null)
            {
                return false;
            }

            ApplicationUser user = new(userDto.UserName, userDto.Password);
            _db.Create(user);

            return true;
        }

        public UserGetResponse Get(string userName)
        {
            ApplicationUser user = _db.Get(userName);
            return user != null ? Map(user) : null;
        }

        public ApplicationUser Get(string userName, string password)
        {
            return _db.Get(userName, password);
        }

        private UserGetResponse Map(ApplicationUser user)
        {
            return new UserGetResponse { UserName = user.UserName, ID = user.ID };
        }
    }
}
