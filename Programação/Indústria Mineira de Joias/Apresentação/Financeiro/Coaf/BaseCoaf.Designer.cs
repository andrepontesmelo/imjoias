namespace Apresentação.Financeiro.Coaf
{
    partial class BaseCoaf
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoImportar = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.opçãoConfigurar = new Apresentação.Formulários.Opção();
            this.listaSaída = new Apresentação.Financeiro.Coaf.Lista.ListaSaída();
            this.listaPessoa = new Apresentação.Financeiro.Coaf.Lista.ListaPessoa();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 478);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Operações de saídas fiscais acumuladas nos últimos 6 mêses. Este relatório implem" +
    "enta a resolução 23 de 20 de Dezembro de 2012 da COAF. PEP: Pessoa exposta polít" +
    "icamente.";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.Logo_COAF;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(705, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Relatório Coaf ";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoImportar);
            this.quadro1.Controls.Add(this.opçãoImprimir);
            this.quadro1.Controls.Add(this.opçãoConfigurar);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 94);
            this.quadro1.TabIndex = 7;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Ações";
            // 
            // opçãoImportar
            // 
            this.opçãoImportar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportar.Descrição = "Importar";
            this.opçãoImportar.Imagem = global::Apresentação.Resource.importar21;
            this.opçãoImportar.Location = new System.Drawing.Point(7, 70);
            this.opçãoImportar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportar.Name = "opçãoImportar";
            this.opçãoImportar.Size = new System.Drawing.Size(150, 18);
            this.opçãoImportar.TabIndex = 10;
            this.opçãoImportar.Click += new System.EventHandler(this.opçãoImportar_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora__altura_58_;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 50);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 18);
            this.opçãoImprimir.TabIndex = 8;
            this.opçãoImprimir.Visible = false;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // opçãoConfigurar
            // 
            this.opçãoConfigurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoConfigurar.Descrição = "Configurar";
            this.opçãoConfigurar.Imagem = global::Apresentação.Resource.repair;
            this.opçãoConfigurar.Location = new System.Drawing.Point(7, 30);
            this.opçãoConfigurar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoConfigurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoConfigurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoConfigurar.Name = "opçãoConfigurar";
            this.opçãoConfigurar.Size = new System.Drawing.Size(150, 16);
            this.opçãoConfigurar.TabIndex = 9;
            this.opçãoConfigurar.Click += new System.EventHandler(this.opçãoConfigurar_Click);
            // 
            // listaSaída
            // 
            this.listaSaída.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaSaída.Location = new System.Drawing.Point(193, 387);
            this.listaSaída.Name = "listaSaída";
            this.listaSaída.Size = new System.Drawing.Size(705, 77);
            this.listaSaída.TabIndex = 7;
            this.listaSaída.DuploClique += new System.EventHandler(this.listaSaída_DuploClique);
            // 
            // listaPessoa
            // 
            this.listaPessoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaPessoa.Location = new System.Drawing.Point(193, 79);
            this.listaPessoa.Name = "listaPessoa";
            this.listaPessoa.Size = new System.Drawing.Size(708, 302);
            this.listaPessoa.TabIndex = 8;
            this.listaPessoa.DuploClique += new System.EventHandler(this.listaPessoa_DuploClique);
            // 
            // BaseCoaf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listaPessoa);
            this.Controls.Add(this.listaSaída);
            this.Controls.Add(this.título);
            this.Name = "BaseCoaf";
            this.Size = new System.Drawing.Size(916, 478);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.listaSaída, 0);
            this.Controls.SetChildIndex(this.listaPessoa, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoImprimir;
        private Formulários.Opção opçãoConfigurar;
        private Formulários.TítuloBaseInferior título;
        private Lista.ListaSaída listaSaída;
        private Lista.ListaPessoa listaPessoa;
        private Formulários.Opção opçãoImportar;
    }
}
