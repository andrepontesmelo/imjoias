namespace Apresentação.Mercadoria.Manutenção.ComponentesDeCusto
{
    partial class BaseListagem
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
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.lista = new Apresentação.Mercadoria.Manutenção.ComponentesDeCusto.ListaComponentesCusto();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 387);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "As modificações são gravadas imediatamente no banco de dados ";
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.diamond;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(203, 13);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(594, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Componentes de Custo";
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
            this.quadro2.Controls.Add(this.lista);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(193, 89);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(592, 280);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Componentes cadastrados";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Location = new System.Drawing.Point(0, 23);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(592, 257);
            this.lista.TabIndex = 4;
            this.lista.ClicouAlterar += new System.EventHandler(this.lista_ClicouAlterar);
            this.lista.ClicouExcluir += new System.EventHandler(this.lista_ClicouExcluir);
            this.lista.ClicouAdicionar += new System.EventHandler(this.lista_ClicouAdicionar);
            // 
            // BaseListagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior1);
            this.Controls.Add(this.quadro2);
            this.Name = "BaseListagem";
            this.Size = new System.Drawing.Size(800, 387);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Apresentação.Formulários.Quadro quadro2;
        private ListaComponentesCusto lista;
    }
}
