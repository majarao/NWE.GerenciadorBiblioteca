using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NWE.GerenciadorBiblioteca.Domain.Entities;

namespace NWE.GerenciadorBiblioteca.Infra.Configurations;

public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        builder.ToTable("Emprestimos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.IdUsuario)
            .IsRequired();

        builder.Property(e => e.IdLivro)
            .IsRequired();

        builder.Property(e => e.DataEmprestimo)
            .IsRequired();

        builder.Property(e => e.DataDevolucaoPrevista)
            .IsRequired();

        builder
            .HasOne(e => e.Usuario)
            .WithMany(u => u.Emprestimos)
            .HasForeignKey(e => e.IdUsuario);

        builder
            .HasOne(e => e.Livro)
            .WithMany(l => l.Emprestimos)
            .HasForeignKey(e => e.IdLivro);
    }
}
