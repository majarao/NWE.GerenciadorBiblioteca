using Microsoft.AspNetCore.Mvc;
using NWE.GerenciadorBiblioteca.Application.Abstractions;
using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoAddModel;
using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoDetailModel;

namespace NWE.GerenciadorBiblioteca.API.Controllers;

[Route("api/emprestimos")]
[ApiController]
public class EmprestimosController(IEmprestimoService emprestimoService) : ControllerBase
{
    private IEmprestimoService EmprestimoService { get; } = emprestimoService;

    [HttpPost]
    public async Task<IActionResult> AddAsync(EmprestimoAddModel model)
    {
        EmprestimoDetailModel detail = await EmprestimoService.AddAsync(model);
        return Ok(detail);
    }

    [HttpPut("devolver/{id:guid}")]
    public async Task<IActionResult> DevolverLivroAsync(Guid id)
    {
        EmprestimoDetailModel? detail = await EmprestimoService.GetByIdAsync(id);

        if (detail is null)
            return NotFound();

        if (detail.Id != id)
            return BadRequest();

        detail = await EmprestimoService.DevolverLivroAsync(id);
        return Ok($"Livro devolvido com {detail.DiaAtraso}(s) dias de atraso");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        EmprestimoDetailModel? detail = await EmprestimoService.GetByIdAsync(id);

        if (detail is null)
            return NotFound();

        return Ok(EmprestimoService.RemoveAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await EmprestimoService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        EmprestimoDetailModel? model = await EmprestimoService.GetByIdAsync(id);

        if (model is null)
            return NotFound();

        return Ok(model);
    }

    [HttpGet("usuarios/{idUsuario:guid}")]
    public async Task<IActionResult> GetAllByUsuarioAsync(Guid idUsuario) => Ok(await EmprestimoService.GetAllByUsuarioAsync(idUsuario));

    [HttpGet("livros/{idLivro:guid}")]
    public async Task<IActionResult> GetAllByLivroAsync(Guid idLivro) => Ok(await EmprestimoService.GetAllByLivroAsync(idLivro));
}
