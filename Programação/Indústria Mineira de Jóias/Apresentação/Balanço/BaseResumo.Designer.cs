using Apresentação.Balanço;
namespace Apresentação.Administrativo.Balanço
{
    partial class BaseResumo
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
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.bandeja = new BandejaBalanço();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Abaixo está o resultado do agrupamento de todas as mercadorias presentes nos docu" +
                "mentos selecionados anteriormente. Quantidade = saídas - retornos - vendas";
            this.títuloBaseInferior1.Imagem = null;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(196, 16);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(604, 70);
            this.títuloBaseInferior1.TabIndex = 7;
            this.títuloBaseInferior1.Título = "Resultado do balanço. ";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora___161;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 27);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 2;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoImprimir);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 60);
            this.quadro1.TabIndex = 2;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Balanço";
            // 
            // quadro2
            // 
            this.quadro2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = false;
            this.quadro2.bInfEsqArredondada = false;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.bandeja);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(193, 92);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(591, 189);
            this.quadro2.TabIndex = 8;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Balanço é agrupado pela mercadoria";
            // 
            // bandeja
            // 
            this.bandeja.Acerto = null;
            this.bandeja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bandeja.FiltragemAcerto = true;
            this.bandeja.Location = new System.Drawing.Point(0, 23);
            this.bandeja.MostrarAgrupar = false;
            this.bandeja.MostrarBarraFerramentas = true;
            this.bandeja.MostrarExcluir = false;
            this.bandeja.MostrarPreço = false;
            this.bandeja.MostrarSeleçãoTabela = false;
            this.bandeja.MostrarStatus = true;
            this.bandeja.Name = "bandeja";
            this.bandeja.OrdenaçãoReferência = true;
            this.bandeja.PermitirExclusão = false;
            this.bandeja.PermitirSeleçãoTabela = false;
            this.bandeja.SepararPeçaPeso = true;
            this.bandeja.Size = new System.Drawing.Size(591, 166);
            this.bandeja.TabIndex = 2;
            // 
            // BaseResumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro2);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseResumo";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.Quadro quadro2;
        private BandejaBalanço bandeja;
    }
}
