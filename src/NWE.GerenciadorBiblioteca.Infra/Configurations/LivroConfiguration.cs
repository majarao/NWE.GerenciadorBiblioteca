using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NWE.GerenciadorBiblioteca.Domain.Entities;

namespace NWE.GerenciadorBiblioteca.Infra.Configurations;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.ToTable("Livros");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Titulo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(l => l.Autor)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(l => l.ISBN)
            .IsRequired()
            .HasMaxLength(23);

        builder.Property(l => l.AnoPublicacao)
            .IsRequired();

        builder
            .HasMany(l => l.Emprestimos)
            .WithOne(e => e.Livro);
    }
}
