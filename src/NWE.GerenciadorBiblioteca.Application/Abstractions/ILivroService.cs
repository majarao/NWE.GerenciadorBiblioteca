using NWE.GerenciadorBiblioteca.Application.LivroActions.LivroAddUpdateModel;
using NWE.GerenciadorBiblioteca.Application.LivroActions.LivroDetailModel;

namespace NWE.GerenciadorBiblioteca.Application.Abstractions;

public interface ILivroService
{
    public Task<LivroDetailModel> AddAsync(LivroAddUpdateModel model);
    public Task<LivroDetailModel> UpdateAsync(Guid id, LivroAddUpdateModel model);
    public Task<bool> RemoveAsync(Guid id);
    public Task<List<LivroDetailModel>> GetAllAsync();
    public Task<LivroDetailModel> GetByIdAsync(Guid id);
    public Task<LivroDetailModel> GetByIdEmprestimosAsync(Guid id);
}
