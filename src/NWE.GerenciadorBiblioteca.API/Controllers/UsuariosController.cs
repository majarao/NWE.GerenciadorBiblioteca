using Microsoft.AspNetCore.Mvc;
using NWE.GerenciadorBiblioteca.Application.Abstractions;
using NWE.GerenciadorBiblioteca.Application.UsuarioActions.UsuarioAddUpdateModel;
using NWE.GerenciadorBiblioteca.Application.UsuarioActions.UsuarioDetailModel;

namespace NWE.GerenciadorBiblioteca.API.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UsuariosController(IUsuarioService usuarioService) : ControllerBase
{
    private IUsuarioService UsuarioService { get; } = usuarioService;

    [HttpPost]
    public async Task<IActionResult> AddAsync(UsuarioAddUpdateModel model)
    {
        UsuarioDetailModel detail = await UsuarioService.AddAsync(model);
        return Ok(detail);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UsuarioAddUpdateModel model)
    {
        UsuarioDetailModel? detail = await UsuarioService.GetByIdAsync(id);

        if (detail is null)
            return NotFound();

        if (detail.Id != id)
            return BadRequest();

        detail = await UsuarioService.UpdateAsync(id, model);
        return Ok(detail);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        UsuarioDetailModel? detail = await UsuarioService.GetByIdAsync(id);

        if (detail is null)
            return NotFound();

        return Ok(UsuarioService.RemoveAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await UsuarioService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        UsuarioDetailModel? model = await UsuarioService.GetByIdAsync(id);

        if (model is null)
            return NotFound();

        return Ok(model);
    }

    [HttpGet("{id:guid}/emprestimos")]
    public async Task<IActionResult> GetByIdEmprestimos(Guid id)
    {
        UsuarioDetailModel? model = await UsuarioService.GetByIdEmprestimosAsync(id);

        if (model is null)
            return NotFound();

        return Ok(model);
    }
}
