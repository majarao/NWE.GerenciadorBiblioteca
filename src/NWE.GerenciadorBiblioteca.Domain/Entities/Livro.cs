namespace NWE.GerenciadorBiblioteca.Domain.Entities;

public class Livro : Entity
{
    protected Livro() { }

    public Livro(string titulo, string autor, string isbn, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        ISBN = isbn;
        AnoPublicacao = anoPublicacao;
    }

    public string Titulo { get; private set; } = string.Empty;
    public string Autor { get; private set; } = string.Empty;
    public string ISBN { get; private set; } = string.Empty;
    public int AnoPublicacao { get; private set; }

    public List<Emprestimo> Emprestimos { get; private set; } = [];

    public void AtualizarLivro(string titulo, string autor, string isbn, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        ISBN = isbn;
        AnoPublicacao = anoPublicacao;
    }
}
