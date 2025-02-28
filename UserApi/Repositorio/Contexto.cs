using Configuracoes;
using Dominio;
using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    private readonly DbContextOptions _options;
    public Contexto() { }
    public Contexto(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_options == null)
            optionsBuilder.UseSqlServer("Server=NOTE189\\SQLEXPRESS;Database=UserApi;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
    }

}
