namespace Apresentação.Atendimento.Clientes
{
    partial class JanelaEtiquetaSedex
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
            if (disposing && (components != null)) {
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lista = new System.Windows.Forms.ListView();
            this.colCódigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLogradouro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimparLista = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.txtPessoa = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(291, 20);
            this.lblTítulo.Text = "Impressão de etiquetas para sedex";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(713, 48);
            this.lblDescrição.Text = "Entre com os clientes de destino.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.sedex31;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(525, 391);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(128, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir Agora";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCódigo,
            this.colTipo,
            this.colQuantidade,
            this.colNome,
            this.colEstado,
            this.colCidade,
            this.colLogradouro});
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(6, 19);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(768, 205);
            this.lista.TabIndex = 4;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colCódigo
            // 
            this.colCódigo.Text = "Código";
            this.colCódigo.Width = 45;
            // 
            // colTipo
            // 
            this.colTipo.Text = "Tipo";
            this.colTipo.Width = 88;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Text = "Qtd";
            this.colQuantidade.Width = 30;
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 191;
            // 
            // colEstado
            // 
            this.colEstado.Text = "UF";
            this.colEstado.Width = 38;
            // 
            // colCidade
            // 
            this.colCidade.Text = "Cidade";
            this.colCidade.Width = 91;
            // 
            // colLogradouro
            // 
            this.colLogradouro.Text = "Logradouro";
            this.colLogradouro.Width = 304;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lista);
            this.groupBox1.Location = new System.Drawing.Point(9, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 232);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Etiquetas na fila para impressão";
            // 
            // btnLimparLista
            // 
            this.btnLimparLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimparLista.Location = new System.Drawing.Point(16, 391);
            this.btnLimparLista.Name = "btnLimparLista";
            this.btnLimparLista.Size = new System.Drawing.Size(101, 23);
            this.btnLimparLista.TabIndex = 6;
            this.btnLimparLista.Text = "Remover tudo";
            this.btnLimparLista.UseVisualStyleBackColor = true;
            this.btnLimparLista.Click += new System.EventHandler(this.btnLimparLista_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAdicionar);
            this.groupBox2.Controls.Add(this.txtPessoa);
            this.groupBox2.Location = new System.Drawing.Point(10, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 54);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adicionar";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdicionar.Location = new System.Drawing.Point(649, 16);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(122, 23);
            this.buttonAdicionar.TabIndex = 10;
            this.buttonAdicionar.Text = "Adicionar Pessoa";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // txtPessoa
            // 
            this.txtPessoa.AlturaProposta = 60;
            this.txtPessoa.Location = new System.Drawing.Point(6, 19);
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Pessoa = null;
            this.txtPessoa.Size = new System.Drawing.Size(637, 20);
            this.txtPessoa.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(659, 391);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(128, 23);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Imprimir Depois";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemover.Location = new System.Drawing.Point(123, 391);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(101, 23);
            this.btnRemover.TabIndex = 9;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // JanelaEtiquetaSedex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLimparLista);
            this.Name = "JanelaEtiquetaSedex";
            this.Text = "Impressão de etiquetas para sedex";
            this.Controls.SetChildIndex(this.btnLimparLista, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnFechar, 0);
            this.Controls.SetChildIndex(this.btnRemover, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimparLista;
        private System.Windows.Forms.GroupBox groupBox2;
        private Apresentação.Pessoa.Consultas.TextBoxPessoa txtPessoa;
        private System.Windows.Forms.ColumnHeader colCódigo;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colEstado;
        private System.Windows.Forms.ColumnHeader colCidade;
        private System.Windows.Forms.ColumnHeader colLogradouro;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.ColumnHeader colTipo;
        private System.Windows.Forms.ColumnHeader colQuantidade;
        private System.Windows.Forms.Button buttonAdicionar;
    }
}