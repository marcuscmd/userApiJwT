using Dominio;

public interface IUsuarioAplicacao
{
    Task AdicionarUsuario(Usuario usuario);
    Task AtualizarUsuario(Usuario usuario);
    Task ExcluirUsuario(Usuario usuario);
    Task<IEnumerable<Usuario>> ObterListaDeUsuarios(bool ativo = true);
    Task<Usuario> ObterUsuarioPorId(Guid id);
    Task<Usuario> ObterUsuarioPorEmail(string email);
    Task<Usuario> ObterUsuarioPorCpf(string cpf);
    Task AlterarSenha(Guid id, string senhaAntiga, string senhaNova);
}