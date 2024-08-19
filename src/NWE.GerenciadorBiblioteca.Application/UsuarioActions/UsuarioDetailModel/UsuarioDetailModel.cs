using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoDetailModel;

namespace NWE.GerenciadorBiblioteca.Application.UsuarioActions.UsuarioDetailModel;

public record UsuarioDetailModel(Guid Id, string Nome, string Email, List<EmprestimoDetailModel> Emprestimos);
