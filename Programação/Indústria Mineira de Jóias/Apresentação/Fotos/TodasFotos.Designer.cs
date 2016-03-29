namespace Apresentação.Álbum.Edição.Fotos
{
    partial class TodasFotos
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
            this.quadroFotosTodas = new Apresentação.Formulários.Quadro();
            this.txtReferência = new Apresentação.Mercadoria.TxtMercadoria();
            this.listaFotosTodas = new Apresentação.Álbum.Edição.Fotos.ListaFotos();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkForaDeLinha = new System.Windows.Forms.CheckBox();
            this.opçãoTodasFotos = new Apresentação.Formulários.Opção();
            this.quadroFotosTodas.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadroFotosTodas
            // 
            this.quadroFotosTodas.BackColor = System.Drawing.Color.NavajoWhite;
            this.quadroFotosTodas.bInfDirArredondada = false;
            this.quadroFotosTodas.bInfEsqArredondada = false;
            this.quadroFotosTodas.bSupDirArredondada = true;
            this.quadroFotosTodas.bSupEsqArredondada = true;
            this.quadroFotosTodas.Controls.Add(this.txtReferência);
            this.quadroFotosTodas.Controls.Add(this.listaFotosTodas);
            this.quadroFotosTodas.Controls.Add(this.panel1);
            this.quadroFotosTodas.Controls.Add(this.chkForaDeLinha);
            this.quadroFotosTodas.Controls.Add(this.opçãoTodasFotos);
            this.quadroFotosTodas.Cor = System.Drawing.Color.SaddleBrown;
            this.quadroFotosTodas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quadroFotosTodas.FundoTítulo = System.Drawing.Color.SaddleBrown;
            this.quadroFotosTodas.LetraTítulo = System.Drawing.Color.White;
            this.quadroFotosTodas.Location = new System.Drawing.Point(0, 0);
            this.quadroFotosTodas.MostrarBotãoMinMax = false;
            this.quadroFotosTodas.Name = "quadroFotosTodas";
            this.quadroFotosTodas.Size = new System.Drawing.Size(483, 284);
            this.quadroFotosTodas.TabIndex = 9;
            this.quadroFotosTodas.Tamanho = 30;
            this.quadroFotosTodas.Título = "Todas as fotos";
            // 
            // txtReferência
            // 
            this.txtReferência.Location = new System.Drawing.Point(25, 26);
            this.txtReferência.MostrarBalãoRefNãoEncontrada = false;
            this.txtReferência.Name = "txtReferência";
            this.txtReferência.Referência = "";
            this.txtReferência.Size = new System.Drawing.Size(170, 20);
            this.txtReferência.TabIndex = 9;
            this.txtReferência.UtilizarListView = false;
            this.txtReferência.ReferênciaAlterada += new System.EventHandler(this.txtReferência_ReferênciaAlterada);
            // 
            // listaFotosTodas
            // 
            this.listaFotosTodas.AllowDrop = true;
            this.listaFotosTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaFotosTodas.Fotos = null;
            this.listaFotosTodas.Location = new System.Drawing.Point(3, 48);
            this.listaFotosTodas.Name = "listaFotosTodas";
            this.listaFotosTodas.Ordenar = true;
            this.listaFotosTodas.Size = new System.Drawing.Size(477, 217);
            this.listaFotosTodas.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Apresentação.Resource.FINDFILE16;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(34, 38);
            this.panel1.TabIndex = 10;
            // 
            // chkForaDeLinha
            // 
            this.chkForaDeLinha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkForaDeLinha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkForaDeLinha.Location = new System.Drawing.Point(344, 25);
            this.chkForaDeLinha.Name = "chkForaDeLinha";
            this.chkForaDeLinha.Size = new System.Drawing.Size(133, 17);
            this.chkForaDeLinha.TabIndex = 5;
            this.chkForaDeLinha.Text = "Exibir f. de linha";
            this.chkForaDeLinha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkForaDeLinha.UseVisualStyleBackColor = true;
            this.chkForaDeLinha.CheckedChanged += new System.EventHandler(this.chkForaDeLinha_CheckedChanged);
            // 
            // opçãoTodasFotos
            // 
            this.opçãoTodasFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.opçãoTodasFotos.AutoSize = true;
            this.opçãoTodasFotos.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoTodasFotos.Descrição = "Visualizar todas as fotos";
            this.opçãoTodasFotos.Imagem = global::Apresentação.Resource.botão___agenda;
            this.opçãoTodasFotos.Location = new System.Drawing.Point(331, 265);
            this.opçãoTodasFotos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoTodasFotos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoTodasFotos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoTodasFotos.Name = "opçãoTodasFotos";
            this.opçãoTodasFotos.Size = new System.Drawing.Size(150, 19);
            this.opçãoTodasFotos.TabIndex = 7;
            this.opçãoTodasFotos.Click += new System.EventHandler(this.opçãoTodasFotos_Click);
            // 
            // TodasFotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadroFotosTodas);
            this.Name = "TodasFotos";
            this.Size = new System.Drawing.Size(483, 284);
            this.quadroFotosTodas.ResumeLayout(false);
            this.quadroFotosTodas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadroFotosTodas;
        private Apresentação.Álbum.Edição.Fotos.ListaFotos listaFotosTodas;
        private System.Windows.Forms.CheckBox chkForaDeLinha;
        private Apresentação.Formulários.Opção opçãoTodasFotos;
        private Mercadoria.TxtMercadoria txtReferência;
        private System.Windows.Forms.Panel panel1;
    }
}
