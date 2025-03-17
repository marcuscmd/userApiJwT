using Dominio;

public interface IUsuarioAplicacao
{
    Task AdicionarUsuario(Usuario usuario);
    Task AtualizarUsuario(Usuario usuario);
    Task DesativarUsuario(int id);
    Task AtivarUsuario(int id);
    Task ExcluirUsuario(Usuario usuario);
    Task<IEnumerable<Usuario>> ObterListaDeUsuarios(bool ativo = true);
    Task<Usuario> ObterUsuarioPorId(int id);
    Task<Usuario> ObterUsuarioPorEmail(string email);
    Task<Usuario> ObterUsuarioPorLogin(string login);
    Task<Usuario> ObterUsuarioPorCpf(string cpf);
    Task AlterarSenha(int id, string senhaAntiga, string senhaNova);
}