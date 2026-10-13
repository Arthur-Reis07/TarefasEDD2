using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgendaWinForms
{
    public partial class Form1 : Form
    {
        private Contatos agenda = new Contatos();
        private List<Telefone> tempTelefones = new List<Telefone>();

        public Form1()
        {
            InitializeComponent();
            ConfigurarGrid();
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
        }

        private void ConfigurarGrid()
        {
            dgvContatos.Columns.Clear();
            dgvContatos.Columns.Add("Email", "E-mail");
            dgvContatos.Columns.Add("Nome", "Nome");
            dgvContatos.Columns.Add("DtNasc", "Data Nasc.");
            dgvContatos.Columns.Add("Idade", "Idade");
            dgvContatos.Columns.Add("TelPrincipal", "Tel. Principal");
            dgvContatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearForm()
        {
            txtEmail.Clear();
            txtNome.Clear();
            dtpDataNasc.Value = DateTime.Today;
            txtNumero.Clear();
            chkPrincipal.Checked = false;
            tempTelefones.Clear();
            lstTelefones.Items.Clear();
            txtDetalhes.Clear();
        }

        private void AtualizarGrid()
        {
            dgvContatos.Rows.Clear();
            foreach (var c in agenda.Agenda)
            {
                dgvContatos.Rows.Add(c.Email, c.Nome, c.DtNasc.ToString(), c.GetIdade(), c.GetTelefonePrincipal());
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAdicionarTel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("Informe o número do telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbTipo.SelectedItem?.ToString() ?? "Geral";
            string numero = txtNumero.Text.Trim();
            bool principal = chkPrincipal.Checked;

            Telefone tel = new Telefone(tipo, numero, principal);

            if (principal)
            {
                foreach (var t in tempTelefones)
                {
                    t.Principal = false;
                }
            }

            tempTelefones.Add(tel);

            lstTelefones.Items.Clear();
            foreach (var t in tempTelefones)
            {
                lstTelefones.Items.Add($"[{t.Tipo}] {t.Numero} {(t.Principal ? "(P)" : "")}");
            }

            txtNumero.Clear();
            chkPrincipal.Checked = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string nome = txtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha ao menos Nome e E-mail.", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Data dt = new Data(dtpDataNasc.Value.Day, dtpDataNasc.Value.Month, dtpDataNasc.Value.Year);
            Contato c = new Contato(email, nome, dt);

            foreach (var t in tempTelefones)
            {
                c.AdicionarTelefone(t);
            }

            if (agenda.Adicionar(c))
            {
                MessageBox.Show("Contato adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Já existe um contato com este e-mail.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Digite o e-mail no campo E-mail para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contato encontrado = agenda.Pesquisar(new Contato(email));
            if (encontrado != null)
            {
                txtNome.Text = encontrado.Nome;
                if (encontrado.DtNasc.Ano > 1900)
                {
                    dtpDataNasc.Value = new DateTime(encontrado.DtNasc.Ano, encontrado.DtNasc.Mes, encontrado.DtNasc.Dia);
                }

                tempTelefones.Clear();
                lstTelefones.Items.Clear();
                foreach (var t in encontrado.Telefones)
                {
                    tempTelefones.Add(t);
                    lstTelefones.Items.Add($"[{t.Tipo}] {t.Numero} {(t.Principal ? "(P)" : "")}");
                }

                txtDetalhes.Text = encontrado.ToString();
                MessageBox.Show("Contato encontrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Contato não encontrado.", "Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string nome = txtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Informe o e-mail do contato que deseja alterar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Data dt = new Data(dtpDataNasc.Value.Day, dtpDataNasc.Value.Month, dtpDataNasc.Value.Year);
            Contato cAlt = new Contato(email, nome, dt);

            if (agenda.Alterar(cAlt))
            {
                MessageBox.Show("Contato alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrid();
            }
            else
            {
                MessageBox.Show("Contato não encontrado para alteração.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Informe o e-mail do contato que deseja remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (agenda.Remover(new Contato(email)))
            {
                MessageBox.Show("Contato removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Contato não encontrado para remoção.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
            if (agenda.Agenda.Count == 0)
            {
                MessageBox.Show("Nenhum contato cadastrado na agenda.", "Lista Vazia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvContatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvContatos.SelectedRows.Count > 0)
            {
                string email = dgvContatos.SelectedRows[0].Cells["Email"].Value?.ToString();
                if (!string.IsNullOrEmpty(email))
                {
                    Contato c = agenda.Pesquisar(new Contato(email));
                    if (c != null)
                    {
                        txtDetalhes.Text = c.ToString();
                    }
                }
            }
        }
    }
}
