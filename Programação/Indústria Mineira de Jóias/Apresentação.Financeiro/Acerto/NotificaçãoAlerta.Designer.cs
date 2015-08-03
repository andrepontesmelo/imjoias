namespace Apresentação.Financeiro.Acerto
{
    partial class NotificaçãoAlerta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPessoa = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblDescrição = new System.Windows.Forms.Label();
            this.quadro.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadro
            // 
            this.quadro.Controls.Add(this.tableLayoutPanel1);
            this.quadro.Título = "Alerta sobre acerto";
            this.quadro.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblPessoa, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNome, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDescrição, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 79);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblPessoa
            // 
            this.lblPessoa.AutoSize = true;
            this.lblPessoa.Location = new System.Drawing.Point(3, 0);
            this.lblPessoa.Name = "lblPessoa";
            this.lblPessoa.Size = new System.Drawing.Size(45, 13);
            this.lblPessoa.TabIndex = 0;
            this.lblPessoa.Text = "Pessoa:";
            // 
            // lblNome
            // 
            this.lblNome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNome.Location = new System.Drawing.Point(54, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(211, 23);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome da pessoa";
            // 
            // lblDescrição
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblDescrição, 2);
            this.lblDescrição.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescrição.Location = new System.Drawing.Point(3, 23);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(262, 56);
            this.lblDescrição.TabIndex = 2;
            this.lblDescrição.Text = "Descrição";
            // 
            // NotificaçãoAlerta
            // 
            this.ClientSize = new System.Drawing.Size(288, 120);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NotificaçãoAlerta";
            this.Título = "Alerta sobre acerto";
            this.quadro.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblPessoa;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDescrição;
    }
}
