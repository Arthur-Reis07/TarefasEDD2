using System;

class Program
{
    static void Main()
    {
        Restaurante restaurante = new Restaurante();
        string opcao = "";

        while (opcao != "0")
        {
            Console.WriteLine("\n=== Sistema da Cozinha Industrial ===");
            Console.WriteLine("1. Criar novo pedido");
            Console.WriteLine("2. Adicionar item ao pedido");
            Console.WriteLine("3. Remover item do pedido");
            Console.WriteLine("4. Consultar pedido (mostrar id, cliente, itens e valor total)");
            Console.WriteLine("5. Cancelar pedido");
            Console.WriteLine("6. Listar todos os pedidos (com id, valores totais e soma geral do dia)");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opcao: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome do cliente: ");
                    string cliente = Console.ReadLine();
                    int novoId = restaurante.ProxPedido;
                    Pedido novoPedido = new Pedido(novoId, cliente);
                    if (restaurante.NovoPedido(novoPedido))
                    {
                        Console.WriteLine($"Pedido criado com sucesso! ID: {novoId}");
                    }
                    else
                    {
                        Console.WriteLine("Erro: Limite maximo de 50 pedidos diarios atingido.");
                    }
                    break;

                case "2":
                    Console.Write("Digite o ID do pedido: ");
                    if (int.TryParse(Console.ReadLine(), out int idAdd))
                    {
                        Pedido pAdd = restaurante.BuscarPedido(new Pedido(idAdd, ""));
                        if (pAdd != null)
                        {
                            Console.Write("ID do Item: ");
                            int itemId = int.Parse(Console.ReadLine());
                            Console.Write("Descricao: ");
                            string desc = Console.ReadLine();
                            Console.Write("Preco: ");
                            double preco = double.Parse(Console.ReadLine());

                            Item item = new Item(itemId, desc, preco);
                            if (pAdd.AdicionarItem(item))
                                Console.WriteLine("Item adicionado com sucesso!");
                            else
                                Console.WriteLine("Erro: Limite maximo de 10 itens por pedido atingido.");
                        }
                        else
                        {
                            Console.WriteLine("Pedido nao encontrado.");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Digite o ID do pedido: ");
                    if (int.TryParse(Console.ReadLine(), out int idRem))
                    {
                        Pedido pRem = restaurante.BuscarPedido(new Pedido(idRem, ""));
                        if (pRem != null)
                        {
                            Console.Write("ID do Item a remover: ");
                            int itemRemId = int.Parse(Console.ReadLine());
                            if (pRem.RemoverItem(new Item(itemRemId, "", 0)))
                                Console.WriteLine("Item removido com sucesso!");
                            else
                                Console.WriteLine("Item nao encontrado neste pedido.");
                        }
                        else
                        {
                            Console.WriteLine("Pedido nao encontrado.");
                        }
                    }
                    break;

                case "4":
                    Console.Write("Digite o ID do pedido: ");
                    if (int.TryParse(Console.ReadLine(), out int idBusca))
                    {
                        Pedido pBusca = restaurante.BuscarPedido(new Pedido(idBusca, ""));
                        if (pBusca != null)
                        {
                            Console.WriteLine("\n" + pBusca.DadosDoPedido());
                        }
                        else
                        {
                            Console.WriteLine("Pedido nao encontrado.");
                        }
                    }
                    break;

                case "5":
                    Console.Write("Digite o ID do pedido a cancelar: ");
                    if (int.TryParse(Console.ReadLine(), out int idCanc))
                    {
                        if (restaurante.CancelarPedido(new Pedido(idCanc, "")))
                            Console.WriteLine("Pedido cancelado e removido do sistema.");
                        else
                            Console.WriteLine("Pedido nao encontrado.");
                    }
                    break;

                case "6":
                    restaurante.ListarTodosPedidos();
                    break;

                case "0":
                    Console.WriteLine("Encerrando o sistema...");
                    break;

                default:
                    Console.WriteLine("Opcao invalida, tente novamente.");
                    break;
            }
        }
    }
}
