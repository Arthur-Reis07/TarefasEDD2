using System;
using System.Collections.Generic;
using System.Text;

public class Contato
{
    private string email;
    private string nome;
    private Data dtNasc;
    private List<Telefone> telefones;

    public string Email { get => email; set => email = value; }
    public string Nome { get => nome; set => nome = value; }
    public Data DtNasc { get => dtNasc; set => dtNasc = value; }
    public List<Telefone> Telefones => telefones;

    public Contato()
    {
        telefones = new List<Telefone>();
        dtNasc = new Data();
    }

    public Contato(string email, string nome, Data dtNasc)
    {
        this.email = email;
        this.nome = nome;
        this.dtNasc = dtNasc;
        this.telefones = new List<Telefone>();
    }

    public Contato(string email)
    {
        this.email = email;
        this.telefones = new List<Telefone>();
        this.dtNasc = new Data();
    }

    public int GetIdade()
    {
        if (dtNasc == null || dtNasc.Ano == 0) return 0;

        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - dtNasc.Ano;

        if (hoje.Month < dtNasc.Mes || (hoje.Month == dtNasc.Mes && hoje.Day < dtNasc.Dia))
        {
            idade--;
        }

        return idade;
    }

    public void AdicionarTelefone(Telefone t)
    {
        if (t.Principal)
        {
            foreach (var tel in telefones)
            {
                tel.Principal = false;
            }
        }
        telefones.Add(t);
    }

    public string GetTelefonePrincipal()
    {
        foreach (var t in telefones)
        {
            if (t.Principal)
            {
                return $"{t.Tipo}: {t.Numero}";
            }
        }
        return telefones.Count > 0 ? $"{telefones[0].Tipo}: {telefones[0].Numero}" : "Nenhum telefone";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Nome: {nome}");
        sb.AppendLine($"E-mail: {email}");
        sb.AppendLine($"Data Nasc.: {dtNasc} ({GetIdade()} anos)");
        sb.AppendLine($"Tel. Principal: {GetTelefonePrincipal()}");
        sb.AppendLine("Todos os Telefones:");
        if (telefones.Count == 0)
        {
            sb.AppendLine("  (nenhum)");
        }
        else
        {
            foreach (var t in telefones)
            {
                sb.AppendLine($"  - [{t.Tipo}] {t.Numero} {(t.Principal ? "(Principal)" : "")}");
            }
        }
        return sb.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj is Contato outro)
        {
            return string.Equals(this.email, outro.email, StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return email != null ? email.ToLower().GetHashCode() : 0;
    }
}
