using NWE.GerenciadorBiblioteca.Domain.Entities;

namespace NWE.GerenciadorBiblioteca.Domain.Repositories;

public interface IEmprestimoRepository
{
    public Task<Emprestimo> AddAsync(Emprestimo emprestimo);
    public Task<Emprestimo> DevolverLivroAsync(Emprestimo emprestimo);
    public Task<bool> RemoveAsync(Emprestimo emprestimo);
    public Task<List<Emprestimo>> GetAllAsync();
    public Task<List<Emprestimo>> GetAllByUsuarioAsync(Guid idUsuario);
    public Task<List<Emprestimo>> GetAllByLivroAsync(Guid idLivro);
    public Task<Emprestimo?> GetByIdAsync(Guid id);
}
