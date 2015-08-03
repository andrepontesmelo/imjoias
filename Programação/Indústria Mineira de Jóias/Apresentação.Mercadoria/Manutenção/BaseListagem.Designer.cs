namespace Apresentação.Mercadoria.Manutenção
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
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.lista = new Apresentação.Mercadoria.Manutenção.ListaMercadorias();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.quadro4 = new Apresentação.Formulários.Quadro();
            this.chkFiltrar = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.quadroImpressão = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.quadro4.SuspendLayout();
            this.quadroImpressão.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroImpressão);
            this.esquerda.Controls.Add(this.quadro4);
            this.esquerda.Controls.Add(this.quadro3);
            this.esquerda.Size = new System.Drawing.Size(187, 444);
            this.esquerda.Controls.SetChildIndex(this.quadro3, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro4, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroImpressão, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Aqui são listadas todas as mercadorias cadastradas no banco de dados.";
            this.títuloBaseInferior1.Imagem = global::Apresentação.Mercadoria.Properties.Resources.m;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(617, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Mercadorias cadastradas.";
            // 
            // quadro1
            // 
            this.quadro1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = false;
            this.quadro1.bInfEsqArredondada = false;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.lista);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 79);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(780, 349);
            this.quadro1.TabIndex = 7;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Mercadorias Cadastradas";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Location = new System.Drawing.Point(0, 26);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(780, 323);
            this.lista.TabIndex = 2;
            this.lista.Excluir += new System.EventHandler(this.lista_Excluir);
            this.lista.Adicionar += new System.EventHandler(this.lista_Adicionar);
            this.lista.Alterar += new Apresentação.Mercadoria.Manutenção.ListaMercadorias.EventoDelegate(this.lista_Alterar);
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.label3);
            this.quadro3.Controls.Add(this.label1);
            this.quadro3.Controls.Add(this.label5);
            this.quadro3.Controls.Add(this.label2);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 19);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 133);
            this.quadro3.TabIndex = 2;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Legenda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Negrito:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Riscado:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(26, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mercadorias com alterações";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(24, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mercadorias marcadas para exclusão";
            // 
            // quadro4
            // 
            this.quadro4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro4.bInfDirArredondada = true;
            this.quadro4.bInfEsqArredondada = true;
            this.quadro4.bSupDirArredondada = true;
            this.quadro4.bSupEsqArredondada = true;
            this.quadro4.Controls.Add(this.chkFiltrar);
            this.quadro4.Controls.Add(this.label4);
            this.quadro4.Cor = System.Drawing.Color.Black;
            this.quadro4.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro4.LetraTítulo = System.Drawing.Color.White;
            this.quadro4.Location = new System.Drawing.Point(7, 158);
            this.quadro4.MostrarBotãoMinMax = false;
            this.quadro4.Name = "quadro4";
            this.quadro4.Size = new System.Drawing.Size(160, 111);
            this.quadro4.TabIndex = 3;
            this.quadro4.Tamanho = 30;
            this.quadro4.Título = "Filtro";
            // 
            // chkFiltrar
            // 
            this.chkFiltrar.AutoSize = true;
            this.chkFiltrar.BackColor = System.Drawing.Color.Transparent;
            this.chkFiltrar.Checked = true;
            this.chkFiltrar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiltrar.Location = new System.Drawing.Point(12, 93);
            this.chkFiltrar.Name = "chkFiltrar";
            this.chkFiltrar.Size = new System.Drawing.Size(93, 17);
            this.chkFiltrar.TabIndex = 2;
            this.chkFiltrar.Text = "Filtrar exibição";
            this.chkFiltrar.UseVisualStyleBackColor = false;
            this.chkFiltrar.CheckedChanged += new System.EventHandler(this.chkFiltrar_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(22, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 59);
            this.label4.TabIndex = 3;
            this.label4.Text = "Você pode filtrar a exibição de forma que as mercadorias fora de linha não sejam " +
                "mostradas";
            // 
            // quadroImpressão
            // 
            this.quadroImpressão.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroImpressão.bInfDirArredondada = true;
            this.quadroImpressão.bInfEsqArredondada = true;
            this.quadroImpressão.bSupDirArredondada = true;
            this.quadroImpressão.bSupEsqArredondada = true;
            this.quadroImpressão.Controls.Add(this.opçãoImprimir);
            this.quadroImpressão.Cor = System.Drawing.Color.Black;
            this.quadroImpressão.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroImpressão.LetraTítulo = System.Drawing.Color.White;
            this.quadroImpressão.Location = new System.Drawing.Point(4, 275);
            this.quadroImpressão.MostrarBotãoMinMax = false;
            this.quadroImpressão.Name = "quadroImpressão";
            this.quadroImpressão.Size = new System.Drawing.Size(163, 58);
            this.quadroImpressão.TabIndex = 4;
            this.quadroImpressão.Tamanho = 30;
            this.quadroImpressão.Título = "Impressão";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Mercadoria.Properties.Resources.impressora___16;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 29);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 2;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // BaseListagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior1);
            this.Controls.Add(this.quadro1);
            this.Imagem = global::Apresentação.Mercadoria.Properties.Resources.m;
            this.Name = "BaseListagem";
            this.Size = new System.Drawing.Size(988, 444);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.quadro3.PerformLayout();
            this.quadro4.ResumeLayout(false);
            this.quadro4.PerformLayout();
            this.quadroImpressão.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Quadro quadro3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ListaMercadorias lista;
        private Apresentação.Formulários.Quadro quadro4;
        private System.Windows.Forms.CheckBox chkFiltrar;
        private System.Windows.Forms.Label label4;
        private Apresentação.Formulários.Quadro quadroImpressão;
        private Apresentação.Formulários.Opção opçãoImprimir;
    }
}
