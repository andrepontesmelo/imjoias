namespace Apresentação.Importação.Intervenção
{
    partial class EditarTelefones
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.telefones = new Apresentação.Pessoa.Cadastro.EditorTelefones();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.painel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Size = new System.Drawing.Size(585, 529);
            this.splitContainer.SplitterDistance = 222;
            // 
            // painel
            // 
            this.painel.Controls.Add(this.groupBox2);
            this.painel.Controls.Add(this.groupBox1);
            this.painel.Size = new System.Drawing.Size(359, 414);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtContato);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFax);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTelefone);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telefones do banco de dados anterior";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefone:";
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(80, 95);
            this.txtContato.Name = "txtContato";
            this.txtContato.ReadOnly = true;
            this.txtContato.Size = new System.Drawing.Size(264, 20);
            this.txtContato.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contato:";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(80, 57);
            this.txtFax.Multiline = true;
            this.txtFax.Name = "txtFax";
            this.txtFax.ReadOnly = true;
            this.txtFax.Size = new System.Drawing.Size(264, 32);
            this.txtFax.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fax:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(80, 19);
            this.txtTelefone.Multiline = true;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.ReadOnly = true;
            this.txtTelefone.Size = new System.Drawing.Size(264, 32);
            this.txtTelefone.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.telefones);
            this.groupBox2.Location = new System.Drawing.Point(3, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 275);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Telefones importados";
            // 
            // telefones
            // 
            this.telefones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telefones.Location = new System.Drawing.Point(3, 16);
            this.telefones.Name = "telefones";
            this.telefones.Size = new System.Drawing.Size(347, 256);
            this.telefones.TabIndex = 1;
            // 
            // EditarTelefones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 529);
            this.Name = "EditarTelefones";
            this.Text = "Editar telefones";
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.painel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.GroupBox groupBox2;
        private Apresentação.Pessoa.Cadastro.EditorTelefones telefones;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}