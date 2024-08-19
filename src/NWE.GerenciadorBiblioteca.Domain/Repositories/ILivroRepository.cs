using NWE.GerenciadorBiblioteca.Domain.Entities;

namespace NWE.GerenciadorBiblioteca.Domain.Repositories;

public interface ILivroRepository
{
    public Task<Livro> AddAsync(Livro livro);
    public Task<Livro> UpdateAsync(Livro livro);
    public Task<bool> RemoveAsync(Livro livro);
    public Task<List<Livro>> GetAllAsync();
    public Task<Livro?> GetByIdAsync(Guid id);
    public Task<Livro?> GetByIdEmprestimosAsync(Guid id);
}
