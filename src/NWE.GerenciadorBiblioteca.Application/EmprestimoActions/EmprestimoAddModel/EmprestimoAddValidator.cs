using FluentValidation;

namespace NWE.GerenciadorBiblioteca.Application.EmprestimoActions.EmprestimoAddModel;

public class EmprestimoAddValidator : AbstractValidator<EmprestimoAddModel>
{
    public EmprestimoAddValidator()
    {
        RuleFor(e => e.IdLivro)
            .NotEmpty().WithMessage("Necessário informar o livro emprestado")
            .NotNull().WithMessage("Necessário informar o livro emprestado");

        RuleFor(e => e.IdUsuario)
            .NotEmpty().WithMessage("Necessário informar o usuário")
            .NotNull().WithMessage("Necessário informar o usuário");

        RuleFor(e => e.DataDevolucaoPrevista)
            .NotEmpty().WithMessage("Necessário informar a data de devolução prevista")
            .NotNull().WithMessage("Necessário informar a data de devolução prevista");
    }
}
