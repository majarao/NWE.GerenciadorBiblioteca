using FluentValidation;

namespace NWE.GerenciadorBiblioteca.Application.UsuarioActions.UsuarioAddUpdateModel;

public class UsuarioAddUpdateValidator : AbstractValidator<UsuarioAddUpdateModel>
{
    public UsuarioAddUpdateValidator()
    {
        RuleFor(u => u.Nome)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .NotNull().WithMessage("Nome não pode ser vazio")
            .MinimumLength(1).WithMessage("Nome precisa ter pelo menos um caráter")
            .MaximumLength(100).WithMessage("Nome precisa ter no máximo 100 caracteres");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("E-mail não pode ser vazio")
            .NotNull().WithMessage("E-mail não pode ser vazio")
            .MinimumLength(1).WithMessage("E-mail precisa ter pelo menos um caráter")
            .MaximumLength(100).WithMessage("E-mail precisa ter no máximo 100 caracteres")
            .EmailAddress().WithMessage("E-mail inválido");
    }
}
