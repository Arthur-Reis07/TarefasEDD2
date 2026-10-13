namespace AgendaWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblDtNasc = new System.Windows.Forms.Label();
            this.dtpDataNasc = new System.Windows.Forms.DateTimePicker();
            this.grpTelefone = new System.Windows.Forms.GroupBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
            this.btnAdicionarTel = new System.Windows.Forms.Button();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lstTelefones = new System.Windows.Forms.ListBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.dgvContatos = new System.Windows.Forms.DataGridView();
            this.txtDetalhes = new System.Windows.Forms.TextBox();
            this.grpTelefone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 15);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(60, 12);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 45);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(60, 42);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(250, 20);
            this.txtNome.TabIndex = 3;
            // 
            // lblDtNasc
            // 
            this.lblDtNasc.AutoSize = true;
            this.lblDtNasc.Location = new System.Drawing.Point(12, 75);
            this.lblDtNasc.Name = "lblDtNasc";
            this.lblDtNasc.Size = new System.Drawing.Size(61, 13);
            this.lblDtNasc.TabIndex = 4;
            this.lblDtNasc.Text = "Data Nasc:";
            // 
            // dtpDataNasc
            // 
            this.dtpDataNasc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNasc.Location = new System.Drawing.Point(79, 72);
            this.dtpDataNasc.Name = "dtpDataNasc";
            this.dtpDataNasc.Size = new System.Drawing.Size(120, 20);
            this.dtpDataNasc.TabIndex = 5;
            // 
            // grpTelefone
            // 
            this.grpTelefone.Controls.Add(this.chkPrincipal);
            this.grpTelefone.Controls.Add(this.btnAdicionarTel);
            this.grpTelefone.Controls.Add(this.lblNumero);
            this.grpTelefone.Controls.Add(this.txtNumero);
            this.grpTelefone.Controls.Add(this.lblTipo);
            this.grpTelefone.Controls.Add(this.cmbTipo);
            this.grpTelefone.Controls.Add(this.lstTelefones);
            this.grpTelefone.Location = new System.Drawing.Point(15, 105);
            this.grpTelefone.Name = "grpTelefone";
            this.grpTelefone.Size = new System.Drawing.Size(295, 170);
            this.grpTelefone.TabIndex = 6;
            this.grpTelefone.TabStop = false;
            this.grpTelefone.Text = "Telefones";
            // 
            // chkPrincipal
            // 
            this.chkPrincipal.AutoSize = true;
            this.chkPrincipal.Location = new System.Drawing.Point(180, 47);
            this.chkPrincipal.Name = "chkPrincipal";
            this.chkPrincipal.Size = new System.Drawing.Size(66, 17);
            this.chkPrincipal.TabIndex = 6;
            this.chkPrincipal.Text = "Principal";
            this.chkPrincipal.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarTel
            // 
            this.btnAdicionarTel.Location = new System.Drawing.Point(180, 70);
            this.btnAdicionarTel.Name = "btnAdicionarTel";
            this.btnAdicionarTel.Size = new System.Drawing.Size(100, 23);
            this.btnAdicionarTel.TabIndex = 5;
            this.btnAdicionarTel.Text = "Add Telefone";
            this.btnAdicionarTel.UseVisualStyleBackColor = true;
            this.btnAdicionarTel.Click += new System.EventHandler(this.btnAdicionarTel_Click);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(10, 48);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 4;
            this.lblNumero.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(63, 45);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(110, 20);
            this.txtNumero.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 22);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Móvel",
            "Residencial",
            "Comercial",
            "Outro"});
            this.cmbTipo.Location = new System.Drawing.Point(63, 19);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(110, 21);
            this.cmbTipo.TabIndex = 1;
            // 
            // lstTelefones
            // 
            this.lstTelefones.FormattingEnabled = true;
            this.lstTelefones.Location = new System.Drawing.Point(10, 75);
            this.lstTelefones.Name = "lstTelefones";
            this.lstTelefones.Size = new System.Drawing.Size(163, 82);
            this.lstTelefones.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(325, 12);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(85, 25);
            this.btnNovo.TabIndex = 7;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(325, 43);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(85, 25);
            this.btnAdicionar.TabIndex = 8;
            this.btnAdicionar.Text = "1. Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(325, 74);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 25);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "2. Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(325, 105);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(85, 25);
            this.btnAlterar.TabIndex = 10;
            this.btnAlterar.Text = "3. Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(325, 136);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(85, 25);
            this.btnRemover.TabIndex = 11;
            this.btnRemover.Text = "4. Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(325, 167);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(85, 25);
            this.btnListar.TabIndex = 12;
            this.btnListar.Text = "5. Listar All";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dgvContatos
            // 
            this.dgvContatos.AllowUserToAddRows = false;
            this.dgvContatos.AllowUserToDeleteRows = false;
            this.dgvContatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContatos.Location = new System.Drawing.Point(15, 290);
            this.dgvContatos.MultiSelect = false;
            this.dgvContatos.Name = "dgvContatos";
            this.dgvContatos.ReadOnly = true;
            this.dgvContatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContatos.Size = new System.Drawing.Size(395, 150);
            this.dgvContatos.TabIndex = 13;
            this.dgvContatos.SelectionChanged += new System.EventHandler(this.dgvContatos_SelectionChanged);
            // 
            // txtDetalhes
            // 
            this.txtDetalhes.Location = new System.Drawing.Point(15, 450);
            this.txtDetalhes.Multiline = true;
            this.txtDetalhes.Name = "txtDetalhes";
            this.txtDetalhes.ReadOnly = true;
            this.txtDetalhes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalhes.Size = new System.Drawing.Size(395, 110);
            this.txtDetalhes.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 575);
            this.Controls.Add(this.txtDetalhes);
            this.Controls.Add(this.dgvContatos);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.grpTelefone);
            this.Controls.Add(this.dtpDataNasc);
            this.Controls.Add(this.lblDtNasc);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Agenda (Contatos) - Windows Forms";
            this.grpTelefone.ResumeLayout(false);
            this.grpTelefone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblDtNasc;
        private System.Windows.Forms.DateTimePicker dtpDataNasc;
        private System.Windows.Forms.GroupBox grpTelefone;
        private System.Windows.Forms.CheckBox chkPrincipal;
        private System.Windows.Forms.Button btnAdicionarTel;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ListBox lstTelefones;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView dgvContatos;
        private System.Windows.Forms.TextBox txtDetalhes;
    }
}
