using Microsoft.EntityFrameworkCore;
using NWE.GerenciadorBiblioteca.Domain.Entities;
using NWE.GerenciadorBiblioteca.Domain.Repositories;
using NWE.GerenciadorBiblioteca.Infra.Data;

namespace NWE.GerenciadorBiblioteca.Infra.Repositories;

public class LivroRepository(IUnitOfWork unitOfWork) : ILivroRepository
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<Livro> AddAsync(Livro livro)
    {
        await UnitOfWork.Context.AddAsync(livro);
        await UnitOfWork.SaveChangesAsync();
        return livro;
    }

    public async Task<Livro> UpdateAsync(Livro livro)
    {
        UnitOfWork.Context.Update(livro);
        await UnitOfWork.SaveChangesAsync();
        return livro;
    }

    public async Task<bool> RemoveAsync(Livro livro)
    {
        UnitOfWork.Context.Remove(livro);
        return await UnitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<List<Livro>> GetAllAsync() => await UnitOfWork.Context.Livros.ToListAsync();

    public async Task<Livro?> GetByIdAsync(Guid id) => await UnitOfWork.Context.Livros.SingleOrDefaultAsync(l => l.Id == id);

    public async Task<Livro?> GetByIdEmprestimosAsync(Guid id) => await UnitOfWork.Context.Livros.Include(l => l.Emprestimos).SingleOrDefaultAsync(l => l.Id == id);
}
