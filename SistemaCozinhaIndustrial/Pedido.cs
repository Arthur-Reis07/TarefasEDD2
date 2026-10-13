using System;
using System.Text;

public class Pedido
{
    private int id;
    private string cliente;
    private Item[] itens;
    private int contadorItens;

    public Pedido(int id, string cliente)
    {
        this.id = id;
        this.cliente = cliente;
        this.itens = new Item[10];
        this.contadorItens = 0;
    }

    public int Id => id;
    public string Cliente => cliente;

    public bool AdicionarItem(Item item)
    {
        if (contadorItens < 10)
        {
            itens[contadorItens] = item;
            contadorItens++;
            return true;
        }
        return false;
    }

    public bool RemoverItem(Item item)
    {
        for (int i = 0; i < contadorItens; i++)
        {
            if (itens[i] != null && itens[i].Id == item.Id)
            {
                for (int j = i; j < contadorItens - 1; j++)
                {
                    itens[j] = itens[j + 1];
                }
                itens[contadorItens - 1] = null;
                contadorItens--;
                return true;
            }
        }
        return false;
    }

    public double CalcularTotal()
    {
        double total = 0;
        for (int i = 0; i < contadorItens; i++)
        {
            total += itens[i].Preco;
        }
        return total;
    }

    public string DadosDoPedido()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Pedido ID: {id} | Cliente: {cliente}");
        for (int i = 0; i < contadorItens; i++)
        {
            sb.AppendLine($"  - [{itens[i].Id}] {itens[i].Descricao} - R$ {itens[i].Preco:F2}");
        }
        sb.AppendLine($"Total do Pedido: R$ {CalcularTotal():F2}");
        return sb.ToString();
    }
}
