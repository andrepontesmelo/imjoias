namespace Apresenta��o.Mercadoria.Manuten��o.Tabela
{
    partial class BaseTabelas
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
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadro2 = new Apresenta��o.Formul�rios.Quadro();
            this.listaTabelasPre�os1 = new Apresenta��o.Mercadoria.Manuten��o.Tabela.ListaTabelasPre�os();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "Descri��o";
            this.t�tuloBaseInferior.Imagem = null;
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(193, 13);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(569, 70);
            this.t�tuloBaseInferior.TabIndex = 6;
            this.t�tuloBaseInferior.T�tulo = "Tabelas de pre�os";
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = false;
            this.quadro2.bInfEsqArredondada = false;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.listaTabelasPre�os1);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraT�tulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(202, 76);
            this.quadro2.MostrarBot�oMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(281, 184);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.T�tulo = "T�tulo";
            // 
            // listaTabelasPre�os1
            // 
            this.listaTabelasPre�os1.Location = new System.Drawing.Point(0, 24);
            this.listaTabelasPre�os1.Name = "listaTabelasPre�os1";
            this.listaTabelasPre�os1.Size = new System.Drawing.Size(281, 160);
            this.listaTabelasPre�os1.TabIndex = 2;
            // 
            // BaseTabelas
            // 
            this.Controls.Add(this.quadro2);
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Name = "BaseTabelas";
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
        private Apresenta��o.Formul�rios.Quadro quadro2;
        private ListaTabelasPre�os listaTabelasPre�os1;
    }
}
