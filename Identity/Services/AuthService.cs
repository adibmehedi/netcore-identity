using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Interfaces;
using Identity.Providers;

namespace Identity.Services
{
    public class AuthService : IAuthService
    {
        public string getAccessToken(string username)
        {
            return JwtTokenProvider.GenerateToken(username);
        }

        public bool validate(string username, string password)
        {
            return true;
        }
    }
}
