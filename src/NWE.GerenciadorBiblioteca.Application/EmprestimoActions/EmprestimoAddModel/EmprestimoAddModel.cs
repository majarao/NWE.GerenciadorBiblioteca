namespace NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoAddModel;

public record EmprestimoAddModel(Guid IdUsuario, Guid IdLivro, DateTime DataDevolucaoPrevista);
