using System;

class Program
{
    static void Main()
    {
        Contatos agenda = new Contatos();
        string opcao = "";

        while (opcao != "0")
        {
            Console.WriteLine("\n=== PROJETO AGENDA (CONTATOS) ===");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Pesquisar contato");
            Console.WriteLine("3. Alterar contato");
            Console.WriteLine("4. Remover contato");
            Console.WriteLine("5. Listar contatos");
            Console.Write("Escolha uma opcao: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("\n--- Adicionar Contato ---");
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();

                    Contato chave = new Contato(email);
                    if (agenda.Pesquisar(chave) != null)
                    {
                        Console.WriteLine("Erro: Ja existe um contato cadastrado com este e-mail.");
                        break;
                    }

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Dia de Nascimento: ");
                    int dia = int.Parse(Console.ReadLine());
                    Console.Write("Mes de Nascimento: ");
                    int mes = int.Parse(Console.ReadLine());
                    Console.Write("Ano de Nascimento: ");
                    int ano = int.Parse(Console.ReadLine());

                    Data dtNasc = new Data(dia, mes, ano);
                    Contato novoContato = new Contato(email, nome, dtNasc);

                    string addTel = "s";
                    while (addTel.ToLower() == "s")
                    {
                        Console.Write("Tipo do telefone (Ex: Celular, Res, Com): ");
                        string tipo = Console.ReadLine();
                        Console.Write("Numero: ");
                        string numero = Console.ReadLine();
                        Console.Write("E o telefone principal? (s/n): ");
                        bool principal = Console.ReadLine().ToLower() == "s";

                        novoContato.AdicionarTelefone(new Telefone(tipo, numero, principal));

                        Console.Write("Deseja adicionar outro telefone? (s/n): ");
                        addTel = Console.ReadLine();
                    }

                    if (agenda.Adicionar(novoContato))
                        Console.WriteLine("Contato adicionado com sucesso!");
                    else
                        Console.WriteLine("Erro ao adicionar contato.");
                    break;

                case "2":
                    Console.WriteLine("\n--- Pesquisar Contato ---");
                    Console.Write("Digite o e-mail do contato: ");
                    string emailBusca = Console.ReadLine();

                    Contato cBusca = agenda.Pesquisar(new Contato(emailBusca));
                    if (cBusca != null)
                    {
                        Console.WriteLine("\nContato encontrado:");
                        Console.WriteLine(cBusca.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Contato nao encontrado.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Alterar Contato ---");
                    Console.Write("Digite o e-mail do contato a alterar: ");
                    string emailAlt = Console.ReadLine();

                    Contato cExistente = agenda.Pesquisar(new Contato(emailAlt));
                    if (cExistente != null)
                    {
                        Console.Write($"Novo Nome (Atual: {cExistente.Nome}): ");
                        string novoNome = Console.ReadLine();

                        Console.Write($"Novo Dia Nasc (Atual: {cExistente.DtNasc.Dia}): ");
                        int nDia = int.Parse(Console.ReadLine());
                        Console.Write($"Novo Mes Nasc (Atual: {cExistente.DtNasc.Mes}): ");
                        int nMes = int.Parse(Console.ReadLine());
                        Console.Write($"Novo Ano Nasc (Atual: {cExistente.DtNasc.Ano}): ");
                        int nAno = int.Parse(Console.ReadLine());

                        Contato cAlt = new Contato(emailAlt, novoNome, new Data(nDia, nMes, nAno));
                        
                        if (agenda.Alterar(cAlt))
                            Console.WriteLine("Contato alterado com sucesso!");
                        else
                            Console.WriteLine("Erro ao alterar contato.");
                    }
                    else
                    {
                        Console.WriteLine("Contato nao encontrado.");
                    }
                    break;

                case "4":
                    Console.WriteLine("\n--- Remover Contato ---");
                    Console.Write("Digite o e-mail do contato a remover: ");
                    string emailRem = Console.ReadLine();

                    if (agenda.Remover(new Contato(emailRem)))
                        Console.WriteLine("Contato removido com sucesso!");
                    else
                        Console.WriteLine("Contato nao encontrado.");
                    break;

                case "5":
                    Console.WriteLine("\n--- Lista de Contatos na Agenda ---");
                    if (agenda.Agenda.Count == 0)
                    {
                        Console.WriteLine("Nenhum contato cadastrado.");
                    }
                    else
                    {
                        foreach (var c in agenda.Agenda)
                        {
                            Console.WriteLine(c.ToString());
                            Console.WriteLine("-----------------------------------");
                        }
                    }
                    break;

                case "0":
                    Console.WriteLine("Encerrando a aplicação...");
                    break;

                default:
                    Console.WriteLine("Opcao invalida, tente novamente.");
                    break;
            }
        }
    }
}
