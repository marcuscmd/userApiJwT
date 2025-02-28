using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuracoes
{
    public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario").HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("Id");

            builder.Property(u => u.Nome).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Sobrenome).HasMaxLength(100).IsRequired();

            builder.HasIndex(u => u.Cpf).IsUnique();
            builder.Property(u => u.Cpf).HasMaxLength(11).HasColumnName("Cpf").IsRequired();

            builder.HasIndex(u => u.Login).IsUnique();
            builder.Property(u => u.Login).HasMaxLength(100).HasColumnName("Login").IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(150).HasColumnName("Email").IsRequired();

            builder.Property(u => u.Senha).IsRequired();
            builder.Property(u => u.DataNascimento).HasColumnName("DataNascimento").IsRequired();
            builder.Property(u => u.DataCriacao).HasColumnName("DataCriacao").IsRequired(); ;
            builder.Property(u => u.Ativo).HasColumnName("Ativo").IsRequired(); ;
        }
    }
}