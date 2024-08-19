namespace NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoDetailModel;

public record EmprestimoDetailModel(Guid Id, DateTime DataEmprestimo, DateTime DataDevolucaoPrevista, DateTime? DataDevolucao, int DiaAtraso);
