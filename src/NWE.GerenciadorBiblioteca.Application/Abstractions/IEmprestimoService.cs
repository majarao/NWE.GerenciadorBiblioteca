using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoAddModel;
using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoDetailModel;

namespace NWE.GerenciadorBiblioteca.Application.Abstractions;

public interface IEmprestimoService
{
    public Task<EmprestimoDetailModel> AddAsync(EmprestimoAddModel model);
    public Task<EmprestimoDetailModel> DevolverLivroAsync(Guid id);
    public Task<bool> RemoveAsync(Guid id);
    public Task<List<EmprestimoDetailModel>> GetAllAsync();
    public Task<List<EmprestimoDetailModel>> GetAllByUsuarioAsync(Guid idUsuario);
    public Task<List<EmprestimoDetailModel>> GetAllByLivroAsync(Guid idLivro);
    public Task<EmprestimoDetailModel?> GetByIdAsync(Guid id);
}
