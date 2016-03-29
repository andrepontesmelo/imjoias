namespace Apresentação.Álbum.Edição.Álbuns
{
    partial class BaseTodasFotos
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
            this.todasFotos = new Apresentação.Álbum.Edição.Fotos.TodasFotos();
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoRefazerÍcones = new Apresentação.Formulários.Opção();
            this.opçãoPrefetch = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // todasFotos
            // 
            this.todasFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.todasFotos.Location = new System.Drawing.Point(193, 79);
            this.todasFotos.Name = "todasFotos";
            this.todasFotos.Size = new System.Drawing.Size(582, 203);
            this.todasFotos.TabIndex = 6;
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Listagem de fotos";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.botão___agenda;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(598, 70);
            this.títuloBaseInferior.TabIndex = 7;
            this.títuloBaseInferior.Título = "Todas as fotos";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoRefazerÍcones);
            this.quadro1.Controls.Add(this.opçãoPrefetch);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 74);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Manutenção";
            // 
            // opçãoRefazerÍcones
            // 
            this.opçãoRefazerÍcones.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoRefazerÍcones.Descrição = "Refazer ícones";
            this.opçãoRefazerÍcones.Imagem = global::Apresentação.Resource.repair;
            this.opçãoRefazerÍcones.Location = new System.Drawing.Point(7, 50);
            this.opçãoRefazerÍcones.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRefazerÍcones.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRefazerÍcones.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRefazerÍcones.Name = "opçãoRefazerÍcones";
            this.opçãoRefazerÍcones.Size = new System.Drawing.Size(150, 16);
            this.opçãoRefazerÍcones.TabIndex = 3;
            this.opçãoRefazerÍcones.Click += new System.EventHandler(this.opçãoRefazerÍcones_Click);
            // 
            // opçãoPrefetch
            // 
            this.opçãoPrefetch.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoPrefetch.Descrição = "Pré-carga de miniaturas";
            this.opçãoPrefetch.Imagem = global::Apresentação.Resource.repair;
            this.opçãoPrefetch.Location = new System.Drawing.Point(7, 30);
            this.opçãoPrefetch.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoPrefetch.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoPrefetch.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoPrefetch.Name = "opçãoPrefetch";
            this.opçãoPrefetch.Size = new System.Drawing.Size(150, 26);
            this.opçãoPrefetch.TabIndex = 2;
            this.opçãoPrefetch.Click += new System.EventHandler(this.opçãoPrefetch_Click);
            // 
            // BaseTodasFotos
            // 
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.todasFotos);
            this.Name = "BaseTodasFotos";
            this.Controls.SetChildIndex(this.todasFotos, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Álbum.Edição.Fotos.TodasFotos todasFotos;
        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opçãoPrefetch;
        private Formulários.Opção opçãoRefazerÍcones;

    }
}
