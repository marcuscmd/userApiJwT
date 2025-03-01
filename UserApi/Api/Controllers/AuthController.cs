using System.Security.Principal;
using Aplicacao;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthAplicacao _auth;

    public AuthController(AuthAplicacao auth)
    {
        _auth = auth;
    }
    [HttpPost("logar_usuario")]
    public async Task<IActionResult> Logar([FromBody] AuthUsuario usuario)
    {
        try
        {
            var logar = await _auth.AutenticarUsuario(usuario.Login, usuario.Senha);
            return Ok(new {token = logar});

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}