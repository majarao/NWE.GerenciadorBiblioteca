using Microsoft.EntityFrameworkCore;
using NWE.GerenciadorBiblioteca.Domain.Entities;
using NWE.GerenciadorBiblioteca.Domain.Repositories;
using NWE.GerenciadorBiblioteca.Infra.Data;

namespace NWE.GerenciadorBiblioteca.Infra.Repositories;

public class EmprestimoRepository(IUnitOfWork unitOfWork) : IEmprestimoRepository
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<Emprestimo> AddAsync(Emprestimo emprestimo)
    {
        await UnitOfWork.Context.AddAsync(emprestimo);
        await UnitOfWork.SaveChangesAsync();
        return emprestimo;
    }

    public async Task<Emprestimo> DevolverLivroAsync(Emprestimo emprestimo)
    {
        UnitOfWork.Context.Update(emprestimo);
        await UnitOfWork.SaveChangesAsync();
        return emprestimo;
    }

    public async Task<bool> RemoveAsync(Emprestimo emprestimo)
    {
        UnitOfWork.Context.Remove(emprestimo);
        return await UnitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<List<Emprestimo>> GetAllAsync() => await UnitOfWork.Context.Emprestimos.ToListAsync();

    public async Task<List<Emprestimo>> GetAllByUsuarioAsync(Guid idUsuario) => await UnitOfWork.Context.Emprestimos.Where(e => e.IdUsuario == idUsuario).ToListAsync();

    public async Task<List<Emprestimo>> GetAllByLivroAsync(Guid idLivro) => await UnitOfWork.Context.Emprestimos.Where(e => e.IdLivro == idLivro).ToListAsync();

    public async Task<Emprestimo?> GetByIdAsync(Guid id) => await UnitOfWork.Context.Emprestimos.SingleOrDefaultAsync(t => t.Id == id);
}
