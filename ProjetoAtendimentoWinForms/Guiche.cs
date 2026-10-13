using System;
using System.Collections.Generic;

public class Guiche
{
    private int id;
    private Queue<Senha> atendimentos;

    public int Id { get => id; set => id = value; }
    public Queue<Senha> Atendimentos => atendimentos;

    public Guiche()
    {
        this.id = 0;
        this.atendimentos = new Queue<Senha>();
    }

    public Guiche(int id)
    {
        this.id = id;
        this.atendimentos = new Queue<Senha>();
    }

    public bool Chamar(Queue<Senha> filaSenhas)
    {
        if (filaSenhas != null && filaSenhas.Count > 0)
        {
            Senha senhaAtendida = filaSenhas.Dequeue();
            DateTime agora = DateTime.Now;
            senhaAtendida.DataAtend = agora.Date;
            senhaAtendida.HoraAtend = agora;

            atendimentos.Enqueue(senhaAtendida);
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Guichê {id}";
    }
}
