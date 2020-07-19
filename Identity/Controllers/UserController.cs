using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Identity.Services;
using Identity.Interfaces;
using Identity.Commands;
using Identity.Models;
using MongoDB.Driver.Core.Authentication;

namespace Identity.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] UserInfo value)
        {
            var user = new User();
            user.Name = value.name;
            user.Password = value.password;

            //new
            //{
            //    Name = value.name,
            //    Username = value.username,
            //    Password = value.password,
            //    Roles = ["user"],
            //}

            _userService.insertUser(user);

            return Ok();
            
        }
    }
}