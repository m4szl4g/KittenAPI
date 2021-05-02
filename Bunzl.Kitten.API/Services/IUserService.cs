using Bunzl.Kitten.API.Domain;
using Bunzl.Kitten.API.DTOs;

namespace Bunzl.Kitten.API.Services
{
    public interface IUserService
    {
        UserGetResponse Get(string userName);
        ApplicationUser Get(string userName, string password);
        bool Create(UserCreationRequest user);
    }
}
