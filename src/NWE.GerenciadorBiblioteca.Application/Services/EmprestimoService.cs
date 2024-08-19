using NWE.GerenciadorBiblioteca.Application.Abstractions;
using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoAddModel;
using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoDetailModel;
using NWE.GerenciadorBiblioteca.Domain.Entities;
using NWE.GerenciadorBiblioteca.Domain.Repositories;

namespace NWE.GerenciadorBiblioteca.Application.Services;

public class EmprestimoService(IEmprestimoRepository emprestimoRepository) : IEmprestimoService
{
    private IEmprestimoRepository EmprestimoRepository { get; } = emprestimoRepository;

    public async Task<EmprestimoDetailModel> AddAsync(EmprestimoAddModel model)
    {
        Emprestimo emprestimo = new(model.IdUsuario, model.IdLivro, model.DataDevolucaoPrevista);

        await EmprestimoRepository.AddAsync(emprestimo);

        return new(emprestimo.Id, emprestimo.DataEmprestimo, emprestimo.DataDevolucaoPrevista, emprestimo.DataDevolucao, emprestimo.DiaAtraso);
    }

    public async Task<EmprestimoDetailModel> DevolverLivroAsync(Guid id)
    {
        Emprestimo? emprestimo = await EmprestimoRepository.GetByIdAsync(id);

        if (emprestimo == null)
            return new(Guid.NewGuid(), DateTime.Now, DateTime.Now, DateTime.Now, 0);

        emprestimo.DevolverLivro();

        await EmprestimoRepository.DevolverLivroAsync(emprestimo);

        return new(emprestimo.Id, emprestimo.DataEmprestimo, emprestimo.DataDevolucaoPrevista, emprestimo.DataDevolucao, emprestimo.DiaAtraso);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        Emprestimo? emprestimo = await EmprestimoRepository.GetByIdAsync(id);

        if (emprestimo is null)
            return false;

        return await EmprestimoRepository.RemoveAsync(emprestimo);
    }

    public async Task<List<EmprestimoDetailModel>> GetAllAsync()
    {
        List<Emprestimo> emprestimos = await EmprestimoRepository.GetAllAsync();

        List<EmprestimoDetailModel> models = [];

        foreach (Emprestimo emprestimo in emprestimos)
            models.Add(new(emprestimo.Id, emprestimo.DataEmprestimo, emprestimo.DataDevolucaoPrevista, emprestimo.DataDevolucao, emprestimo.DiaAtraso));

        return models;
    }

    public async Task<List<EmprestimoDetailModel>> GetAllByLivroAsync(Guid idLivro)
    {
        List<Emprestimo> emprestimos = await EmprestimoRepository.GetAllByLivroAsync(idLivro);

        List<EmprestimoDetailModel> models = [];

        foreach (Emprestimo emprestimo in emprestimos)
            models.Add(new(emprestimo.Id, emprestimo.DataEmprestimo, emprestimo.DataDevolucaoPrevista, emprestimo.DataDevolucao, emprestimo.DiaAtraso));

        return models;
    }

    public async Task<List<EmprestimoDetailModel>> GetAllByUsuarioAsync(Guid idUsuario)
    {
        List<Emprestimo> emprestimos = await EmprestimoRepository.GetAllByUsuarioAsync(idUsuario);

        List<EmprestimoDetailModel> models = [];

        foreach (Emprestimo emprestimo in emprestimos)
            models.Add(new(emprestimo.Id, emprestimo.DataEmprestimo, emprestimo.DataDevolucaoPrevista, emprestimo.DataDevolucao, emprestimo.DiaAtraso));

        return models;
    }

    public async Task<EmprestimoDetailModel?> GetByIdAsync(Guid id)
    {
        Emprestimo? emprestimo = await EmprestimoRepository.GetByIdAsync(id);

        if (emprestimo is null)
            return null;

        EmprestimoDetailModel emprestimoModel = new(emprestimo.Id, emprestimo.DataEmprestimo, emprestimo.DataDevolucaoPrevista, emprestimo.DataDevolucao, emprestimo.DiaAtraso);

        return emprestimoModel;
    }
}
