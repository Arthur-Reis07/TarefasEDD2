public class Item
{
    public int Id { get; private set; }
    public string Descricao { get; private set; }
    public double Preco { get; private set; }

    public Item(int id, string descricao, double preco)
    {
        Id = id;
        Descricao = descricao;
        Preco = preco;
    }
}
