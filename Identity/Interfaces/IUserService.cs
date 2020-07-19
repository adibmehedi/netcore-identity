using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Models;

namespace Identity.Interfaces
{
    public interface IUserService
    {
        User getUserById(string userId);
        bool insertUser(User user);
    }
}
