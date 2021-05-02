using Microsoft.AspNetCore.Authorization;

namespace Bunzl.Kitten.API.Authentication
{
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        public BasicAuthorizationAttribute()
        {
            Policy = "BasicAuthentication";
        }
    }
}
