using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoBilheteria
{
    public enum EstadoPoltrona
    {
        Vaga,
        OcupadaInteira,
        OcupadaMeia
    }

    public class Form1 : Form
    {
        private const int FILEIRAS = 15;
        private const int COLUNAS = 40;
        private const int TOTAL_POLTRONAS = FILEIRAS * COLUNAS;

        // Estrutura de dados para o estado das poltronas (Matriz 15x40)
        private EstadoPoltrona[,] mapaPoltronas = new EstadoPoltrona[FILEIRAS, COLUNAS];

        // Matriz de botões para representação visual
        private Button[,] botoesPoltronas = new Button[FILEIRAS, COLUNAS];

        // Controles dinâmicos para Faturamento
        private Button btnFaturamento;
        private Label lblFaturamentoLugares;
        private Label lblFaturamentoValor;
        private Panel panelMapa;
        private Panel panelControles;

        public Form1()
        {
            InitializeComponentesDinamicos();
        }

        private void InitializeComponentesDinamicos()
        {
            // Configurações do Form principal
            this.Text = "Sistema de Controle de Bilheteria do Teatro";
            this.Size = new Size(1300, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Título Principal
            Label lblTitulo = new Label();
            lblTitulo.Text = "SISTEMA DE CONTROLE DE BILHETERIA E OCUPAÇÃO";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 15);
            this.Controls.Add(lblTitulo);

            // Legenda de Cores
            CriarLegenda();

            // Painel para abrigar a grade de botões (com barra de rolagem se necessário)
            panelMapa = new Panel();
            panelMapa.Location = new Point(20, 80);
            panelMapa.Size = new Size(1240, 480);
            panelMapa.AutoScroll = true;
            panelMapa.BorderStyle = BorderStyle.FixedSingle;
            panelMapa.BackColor = Color.White;
            this.Controls.Add(panelMapa);

            // Criar os 600 botões dinamicamente (15 fileiras x 40 colunas)
            int btnLargura = 26;
            int btnAltura = 24;
            int espacamento = 3;
            int margemEsquerda = 45;
            int margemTopo = 30;

            // Rótulo para colunas
            for (int col = 0; col < COLUNAS; col++)
            {
                Label lblCol = new Label();
                lblCol.Text = (col + 1).ToString();
                lblCol.Size = new Size(btnLargura, 18);
                lblCol.Location = new Point(margemEsquerda + col * (btnLargura + espacamento), margemTopo - 20);
                lblCol.TextAlign = ContentAlignment.MiddleCenter;
                lblCol.Font = new Font("Segoe UI", 7, FontStyle.Bold);
                lblCol.ForeColor = Color.Gray;
                panelMapa.Controls.Add(lblCol);
            }

            for (int f = 0; f < FILEIRAS; f++)
            {
                // Rótulo da Fileira
                Label lblFileira = new Label();
                lblFileira.Text = $"F{(f + 1):D2}";
                lblFileira.Size = new Size(38, btnAltura);
                lblFileira.Location = new Point(5, margemTopo + f * (btnAltura + espacamento));
                lblFileira.TextAlign = ContentAlignment.MiddleRight;
                lblFileira.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblFileira.ForeColor = Color.FromArgb(70, 80, 95);
                panelMapa.Controls.Add(lblFileira);

                for (int c = 0; c < COLUNAS; c++)
                {
                    mapaPoltronas[f, c] = EstadoPoltrona.Vaga;

                    Button btn = new Button();
                    btn.Size = new Size(btnLargura, btnAltura);
                    btn.Location = new Point(margemEsquerda + c * (btnLargura + espacamento), margemTopo + f * (btnAltura + espacamento));
                    btn.Text = $"{c + 1}";
                    btn.Font = new Font("Segoe UI", 7.5f, FontStyle.Regular);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.LightGray;
                    
                    // Identificadores da poltrona associados ao botão
                    btn.Tag = new Point(f, c);
                    btn.Click += Poltrona_Click;

                    AtualizarAparenciaBotao(btn, EstadoPoltrona.Vaga);

                    botoesPoltronas[f, c] = btn;
                    panelMapa.Controls.Add(btn);
                }
            }

            // Painel Inferior para Faturamento e Estatísticas
            panelControles = new Panel();
            panelControles.Location = new Point(20, 575);
            panelControles.Size = new Size(1240, 110);
            panelControles.BackColor = Color.White;
            panelControles.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panelControles);

            // Botão Faturamento Criado Dinamicamente
            btnFaturamento = new Button();
            btnFaturamento.Text = "📊 Calcular Faturamento";
            btnFaturamento.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnFaturamento.Size = new Size(220, 50);
            btnFaturamento.Location = new Point(20, 30);
            btnFaturamento.BackColor = Color.FromArgb(13, 110, 253);
            btnFaturamento.ForeColor = Color.White;
            btnFaturamento.FlatStyle = FlatStyle.Flat;
            btnFaturamento.FlatAppearance.BorderSize = 0;
            btnFaturamento.Cursor = Cursors.Hand;
            btnFaturamento.Click += BtnFaturamento_Click;
            panelControles.Controls.Add(btnFaturamento);

            // Labels para exibir os resultados do faturamento
            lblFaturamentoLugares = new Label();
            lblFaturamentoLugares.Text = "Qtde de lugares ocupados: 0 (Inteira: 0 | Meia: 0)";
            lblFaturamentoLugares.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblFaturamentoLugares.ForeColor = Color.FromArgb(33, 37, 41);
            lblFaturamentoLugares.AutoSize = true;
            lblFaturamentoLugares.Location = new Point(270, 28);
            panelControles.Controls.Add(lblFaturamentoLugares);

            lblFaturamentoValor = new Label();
            lblFaturamentoValor.Text = "Valor da bilheteria: R$ 0,00";
            lblFaturamentoValor.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblFaturamentoValor.ForeColor = Color.FromArgb(25, 135, 84);
            lblFaturamentoValor.AutoSize = true;
            lblFaturamentoValor.Location = new Point(270, 58);
            panelControles.Controls.Add(lblFaturamentoValor);
        }

        private void CriarLegenda()
        {
            Panel panelLegenda = new Panel();
            panelLegenda.Location = new Point(600, 15);
            panelLegenda.Size = new Size(660, 55);
            panelLegenda.BackColor = Color.Transparent;
            this.Controls.Add(panelLegenda);

            // Legenda Vaga
            AddLegendaItem(panelLegenda, Color.FromArgb(220, 245, 220), Color.DarkGreen, "Vaga", 0);
            // Legenda Inteira
            AddLegendaItem(panelLegenda, Color.FromArgb(220, 53, 69), Color.White, "Ocupada (Inteira)", 110);
            // Legenda Meia
            AddLegendaItem(panelLegenda, Color.FromArgb(255, 193, 7), Color.Black, "Ocupada (Meia)", 260);

            // Informação de Preços
            Label lblPrecos = new Label();
            lblPrecos.Text = "Preços: Fileiras 1-5: R$50 | Fileiras 6-10: R$30 | Fileiras 11-15: R$15 (Meia: 50%)";
            lblPrecos.Font = new Font("Segoe UI", 8.5f, FontStyle.Italic);
            lblPrecos.ForeColor = Color.DimGray;
            lblPrecos.AutoSize = true;
            lblPrecos.Location = new Point(140, 32);
            panelLegenda.Controls.Add(lblPrecos);
        }

        private void AddLegendaItem(Panel parent, Color backColor, Color textColor, string texto, int posX)
        {
            Button box = new Button();
            box.Size = new Size(22, 22);
            box.Location = new Point(posX, 5);
            box.BackColor = backColor;
            box.Enabled = false;
            box.FlatStyle = FlatStyle.Flat;
            box.FlatAppearance.BorderSize = 1;
            parent.Controls.Add(box);

            Label lbl = new Label();
            lbl.Text = texto;
            lbl.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
            lbl.Location = new Point(posX + 26, 8);
            lbl.AutoSize = true;
            parent.Controls.Add(lbl);
        }

        private double ObterValorCheioFileira(int fileiraIndex)
        {
            // Regras de precificação:
            // Fileiras 1 a 5 (índices 0 a 4): R$ 50,00
            // Fileiras 6 a 10 (índices 5 a 9): R$ 30,00
            // Fileiras 11 a 15 (índices 10 a 14): R$ 15,00
            if (fileiraIndex >= 0 && fileiraIndex <= 4)
                return 50.00;
            else if (fileiraIndex >= 5 && fileiraIndex <= 9)
                return 30.00;
            else if (fileiraIndex >= 10 && fileiraIndex <= 14)
                return 15.00;

            return 0.00;
        }

        private void Poltrona_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || !(btn.Tag is Point)) return;

            Point pos = (Point)btn.Tag;
            int f = pos.X;
            int c = pos.Y;

            // Consistência de limites
            if (f < 0 || f >= FILEIRAS || c < 0 || c >= COLUNAS)
            {
                MessageBox.Show("Coordenadas de poltrona inválidas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EstadoPoltrona estadoAtual = mapaPoltronas[f, c];

            if (estadoAtual != EstadoPoltrona.Vaga)
            {
                // Regra: Alertar ocupação sem alterar
                string tipoOcupacao = (estadoAtual == EstadoPoltrona.OcupadaInteira) ? "Inteira" : "Meia Entrada";
                MessageBox.Show(
                    $"A poltrona da Fileira {f + 1}, Assento {c + 1} já está OCUPADA!
Tipo de reserva: {tipoOcupacao}.",
                    "Poltrona Ocupada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                // Poltrona Vaga: Solicitar tipo de entrada
                double valorCheio = ObterValorCheioFileira(f);
                double valorMeia = valorCheio * 0.5;

                string mensagem = $"Reserva da Poltrona - Fileira {f + 1}, Assento {c + 1}

" +
                                  $"Valor Inteira: R$ {valorCheio:F2}
" +
                                  $"Valor Meia Entrada: R$ {valorMeia:F2}

" +
                                  "Escolha o tipo de reserva:
" +
                                  "[Sim] = Entrada Inteira
" +
                                  "[Não] = Meia Entrada
" +
                                  "[Cancelar] = Cancelar Operação";

                DialogResult result = MessageBox.Show(
                    mensagem,
                    "Efetivar Reserva",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    mapaPoltronas[f, c] = EstadoPoltrona.OcupadaInteira;
                    AtualizarAparenciaBotao(btn, EstadoPoltrona.OcupadaInteira);
                    MessageBox.Show($"Reserva (INTEIRA) efetuada com sucesso para a poltrona F{f + 1}-{c + 1}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    mapaPoltronas[f, c] = EstadoPoltrona.OcupadaMeia;
                    AtualizarAparenciaBotao(btn, EstadoPoltrona.OcupadaMeia);
                    MessageBox.Show($"Reserva (MEIA ENTRADA) efetuada com sucesso para a poltrona F{f + 1}-{c + 1}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AtualizarAparenciaBotao(Button btn, EstadoPoltrona estado)
        {
            switch (estado)
            {
                case EstadoPoltrona.Vaga:
                    btn.BackColor = Color.FromArgb(220, 245, 220);
                    btn.ForeColor = Color.FromArgb(20, 80, 20);
                    break;
                case EstadoPoltrona.OcupadaInteira:
                    btn.BackColor = Color.FromArgb(220, 53, 69);
                    btn.ForeColor = Color.White;
                    break;
                case EstadoPoltrona.OcupadaMeia:
                    btn.BackColor = Color.FromArgb(255, 193, 7);
                    btn.ForeColor = Color.Black;
                    break;
            }
        }

        private void BtnFaturamento_Click(object sender, EventArgs e)
        {
            int totalOcupados = 0;
            int totalInteiras = 0;
            int totalMeias = 0;
            double valorTotalAcumulado = 0.0;

            for (int f = 0; f < FILEIRAS; f++)
            {
                double valorCheio = ObterValorCheioFileira(f);

                for (int c = 0; c < COLUNAS; c++)
                {
                    if (mapaPoltronas[f, c] == EstadoPoltrona.OcupadaInteira)
                    {
                        totalOcupados++;
                        totalInteiras++;
                        valorTotalAcumulado += valorCheio;
                    }
                    else if (mapaPoltronas[f, c] == EstadoPoltrona.OcupadaMeia)
                    {
                        totalOcupados++;
                        totalMeias++;
                        valorTotalAcumulado += (valorCheio * 0.5);
                    }
                }
            }

            // Formatação do resultado conforme especificado nas regras da atividade
            lblFaturamentoLugares.Text = $"Qtde de lugares ocupados: {totalOcupados} (Inteira: {totalInteiras} | Meia: {totalMeias})";
            lblFaturamentoValor.Text = $"Valor da bilheteria: R$ {valorTotalAcumulado:F2}";
        }
    }
}
