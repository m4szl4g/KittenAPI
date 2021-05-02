
using System.Collections.Generic;
using System.Linq;
using Bunzl.Kitten.API.Domain;

namespace Bunzl.Kitten.API.Infrastructure.Database
{
    public class UserDatabase : IUserDatabase
    {
        private List<ApplicationUser> _users = new();

        public void Create(ApplicationUser user)
        {
            _users.Add(user);
        }

        public ApplicationUser Get(string userName)
        {
            return _users.FirstOrDefault(
                u => u.UserName == userName);
        }

        public ApplicationUser Get(string userName, string password)
        {
            return _users.FirstOrDefault(
                u => u.UserName == userName && u.Password == password);
        }
    }
}
