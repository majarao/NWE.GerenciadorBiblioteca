using Microsoft.AspNetCore.Mvc;
using NWE.GerenciadorBiblioteca.Application.Abstractions;
using NWE.GerenciadorBiblioteca.Application.LivroActions.LivroAddUpdateModel;
using NWE.GerenciadorBiblioteca.Application.LivroActions.LivroDetailModel;

namespace NWE.GerenciadorBiblioteca.API.Controllers;

[Route("api/livros")]
[ApiController]
public class LivrosController(ILivroService livroService) : ControllerBase
{
    private ILivroService LivroService { get; } = livroService;

    [HttpPost]
    public async Task<IActionResult> AddAsync(LivroAddUpdateModel model)
    {
        LivroDetailModel detail = await LivroService.AddAsync(model);
        return Ok(detail);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, LivroAddUpdateModel model)
    {
        LivroDetailModel? detail = await LivroService.GetByIdAsync(id);

        if (detail is null)
            return NotFound();

        if (detail.Id != id)
            return BadRequest();

        detail = await LivroService.UpdateAsync(id, model);
        return Ok(detail);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        LivroDetailModel? detail = await LivroService.GetByIdAsync(id);

        if (detail is null)
            return NotFound();

        return Ok(LivroService.RemoveAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await LivroService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        LivroDetailModel? model = await LivroService.GetByIdAsync(id);

        if (model is null)
            return NotFound();

        return Ok(model);
    }

    [HttpGet("{id:guid}/emprestimos")]
    public async Task<IActionResult> GetByIdEmprestimos(Guid id)
    {
        LivroDetailModel? model = await LivroService.GetByIdEmprestimosAsync(id);

        if (model is null)
            return NotFound();

        return Ok(model);
    }
}
