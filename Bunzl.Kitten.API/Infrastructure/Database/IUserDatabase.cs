using Bunzl.Kitten.API.Domain;

namespace Bunzl.Kitten.API.Infrastructure.Database
{
    public interface IUserDatabase
    {
        void Create(ApplicationUser user);
        ApplicationUser Get(string userName);

        ApplicationUser Get(string userName, string password);
    }
}
