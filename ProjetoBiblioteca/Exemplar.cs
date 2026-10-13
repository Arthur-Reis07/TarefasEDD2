using System;
using System.Collections.Generic;

public class Exemplar
{
    private int tombo;
    private List<Emprestimo> emprestimos;

    public int Tombo
    {
        get => tombo;
        set => tombo = value;
    }

    public List<Emprestimo> Emprestimos => emprestimos;

    public Exemplar()
    {
        emprestimos = new List<Emprestimo>();
    }

    public Exemplar(int tombo)
    {
        this.tombo = tombo;
        this.emprestimos = new List<Emprestimo>();
    }

    public bool Disponivel()
    {
        if (emprestimos.Count == 0) return true;
        
        // Se o último empréstimo não tiver data de devolução preenchida, está emprestado
        Emprestimo ultimo = emprestimos[emprestimos.Count - 1];
        return ultimo.DtDevolucao != DateTime.MinValue;
    }

    public bool Emprestar()
    {
        if (Disponivel())
        {
            emprestimos.Add(new Emprestimo(DateTime.Now));
            return true;
        }
        return false;
    }

    public bool Devolver()
    {
        if (!Disponivel())
        {
            Emprestimo ultimo = emprestimos[emprestimos.Count - 1];
            ultimo.DtDevolucao = DateTime.Now;
            return true;
        }
        return false;
    }

    public int QtdeEmprestimos()
    {
        return emprestimos.Count;
    }
}
