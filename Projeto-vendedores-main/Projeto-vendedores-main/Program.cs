using System;

namespace ControleVendas
{
    // ==========================================
    // Classe Venda
    // ==========================================
    public class Venda
    {
        private int qtde;
        private double valor;

        public Venda() : this(0, 0.0) { }

        public Venda(int qtde, double valor)
        {
            this.qtde = qtde;
            this.valor = valor;
        }

        public int Qtde
        {
            get => qtde;
            set => qtde = value;
        }

        public double Valor
        {
            get => valor;
            set => valor = value;
        }

        public double ValorMedio()
        {
            return qtde > 0 ? valor / qtde : 0.0;
        }
    }

    // ==========================================
    // Classe Vendedor
    // ==========================================
    public class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31];
            for (int i = 0; i < 31; i++)
            {
                this.asVendas[i] = new Venda();
            }
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public double PercComissao
        {
            get => percComissao;
            set => percComissao = value;
        }

        public Venda[] AsVendas => asVendas;

        public void RegistrarVenda(int dia, Venda venda)
        {
            if (dia >= 1 && dia <= 31)
            {
                int index = dia - 1;
                asVendas[index].Qtde += venda.Qtde;
                asVendas[index].Valor += venda.Valor;
            }
        }

        public double ValorVendas()
        {
            double total = 0.0;
            foreach (var v in asVendas)
            {
                if (v != null)
                {
                    total += v.Valor;
                }
            }
            return total;
        }

        public double ValorComissao()
        {
            return ValorVendas() * (percComissao / 100.0);
        }
    }

    // ==========================================
    // Classe Vendedores
    // ==========================================
    public class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedores(int max = 10)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
        }

        public int Qtde => qtde;
        public int Max => max;
        public Vendedor[] OsVendedores => osVendedores;

        public bool AddVendedor(Vendedor v)
        {
            if (qtde >= max)
            {
                return false; // Limite atingido
            }

            if (SearchVendedor(v) != null)
            {
                return false; // Vendedor com este ID já existe
            }

            osVendedores[qtde] = v;
            qtde++;
            return true;
        }

        public bool DelVendedor(Vendedor v)
        {
            Vendedor encontrado = SearchVendedor(v);
            if (encontrado == null)
            {
                return false;
            }

            // Regra (***): Só pode excluir se não houver vendas associadas
            if (encontrado.ValorVendas() > 0)
            {
                return false;
            }

            int index = -1;
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Id == v.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                for (int i = index; i < qtde - 1; i++)
                {
                    osVendedores[i] = osVendedores[i + 1];
                }
                osVendedores[qtde - 1] = null;
                qtde--;
                return true;
            }

            return false;
        }

        public Vendedor SearchVendedor(Vendedor v)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i] != null && osVendedores[i].Id == v.Id)
                {
                    return osVendedores[i];
                }
            }
            return null;
        }

        public double ValorVendas()
        {
            double total = 0.0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].ValorVendas();
            }
            return total;
        }

        public double ValorComissao()
        {
            double total = 0.0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].ValorComissao();
            }
            return total;
        }
    }

    // ==========================================
    // Programa Principal (Console UI)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Vendedores cadastro = new Vendedores(10);
            int opcao = -1;

            do
            {
                Console.WriteLine("\n======================================");
                Console.WriteLine("          SISTEMA DE VENDAS           ");
                Console.WriteLine("======================================");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar vendedor");
                Console.WriteLine("2. Consultar vendedor");
                Console.WriteLine("3. Excluir vendedor");
                Console.WriteLine("4. Registrar venda");
                Console.WriteLine("5. Listar vendedores");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                Console.WriteLine();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando a aplicação...");
                        break;

                    case 1:
                        // Cadastrar vendedor
                        if (cadastro.Qtde >= cadastro.Max)
                        {
                            Console.WriteLine("Erro: Limite máximo de vendedores cadastrados (10) atingido!");
                            break;
                        }

                        Console.Write("ID do vendedor: ");
                        int idCad = int.Parse(Console.ReadLine());

                        if (cadastro.SearchVendedor(new Vendedor(idCad, "", 0)) != null)
                        {
                            Console.WriteLine("Erro: Já existe um vendedor com este ID!");
                            break;
                        }

                        Console.Write("Nome do vendedor: ");
                        string nomeCad = Console.ReadLine();

                        Console.Write("Percentual de comissão (%): ");
                        double percCad = double.Parse(Console.ReadLine());

                        Vendedor novoVendedor = new Vendedor(idCad, nomeCad, percCad);
                        if (cadastro.AddVendedor(novoVendedor))
                        {
                            Console.WriteLine("Vendedor cadastrado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Falha ao cadastrar vendedor.");
                        }
                        break;

                    case 2:
                        // Consultar vendedor
                        Console.Write("Informe o ID do vendedor para consulta: ");
                        int idConsulta = int.Parse(Console.ReadLine());

                        Vendedor vConsultado = cadastro.SearchVendedor(new Vendedor(idConsulta, "", 0));

                        if (vConsultado == null)
                        {
                            Console.WriteLine("Vendedor não encontrado!");
                        }
                        else
                        {
                            Console.WriteLine($"ID: {vConsultado.Id}");
                            Console.WriteLine($"Nome: {vConsultado.Nome}");
                            Console.WriteLine($"Valor Total de Vendas: R$ {vConsultado.ValorVendas():F2}");
                            Console.WriteLine($"Comissão Devida: R$ {vConsultado.ValorComissao():F2}");
                            Console.WriteLine("\n--- Detalhamento das Vendas Diárias ---");

                            bool teveVenda = false;
                            for (int dia = 1; dia <= 31; dia++)
                            {
                                Venda vDia = vConsultado.AsVendas[dia - 1];
                                if (vDia.Qtde > 0)
                                {
                                    teveVenda = true;
                                    Console.WriteLine($"Dia {dia:D2} | Qtde: {vDia.Qtde} | Valor Total: R$ {vDia.Valor:F2} | Valor Médio/Venda: R$ {vDia.ValorMedio():F2}");
                                }
                            }

                            if (!teveVenda)
                            {
                                Console.WriteLine("Nenhuma venda registrada neste mês.");
                            }
                        }
                        break;

                    case 3:
                        // Excluir vendedor
                        Console.Write("Informe o ID do vendedor a ser excluído: ");
                        int idExcluir = int.Parse(Console.ReadLine());

                        Vendedor vExcluir = cadastro.SearchVendedor(new Vendedor(idExcluir, "", 0));

                        if (vExcluir == null)
                        {
                            Console.WriteLine("Vendedor não encontrado!");
                        }
                        else if (vExcluir.ValorVendas() > 0)
                        {
                            Console.WriteLine("Erro: O vendedor possui vendas registradas e NÃO pode ser excluído!");
                        }
                        else
                        {
                            if (cadastro.DelVendedor(vExcluir))
                            {
                                Console.WriteLine("Vendedor excluído com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Falha ao excluir vendedor.");
                            }
                        }
                        break;

                    case 4:
                        // Registrar venda
                        Console.Write("Informe o ID do vendedor: ");
                        int idVenda = int.Parse(Console.ReadLine());

                        Vendedor vVenda = cadastro.SearchVendedor(new Vendedor(idVenda, "", 0));

                        if (vVenda == null)
                        {
                            Console.WriteLine("Vendedor não encontrado!");
                        }
                        else
                        {
                            Console.Write("Informe o dia do mês (1 a 31): ");
                            int dia = int.Parse(Console.ReadLine());

                            if (dia < 1 || dia > 31)
                            {
                                Console.WriteLine("Dia inválido! Informe um valor entre 1 e 31.");
                                break;
                            }

                            Console.Write("Quantidade vendida: ");
                            int qtdeVenda = int.Parse(Console.ReadLine());

                            Console.Write("Valor total da venda: R$ ");
                            double valorVenda = double.Parse(Console.ReadLine());

                            vVenda.RegistrarVenda(dia, new Venda(qtdeVenda, valorVenda));
                            Console.WriteLine("Venda registrada com sucesso!");
                        }
                        break;

                    case 5:
                        // Listar vendedores
                        if (cadastro.Qtde == 0)
                        {
                            Console.WriteLine("Nenhum vendedor cadastrado.");
                        }
                        else
                        {
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine(string.Format("{0,-6} | {0,-20} | {1,-18} | {2,-15}", "ID", "Nome", "Total Vendas (R$)", "Comissão (R$)"));
                            Console.WriteLine("-------------------------------------------------------------------");

                            for (int i = 0; i < cadastro.Qtde; i++)
                            {
                                Vendedor v = cadastro.OsVendedores[i];
                                Console.WriteLine($"{v.Id,-6} | {v.Nome,-20} | R$ {v.ValorVendas(),-15:F2} | R$ {v.ValorComissao(),-12:F2}");
                            }

                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine($"TOTALIZADOR GERAL DE VENDAS:    R$ {cadastro.ValorVendas():F2}");
                            Console.WriteLine($"TOTALIZADOR GERAL DE COMISSÕES: R$ {cadastro.ValorComissao():F2}");
                            Console.WriteLine("-------------------------------------------------------------------");
                        }
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

            } while (opcao != 0);
        }
    }
}