namespace Apresentação.Mercadoria.Manutenção
{
    partial class BaseEdição
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEdição));
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.listaComponentesMercadoria = new Apresentação.Mercadoria.Manutenção.ComponentesDeCusto.ListaComponentesMercadoria();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opção2 = new Apresentação.Formulários.Opção();
            this.label3 = new System.Windows.Forms.Label();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.informaçõesVigentes = new Apresentação.Mercadoria.Manutenção.InformaçõesMercadoriaEdição();
            this.quadro4 = new Apresentação.Formulários.Quadro();
            this.informaçõesAlterações = new Apresentação.Mercadoria.Manutenção.InformaçõesMercadoriaEdição();
            this.esquerda.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.quadro4.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 508);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Os campos vigentes podem ser consultados na primeira aba. Na segunda, é possível " +
                "alterá-los, entrando em vigor na próxima atualização da tabela.";
            this.títuloBaseInferior1.Imagem = global::Apresentação.Mercadoria.Properties.Resources.m;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(480, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Editando 101.001.01.121-1";
            // 
            // quadro2
            // 
            this.quadro2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = false;
            this.quadro2.bInfEsqArredondada = false;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.listaComponentesMercadoria);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(495, 103);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(228, 402);
            this.quadro2.TabIndex = 8;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Componentes de Custo";
            // 
            // listaComponentesMercadoria
            // 
            this.listaComponentesMercadoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listaComponentesMercadoria.Location = new System.Drawing.Point(3, 24);
            this.listaComponentesMercadoria.Name = "listaComponentesMercadoria";
            this.listaComponentesMercadoria.Size = new System.Drawing.Size(222, 375);
            this.listaComponentesMercadoria.TabIndex = 2;
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opção2);
            this.quadro1.Controls.Add(this.label3);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 185);
            this.quadro1.TabIndex = 2;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Atualização";
            // 
            // opção2
            // 
            this.opção2.BackColor = System.Drawing.Color.Transparent;
            this.opção2.Descrição = "Atualizar agora!";
            this.opção2.Imagem = ((System.Drawing.Image)(resources.GetObject("opção2.Imagem")));
            this.opção2.Location = new System.Drawing.Point(5, 161);
            this.opção2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opção2.MaximumSize = new System.Drawing.Size(150, 100);
            this.opção2.MinimumSize = new System.Drawing.Size(150, 16);
            this.opção2.Name = "opção2";
            this.opção2.Size = new System.Drawing.Size(150, 24);
            this.opção2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 121);
            this.label3.TabIndex = 3;
            this.label3.Text = "As alterações entrarão em vigência assim que a tabela for atualizada.            " +
                "                                      No entanto, é possível atualizar as modifi" +
                "cações desta mercadoria imediatamente";
            // 
            // quadro3
            // 
            this.quadro3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.informaçõesVigentes);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(193, 103);
            this.quadro3.MostrarBotãoMinMax = true;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(296, 194);
            this.quadro3.TabIndex = 12;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Dados vigentes";
            // 
            // informaçõesVigentes
            // 
            this.informaçõesVigentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.informaçõesVigentes.Location = new System.Drawing.Point(3, 24);
            this.informaçõesVigentes.Mercadoria = null;
            this.informaçõesVigentes.Name = "informaçõesVigentes";
            this.informaçõesVigentes.Size = new System.Drawing.Size(287, 167);
            this.informaçõesVigentes.TabIndex = 11;
            this.informaçõesVigentes.Travado = true;
            // 
            // quadro4
            // 
            this.quadro4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro4.bInfDirArredondada = true;
            this.quadro4.bInfEsqArredondada = true;
            this.quadro4.bSupDirArredondada = true;
            this.quadro4.bSupEsqArredondada = true;
            this.quadro4.Controls.Add(this.informaçõesAlterações);
            this.quadro4.Cor = System.Drawing.Color.Black;
            this.quadro4.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro4.LetraTítulo = System.Drawing.Color.White;
            this.quadro4.Location = new System.Drawing.Point(192, 303);
            this.quadro4.MostrarBotãoMinMax = false;
            this.quadro4.Name = "quadro4";
            this.quadro4.Size = new System.Drawing.Size(296, 199);
            this.quadro4.TabIndex = 13;
            this.quadro4.Tamanho = 30;
            this.quadro4.Título = "Alterações...";
            // 
            // informaçõesAlterações
            // 
            this.informaçõesAlterações.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.informaçõesAlterações.Location = new System.Drawing.Point(3, 23);
            this.informaçõesAlterações.Mercadoria = null;
            this.informaçõesAlterações.Name = "informaçõesAlterações";
            this.informaçõesAlterações.Size = new System.Drawing.Size(290, 164);
            this.informaçõesAlterações.TabIndex = 11;
            this.informaçõesAlterações.Travado = false;
            // 
            // BaseEdição
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro4);
            this.Controls.Add(this.quadro3);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Controls.Add(this.quadro2);
            this.Imagem = global::Apresentação.Mercadoria.Properties.Resources.m;
            this.Name = "BaseEdição";
            this.Size = new System.Drawing.Size(726, 508);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadro3, 0);
            this.Controls.SetChildIndex(this.quadro4, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.quadro4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Apresentação.Formulários.Quadro quadro2;
        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opção2;
        private System.Windows.Forms.Label label3;
        private InformaçõesMercadoriaEdição informaçõesAlterações;
        private Apresentação.Formulários.Quadro quadro3;
        private InformaçõesMercadoriaEdição informaçõesVigentes;
        private Apresentação.Formulários.Quadro quadro4;
        private Apresentação.Mercadoria.Manutenção.ComponentesDeCusto.ListaComponentesMercadoria listaComponentesMercadoria;
    }
}
