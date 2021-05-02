
using System;

namespace Bunzl.Kitten.API.Domain
{
    public class ApplicationUser
    {
        public ApplicationUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new InvalidOperationException("userName is not set");

            if (string.IsNullOrEmpty(userName))
                throw new InvalidOperationException("password is not set");

            UserName = userName;
            Password = password;
            ID = Guid.NewGuid();
        }

        public Guid ID { get; }
        public string UserName { get; }
        public string Password { get; }
    }
}
