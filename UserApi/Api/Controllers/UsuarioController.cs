using Dominio;
using Microsoft.AspNetCore.Mvc;
using Resposta;

[ApiController]
[Route("[controller]")]

public class UsuarioController : ControllerBase
{
    private readonly IUsuarioAplicacao _usuarioAplicacao;

    public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
    {
        _usuarioAplicacao = usuarioAplicacao;
    }

    [HttpGet("usuario/{id}")]
    public async Task<IActionResult> ObterUsuarioId([FromRoute] Guid id)
    {
        try
        {
            var usuario = await _usuarioAplicacao.ObterUsuarioPorId(id);
            ObterUsuario obterUsuario = new ObterUsuario()
            {
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                Ativo = usuario.Ativo
            };
            return Ok(obterUsuario);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("listar_usuarios")]
    public async Task<IActionResult> ObterTodosUsuario()
    {
        try
        {
            var usuarios = await _usuarioAplicacao.ObterListaDeUsuarios();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("listar_usuarios_desativados")]
    public async Task<IActionResult> ObterTodosUsuarioDesativados()
    {
        try
        {
            var usuarios = await _usuarioAplicacao.ObterListaDeUsuarios(false);
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("adicionar_usuario")]
    public async Task<IActionResult> AdicionarUsuario([FromBody] AdicionarUsuario usuario)
    {
        try
        {
            Usuario adicionarUsuario = new Usuario()
            {
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Email = usuario.Email,
                Cpf = usuario.Cpf,
                Login = usuario.Login,
                DataNascimento = usuario.DataNascimento,
            };
            adicionarUsuario.CriarSenha(usuario.Senha);

            await _usuarioAplicacao.AdicionarUsuario(adicionarUsuario);

            return Ok(adicionarUsuario.Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("atualizar_usuario/{id}")]
    public async Task<IActionResult> AtualizarUsuario([FromBody] AtualizarUsuario usuario, [FromRoute] Guid id)
    {
        try
        {
            var obterUsuario = await _usuarioAplicacao.ObterUsuarioPorId(id);
            Usuario atualizarUsurio = new Usuario()
            {
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
            };

            await _usuarioAplicacao.AtualizarUsuario(atualizarUsurio);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("excluir_usuario/{id}")]
    public async Task<IActionResult> ExcluirUsuario([FromRoute] Guid id)
    {
        try
        {
            var usuario = await _usuarioAplicacao.ObterUsuarioPorId(id);
            usuario.DesativarUsuario();

            await _usuarioAplicacao.AtualizarUsuario(usuario);

            return Ok("Usuario excluido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("alterar_senha/{id}")]
    public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenha alterarSenha, [FromRoute] Guid id)
    {
        try
        {
            var usuarioSenha = await _usuarioAplicacao.ObterUsuarioPorId(id);
            await _usuarioAplicacao.AlterarSenha(id, alterarSenha.SenhaAntiga, alterarSenha.SenhaNova);

            return Ok("Senha alterada com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("restaurar_usuario/{id}")]
    public async Task<IActionResult> RestaurarUsuario([FromRoute] Guid id)
    {
        try
        {
            var usuario = await _usuarioAplicacao.ObterUsuarioPorId(id);
            usuario.AtivarUsuario();

            await _usuarioAplicacao.AtualizarUsuario(usuario);

            return Ok("Usuario excluido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}