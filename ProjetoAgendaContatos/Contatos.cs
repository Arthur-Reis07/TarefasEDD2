using System.Collections.Generic;

public class Contatos
{
    private readonly List<Contato> agenda;

    public List<Contato> Agenda => agenda;

    public Contatos()
    {
        agenda = new List<Contato>();
    }

    public bool Adicionar(Contato c)
    {
        if (agenda.Contains(c))
        {
            return false;
        }
        agenda.Add(c);
        return true;
    }

    public Contato Pesquisar(Contato c)
    {
        int index = agenda.IndexOf(c);
        if (index >= 0)
        {
            return agenda[index];
        }
        return null;
    }

    public bool Alterar(Contato c)
    {
        int index = agenda.IndexOf(c);
        if (index >= 0)
        {
            agenda[index].Nome = c.Nome;
            agenda[index].DtNasc = c.DtNasc;
            return true;
        }
        return false;
    }

    public bool Remover(Contato c)
    {
        return agenda.Remove(c);
    }
}
