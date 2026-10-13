using System.Collections.Generic;

public class Projetos
{
    private List<Projeto> itens;

    public List<Projeto> Itens => itens;

    public Projetos()
    {
        itens = new List<Projeto>();
    }

    public bool Adicionar(Projeto p)
    {
        if (itens.Contains(p))
        {
            return false;
        }
        itens.Add(p);
        return true;
    }

    public bool Remover(Projeto p)
    {
        Projeto encontrado = Buscar(p);
        if (encontrado != null && encontrado.Tarefas.Count == 0)
        {
            return itens.Remove(encontrado);
        }
        return false;
    }

    public Projeto Buscar(Projeto p)
    {
        int index = itens.IndexOf(p);
        if (index >= 0)
        {
            return itens[index];
        }
        return null;
    }

    public List<Projeto> Listar()
    {
        return itens;
    }
}
