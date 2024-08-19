using NWE.GerenciadorBiblioteca.Application.Abstractions;
using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoDetailModel;
using NWE.GerenciadorBiblioteca.Application.LivroActions.LivroAddUpdateModel;
using NWE.GerenciadorBiblioteca.Application.LivroActions.LivroDetailModel;
using NWE.GerenciadorBiblioteca.Domain.Entities;
using NWE.GerenciadorBiblioteca.Domain.Repositories;

namespace NWE.GerenciadorBiblioteca.Application.Services;

public class LivroService(ILivroRepository livroRepository) : ILivroService
{
    private ILivroRepository LivroRepository { get; } = livroRepository;

    public async Task<LivroDetailModel> AddAsync(LivroAddUpdateModel model)
    {
        Livro livro = new(model.Titulo, model.Autor, model.ISBN, model.AnoPublicacao);

        await LivroRepository.AddAsync(livro);

        return new(livro.Id, livro.Titulo, livro.Autor, livro.ISBN, livro.AnoPublicacao, []);
    }

    public async Task<LivroDetailModel> UpdateAsync(Guid id, LivroAddUpdateModel model)
    {
        Livro? livro = await LivroRepository.GetByIdAsync(id);

        if (livro is null)
            return new(id, model.Titulo, model.Autor, model.ISBN, model.AnoPublicacao, []);

        livro.AtualizarLivro(model.Titulo, model.Autor, model.ISBN, model.AnoPublicacao);

        await LivroRepository.UpdateAsync(livro);

        return new(livro.Id, livro.Titulo, livro.Autor, livro.ISBN, livro.AnoPublicacao, []);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        Livro? livro = await LivroRepository.GetByIdAsync(id);

        if (livro is null)
            return false;

        return await LivroRepository.RemoveAsync(livro);
    }

    public async Task<List<LivroDetailModel>> GetAllAsync()
    {
        List<Livro> livros = await LivroRepository.GetAllAsync();

        List<LivroDetailModel> models = [];

        foreach (Livro livro in livros)
            models.Add(new(livro.Id, livro.Titulo, livro.Autor, livro.ISBN, livro.AnoPublicacao, []));

        return models;
    }

    public async Task<LivroDetailModel?> GetByIdAsync(Guid id)
    {
        Livro? livro = await LivroRepository.GetByIdAsync(id);

        if (livro is null)
            return null;

        LivroDetailModel livroModel = new(livro.Id, livro.Titulo, livro.Autor, livro.ISBN, livro.AnoPublicacao, []);

        return livroModel;
    }

    public async Task<LivroDetailModel?> GetByIdEmprestimosAsync(Guid id)
    {
        Livro? livro = await LivroRepository.GetByIdEmprestimosAsync(id);

        if (livro is null)
            return null;

        List<EmprestimoDetailModel> emprestimosModel = [];
        foreach (Emprestimo emprestimo in livro.Emprestimos)
            emprestimosModel.Add(new(emprestimo.Id, emprestimo.DataEmprestimo, emprestimo.DataDevolucaoPrevista, emprestimo.DataDevolucao, emprestimo.DiaAtraso));

        LivroDetailModel livroModel = new(livro.Id, livro.Titulo, livro.Autor, livro.ISBN, livro.AnoPublicacao, emprestimosModel);

        return livroModel;
    }
}
