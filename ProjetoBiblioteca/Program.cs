using System;

class Program
{
    static void Main()
    {
        Livros acervoGeral = new Livros();
        string opcao = "";

        while (opcao != "0")
        {
            Console.WriteLine("\n=== SISTEMA DE BIBLIOTECA ===");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar livro");
            Console.WriteLine("2. Pesquisar livro (sintético)");
            Console.WriteLine("3. Pesquisar livro (analítico)");
            Console.WriteLine("4. Adicionar exemplar");
            Console.WriteLine("5. Registrar empréstimo");
            Console.WriteLine("6. Registrar devolução");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("\n--- 1. Adicionar Livro ---");
                    Console.Write("ISBN (inteiro): ");
                    if (int.TryParse(Console.ReadLine(), out int isbn))
                    {
                        Livro testeBusca = acervoGeral.Pesquisar(new Livro(isbn));
                        if (testeBusca != null)
                        {
                            Console.WriteLine("Erro: Já existe um livro com este ISBN no acervo.");
                            break;
                        }

                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Editora: ");
                        string editora = Console.ReadLine();

                        acervoGeral.Adicionar(new Livro(isbn, titulo, autor, editora));
                        Console.WriteLine("Livro cadastrado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("ISBN inválido.");
                    }
                    break;

                case "2":
                    Console.WriteLine("\n--- 2. Pesquisar Livro (Sintético) ---");
                    Console.Write("Digite o ISBN do livro: ");
                    if (int.TryParse(Console.ReadLine(), out int isbnSint))
                    {
                        Livro lSint = acervoGeral.Pesquisar(new Livro(isbnSint));
                        if (lSint != null)
                        {
                            Console.WriteLine($"\nISBN: {lSint.Isbn}");
                            Console.WriteLine($"Título: {lSint.Titulo}");
                            Console.WriteLine($"Autor: {lSint.Autor}");
                            Console.WriteLine($"Editora: {lSint.Editora}");
                            Console.WriteLine($"Total de Exemplares: {lSint.QtdeExemplares()}");
                            Console.WriteLine($"Exemplares Disponíveis: {lSint.QtdeDisponiveis()}");
                            Console.WriteLine($"Total de Empréstimos Realizados: {lSint.QtdeEmprestimos()}");
                            Console.WriteLine($"Percentual de Disponibilidade: {lSint.PercDisponibilidade():F2}%");
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ISBN inválido.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- 3. Pesquisar Livro (Analítico) ---");
                    Console.Write("Digite o ISBN do livro: ");
                    if (int.TryParse(Console.ReadLine(), out int isbnAnal))
                    {
                        Livro lAnal = acervoGeral.Pesquisar(new Livro(isbnAnal));
                        if (lAnal != null)
                        {
                            Console.WriteLine($"\nISBN: {lAnal.Isbn}");
                            Console.WriteLine($"Título: {lAnal.Titulo}");
                            Console.WriteLine($"Autor: {lAnal.Autor}");
                            Console.WriteLine($"Editora: {lAnal.Editora}");
                            Console.WriteLine($"Total de Exemplares: {lAnal.QtdeExemplares()}");
                            Console.WriteLine($"Exemplares Disponíveis: {lAnal.QtdeDisponiveis()}");
                            Console.WriteLine($"Total de Empréstimos Realizados: {lAnal.QtdeEmprestimos()}");
                            Console.WriteLine($"Percentual de Disponibilidade: {lAnal.PercDisponibilidade():F2}%");
                            Console.WriteLine("\n--- Detalhes dos Exemplares ---");

                            if (lAnal.Exemplares.Count == 0)
                            {
                                Console.WriteLine("  (Nenhum exemplar cadastrado para este título)");
                            }
                            else
                            {
                                foreach (var ex in lAnal.Exemplares)
                                {
                                    Console.WriteLine($"\n  Exemplar Tombo: {ex.Tombo} | Disponível: {(ex.Disponivel() ? "Sim" : "Não")} | Total de Empréstimos: {ex.QtdeEmprestimos()}");
                                    Console.WriteLine("  Histórico de Empréstimos:");
                                    if (ex.Emprestimos.Count == 0)
                                    {
                                        Console.WriteLine("    (Nenhum empréstimo registrado para este exemplar)");
                                    }
                                    else
                                    {
                                        foreach (var emp in ex.Emprestimos)
                                        {
                                            string devStr = emp.DtDevolucao == DateTime.MinValue ? "EM ABERTO" : emp.DtDevolucao.ToString("dd/MM/yyyy HH:mm:ss");
                                            Console.WriteLine($"    - Data Empréstimo: {emp.DtEmprestimo:dd/MM/yyyy HH:mm:ss} | Data Devolução: {devStr}");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ISBN inválido.");
                    }
                    break;

                case "4":
                    Console.WriteLine("\n--- 4. Adicionar Exemplar ---");
                    Console.Write("Digite o ISBN do livro: ");
                    if (int.TryParse(Console.ReadLine(), out int isbnEx))
                    {
                        Livro lEx = acervoGeral.Pesquisar(new Livro(isbnEx));
                        if (lEx != null)
                        {
                            Console.Write("Digite o Tombo do novo exemplar: ");
                            if (int.TryParse(Console.ReadLine(), out int tombo))
                            {
                                // Verificar duplicidade de tombo no livro
                                bool tomboExiste = lEx.Exemplares.Exists(e => e.Tombo == tombo);
                                if (tomboExiste)
                                {
                                    Console.WriteLine("Erro: Já existe um exemplar com esse tombo para este livro.");
                                }
                                else
                                {
                                    lEx.AdicionarExemplar(new Exemplar(tombo));
                                    Console.WriteLine("Exemplar adicionado com sucesso!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tombo inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ISBN inválido.");
                    }
                    break;

                case "5":
                    Console.WriteLine("\n--- 5. Registrar Empréstimo ---");
                    Console.Write("Digite o ISBN do livro: ");
                    if (int.TryParse(Console.ReadLine(), out int isbnEmp))
                    {
                        Livro lEmp = acervoGeral.Pesquisar(new Livro(isbnEmp));
                        if (lEmp != null)
                        {
                            Console.Write("Digite o Tombo do exemplar: ");
                            if (int.TryParse(Console.ReadLine(), out int tomboEmp))
                            {
                                Exemplar exEmp = lEmp.Exemplares.Find(e => e.Tombo == tomboEmp);
                                if (exEmp != null)
                                {
                                    if (exEmp.Emprestar())
                                    {
                                        Console.WriteLine("Empréstimo registrado com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Erro: Exemplar indisponível para empréstimo no momento.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Exemplar não encontrado.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tombo inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ISBN inválido.");
                    }
                    break;

                case "6":
                    Console.WriteLine("\n--- 6. Registrar Devolução ---");
                    Console.Write("Digite o ISBN do livro: ");
                    if (int.TryParse(Console.ReadLine(), out int isbnDev))
                    {
                        Livro lDev = acervoGeral.Pesquisar(new Livro(isbnDev));
                        if (lDev != null)
                        {
                            Console.Write("Digite o Tombo do exemplar: ");
                            if (int.TryParse(Console.ReadLine(), out int tomboDev))
                            {
                                Exemplar exDev = lDev.Exemplares.Find(e => e.Tombo == tomboDev);
                                if (exDev != null)
                                {
                                    if (exDev.Devolver())
                                    {
                                        Console.WriteLine("Devolução registrada com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Erro: Este exemplar não consta como emprestado no momento.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Exemplar não encontrado.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tombo inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ISBN inválido.");
                    }
                    break;

                case "0":
                    Console.WriteLine("Encerrando a aplicação...");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
}
