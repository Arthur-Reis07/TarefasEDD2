using System.Collections.Generic;

public class Livros
{
    private List<Livro> acervo;

    public List<Livro> Acervo => acervo;

    public Livros()
    {
        acervo = new List<Livro>();
    }

    public void Adicionar(Livro livro)
    {
        if (!acervo.Contains(livro))
        {
            acervo.Add(livro);
        }
    }

    public Livro Pesquisar(Livro livro)
    {
        int index = acervo.IndexOf(livro);
        if (index >= 0)
        {
            return acervo[index];
        }
        return null;
    }
}
