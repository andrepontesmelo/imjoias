namespace Apresentação.Financeiro.Acerto
{
    partial class BaseDadosAcerto
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
            this.informaçõesAcerto = new Apresentação.Financeiro.Acerto.DadosAcerto();
            this.botãoLiberarPrevisão = new System.Windows.Forms.LinkLabel();
            this.listaDocumentosAcerto = new Apresentação.Financeiro.Acerto.ListaDocumentosAcerto();
            this.quadroDocumentos = new Apresentação.Formulários.Quadro();
            this.btnCalcularDesconto = new Apresentação.Formulários.Opção();
            this.opçãoIniciarRetorno = new Apresentação.Formulários.Opção();
            this.opçãoContabilizar = new Apresentação.Formulários.Opção();
            this.painelDocumentos = new System.Windows.Forms.Panel();
            this.simulaçãoAcerto1 = new Apresentação.Financeiro.Acerto.SumárioAcerto();
            this.esquerda.SuspendLayout();
            this.informaçõesAcerto.SuspendLayout();
            this.quadroDocumentos.SuspendLayout();
            this.painelDocumentos.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.simulaçãoAcerto1);
            this.esquerda.Controls.Add(this.quadroDocumentos);
            this.esquerda.Size = new System.Drawing.Size(187, 634);
            this.esquerda.Controls.SetChildIndex(this.quadroDocumentos, 0);
            this.esquerda.Controls.SetChildIndex(this.simulaçãoAcerto1, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Acerto de mercadorias.";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.Acerto;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(203, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(578, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Nome do cliente";
            // 
            // informaçõesAcerto
            // 
            this.informaçõesAcerto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.informaçõesAcerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.informaçõesAcerto.bInfDirArredondada = true;
            this.informaçõesAcerto.bInfEsqArredondada = true;
            this.informaçõesAcerto.bSupDirArredondada = true;
            this.informaçõesAcerto.bSupEsqArredondada = true;
            this.informaçõesAcerto.Controls.Add(this.botãoLiberarPrevisão);
            this.informaçõesAcerto.Cor = System.Drawing.Color.Black;
            this.informaçõesAcerto.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.informaçõesAcerto.LetraTítulo = System.Drawing.Color.White;
            this.informaçõesAcerto.Location = new System.Drawing.Point(560, 100);
            this.informaçõesAcerto.MostrarBotãoMinMax = false;
            this.informaçõesAcerto.Name = "informaçõesAcerto";
            this.informaçõesAcerto.Size = new System.Drawing.Size(221, 249);
            this.informaçõesAcerto.TabIndex = 7;
            this.informaçõesAcerto.Tamanho = 30;
            this.informaçõesAcerto.Título = "Informações - Acerto";
            // 
            // botãoLiberarPrevisão
            // 
            this.botãoLiberarPrevisão.AutoSize = true;
            this.botãoLiberarPrevisão.Location = new System.Drawing.Point(6, 231);
            this.botãoLiberarPrevisão.Name = "botãoLiberarPrevisão";
            this.botãoLiberarPrevisão.Size = new System.Drawing.Size(46, 13);
            this.botãoLiberarPrevisão.TabIndex = 16;
            this.botãoLiberarPrevisão.TabStop = true;
            this.botãoLiberarPrevisão.Text = "Alterar...";
            this.botãoLiberarPrevisão.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.botãoLiberarPrevisão_LinkClicked);
            // 
            // listaDocumentosAcerto
            // 
            this.listaDocumentosAcerto.AcertoConsignado = null;
            this.listaDocumentosAcerto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaDocumentosAcerto.AutoScroll = true;
            this.listaDocumentosAcerto.AutoSize = true;
            this.listaDocumentosAcerto.Location = new System.Drawing.Point(0, 0);
            this.listaDocumentosAcerto.Name = "listaDocumentosAcerto";
            this.listaDocumentosAcerto.Size = new System.Drawing.Size(348, 333);
            this.listaDocumentosAcerto.TabIndex = 9;
            this.listaDocumentosAcerto.AoEscolherDocumento += new Apresentação.Financeiro.Acerto.ListaDocumentosAcertoItem.ClickDelegate(this.listaDocumentosAcerto_AoEscolherDocumento);
            // 
            // quadroDocumentos
            // 
            this.quadroDocumentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroDocumentos.bInfDirArredondada = true;
            this.quadroDocumentos.bInfEsqArredondada = true;
            this.quadroDocumentos.bSupDirArredondada = true;
            this.quadroDocumentos.bSupEsqArredondada = true;
            this.quadroDocumentos.Controls.Add(this.btnCalcularDesconto);
            this.quadroDocumentos.Controls.Add(this.opçãoIniciarRetorno);
            this.quadroDocumentos.Controls.Add(this.opçãoContabilizar);
            this.quadroDocumentos.Cor = System.Drawing.Color.Black;
            this.quadroDocumentos.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDocumentos.LetraTítulo = System.Drawing.Color.White;
            this.quadroDocumentos.Location = new System.Drawing.Point(7, 13);
            this.quadroDocumentos.MostrarBotãoMinMax = false;
            this.quadroDocumentos.Name = "quadroDocumentos";
            this.quadroDocumentos.Size = new System.Drawing.Size(160, 97);
            this.quadroDocumentos.TabIndex = 1;
            this.quadroDocumentos.Tamanho = 30;
            this.quadroDocumentos.Título = "Documentos";
            // 
            // btnCalcularDesconto
            // 
            this.btnCalcularDesconto.BackColor = System.Drawing.Color.Transparent;
            this.btnCalcularDesconto.Descrição = "Calcular desconto";
            this.btnCalcularDesconto.Imagem = global::Apresentação.Resource.CalculatorHS;
            this.btnCalcularDesconto.Location = new System.Drawing.Point(7, 70);
            this.btnCalcularDesconto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCalcularDesconto.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnCalcularDesconto.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnCalcularDesconto.Name = "btnCalcularDesconto";
            this.btnCalcularDesconto.Size = new System.Drawing.Size(150, 24);
            this.btnCalcularDesconto.TabIndex = 5;
            this.btnCalcularDesconto.Click += new System.EventHandler(this.btnCalcularDesconto_Click);
            // 
            // opçãoIniciarRetorno
            // 
            this.opçãoIniciarRetorno.BackColor = System.Drawing.Color.Transparent;
            this.opçãoIniciarRetorno.Descrição = "Iniciar retorno...";
            this.opçãoIniciarRetorno.Imagem = global::Apresentação.Resource.Retorno__Ícone_;
            this.opçãoIniciarRetorno.Location = new System.Drawing.Point(7, 30);
            this.opçãoIniciarRetorno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoIniciarRetorno.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoIniciarRetorno.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoIniciarRetorno.Name = "opçãoIniciarRetorno";
            this.opçãoIniciarRetorno.Privilégio = Entidades.Privilégio.Permissão.ConsignadoRetorno;
            this.opçãoIniciarRetorno.Size = new System.Drawing.Size(150, 16);
            this.opçãoIniciarRetorno.TabIndex = 3;
            this.opçãoIniciarRetorno.Click += new System.EventHandler(this.opçãoIniciarRetorno_Click);
            // 
            // opçãoContabilizar
            // 
            this.opçãoContabilizar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoContabilizar.Descrição = "Contabilizar mercadorias";
            this.opçãoContabilizar.Imagem = global::Apresentação.Resource.CalculatorHS;
            this.opçãoContabilizar.Location = new System.Drawing.Point(7, 50);
            this.opçãoContabilizar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoContabilizar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoContabilizar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoContabilizar.Name = "opçãoContabilizar";
            this.opçãoContabilizar.Size = new System.Drawing.Size(150, 16);
            this.opçãoContabilizar.TabIndex = 4;
            this.opçãoContabilizar.Click += new System.EventHandler(this.opçãoContabilizar_Click);
            // 
            // painelDocumentos
            // 
            this.painelDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.painelDocumentos.AutoScroll = true;
            this.painelDocumentos.Controls.Add(this.listaDocumentosAcerto);
            this.painelDocumentos.Location = new System.Drawing.Point(203, 100);
            this.painelDocumentos.Name = "painelDocumentos";
            this.painelDocumentos.Size = new System.Drawing.Size(351, 535);
            this.painelDocumentos.TabIndex = 10;
            // 
            // simulaçãoAcerto1
            // 
            this.simulaçãoAcerto1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simulaçãoAcerto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.simulaçãoAcerto1.bInfDirArredondada = true;
            this.simulaçãoAcerto1.bInfEsqArredondada = true;
            this.simulaçãoAcerto1.bSupDirArredondada = true;
            this.simulaçãoAcerto1.bSupEsqArredondada = true;
            this.simulaçãoAcerto1.Cor = System.Drawing.Color.Black;
            this.simulaçãoAcerto1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.simulaçãoAcerto1.LetraTítulo = System.Drawing.Color.White;
            this.simulaçãoAcerto1.Location = new System.Drawing.Point(7, 116);
            this.simulaçãoAcerto1.MostrarBotãoMinMax = false;
            this.simulaçãoAcerto1.Name = "simulaçãoAcerto1";
            this.simulaçãoAcerto1.Size = new System.Drawing.Size(160, 370);
            this.simulaçãoAcerto1.TabIndex = 11;
            this.simulaçãoAcerto1.Tamanho = 30;
            this.simulaçãoAcerto1.Título = "Sumário";
            // 
            // BaseDadosAcerto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior1);
            this.Controls.Add(this.painelDocumentos);
            this.Controls.Add(this.informaçõesAcerto);
            this.Name = "BaseDadosAcerto";
            this.Size = new System.Drawing.Size(800, 634);
            this.Controls.SetChildIndex(this.informaçõesAcerto, 0);
            this.Controls.SetChildIndex(this.painelDocumentos, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.informaçõesAcerto.ResumeLayout(false);
            this.informaçõesAcerto.PerformLayout();
            this.quadroDocumentos.ResumeLayout(false);
            this.painelDocumentos.ResumeLayout(false);
            this.painelDocumentos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private DadosAcerto informaçõesAcerto;
        private ListaDocumentosAcerto listaDocumentosAcerto;
        private Apresentação.Formulários.Quadro quadroDocumentos;
        private Apresentação.Formulários.Opção opçãoIniciarRetorno;
        private Apresentação.Formulários.Opção opçãoContabilizar;
        private System.Windows.Forms.Panel painelDocumentos;
        private Apresentação.Formulários.Opção btnCalcularDesconto;
        private SumárioAcerto simulaçãoAcerto1;
        private System.Windows.Forms.LinkLabel botãoLiberarPrevisão;
    }
}
