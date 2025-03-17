// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Dominio;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;

// namespace Aplicacao
// {
//     public class AuthAplicacao : IAuthAplicacao
//     {
//         private readonly IUsuarioRepositorio _usuarioRepositorio;
//         private readonly IConfiguration _configuration;
//         public AuthAplicacao(IUsuarioRepositorio usuarioRepositorio, IConfiguration configuration)
//         {
//             _usuarioRepositorio = usuarioRepositorio;
//             _configuration = configuration;
//         }

//         public string GerarToken(int id)
//         {
//             try
//             {
//                 var jwtSettings = _configuration.GetSection("JwtSettings");
//                 if (jwtSettings["Key"] == null || jwtSettings["Issuer"] == null || jwtSettings["Audience"] == null)
//                 {
//                     throw new Exception("Configurações JWT não encontradas. Verifique o arquivo de configuração.");
//                 }
//                 var claims = new[]
//                 {
//                     new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
//                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                     new Claim(JwtRegisteredClaimNames.Iss, jwtSettings["Issuer"]),
//                     new Claim(JwtRegisteredClaimNames.Aud, jwtSettings["Audience"]),
//                     new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.DateTime),
//                 };

//                 var expirationMinutes = Convert.ToInt32(jwtSettings["ExpirationMinutes"]);
//                 if (expirationMinutes <= 0)
//                 {
//                     throw new Exception("A configuração de ExpirationMinutes não está válida.");
//                 }

//                 var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
//                 var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

//                 var token = new JwtSecurityToken(
//                     issuer: jwtSettings["Issuer"],
//                     audience: jwtSettings["Audience"],
//                     claims: claims,
//                     expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
//                     signingCredentials: credencial
//                 );

//                 var tokenHandler = new JwtSecurityTokenHandler();
//                 return tokenHandler.WriteToken(token);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception($"Erro ao gerar token JWT: {ex.Message}");
//             }
//         }

//         public async Task<string> ValidarLogin(string login, string senha)
//         {
//             try
//             {
//                 var usuario = await _usuarioRepositorio.ObterUsuarioPorLogin(login);
//                 if (usuario.Login == login && usuario.Senha == senha)
//                     return GerarToken(usuario.Id);
//                 throw new Exception("Usuario Invalido");
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//         }
//     }
// }
