using Dominio;
public interface IAuthAplicacao
{
    string GerarToken(int id);
    Task<string> ValidarLogin(string login, string senha);
}