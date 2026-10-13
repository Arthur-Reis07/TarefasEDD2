using System;

public class Tarefa
{
    private int id;
    private string titulo;
    private string descricao;
    private int prioridade; // 1=alta, 2=média, 3=baixa
    private string status; // "Aberta", "Fechada", "Cancelada"
    private DateTime dataCriacao;
    private DateTime dataConclusao;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descricao { get => descricao; set => descricao = value; }
    public int Prioridade { get => prioridade; set => prioridade = value; }
    public string Status { get => status; set => status = value; }
    public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
    public DateTime DataConclusao { get => dataConclusao; set => dataConclusao = value; }

    public Tarefa()
    {
        dataCriacao = DateTime.Now;
        dataConclusao = DateTime.MinValue;
        status = "Aberta";
        prioridade = 2;
    }

    public Tarefa(int id) : this()
    {
        this.id = id;
    }

    public Tarefa(int id, string titulo, string descricao, int prioridade) : this()
    {
        this.id = id;
        this.titulo = titulo;
        this.descricao = descricao;
        this.prioridade = prioridade;
    }

    public void Concluir()
    {
        status = "Fechada";
        dataConclusao = DateTime.Now;
    }

    public void Cancelar()
    {
        status = "Cancelada";
        dataConclusao = DateTime.Now;
    }

    public void Reabrir()
    {
        status = "Aberta";
        dataConclusao = DateTime.MinValue;
    }

    public string DescricaoPrioridade()
    {
        switch (prioridade)
        {
            case 1: return "Alta";
            case 2: return "Média";
            case 3: return "Baixa";
            default: return "Indefinida";
        }
    }

    public override bool Equals(object obj)
    {
        if (obj is Tarefa outra)
        {
            return this.id == outra.id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }

    public override string ToString()
    {
        string dtConc = dataConclusao == DateTime.MinValue ? "N/A" : dataConclusao.ToString("dd/MM/yyyy HH:mm");
        return $"[ID: {id}] {titulo} | Prioridade: {DescricaoPrioridade()} | Status: {status} | Criada: {dataCriacao:dd/MM/yyyy HH:mm} | Concluída/Cancelada: {dtConc}
  Descrição: {descricao}";
    }
}
