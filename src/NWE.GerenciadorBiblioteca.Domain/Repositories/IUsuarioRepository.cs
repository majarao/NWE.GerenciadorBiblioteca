using NWE.GerenciadorBiblioteca.Domain.Entities;

namespace NWE.GerenciadorBiblioteca.Domain.Repositories;

public interface IUsuarioRepository
{
    public Task<Usuario> AddAsync(Usuario usuario);
    public Task<Usuario> UpdateAsync(Usuario usuario);
    public Task<bool> RemoveAsync(Usuario usuario);
    public Task<List<Usuario>> GetAllAsync();
    public Task<Usuario?> GetByIdAsync(Guid id);
    public Task<Usuario?> GetByIdEmprestimosAsync(Guid id);
}
