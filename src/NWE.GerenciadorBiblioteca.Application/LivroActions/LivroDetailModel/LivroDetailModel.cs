using NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoDetailModel;

namespace NWE.GerenciadorBiblioteca.Application.LivroActions.LivroDetailModel;

public record LivroDetailModel(Guid Id, string Titulo, string Autor, string ISBN, int AnoPublicacao, List<EmprestimoDetailModel> Emprestimos);
