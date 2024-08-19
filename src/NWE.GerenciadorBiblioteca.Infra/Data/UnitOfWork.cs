namespace NWE.GerenciadorBiblioteca.Infra.Data;

public class UnitOfWork(BibliotecaContext context) : IUnitOfWork
{
    public BibliotecaContext Context { set; get; } = context;

    public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
}
