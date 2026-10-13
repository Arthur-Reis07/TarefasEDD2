using System;
using System.Linq;
using System.Windows.Forms;

namespace AtendimentoWinForms
{
    public partial class Form1 : Form
    {
        private Senhas guicheSenhas = new Senhas();
        private Guiches conjuntoGuiches = new Guiches();

        public Form1()
        {
            InitializeComponent();
            AtualizarQuantidadeGuiches();
        }

        private void AtualizarQuantidadeGuiches()
        {
            lblGuiches.Text = $"Qtde de Guichês: {conjuntoGuiches.ListaGuiches.Count}";
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            guicheSenhas.Gerar();
            AtualizarListaSenhas();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int novoId = conjuntoGuiches.ListaGuiches.Count + 1;
            Guiche novoGuiche = new Guiche(novoId);
            conjuntoGuiches.Adicionar(novoGuiche);

            AtualizarQuantidadeGuiches();
            MessageBox.Show($"Guichê {novoId} adicionado com sucesso!", "Novo Guichê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChamar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGuicheId.Text, out int idGuiche) || idGuiche <= 0)
            {
                MessageBox.Show("Informe um ID de Guichê válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guiche g = conjuntoGuiches.ListaGuiches.FirstOrDefault(x => x.Id == idGuiche);
            if (g == null)
            {
                MessageBox.Show($"Guichê {idGuiche} não encontrado. Adicione guichês primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (g.Chamar(guicheSenhas.FilaSenhas))
            {
                MessageBox.Show($"Senha chamada com sucesso pelo Guichê {g.Id}!", "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarListaSenhas();
                AtualizarListaAtendimentos(g);
            }
            else
            {
                MessageBox.Show("Não há senhas na fila aguardando atendimento.", "Fila Vazia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnListarSenhas_Click(object sender, EventArgs e)
        {
            AtualizarListaSenhas();
        }

        private void btnListarAtendimentos_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGuicheId.Text, out int idGuiche) || idGuiche <= 0)
            {
                MessageBox.Show("Informe o ID do Guichê no campo Guichê para listar seus atendimentos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guiche g = conjuntoGuiches.ListaGuiches.FirstOrDefault(x => x.Id == idGuiche);
            if (g != null)
            {
                AtualizarListaAtendimentos(g);
            }
            else
            {
                MessageBox.Show($"Guichê {idGuiche} não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarListaSenhas()
        {
            lstSenhas.Items.Clear();
            foreach (var s in guicheSenhas.FilaSenhas)
            {
                lstSenhas.Items.Add(s.DadosParciais());
            }
        }

        private void AtualizarListaAtendimentos(Guiche g)
        {
            lstAtendimentos.Items.Clear();
            lstAtendimentos.Items.Add($"=== Atendimentos do Guichê {g.Id} ===");
            if (g.Atendimentos.Count == 0)
            {
                lstAtendimentos.Items.Add("(Nenhum atendimento realizado)");
            }
            else
            {
                foreach (var s in g.Atendimentos)
                {
                    lstAtendimentos.Items.Add(s.DadosCompletos());
                }
            }
        }
    }
}
