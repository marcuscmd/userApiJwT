using System.Runtime.CompilerServices;

namespace Dominio
{
    public class Usuario
    {
        private string _senha;

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get { return _senha; } }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }



        public Usuario(string senha)
        {
            _senha = senha;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public void AtivarUsuario()
        {
            Ativo = true;
        }

        public void DesativarUsuario()
        {
            Ativo = false;
        }

        public void AlterarSenha(string senha)
        {
            _senha = senha;
        }
    }
}
