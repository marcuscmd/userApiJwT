using Dominio;

public interface IUsuarioRepositorio
{
    Task AdicionarUsuario(Usuario usuario);
    Task AtualizarUsuario(Usuario usuario);
    Task ExcluirUsuario(Usuario usuario);
    Task<IEnumerable<Usuario>> ObterListaDeUsuarios(bool ativo = true);
    Task<Usuario> ObterUsuarioPorId(Guid id);
    Task<Usuario> ObterUsuarioPorEmail(string email);
    Task<Usuario> ObterUsuarioPorCpf(string cpf);
    Task<Usuario> ObterUsuarioPorLogin(string login);
}