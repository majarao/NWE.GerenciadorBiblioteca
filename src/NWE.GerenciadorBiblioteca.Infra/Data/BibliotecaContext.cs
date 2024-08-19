using Microsoft.EntityFrameworkCore;
using NWE.GerenciadorBiblioteca.Domain.Entities;
using System.Reflection;

namespace NWE.GerenciadorBiblioteca.Infra.Data;

public class BibliotecaContext : DbContext
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) =>
        Database.EnsureCreated();

    public DbSet<Livro> Livros { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Emprestimo> Emprestimos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
