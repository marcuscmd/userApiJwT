using Dominio;
public interface IAuthAplicacao
{
    Task<string> AutenticarUsuario(string login, string senha);
    Task<string> GerarToken(Usuario usuario);
}