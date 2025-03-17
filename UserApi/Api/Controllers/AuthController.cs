// using System.Security.Principal;
// using Aplicacao;
// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("[controller]")]
// public class AuthController : ControllerBase
// {
//     private readonly IUsuarioAplicacao _aplicacaoUsuario;
//     private readonly IAuthAplicacao _auth;

//     public AuthController(IAuthAplicacao auth, IUsuarioAplicacao aplicacaoUsuario)
//     {
//         _auth = auth;
//         _aplicacaoUsuario = aplicacaoUsuario;
//     }
//     [HttpPost("logar_usuario")]
//     public async Task<IActionResult> Logar([FromBody] AuthUsuario usuario)
//     {
//         try
//         {
//             var usuarioAutenticar = await _aplicacaoUsuario.ObterUsuarioPorLogin(usuario.Login);

//             var gerarToken = await _auth.ValidarLogin(usuario.Login, usuario.Senha);

//             return Ok(new {token = gerarToken});

//         }
//         catch (Exception ex)
//         {
//             return BadRequest(ex.Message);
//         }
//     }
// }