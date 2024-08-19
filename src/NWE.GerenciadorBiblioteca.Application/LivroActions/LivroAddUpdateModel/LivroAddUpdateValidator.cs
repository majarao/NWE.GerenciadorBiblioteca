using FluentValidation;

namespace NWE.GerenciadorBiblioteca.Application.LivroActions.LivroAddUpdateModel;

public class LivroAddUpdateValidator : AbstractValidator<LivroAddUpdateModel>
{
    public LivroAddUpdateValidator()
    {
        RuleFor(l => l.Titulo)
            .NotEmpty().WithMessage("Título não pode ser vazio")
            .NotNull().WithMessage("Título não pode ser vazio")
            .MinimumLength(1).WithMessage("Título precisa ter pelo menos um caráter")
            .MaximumLength(100).WithMessage("Título precisa ter no máximo 100 caracteres");

        RuleFor(l => l.Autor)
            .NotEmpty().WithMessage("Autor não pode ser vazio")
            .NotNull().WithMessage("Autor não pode ser vazio")
            .MinimumLength(1).WithMessage("Autor precisa ter pelo menos um caráter")
            .MaximumLength(100).WithMessage("Autor precisa ter no máximo 100 caracteres");

        RuleFor(l => l.ISBN)
            .NotEmpty().WithMessage("ISBN não pode ser vazio")
            .NotNull().WithMessage("ISBN não pode ser vazio")
            .Length(23).WithMessage("ISBN precisa ter 23 caracteres")
            .Matches("^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$")
                .WithMessage("ISBN inválido");

        RuleFor(l => l.AnoPublicacao)
            .GreaterThanOrEqualTo(1900).WithMessage("Ano de publicação precisa ser superior à 1900")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Ano de publicação não pode superior à {DateTime.Now.Year}");
    }
}
