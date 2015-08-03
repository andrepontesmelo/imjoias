namespace Apresentação.Mercadoria.Manutenção.Tabela
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.listaTabelasPreços1 = new Apresentação.Mercadoria.Manutenção.Tabela.ListaTabelasPreços();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Descrição";
            this.títuloBaseInferior.Imagem = null;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 13);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(569, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Tabelas de preços";
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = false;
            this.quadro2.bInfEsqArredondada = false;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.listaTabelasPreços1);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(202, 76);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(281, 184);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Título";
            // 
            // listaTabelasPreços1
            // 
            this.listaTabelasPreços1.Location = new System.Drawing.Point(0, 24);
            this.listaTabelasPreços1.Name = "listaTabelasPreços1";
            this.listaTabelasPreços1.Size = new System.Drawing.Size(281, 160);
            this.listaTabelasPreços1.TabIndex = 2;
            // 
            // BaseTabelas
            // 
            this.Controls.Add(this.quadro2);
            this.Controls.Add(this.títuloBaseInferior);
            this.Name = "BaseTabelas";
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadro2;
        private ListaTabelasPreços listaTabelasPreços1;
    }
}
