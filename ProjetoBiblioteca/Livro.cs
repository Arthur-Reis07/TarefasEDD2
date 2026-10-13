using System;
using System.Collections.Generic;
using System.Text;

public class Livro
{
    private int isbn;
    private string titulo;
    private string autor;
    private string editora;
    private List<Exemplar> exemplares;

    public int Isbn
    {
        get => isbn;
        set => isbn = value;
    }

    public string Titulo
    {
        get => titulo;
        set => titulo = value;
    }

    public string Autor
    {
        get => autor;
        set => autor = value;
    }

    public string Editora
    {
        get => editora;
        set => editora = value;
    }

    public List<Exemplar> Exemplares => exemplares;

    public Livro()
    {
        exemplares = new List<Exemplar>();
    }

    public Livro(int isbn, string titulo, string autor, string editora)
    {
        this.isbn = isbn;
        this.titulo = titulo;
        this.autor = autor;
        this.editora = editora;
        this.exemplares = new List<Exemplar>();
    }

    public Livro(int isbn)
    {
        this.isbn = isbn;
        this.exemplares = new List<Exemplar>();
    }

    public void AdicionarExemplar(Exemplar exemplar)
    {
        exemplares.Add(exemplar);
    }

    public int QtdeExemplares()
    {
        return exemplares.Count;
    }

    public int QtdeDisponiveis()
    {
        int cont = 0;
        foreach (var ex in exemplares)
        {
            if (ex.Disponivel()) cont++;
        }
        return cont;
    }

    public int QtdeEmprestimos()
    {
        int total = 0;
        foreach (var ex in exemplares)
        {
            total += ex.QtdeEmprestimos();
        }
        return total;
    }

    public double PercDisponibilidade()
    {
        if (exemplares.Count == 0) return 0.0;
        return ((double)QtdeDisponiveis() / QtdeExemplares()) * 100.0;
    }

    public override bool Equals(object obj)
    {
        if (obj is Livro outro)
        {
            return this.isbn == outro.isbn;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return isbn.GetHashCode();
    }
}
