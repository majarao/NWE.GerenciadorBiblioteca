namespace NWE.GerenciadorBiblioteca.Domain.Entities;

public class Usuario : Entity
{
    protected Usuario() { }

    public Usuario(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }

    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public List<Emprestimo> Emprestimos { get; private set; } = [];

    public void AtualizarUsuario(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}
