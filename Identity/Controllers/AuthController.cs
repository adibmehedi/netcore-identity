using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Identity.Commands;
using Identity.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Identity.Models;
using Identity.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Identity.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private IUserService _userService;
        private IAuthService _authService;
        public AuthController(
            ILogger<AuthController> logger,
            IUserService userService,
            IAuthService authService
        )
        {
            _logger = logger;
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        public string Get()
        {
            
            return "Hello World";

        }

        [HttpPost]
        public IActionResult Post([FromBody] UserCredential value ) 
        {
            _logger.LogInformation("UserCredential: inside");

            if (_authService.validate(value.username, value.password))
            {
                var model = new { success = true, token = _authService.getAccessToken(value.username) };
                return Ok(model);
            }

            return StatusCode(403);
        }


    }
}