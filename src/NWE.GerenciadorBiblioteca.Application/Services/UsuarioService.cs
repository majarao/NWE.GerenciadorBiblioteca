using NWE.GerenciadorBiblioteca.Application.Abstractions;
using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoDetailModel;
using NWE.GerenciadorBiblioteca.Application.UsuarioActions.UsuarioAddUpdateModel;
using NWE.GerenciadorBiblioteca.Application.UsuarioActions.UsuarioDetailModel;
using NWE.GerenciadorBiblioteca.Domain.Entities;
using NWE.GerenciadorBiblioteca.Domain.Repositories;

namespace NWE.GerenciadorBiblioteca.Application.Services;

public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
{
    private IUsuarioRepository UsuarioRepository { get; } = usuarioRepository;

    public async Task<UsuarioDetailModel> AddAsync(UsuarioAddUpdateModel model)
    {
        Usuario usuario = new(model.Nome, model.Email);

        await UsuarioRepository.AddAsync(usuario);

        return new(usuario.Id, usuario.Nome, usuario.Email, []);
    }

    public async Task<UsuarioDetailModel> UpdateAsync(Guid id, UsuarioAddUpdateModel model)
    {
        Usuario? usuario = await UsuarioRepository.GetByIdAsync(id);

        if (usuario is null)
            return new(id, model.Nome, model.Email, []);

        usuario.AtualizarUsuario(model.Nome, model.Email);

        await UsuarioRepository.UpdateAsync(usuario);

        return new(usuario.Id, usuario.Nome, usuario.Email, []);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        Usuario? usuario = await UsuarioRepository.GetByIdAsync(id);

        if (usuario is null)
            return false;

        return await UsuarioRepository.RemoveAsync(usuario);
    }

    public async Task<List<UsuarioDetailModel>> GetAllAsync()
    {
        List<Usuario> usuarios = await UsuarioRepository.GetAllAsync();

        List<UsuarioDetailModel> models = [];

        foreach (Usuario usuario in usuarios)
            models.Add(new(usuario.Id, usuario.Nome, usuario.Email, []));

        return models;
    }

    public async Task<UsuarioDetailModel?> GetByIdAsync(Guid id)
    {
        Usuario? usuario = await UsuarioRepository.GetByIdAsync(id);

        if (usuario is null)
            return null;

        UsuarioDetailModel usuarioModel = new(usuario.Id, usuario.Nome, usuario.Email, []);

        return usuarioModel;
    }

    public async Task<UsuarioDetailModel?> GetByIdEmprestimosAsync(Guid id)
    {
        Usuario? usuario = await UsuarioRepository.GetByIdEmprestimosAsync(id);

        if (usuario is null)
            return null;

        List<EmprestimoDetailModel> emprestimosModel = [];
        foreach (Emprestimo emprestimo in usuario.Emprestimos)
            emprestimosModel.Add(new(emprestimo.Id, emprestimo.DataEmprestimo, emprestimo.DataDevolucaoPrevista, emprestimo.DataDevolucao, emprestimo.DiaAtraso));

        UsuarioDetailModel usuarioModel = new(usuario.Id, usuario.Nome, usuario.Email, emprestimosModel);

        return usuarioModel;
    }
}
