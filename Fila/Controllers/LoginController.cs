using Fila.Models;
using Fila.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fila.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            //Consultar usuários cadastradas no banco.

            Usuario usuario = null;

            if (request.Login == "admin" && request.Senha == "admin")
            {
                usuario = new Usuario() { Login = request.Login };
                usuario.Permissoes = new Collection<Permissao>();
                usuario.Permissoes.Add(new Permissao("admin"));
            }
            else if (request.Login == "atendente" && request.Senha == "123")
            {
                usuario = new Usuario() { Login = request.Login };
                usuario.Permissoes = new Collection<Permissao>();
                usuario.Permissoes.Add(new Permissao("atendimento"));
            }

            if (usuario == null) return Unauthorized();

            LoginResponse response = new LoginResponse()
            {
                Login = usuario.Login,
                Permissoes = usuario.Permissoes.Select(p => p.Nome).ToList(),
                Token = GenerateToken(usuario)
            };

            return Ok(response);
        }

        private string GenerateToken(Usuario usuario)
        {
            IList<Claim> claims = new List<Claim>();

            //Login
            claims.Add(new Claim(ClaimTypes.Name, usuario.Login));

            //Permissoes
            foreach (var permissao in usuario.Permissoes)
            {
                claims.Add(new Claim(ClaimTypes.Role, permissao.Nome));
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            //https://www.freeformatter.com/hmac-generator.html
            var key = Encoding.ASCII.GetBytes("3b2adbe1313d27dd4e4cd9c33ae184f37ec17b2e16da53cacd238e0e1af35929");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
