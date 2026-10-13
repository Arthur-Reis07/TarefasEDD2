using System.Collections.Generic;

public class Guiches
{
    private List<Guiche> listaGuiches;

    public List<Guiche> ListaGuiches => listaGuiches;

    public Guiches()
    {
        listaGuiches = new List<Guiche>();
    }

    public void Adicionar(Guiche guiche)
    {
        listaGuiches.Add(guiche);
    }
}
