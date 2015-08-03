namespace Apresentação.Financeiro.Acerto
{
    partial class BaseAcertosPendentes
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroSeleção = new Apresentação.Formulários.Quadro();
            this.opçãoAbrir = new Apresentação.Formulários.Opção();
            this.listaAcertos = new Apresentação.Financeiro.Acerto.ListaAcertos();
            this.esquerda.SuspendLayout();
            this.quadroSeleção.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroSeleção);
            this.esquerda.Controls.SetChildIndex(this.quadroSeleção, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Os acertos futuros ou atrasados constam na lista abaixo.";
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.Dardo;
            this.títuloBaseInferior.Location = new System.Drawing.Point(209, 21);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(568, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Acertos pendentes";
            // 
            // quadroSeleção
            // 
            this.quadroSeleção.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroSeleção.bInfDirArredondada = true;
            this.quadroSeleção.bInfEsqArredondada = true;
            this.quadroSeleção.bSupDirArredondada = true;
            this.quadroSeleção.bSupEsqArredondada = true;
            this.quadroSeleção.Controls.Add(this.opçãoAbrir);
            this.quadroSeleção.Cor = System.Drawing.Color.Black;
            this.quadroSeleção.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroSeleção.LetraTítulo = System.Drawing.Color.White;
            this.quadroSeleção.Location = new System.Drawing.Point(7, 13);
            this.quadroSeleção.MostrarBotãoMinMax = false;
            this.quadroSeleção.Name = "quadroSeleção";
            this.quadroSeleção.Size = new System.Drawing.Size(160, 55);
            this.quadroSeleção.TabIndex = 1;
            this.quadroSeleção.Tamanho = 30;
            this.quadroSeleção.Título = "Acerto Selecionado";
            this.quadroSeleção.Visible = false;
            // 
            // opçãoAbrir
            // 
            this.opçãoAbrir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrir.Descrição = "Abrir";
            this.opçãoAbrir.Imagem = global::Apresentação.Resource.openfolderHS;
            this.opçãoAbrir.Location = new System.Drawing.Point(5, 30);
            this.opçãoAbrir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAbrir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrir.Name = "opçãoAbrir";
            this.opçãoAbrir.Size = new System.Drawing.Size(150, 24);
            this.opçãoAbrir.TabIndex = 2;
            this.opçãoAbrir.Click += new System.EventHandler(this.listaAcertos_DoubleClick);
            // 
            // listaAcertos
            // 
            this.listaAcertos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaAcertos.Location = new System.Drawing.Point(209, 122);
            this.listaAcertos.Name = "listaAcertos";
            this.listaAcertos.Size = new System.Drawing.Size(568, 156);
            this.listaAcertos.TabIndex = 7;
            this.listaAcertos.AoClicarDuasVezesItem += new System.EventHandler(this.listaAcertos_DoubleClick);
            this.listaAcertos.AoMudarSeleção += new System.EventHandler(this.listaAcertos_AoMudarSeleção);
            // 
            // BaseAcertosPendentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.listaAcertos);
            this.Imagem = global::Apresentação.Resource.Dardo;
            this.Name = "BaseAcertosPendentes";
            this.Privilégio = Entidades.Privilégio.Permissão.Consignado;
            this.Controls.SetChildIndex(this.listaAcertos, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroSeleção.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private ListaAcertos listaAcertos;
        private Apresentação.Formulários.Quadro quadroSeleção;
        private Apresentação.Formulários.Opção opçãoAbrir;
    }
}
