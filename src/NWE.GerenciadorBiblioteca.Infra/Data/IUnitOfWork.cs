namespace NWE.GerenciadorBiblioteca.Infra.Data;

public interface IUnitOfWork
{
    public BibliotecaContext Context { get; set; }

    public Task<int> SaveChangesAsync();
}
