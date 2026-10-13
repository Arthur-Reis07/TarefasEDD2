using System.Collections.Generic;

public class Projeto
{
    private int id;
    private string nome;
    private List<Tarefa> tarefas;

    public int Id { get => id; set => id = value; }
    public string Nome { get => nome; set => nome = value; }
    public List<Tarefa> Tarefas => tarefas;

    public Projeto()
    {
        tarefas = new List<Tarefa>();
    }

    public Projeto(int id) : this()
    {
        this.id = id;
    }

    public Projeto(int id, string nome) : this()
    {
        this.id = id;
        this.nome = nome;
    }

    public void AdicionarTarefa(Tarefa t)
    {
        if (!tarefas.Contains(t))
        {
            tarefas.Add(t);
        }
    }

    public bool RemoverTarefa(Tarefa t)
    {
        return tarefas.Remove(t);
    }

    public Tarefa BuscarTarefa(Tarefa t)
    {
        int index = tarefas.IndexOf(t);
        if (index >= 0)
        {
            return tarefas[index];
        }
        return null;
    }

    public List<Tarefa> TarefasPorStatus(string s)
    {
        List<Tarefa> filtradas = new List<Tarefa>();
        foreach (var t in tarefas)
        {
            if (t.Status.Equals(s, System.StringComparison.OrdinalIgnoreCase))
            {
                filtradas.Add(t);
            }
        }
        return filtradas;
    }

    public List<Tarefa> TarefasPorPrioridade(int p)
    {
        List<Tarefa> filtradas = new List<Tarefa>();
        foreach (var t in tarefas)
        {
            if (t.Prioridade == p)
            {
                filtradas.Add(t);
            }
        }
        return filtradas;
    }

    public int TotalAbertas()
    {
        return TarefasPorStatus("Aberta").Count;
    }

    public int TotalFechadas()
    {
        return TarefasPorStatus("Fechada").Count;
    }

    public int TotalCanceladas()
    {
        return TarefasPorStatus("Cancelada").Count;
    }

    public override bool Equals(object obj)
    {
        if (obj is Projeto outro)
        {
            return this.id == outro.id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}
