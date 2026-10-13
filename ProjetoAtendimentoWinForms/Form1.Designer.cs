namespace AtendimentoWinForms
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
            this.btnGerar = new System.Windows.Forms.Button();
            this.lblGuiches = new System.Windows.Forms.Label();
            this.lblQtdeGuiches = new System.Windows.Forms.Label();
            this.txtGuicheId = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnChamar = new System.Windows.Forms.Button();
            this.lstSenhas = new System.Windows.Forms.ListBox();
            this.lstAtendimentos = new System.Windows.Forms.ListBox();
            this.btnListarSenhas = new System.Windows.Forms.Button();
            this.btnListarAtendimentos = new System.Windows.Forms.Button();
            this.lblSenhas = new System.Windows.Forms.Label();
            this.lblAtendimentos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGerar
            // 
            this.btnGerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerar.Location = new System.Drawing.Point(20, 20);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(120, 40);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // lblGuiches
            // 
            this.lblGuiches.AutoSize = true;
            this.lblGuiches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiches.Location = new System.Drawing.Point(180, 20);
            this.lblGuiches.Name = "lblGuiches";
            this.lblGuiches.Size = new System.Drawing.Size(125, 15);
            this.lblGuiches.TabIndex = 1;
            this.lblGuiches.Text = "Qtde de Guichês: 0";
            // 
            // lblQtdeGuiches
            // 
            this.lblQtdeGuiches.AutoSize = true;
            this.lblQtdeGuiches.Location = new System.Drawing.Point(180, 45);
            this.lblQtdeGuiches.Name = "lblQtdeGuiches";
            this.lblQtdeGuiches.Size = new System.Drawing.Size(44, 13);
            this.lblQtdeGuiches.TabIndex = 2;
            this.lblQtdeGuiches.Text = "Guichê:";
            // 
            // txtGuicheId
            // 
            this.txtGuicheId.Location = new System.Drawing.Point(230, 42);
            this.txtGuicheId.Name = "txtGuicheId";
            this.txtGuicheId.Size = new System.Drawing.Size(50, 20);
            this.txtGuicheId.TabIndex = 3;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(300, 16);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(80, 25);
            this.btnAdicionar.TabIndex = 4;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnChamar
            // 
            this.btnChamar.Location = new System.Drawing.Point(300, 40);
            this.btnChamar.Name = "btnChamar";
            this.btnChamar.Size = new System.Drawing.Size(80, 25);
            this.btnChamar.TabIndex = 5;
            this.btnChamar.Text = "Chamar";
            this.btnChamar.UseVisualStyleBackColor = true;
            this.btnChamar.Click += new System.EventHandler(this.btnChamar_Click);
            // 
            // lstSenhas
            // 
            this.lstSenhas.FormattingEnabled = true;
            this.lstSenhas.Location = new System.Drawing.Point(20, 100);
            this.lstSenhas.Name = "lstSenhas";
            this.lstSenhas.Size = new System.Drawing.Size(250, 225);
            this.lstSenhas.TabIndex = 6;
            // 
            // lstAtendimentos
            // 
            this.lstAtendimentos.FormattingEnabled = true;
            this.lstAtendimentos.Location = new System.Drawing.Point(290, 100);
            this.lstAtendimentos.Name = "lstAtendimentos";
            this.lstAtendimentos.Size = new System.Drawing.Size(320, 225);
            this.lstAtendimentos.TabIndex = 7;
            // 
            // btnListarSenhas
            // 
            this.btnListarSenhas.Location = new System.Drawing.Point(20, 335);
            this.btnListarSenhas.Name = "btnListarSenhas";
            this.btnListarSenhas.Size = new System.Drawing.Size(250, 30);
            this.btnListarSenhas.TabIndex = 8;
            this.btnListarSenhas.Text = "Listar Senhas";
            this.btnListarSenhas.UseVisualStyleBackColor = true;
            this.btnListarSenhas.Click += new System.EventHandler(this.btnListarSenhas_Click);
            // 
            // btnListarAtendimentos
            // 
            this.btnListarAtendimentos.Location = new System.Drawing.Point(290, 335);
            this.btnListarAtendimentos.Name = "btnListarAtendimentos";
            this.btnListarAtendimentos.Size = new System.Drawing.Size(320, 30);
            this.btnListarAtendimentos.TabIndex = 9;
            this.btnListarAtendimentos.Text = "Listar Atendimentos";
            this.btnListarAtendimentos.UseVisualStyleBackColor = true;
            this.btnListarAtendimentos.Click += new System.EventHandler(this.btnListarAtendimentos_Click);
            // 
            // lblSenhas
            // 
            this.lblSenhas.AutoSize = true;
            this.lblSenhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhas.Location = new System.Drawing.Point(20, 80);
            this.lblSenhas.Name = "lblSenhas";
            this.lblSenhas.Size = new System.Drawing.Size(56, 15);
            this.lblSenhas.TabIndex = 10;
            this.lblSenhas.Text = "Senhas";
            // 
            // lblAtendimentos
            // 
            this.lblAtendimentos.AutoSize = true;
            this.lblAtendimentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtendimentos.Location = new System.Drawing.Point(290, 80);
            this.lblAtendimentos.Name = "lblAtendimentos";
            this.lblAtendimentos.Size = new System.Drawing.Size(94, 15);
            this.lblAtendimentos.TabIndex = 11;
            this.lblAtendimentos.Text = "Atendimentos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 385);
            this.Controls.Add(this.lblAtendimentos);
            this.Controls.Add(this.lblSenhas);
            this.Controls.Add(this.btnListarAtendimentos);
            this.Controls.Add(this.btnListarSenhas);
            this.Controls.Add(this.lstAtendimentos);
            this.Controls.Add(this.lstSenhas);
            this.Controls.Add(this.btnChamar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtGuicheId);
            this.Controls.Add(this.lblQtdeGuiches);
            this.Controls.Add(this.lblGuiches);
            this.Controls.Add(this.btnGerar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Atendimento - Windows Forms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Label lblGuiches;
        private System.Windows.Forms.Label lblQtdeGuiches;
        private System.Windows.Forms.TextBox txtGuicheId;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnChamar;
        private System.Windows.Forms.ListBox lstSenhas;
        private System.Windows.Forms.ListBox lstAtendimentos;
        private System.Windows.Forms.Button btnListarSenhas;
        private System.Windows.Forms.Button btnListarAtendimentos;
        private System.Windows.Forms.Label lblSenhas;
        private System.Windows.Forms.Label lblAtendimentos;
    }
}
