using Dominio;

namespace Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _repositorioUsuario;
        public UsuarioAplicacao(IUsuarioRepositorio repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public async Task AdicionarUsuario(Usuario usuario)
        {
            try
            {
                ValidarInformacoes(usuario);
                await _repositorioUsuario.AdicionarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            try
            {
                var atualizarUsuario = await _repositorioUsuario.ObterUsuarioPorId(usuario.Id);
                ValidarInformacoes(atualizarUsuario);

                atualizarUsuario.Nome = usuario.Nome;
                atualizarUsuario.Sobrenome = usuario.Sobrenome;

                await _repositorioUsuario.AtualizarUsuario(atualizarUsuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task ExcluirUsuario(Usuario usuario)
        {
            try
            {
                var excluirUsuario = await _repositorioUsuario.ObterUsuarioPorId(usuario.Id);
                ValidarInformacoes(excluirUsuario);

                await _repositorioUsuario.ExcluirUsuario(excluirUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Usuario>> ObterListaDeUsuarios(bool ativo)
        {
            try
            {
                var listaUsuarios = await _repositorioUsuario.ObterListaDeUsuarios(ativo);
                if (!listaUsuarios.Any())
                    throw new Exception("Lista de Usuario esta vazia!");

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> ObterUsuarioPorCpf(string cpf)
        {
            try
            {
                var cpfUsuario = await _repositorioUsuario.ObterUsuarioPorCpf(cpf);
                ValidarInformacoes(cpfUsuario);

                return cpfUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            try
            {
                var emailUsuario = await _repositorioUsuario.ObterUsuarioPorEmail(email);
                ValidarInformacoes(emailUsuario);

                return emailUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            try
            {
                var usaurio = await _repositorioUsuario.ObterUsuarioPorId(id);
                ValidarInformacoes(usaurio);

                return usaurio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ValidarInformacoes(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    throw new Exception("Usuario não pode ser vazio");
                if (usuario.Nome == null)
                    throw new Exception("Nome não pode ser vazio");
                if (usuario.Sobrenome == null)
                    throw new Exception("Sobrenome não pode ser vazio");
                if (string.IsNullOrWhiteSpace(usuario.Cpf))
                    throw new Exception("Cpf não pode ser vazio");
                if (usuario.Email == null)
                    throw new Exception("E-mail não pode ser vazio");
                if (string.IsNullOrWhiteSpace(usuario.Senha))
                    throw new Exception("Senha não pode ser vazio");
                if (usuario.Login == null)
                    throw new Exception("Login do usuario não pode ser vazio");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}