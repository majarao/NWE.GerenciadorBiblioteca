using NWE.GerenciadorBiblioteca.Application.UsuarioActions.UsuarioAddUpdateModel;
using NWE.GerenciadorBiblioteca.Application.UsuarioActions.UsuarioDetailModel;

namespace NWE.GerenciadorBiblioteca.Application.Abstractions;

public interface IUsuarioService
{
    public Task<UsuarioDetailModel> AddAsync(UsuarioAddUpdateModel model);
    public Task<UsuarioDetailModel> UpdateAsync(Guid id, UsuarioAddUpdateModel model);
    public Task<bool> RemoveAsync(Guid id);
    public Task<List<UsuarioDetailModel>> GetAllAsync();
    public Task<UsuarioDetailModel?> GetByIdAsync(Guid id);
    public Task<UsuarioDetailModel?> GetByIdEmprestimosAsync(Guid id);
}
