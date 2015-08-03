namespace Apresenta��o.Financeiro.Comiss�o
{
    partial class BasePend�ncias
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
            this.t�tuloBaseInferior1 = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadroVendaSelecionada = new Apresenta��o.Formul�rios.Quadro();
            this.op��oVerificar = new Apresenta��o.Formul�rios.Op��o();
            this.quadroVendas = new Apresenta��o.Formul�rios.Quadro();
            this.listaVendas = new Apresenta��o.Financeiro.Venda.ListViewVendas();
            this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroVendaSelecionada.SuspendLayout();
            this.quadroVendas.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.Add(this.quadroVendaSelecionada);
            this.esquerda.Controls.SetChildIndex(this.quadroVendaSelecionada, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // t�tuloBaseInferior1
            // 
            this.t�tuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior1.Descri��o = "A comiss�o s� � calculada para as vendas que tem sua comiss�o autorizada. ";
            this.t�tuloBaseInferior1.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.Porcento;
            this.t�tuloBaseInferior1.Location = new System.Drawing.Point(207, 0);
            this.t�tuloBaseInferior1.Name = "t�tuloBaseInferior1";
            this.t�tuloBaseInferior1.Size = new System.Drawing.Size(601, 70);
            this.t�tuloBaseInferior1.TabIndex = 6;
            this.t�tuloBaseInferior1.T�tulo = "Vendas com comiss�o ainda n�o autorizada";
            // 
            // quadroVendaSelecionada
            // 
            this.quadroVendaSelecionada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVendaSelecionada.bInfDirArredondada = true;
            this.quadroVendaSelecionada.bInfEsqArredondada = true;
            this.quadroVendaSelecionada.bSupDirArredondada = true;
            this.quadroVendaSelecionada.bSupEsqArredondada = true;
            this.quadroVendaSelecionada.Controls.Add(this.op��oVerificar);
            this.quadroVendaSelecionada.Cor = System.Drawing.Color.Black;
            this.quadroVendaSelecionada.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendaSelecionada.LetraT�tulo = System.Drawing.Color.White;
            this.quadroVendaSelecionada.Location = new System.Drawing.Point(7, 13);
            this.quadroVendaSelecionada.MostrarBot�oMinMax = false;
            this.quadroVendaSelecionada.Name = "quadroVendaSelecionada";
            this.quadroVendaSelecionada.Size = new System.Drawing.Size(160, 57);
            this.quadroVendaSelecionada.TabIndex = 0;
            this.quadroVendaSelecionada.Tamanho = 30;
            this.quadroVendaSelecionada.T�tulo = "Venda(s) selecionada(s)";
            // 
            // op��oVerificar
            // 
            this.op��oVerificar.BackColor = System.Drawing.Color.Transparent;
            this.op��oVerificar.Descri��o = "Autorizar comiss�o";
            this.op��oVerificar.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.ok;
            this.op��oVerificar.Location = new System.Drawing.Point(7, 33);
            this.op��oVerificar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oVerificar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVerificar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVerificar.Name = "op��oVerificar";
            this.op��oVerificar.Privil�gio = Entidades.Privil�gio.Permiss�o.VendasVerificar;
            this.op��oVerificar.Size = new System.Drawing.Size(150, 24);
            this.op��oVerificar.TabIndex = 2;
            this.op��oVerificar.Click += new System.EventHandler(this.op��oVerificar_Click);
            // 
            // quadroVendas
            // 
            this.quadroVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroVendas.bInfDirArredondada = false;
            this.quadroVendas.bInfEsqArredondada = false;
            this.quadroVendas.bSupDirArredondada = true;
            this.quadroVendas.bSupEsqArredondada = true;
            this.quadroVendas.Controls.Add(this.listaVendas);
            this.quadroVendas.Cor = System.Drawing.Color.Black;
            this.quadroVendas.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendas.LetraT�tulo = System.Drawing.Color.White;
            this.quadroVendas.Location = new System.Drawing.Point(207, 76);
            this.quadroVendas.MostrarBot�oMinMax = false;
            this.quadroVendas.Name = "quadroVendas";
            this.quadroVendas.Size = new System.Drawing.Size(578, 206);
            this.quadroVendas.TabIndex = 8;
            this.quadroVendas.Tamanho = 30;
            this.quadroVendas.T�tulo = "Comiss�es n�o autorizadas";
            // 
            // listaVendas
            // 
            this.listaVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaVendas.ApenasN�oAcertado = false;
            this.listaVendas.Location = new System.Drawing.Point(0, 24);
            this.listaVendas.Name = "listaVendas";
            this.listaVendas.Size = new System.Drawing.Size(578, 182);
            this.listaVendas.TabIndex = 7;
            this.listaVendas.TipoExibi��o = Apresenta��o.Financeiro.Venda.V�nculoVendaPessoa.Indefinido;
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.label1);
            this.quadro1.Controls.Add(this.label2);
            this.quadro1.Controls.Add(this.label3);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraT�tulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 80);
            this.quadro1.MostrarBot�oMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 137);
            this.quadro1.TabIndex = 10;
            this.quadro1.Tamanho = 30;
            this.quadro1.T�tulo = "Legenda:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escrito em";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(64, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "cinza:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 58);
            this.label3.TabIndex = 4;
            this.label3.Text = "S�o as vendas j� acertadas pelo acerto de mercadorias";
            // 
            // BasePend�ncias
            // 
            this.Controls.Add(this.t�tuloBaseInferior1);
            this.Controls.Add(this.quadroVendas);
            this.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.Porcento;
            this.Name = "BasePend�ncias";
            this.Controls.SetChildIndex(this.quadroVendas, 0);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroVendaSelecionada.ResumeLayout(false);
            this.quadroVendas.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior1;
        private Apresenta��o.Formul�rios.Quadro quadroVendaSelecionada;
        private Apresenta��o.Financeiro.Venda.ListViewVendas listaVendas;
        private Apresenta��o.Formul�rios.Quadro quadroVendas;
        private Apresenta��o.Formul�rios.Op��o op��oVerificar;
        private Apresenta��o.Formul�rios.Quadro quadro1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
