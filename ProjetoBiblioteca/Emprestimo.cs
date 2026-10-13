using System;

public class Emprestimo
{
    private DateTime dtEmprestimo;
    private DateTime dtDevolucao;

    public DateTime DtEmprestimo
    {
        get => dtEmprestimo;
        set => dtEmprestimo = value;
    }

    public DateTime DtDevolucao
    {
        get => dtDevolucao;
        set => dtDevolucao = value;
    }

    public Emprestimo()
    {
        dtEmprestimo = DateTime.Now;
        dtDevolucao = DateTime.MinValue; // Indicativo de empréstimo ativo (não devolvido)
    }

    public Emprestimo(DateTime dtEmprestimo)
    {
        this.dtEmprestimo = dtEmprestimo;
        this.dtDevolucao = DateTime.MinValue;
    }
}
