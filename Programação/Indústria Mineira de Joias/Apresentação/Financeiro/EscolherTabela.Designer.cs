namespace Apresentação.Financeiro
{
    partial class EscolherTabela
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
            this.label1 = new System.Windows.Forms.Label();
            this.lst = new System.Windows.Forms.ListView();
            this.colTabela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSetor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.botãoLiberarRecurso = new Apresentação.Formulários.BotãoLiberarRecurso();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(147, 20);
            this.lblTítulo.Text = "Tabela de preços";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Escolha a tabela do setor com que deseja trabalhar.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.tabela_precos_90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Escolha a tabela:";
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTabela,
            this.colSetor});
            this.lst.FullRowSelect = true;
            this.lst.Location = new System.Drawing.Point(20, 123);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(349, 144);
            this.lst.TabIndex = 4;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            // 
            // colTabela
            // 
            this.colTabela.Text = "Tabela";
            this.colTabela.Width = 237;
            // 
            // colSetor
            // 
            this.colSetor.Text = "Setor";
            this.colSetor.Width = 91;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(294, 273);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // botãoLiberarRecurso
            // 
            this.botãoLiberarRecurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botãoLiberarRecurso.AutoSize = true;
            this.botãoLiberarRecurso.Descrição = "Este recurso permite que o funcionário utilize tabela de preço de qualquer setor " +
    "para registrar saída, retorno ou venda para o cliente.";
            this.botãoLiberarRecurso.Location = new System.Drawing.Point(20, 273);
            this.botãoLiberarRecurso.Name = "botãoLiberarRecurso";
            this.botãoLiberarRecurso.Privilégios = Entidades.Privilégio.Permissão.EscolherQualquerTabela;
            this.botãoLiberarRecurso.Recurso = "Escolher tabela de preço de outros setores";
            this.botãoLiberarRecurso.Size = new System.Drawing.Size(131, 23);
            this.botãoLiberarRecurso.TabIndex = 7;
            this.botãoLiberarRecurso.Texto = "Liberar outras tabelas";
            this.botãoLiberarRecurso.LiberarRecurso += new System.EventHandler(this.botãoLiberarRecurso_LiberarRecurso);
            // 
            // EscolherTabela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 308);
            this.Controls.Add(this.botãoLiberarRecurso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.btnOK);
            this.Name = "EscolherTabela";
            this.Text = "Tabela de preços";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EscolherTabela_FormClosed);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.lst, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.botãoLiberarRecurso, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colTabela;
        private System.Windows.Forms.ColumnHeader colSetor;
        private System.Windows.Forms.Button btnOK;
        private Apresentação.Formulários.BotãoLiberarRecurso botãoLiberarRecurso;
    }
}