namespace Programa.TesteDesempenho
{
    partial class TesteQuadro
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
            this.quadroMercadoria1 = new Apresenta��o.Mercadoria.QuadroMercadoria();
            this.quadroFoto1 = new Apresenta��o.Mercadoria.QuadroFoto();
            this.SuspendLayout();
            // 
            // quadroMercadoria1
            // 
            this.quadroMercadoria1.AtualizarFotoNaSele��o = true;
            this.quadroMercadoria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroMercadoria1.bInfDirArredondada = true;
            this.quadroMercadoria1.bInfEsqArredondada = true;
            this.quadroMercadoria1.bSupDirArredondada = true;
            this.quadroMercadoria1.bSupEsqArredondada = true;
            this.quadroMercadoria1.ControleFoto = this.quadroFoto1;
            this.quadroMercadoria1.Cor = System.Drawing.Color.Black;
            this.quadroMercadoria1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroMercadoria1.LetraT�tulo = System.Drawing.Color.White;
            this.quadroMercadoria1.Location = new System.Drawing.Point(275, 83);
            this.quadroMercadoria1.MaximumSize = new System.Drawing.Size(999999, 146);
            this.quadroMercadoria1.MinimumSize = new System.Drawing.Size(160, 146);
            this.quadroMercadoria1.MostrarBot�oMinMax = false;
            this.quadroMercadoria1.Name = "quadroMercadoria1";
            this.quadroMercadoria1.Size = new System.Drawing.Size(233, 146);
            this.quadroMercadoria1.TabIndex = 6;
            this.quadroMercadoria1.Tamanho = 30;
            this.quadroMercadoria1.T�tulo = "Escolha da mercadoria";
            this.quadroMercadoria1.EventoRefer�nciaEscolhida += new Apresenta��o.Mercadoria.QuadroMercadoria.Refer�nciaEscolhidaDelegate(this.quadroMercadoria1_EventoRefer�nciaEscolhida);
            this.quadroMercadoria1.EventoAdicionou += new Apresenta��o.Mercadoria.QuadroMercadoria.AdicionouDelegate(this.quadroMercadoria1_EventoAdicionou);
            // 
            // quadroFoto1
            // 
            this.quadroFoto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(215)))));
            this.quadroFoto1.bInfDirArredondada = true;
            this.quadroFoto1.bInfEsqArredondada = true;
            this.quadroFoto1.bSupDirArredondada = true;
            this.quadroFoto1.bSupEsqArredondada = true;
            this.quadroFoto1.Cor = System.Drawing.Color.Black;
            this.quadroFoto1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFoto1.LetraT�tulo = System.Drawing.Color.White;
            this.quadroFoto1.Location = new System.Drawing.Point(538, 83);
            this.quadroFoto1.MostrarBot�oMinMax = false;
            this.quadroFoto1.Name = "quadroFoto1";
            this.quadroFoto1.ReportarErros = false;
            this.quadroFoto1.Size = new System.Drawing.Size(240, 160);
            this.quadroFoto1.TabIndex = 7;
            this.quadroFoto1.Tamanho = 30;
            this.quadroFoto1.T�tulo = "Mercadoria";
            // 
            // TesteQuadro
            // 
            this.Controls.Add(this.quadroMercadoria1);
            this.Controls.Add(this.quadroFoto1);
            this.Name = "TesteQuadro";
            this.Controls.SetChildIndex(this.quadroFoto1, 0);
            this.Controls.SetChildIndex(this.quadroMercadoria1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Mercadoria.QuadroMercadoria quadroMercadoria1;
        private Apresenta��o.Mercadoria.QuadroFoto quadroFoto1;
    }
}
