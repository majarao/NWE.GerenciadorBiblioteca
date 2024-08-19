using Microsoft.EntityFrameworkCore;
using NWE.GerenciadorBiblioteca.Domain.Entities;
using NWE.GerenciadorBiblioteca.Domain.Repositories;
using NWE.GerenciadorBiblioteca.Infra.Data;

namespace NWE.GerenciadorBiblioteca.Infra.Repositories;

public class UsuarioRepository(IUnitOfWork unitOfWork) : IUsuarioRepository
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<Usuario> AddAsync(Usuario usuario)
    {
        await UnitOfWork.Context.AddAsync(usuario);
        await UnitOfWork.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        UnitOfWork.Context.Update(usuario);
        await UnitOfWork.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> RemoveAsync(Usuario usuario)
    {
        UnitOfWork.Context.Remove(usuario);
        return await UnitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<List<Usuario>> GetAllAsync() => await UnitOfWork.Context.Usuarios.ToListAsync();

    public async Task<Usuario?> GetByIdAsync(Guid id) => await UnitOfWork.Context.Usuarios.SingleOrDefaultAsync(t => t.Id == id);

    public async Task<Usuario?> GetByIdEmprestimosAsync(Guid id) => await UnitOfWork.Context.Usuarios.Include(u => u.Emprestimos).SingleOrDefaultAsync(t => t.Id == id);
}
