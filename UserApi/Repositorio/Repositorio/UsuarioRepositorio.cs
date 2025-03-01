using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _contexto;
        public UsuarioRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task AdicionarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task ExcluirUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Remove(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterListaDeUsuarios(bool ativo = true)
        {
            return await _contexto.Usuarios.Where(u => u.Ativo == ativo).ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorCpf(string cpf)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Cpf == cpf && u.Ativo == true);
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Ativo == true);
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == id && u.Ativo == true);
        }

        public async Task<Usuario> ObterUsuarioPorLogin(string login)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Login == login && u.Ativo == true);
        }
    }
}