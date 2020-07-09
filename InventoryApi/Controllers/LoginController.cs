using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InventoryApi.Context;
using InventoryApi.Exceptions;
using InventoryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private InventoryContext _context;
        private IConfiguration _config;

        public LoginController(InventoryContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        public IActionResult Login(string user, string pass)
        {
            User login = new User();
            login.userName = user;
            login.password = pass;
            IActionResult response = Unauthorized();

            var usuario = AuthenticateUser(login);

            if (user != null && usuario != null)
            {
                var tokeStr = GenerateJSONWebToken(usuario);
                response = Ok(new { token = tokeStr });
            }
            else if (usuario == null)
            {

                LogTraceFactory.LogError($"Parametros incorrectos");
                return BadRequest(new ErrorDetails { statusCode = Convert.ToInt32(HttpStatusCode.BadRequest), message = $"Usuario o password invalidos" });

            }

            return response;
        }

        private User AuthenticateUser(User login)
        {
            User usuario = null;

            try
            {
                var user = _context.userItems.Where(s => s.userName == login.userName);

                if (user == null)
                {
                    Unauthorized();
                }

                foreach (var usuarios in user)
                {
                    if (login.userName == usuarios.userName && login.password == usuarios.password)
                    {
                        usuario = new User { id = usuarios.id, userName = usuarios.userName, password = usuarios.password};
                    }
                    else
                    {

                    }

                }

            }
            catch (Exception e)
            {

            }

            return usuario;

        }


        private string GenerateJSONWebToken(User usuarioInfo)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,usuarioInfo.userName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodeToken;

        }

        [Authorize]
        [HttpPost]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;

            return "Welcome to: " + userName;
        }

        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Value1", "Value2", "Value3" };
        }

    }


}


