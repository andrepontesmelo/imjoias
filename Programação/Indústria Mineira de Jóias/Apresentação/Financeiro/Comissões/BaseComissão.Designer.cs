namespace Apresentação.Financeiro.Comissões
{
    partial class BaseComissão
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
            this.quadro = new Apresentação.Formulários.Quadro();
            this.listaComissões = new Apresentação.Financeiro.Comissões.ListaComissões();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.opçãoEditar = new Apresentação.Formulários.Opção();
            this.opçãoAbrir = new Apresentação.Formulários.Opção();
            this.opçãoNova = new Apresentação.Formulários.Opção();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.opçãoVendasSemComissão = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro3);
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 439);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro3, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.giveMoney;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(593, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Cálculo de comissão";
            // 
            // quadro
            // 
            this.quadro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro.bInfDirArredondada = false;
            this.quadro.bInfEsqArredondada = false;
            this.quadro.bSupDirArredondada = true;
            this.quadro.bSupEsqArredondada = true;
            this.quadro.Controls.Add(this.listaComissões);
            this.quadro.Cor = System.Drawing.Color.Black;
            this.quadro.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro.LetraTítulo = System.Drawing.Color.White;
            this.quadro.Location = new System.Drawing.Point(193, 79);
            this.quadro.MostrarBotãoMinMax = false;
            this.quadro.Name = "quadro";
            this.quadro.Size = new System.Drawing.Size(593, 357);
            this.quadro.TabIndex = 8;
            this.quadro.Tamanho = 30;
            this.quadro.Título = "Relatórios de Comissão";
            // 
            // listaComissões
            // 
            this.listaComissões.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaComissões.Location = new System.Drawing.Point(0, 24);
            this.listaComissões.Name = "listaComissões";
            this.listaComissões.Size = new System.Drawing.Size(593, 333);
            this.listaComissões.TabIndex = 2;
            this.listaComissões.DuploClique += new System.EventHandler(this.listaComissões_DuploClique);
            this.listaComissões.AoPressionar += new Apresentação.Financeiro.Comissões.ListaComissões.TeclaDelegate(this.listaComissões_AoPressionar);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoExcluir);
            this.quadro1.Controls.Add(this.opçãoEditar);
            this.quadro1.Controls.Add(this.opçãoAbrir);
            this.quadro1.Controls.Add(this.opçãoNova);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 115);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Comissão";
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoExcluir.Location = new System.Drawing.Point(7, 90);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.TabIndex = 5;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // opçãoEditar
            // 
            this.opçãoEditar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEditar.Descrição = "Editar";
            this.opçãoEditar.Imagem = global::Apresentação.Resource.arrow_switch;
            this.opçãoEditar.Location = new System.Drawing.Point(7, 70);
            this.opçãoEditar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEditar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEditar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEditar.Name = "opçãoEditar";
            this.opçãoEditar.Size = new System.Drawing.Size(150, 16);
            this.opçãoEditar.TabIndex = 4;
            this.opçãoEditar.Click += new System.EventHandler(this.opçãoAlterarEstado_Click);
            // 
            // opçãoAbrir
            // 
            this.opçãoAbrir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrir.Descrição = "Abrir";
            this.opçãoAbrir.Imagem = global::Apresentação.Resource.openfolderHS1;
            this.opçãoAbrir.Location = new System.Drawing.Point(7, 50);
            this.opçãoAbrir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAbrir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrir.Name = "opçãoAbrir";
            this.opçãoAbrir.Size = new System.Drawing.Size(150, 16);
            this.opçãoAbrir.TabIndex = 3;
            this.opçãoAbrir.Click += new System.EventHandler(this.opçãoAbrir_Click);
            // 
            // opçãoNova
            // 
            this.opçãoNova.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNova.Descrição = "Nova";
            this.opçãoNova.ForeColor = System.Drawing.Color.Thistle;
            this.opçãoNova.Imagem = global::Apresentação.Resource.novo;
            this.opçãoNova.Location = new System.Drawing.Point(7, 30);
            this.opçãoNova.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNova.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNova.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNova.Name = "opçãoNova";
            this.opçãoNova.Size = new System.Drawing.Size(150, 16);
            this.opçãoNova.TabIndex = 2;
            this.opçãoNova.Click += new System.EventHandler(this.opçãoNova_Click);
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoImprimir);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 134);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 53);
            this.quadro2.TabIndex = 2;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Impressão";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora___163;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 30);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 17);
            this.opçãoImprimir.TabIndex = 6;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.opçãoVendasSemComissão);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 193);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 55);
            this.quadro3.TabIndex = 3;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Vendas sem comissão";
            // 
            // opçãoVendasSemComissão
            // 
            this.opçãoVendasSemComissão.BackColor = System.Drawing.Color.Transparent;
            this.opçãoVendasSemComissão.Descrição = "Vendas sem comissão";
            this.opçãoVendasSemComissão.Imagem = global::Apresentação.Resource.ImportXMLHS1;
            this.opçãoVendasSemComissão.Location = new System.Drawing.Point(7, 30);
            this.opçãoVendasSemComissão.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVendasSemComissão.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVendasSemComissão.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVendasSemComissão.Name = "opçãoVendasSemComissão";
            this.opçãoVendasSemComissão.Size = new System.Drawing.Size(150, 24);
            this.opçãoVendasSemComissão.TabIndex = 6;
            this.opçãoVendasSemComissão.Click += new System.EventHandler(this.opçãoVendasSemComissão_Click);
            // 
            // BaseComissão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.quadro);
            this.Name = "BaseComissão";
            this.Privilégio = Entidades.Privilégio.Permissão.ManipularComissão;
            this.Size = new System.Drawing.Size(800, 439);
            this.Controls.SetChildIndex(this.quadro, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadro;
        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opçãoNova;
        private Formulários.Quadro quadro2;
        private Formulários.Opção opçãoImprimir;
        private Formulários.Opção opçãoExcluir;
        private Formulários.Opção opçãoEditar;
        private Formulários.Opção opçãoAbrir;
        private ListaComissões listaComissões;
        private Formulários.Quadro quadro3;
        private Formulários.Opção opçãoVendasSemComissão;
    }
}
