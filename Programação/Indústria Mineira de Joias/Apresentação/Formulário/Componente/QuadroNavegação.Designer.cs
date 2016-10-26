namespace Apresentação.Formulários
{
    partial class QuadroNavegação
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuadroNavegação));
            this.quadro = new Apresentação.Formulários.Quadro();
            this.opçãoVoltar = new Apresentação.Formulários.Opção();
            this.quadro.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadro
            // 
            this.quadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.quadro.bInfDirArredondada = true;
            this.quadro.bInfEsqArredondada = true;
            this.quadro.bSupDirArredondada = true;
            this.quadro.bSupEsqArredondada = true;
            this.quadro.Controls.Add(this.opçãoVoltar);
            this.quadro.Cor = System.Drawing.Color.DarkSeaGreen;
            this.quadro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quadro.FundoTítulo = System.Drawing.Color.DarkSeaGreen;
            this.quadro.LetraTítulo = System.Drawing.Color.White;
            this.quadro.Location = new System.Drawing.Point(0, 0);
            this.quadro.MostrarBotãoMinMax = false;
            this.quadro.Name = "quadro";
            this.quadro.Size = new System.Drawing.Size(160, 48);
            this.quadro.TabIndex = 1;
            this.quadro.Tamanho = 30;
            this.quadro.Título = "Navegação";
            // 
            // opçãoVoltar
            // 
            this.opçãoVoltar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoVoltar.Descrição = "Ir para tela anterior";
            this.opçãoVoltar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVoltar.Imagem")));
            this.opçãoVoltar.Location = new System.Drawing.Point(6, 27);
            this.opçãoVoltar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoVoltar.Name = "opçãoVoltar";
            this.opçãoVoltar.Size = new System.Drawing.Size(146, 20);
            this.opçãoVoltar.TabIndex = 2;
            this.opçãoVoltar.Click += new System.EventHandler(this.opçãoVoltar_Click);
            // 
            // QuadroNavegação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.quadro);
            this.MaximumSize = new System.Drawing.Size(160, 48);
            this.MinimumSize = new System.Drawing.Size(160, 48);
            this.Name = "QuadroNavegação";
            this.Size = new System.Drawing.Size(160, 48);
            this.quadro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Quadro quadro;
        private Opção opçãoVoltar;
    }
}
