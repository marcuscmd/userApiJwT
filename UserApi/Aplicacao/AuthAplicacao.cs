using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dominio;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Aplicacao
{
    public class AuthAplicacao : IAuthAplicacao
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IConfiguration _configuration;
        public AuthAplicacao(IUsuarioRepositorio usuarioRepositorio, IConfiguration configuration)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _configuration = configuration;
        }

        public async Task<string> AutenticarUsuario(string login, string senha)
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObterUsuarioPorLogin(login);
                if (usuario == null)
                    throw new Exception("Usuario não encontrado");
                if (usuario.Login != login)
                    throw new Exception("Login de usuario invalido!");
                if (usuario.Senha != senha)
                    throw new Exception("Senha de usuario invalido!");

                return await GerarToken(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> GerarToken(Usuario usuario)
        {
            try
            {
                var chave = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["Jwt:ExpireHours"])),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
