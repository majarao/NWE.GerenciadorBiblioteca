using Microsoft.VisualBasic;

namespace NWE.GerenciadorBiblioteca.Domain.Entities;

public class Emprestimo : Entity
{
    protected Emprestimo() { }

    public Emprestimo(Guid idUsuario, Guid idLivro, DateTime dataDevolucaoPrevista)
    {
        IdUsuario = idUsuario;
        IdLivro = idLivro;
        DataDevolucaoPrevista = dataDevolucaoPrevista;
    }

    public Guid IdUsuario { get; private set; }
    public Guid IdLivro { get; private set; }
    public DateTime DataEmprestimo { get; private set; } = DateTime.Now;
    public DateTime DataDevolucaoPrevista { get; private set; }
    public DateTime? DataDevolucao { get; private set; }
    public int DiaAtraso { get; private set; }

    public Usuario? Usuario { get; private set; }
    public Livro? Livro { get; private set; }

    public void DevolverLivro()
    {
        DataDevolucao = DateTime.Now;
        DiaAtraso = (int)DateAndTime.DateDiff(DateInterval.Day, DataDevolucaoPrevista, (DateTime)DataDevolucao);
    }
}
