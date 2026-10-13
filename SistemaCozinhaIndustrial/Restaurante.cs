using System;

public class Restaurante
{
    private int proxPedido = 1;
    private Pedido[] pedidos = new Pedido[50];
    private int contadorPedidos = 0;

    public int ProxPedido => proxPedido;

    public bool NovoPedido(Pedido pedido)
    {
        if (contadorPedidos < 50)
        {
            pedidos[contadorPedidos] = pedido;
            contadorPedidos++;
            proxPedido++;
            return true;
        }
        return false;
    }

    public Pedido BuscarPedido(Pedido pedido)
    {
        for (int i = 0; i < contadorPedidos; i++)
        {
            if (pedidos[i] != null && pedidos[i].Id == pedido.Id)
            {
                return pedidos[i];
            }
        }
        return null;
    }

    public bool CancelarPedido(Pedido pedido)
    {
        for (int i = 0; i < contadorPedidos; i++)
        {
            if (pedidos[i] != null && pedidos[i].Id == pedido.Id)
            {
                // Remove shifting the array
                for (int j = i; j < contadorPedidos - 1; j++)
                {
                    pedidos[j] = pedidos[j + 1];
                }
                pedidos[contadorPedidos - 1] = null;
                contadorPedidos--;
                return true;
            }
        }
        return false;
    }

    public void ListarTodosPedidos()
    {
        Console.WriteLine("\n--- Lista de Todos os Pedidos ---");
        double somaGeral = 0;
        
        if (contadorPedidos == 0)
        {
            Console.WriteLine("Nenhum pedido registrado no momento.");
        }
        else
        {
            for (int i = 0; i < contadorPedidos; i++)
            {
                if (pedidos[i] != null)
                {
                    double total = pedidos[i].CalcularTotal();
                    somaGeral += total;
                    Console.WriteLine($"Pedido [{pedidos[i].Id}] - {pedidos[i].Cliente} | Valor: R$ {total:F2}");
                }
            }
        }
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Soma geral do dia: R$ {somaGeral:F2}");
    }
}
