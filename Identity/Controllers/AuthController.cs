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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Identity.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserCredential value ) {
            _logger.LogInformation("UserCredential: inside");
            // check in Controller for now
            //send JSON reuest JWT token
            //return Ok(JwtTokenService.GenerateToken("john"));

            var model = new
            {
                success = true,
                token = JwtTokenService.GenerateToken("john")
            };

            _logger.LogInformation("UserCredential: token send");
            return Ok(model);
        }


    }
}