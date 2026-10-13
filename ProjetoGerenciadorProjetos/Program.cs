using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Projetos gerenciador = new Projetos();
        string opcao = "";

        while (opcao != "0")
        {
            Console.WriteLine("
=== SISTEMA GERENCIADOR DE PROJETOS ===");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar projeto");
            Console.WriteLine("2. Pesquisar projeto");
            Console.WriteLine("3. Remover projeto (se sem tarefas)");
            Console.WriteLine("4. Adicionar tarefa em projeto");
            Console.WriteLine("5. Concluir tarefa");
            Console.WriteLine("6. Cancelar tarefa");
            Console.WriteLine("7. Reabrir tarefa");
            Console.WriteLine("8. Listar tarefas de um projeto");
            Console.WriteLine("9. Filtrar tarefas por status/prioridade em um projeto");
            Console.WriteLine("10. Filtrar tarefas por status/prioridade em todos os projetos");
            Console.WriteLine("11. Resumo geral");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("
--- 1. Adicionar Projeto ---");
                    Console.Write("ID do Projeto: ");
                    if (int.TryParse(Console.ReadLine(), out int idProj))
                    {
                        if (gerenciador.Buscar(new Projeto(idProj)) != null)
                        {
                            Console.WriteLine("Erro: Já existe um projeto com este ID.");
                            break;
                        }
                        Console.Write("Nome do Projeto: ");
                        string nomeProj = Console.ReadLine();
                        gerenciador.Adicionar(new Projeto(idProj, nomeProj));
                        Console.WriteLine("Projeto cadastrado com sucesso!");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "2":
                    Console.WriteLine("
--- 2. Pesquisar Projeto ---");
                    Console.Write("ID do Projeto: ");
                    if (int.TryParse(Console.ReadLine(), out int idBusca))
                    {
                        Projeto p = gerenciador.Buscar(new Projeto(idBusca));
                        if (p != null)
                        {
                            Console.WriteLine($"
Projeto ID: {p.Id} | Nome: {p.Nome}");
                            Console.WriteLine($"Total de Tarefas: {p.Tarefas.Count}");
                            Console.WriteLine($"Tarefas Abertas: {p.TotalAbertas()}");
                            Console.WriteLine($"Tarefas Fechadas: {p.TotalFechadas()}");
                            Console.WriteLine($"Tarefas Canceladas: {p.TotalCanceladas()}");

                            Console.WriteLine("
-- Tarefas por Status --");
                            foreach (string st in new[] { "Aberta", "Fechada", "Cancelada" })
                            {
                                Console.WriteLine($"
> Status [{st}]:");
                                var listaSt = p.TarefasPorStatus(st);
                                if (listaSt.Count == 0) Console.WriteLine("  (nenhuma)");
                                else foreach (var t in listaSt) Console.WriteLine($"  {t}");
                            }
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "3":
                    Console.WriteLine("
--- 3. Remover Projeto ---");
                    Console.Write("ID do Projeto a remover: ");
                    if (int.TryParse(Console.ReadLine(), out int idRem))
                    {
                        Projeto pRem = gerenciador.Buscar(new Projeto(idRem));
                        if (pRem == null)
                        {
                            Console.WriteLine("Projeto não encontrado.");
                        }
                        else if (pRem.Tarefas.Count > 0)
                        {
                            Console.WriteLine("Erro: O projeto contém tarefas e não pode ser removido.");
                        }
                        else
                        {
                            gerenciador.Remover(pRem);
                            Console.WriteLine("Projeto removido com sucesso!");
                        }
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "4":
                    Console.WriteLine("
--- 4. Adicionar Tarefa em Projeto ---");
                    Console.Write("ID do Projeto: ");
                    if (int.TryParse(Console.ReadLine(), out int idProjTar))
                    {
                        Projeto pTar = gerenciador.Buscar(new Projeto(idProjTar));
                        if (pTar != null)
                        {
                            Console.Write("ID da Tarefa: ");
                            if (int.TryParse(Console.ReadLine(), out int idT))
                            {
                                if (pTar.BuscarTarefa(new Tarefa(idT)) != null)
                                {
                                    Console.WriteLine("Erro: Já existe uma tarefa com este ID no projeto.");
                                    break;
                                }
                                Console.Write("Título: ");
                                string tit = Console.ReadLine();
                                Console.Write("Descrição: ");
                                string desc = Console.ReadLine();
                                Console.Write("Prioridade (1=Alta, 2=Média, 3=Baixa): ");
                                int prio = int.Parse(Console.ReadLine());

                                pTar.AdicionarTarefa(new Tarefa(idT, tit, desc, prio));
                                Console.WriteLine("Tarefa adicionada com sucesso!");
                            }
                            else Console.WriteLine("ID de tarefa inválido.");
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                    }
                    else Console.WriteLine("ID de projeto inválido.");
                    break;

                case "5":
                    Console.WriteLine("
--- 5. Concluir Tarefa ---");
                    AlterarStatusTarefa(gerenciador, 1);
                    break;

                case "6":
                    Console.WriteLine("
--- 6. Cancelar Tarefa ---");
                    AlterarStatusTarefa(gerenciador, 2);
                    break;

                case "7":
                    Console.WriteLine("
--- 7. Reabrir Tarefa ---");
                    AlterarStatusTarefa(gerenciador, 3);
                    break;

                case "8":
                    Console.WriteLine("
--- 8. Listar Tarefas de um Projeto ---");
                    Console.Write("ID do Projeto: ");
                    if (int.TryParse(Console.ReadLine(), out int idL8))
                    {
                        Projeto p8 = gerenciador.Buscar(new Projeto(idL8));
                        if (p8 != null)
                        {
                            Console.WriteLine($"
Tarefas do Projeto '{p8.Nome}':");
                            if (p8.Tarefas.Count == 0) Console.WriteLine("  (nenhuma tarefa cadastrada)");
                            else foreach (var t in p8.Tarefas) Console.WriteLine(t);
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "9":
                    Console.WriteLine("
--- 9. Filtrar Tarefas em um Projeto ---");
                    Console.Write("ID do Projeto: ");
                    if (int.TryParse(Console.ReadLine(), out int idL9))
                    {
                        Projeto p9 = gerenciador.Buscar(new Projeto(idL9));
                        if (p9 != null)
                        {
                            Console.WriteLine("Filtrar por: 1. Status | 2. Prioridade");
                            string tFiltro = Console.ReadLine();
                            if (tFiltro == "1")
                            {
                                Console.Write("Informe o Status (Aberta, Fechada, Cancelada): ");
                                string st = Console.ReadLine();
                                var res = p9.TarefasPorStatus(st);
                                ExibirTarefasFiltradas(res);
                            }
                            else if (tFiltro == "2")
                            {
                                Console.Write("Informe a Prioridade (1=Alta, 2=Média, 3=Baixa): ");
                                if (int.TryParse(Console.ReadLine(), out int pr))
                                {
                                    var res = p9.TarefasPorPrioridade(pr);
                                    ExibirTarefasFiltradas(res);
                                }
                            }
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "10":
                    Console.WriteLine("
--- 10. Filtrar Tarefas em TODOS os Projetos ---");
                    Console.WriteLine("Filtrar por: 1. Status | 2. Prioridade");
                    string tFiltro10 = Console.ReadLine();
                    if (tFiltro10 == "1")
                    {
                        Console.Write("Informe o Status (Aberta, Fechada, Cancelada): ");
                        string st = Console.ReadLine();
                        foreach (var p in gerenciador.Listar())
                        {
                            var res = p.TarefasPorStatus(st);
                            if (res.Count > 0)
                            {
                                Console.WriteLine($"
[Projeto: {p.Nome}]");
                                ExibirTarefasFiltradas(res);
                            }
                        }
                    }
                    else if (tFiltro10 == "2")
                    {
                        Console.Write("Informe a Prioridade (1=Alta, 2=Média, 3=Baixa): ");
                        if (int.TryParse(Console.ReadLine(), out int pr))
                        {
                            foreach (var p in gerenciador.Listar())
                            {
                                var res = p.TarefasPorPrioridade(pr);
                                if (res.Count > 0)
                                {
                                    Console.WriteLine($"
[Projeto: {p.Nome}]");
                                    ExibirTarefasFiltradas(res);
                                }
                            }
                        }
                    }
                    break;

                case "11":
                    Console.WriteLine("
--- 11. Resumo Geral ---");
                    int totalProjetos = gerenciador.Listar().Count;
                    int totAbertas = 0;
                    int totFechadas = 0;
                    int totCanceladas = 0;

                    foreach (var p in gerenciador.Listar())
                    {
                        totAbertas += p.TotalAbertas();
                        totFechadas += p.TotalFechadas();
                        totCanceladas += p.TotalCanceladas();
                    }

                    int baseCalculo = totAbertas + totFechadas;
                    double percConcluid = baseCalculo > 0 ? ((double)totFechadas / baseCalculo) * 100.0 : 0.0;

                    Console.WriteLine($"Quantidade Total de Projetos: {totalProjetos}");
                    Console.WriteLine($"Total de Tarefas Abertas: {totAbertas}");
                    Console.WriteLine($"Total de Tarefas Fechadas (Concluídas): {totFechadas}");
                    Console.WriteLine($"Total de Tarefas Canceladas: {totCanceladas}");
                    Console.WriteLine($"% Concluídas em relação às Abertas/Fechadas: {percConcluid:F2}%");
                    break;

                case "0":
                    Console.WriteLine("Encerrando o sistema...");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    static void AlterarStatusTarefa(Projetos g, int acao)
    {
        Console.Write("ID do Projeto: ");
        if (int.TryParse(Console.ReadLine(), out int idP))
        {
            Projeto p = g.Buscar(new Projeto(idP));
            if (p != null)
            {
                Console.Write("ID da Tarefa: ");
                if (int.TryParse(Console.ReadLine(), out int idT))
                {
                    Tarefa t = p.BuscarTarefa(new Tarefa(idT));
                    if (t != null)
                    {
                        if (acao == 1) t.Concluir();
                        else if (acao == 2) t.Cancelar();
                        else if (acao == 3) t.Reabrir();

                        Console.WriteLine("Status da tarefa atualizado com sucesso!");
                    }
                    else Console.WriteLine("Tarefa não encontrada.");
                }
                else Console.WriteLine("ID de tarefa inválido.");
            }
            else Console.WriteLine("Projeto não encontrado.");
        }
        else Console.WriteLine("ID de projeto inválido.");
    }

    static void ExibirTarefasFiltradas(List<Tarefa> lista)
    {
        if (lista.Count == 0) Console.WriteLine("  (nenhuma tarefa encontrada)");
        else foreach (var t in lista) Console.WriteLine($"  {t}");
    }
}
