namespace Apresentação.Financeiro
{
    partial class PesquisaMercadoriaResultado
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
            this.listaFotos = new Apresentação.Álbum.Edição.Fotos.ListaFotos();
            this.quadroSeleção = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReferência = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCotação = new Apresentação.Mercadoria.Cotação.TxtCotação();
            this.lblPreço = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.cmbTabela = new Apresentação.Financeiro.ComboTabela();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.quadroSeleção.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(201, 20);
            this.lblTítulo.Text = "Pesquisa de mercadoria";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(506, 48);
            this.lblDescrição.Text = "Abaixo seguem os resultados para a pesquisa realizada.  Somente mercadorias com f" +
                "otos existentes no álbum de mercadorias constam no resultado desta pesquisa.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Financeiro.Properties.Resources.ConsultarMercadoria;
            // 
            // listaFotos
            // 
            this.listaFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaFotos.Fotos = null;
            this.listaFotos.Location = new System.Drawing.Point(16, 103);
            this.listaFotos.Name = "listaFotos";
            this.listaFotos.Ordenar = true;
            this.listaFotos.Size = new System.Drawing.Size(395, 357);
            this.listaFotos.TabIndex = 3;
            this.listaFotos.AoSelecionar += new Apresentação.Álbum.Edição.Fotos.ListaFotos.FotoHandle(this.listaFotos_AoSelecionar);
            // 
            // quadroSeleção
            // 
            this.quadroSeleção.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroSeleção.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroSeleção.bInfDirArredondada = true;
            this.quadroSeleção.bInfEsqArredondada = true;
            this.quadroSeleção.bSupDirArredondada = true;
            this.quadroSeleção.bSupEsqArredondada = true;
            this.quadroSeleção.Controls.Add(this.picFoto);
            this.quadroSeleção.Controls.Add(this.label1);
            this.quadroSeleção.Controls.Add(this.cmbTabela);
            this.quadroSeleção.Controls.Add(this.txtCotação);
            this.quadroSeleção.Controls.Add(this.lblReferência);
            this.quadroSeleção.Controls.Add(this.label3);
            this.quadroSeleção.Controls.Add(this.label5);
            this.quadroSeleção.Controls.Add(this.label8);
            this.quadroSeleção.Controls.Add(this.label7);
            this.quadroSeleção.Controls.Add(this.lblPreço);
            this.quadroSeleção.Controls.Add(this.lblPeso);
            this.quadroSeleção.Cor = System.Drawing.Color.Black;
            this.quadroSeleção.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroSeleção.LetraTítulo = System.Drawing.Color.White;
            this.quadroSeleção.Location = new System.Drawing.Point(422, 103);
            this.quadroSeleção.MostrarBotãoMinMax = false;
            this.quadroSeleção.Name = "quadroSeleção";
            this.quadroSeleção.Size = new System.Drawing.Size(157, 356);
            this.quadroSeleção.TabIndex = 4;
            this.quadroSeleção.Tamanho = 30;
            this.quadroSeleção.Título = "Informações";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Referência:";
            // 
            // lblReferência
            // 
            this.lblReferência.AutoSize = true;
            this.lblReferência.Location = new System.Drawing.Point(5, 178);
            this.lblReferência.Name = "lblReferência";
            this.lblReferência.Size = new System.Drawing.Size(28, 13);
            this.lblReferência.TabIndex = 3;
            this.lblReferência.Text = "N/D";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Peso:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Preço:";
            // 
            // txtCotação
            // 
            this.txtCotação.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCotação.Cotação = null;
            this.txtCotação.Location = new System.Drawing.Point(6, 328);
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.Size = new System.Drawing.Size(145, 20);
            this.txtCotação.TabIndex = 9;
            this.txtCotação.Valor = 0;
            this.txtCotação.EscolheuCotação += new Apresentação.Mercadoria.Cotação.TxtCotação.Escolha(this.txtCotação_EscolheuCotação);
            // 
            // lblPreço
            // 
            this.lblPreço.AutoSize = true;
            this.lblPreço.Location = new System.Drawing.Point(5, 249);
            this.lblPreço.Name = "lblPreço";
            this.lblPreço.Size = new System.Drawing.Size(28, 13);
            this.lblPreço.TabIndex = 7;
            this.lblPreço.Text = "N/D";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(5, 213);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(28, 13);
            this.lblPeso.TabIndex = 5;
            this.lblPeso.Text = "N/D";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tabela:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cotação:";
            // 
            // picFoto
            // 
            this.picFoto.Image = global::Apresentação.Financeiro.Properties.Resources.logo;
            this.picFoto.Location = new System.Drawing.Point(6, 30);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(144, 131);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 12;
            this.picFoto.TabStop = false;
            // 
            // cmbTabela
            // 
            this.cmbTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTabela.Cotação = this.txtCotação;
            this.cmbTabela.DisplayMember = "Nome";
            this.cmbTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabela.FormattingEnabled = true;
            this.cmbTabela.Location = new System.Drawing.Point(6, 288);
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(145, 21);
            this.cmbTabela.TabIndex = 11;
            // 
            // PesquisaMercadoriaResultado
            // 
            this.ClientSize = new System.Drawing.Size(594, 475);
            this.Controls.Add(this.quadroSeleção);
            this.Controls.Add(this.listaFotos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(610, 511);
            this.Name = "PesquisaMercadoriaResultado";
            this.ShowInTaskbar = true;
            this.Text = "Pesquisa de mercadoria";
            this.Controls.SetChildIndex(this.listaFotos, 0);
            this.Controls.SetChildIndex(this.quadroSeleção, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.quadroSeleção.ResumeLayout(false);
            this.quadroSeleção.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Álbum.Edição.Fotos.ListaFotos listaFotos;
        private Apresentação.Formulários.Quadro quadroSeleção;
        private System.Windows.Forms.Label lblReferência;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPreço;
        private System.Windows.Forms.Label lblPeso;
        private ComboTabela cmbTabela;
        private Apresentação.Mercadoria.Cotação.TxtCotação txtCotação;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picFoto;

    }
}
