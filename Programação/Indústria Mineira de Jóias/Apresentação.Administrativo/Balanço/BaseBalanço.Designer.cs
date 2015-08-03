namespace Apresentação.Administrativo.Balanço
{
    partial class BaseBalanço
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseBalanço));
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSaídas = new System.Windows.Forms.TabPage();
            this.listaSaídas = new Apresentação.Financeiro.Saída.ListaSaídas();
            this.tabRetornos = new System.Windows.Forms.TabPage();
            this.listaRetornos = new Apresentação.Financeiro.Retorno.ListaRetornos();
            this.tabVendas = new System.Windows.Forms.TabPage();
            this.listaVendas = new Apresentação.Financeiro.Venda.ListViewVendas();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoAbrirBalanço = new Apresentação.Formulários.Opção();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoFiltrar = new Apresentação.Formulários.Opção();
            this.label1 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSaídas.SuspendLayout();
            this.tabRetornos.SuspendLayout();
            this.tabVendas.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Contabilização de mercadorias presentes em documentos relacionados. Selecione aqu" +
                "eles que serão considerados.";
            this.títuloBaseInferior1.Imagem = global::Apresentação.Administrativo.Properties.Resources.balança_pequena;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(604, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Balanço";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSaídas);
            this.tabControl1.Controls.Add(this.tabRetornos);
            this.tabControl1.Controls.Add(this.tabVendas);
            this.tabControl1.Location = new System.Drawing.Point(193, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 183);
            this.tabControl1.TabIndex = 8;
            // 
            // tabSaídas
            // 
            this.tabSaídas.Controls.Add(this.listaSaídas);
            this.tabSaídas.Location = new System.Drawing.Point(4, 22);
            this.tabSaídas.Name = "tabSaídas";
            this.tabSaídas.Padding = new System.Windows.Forms.Padding(3);
            this.tabSaídas.Size = new System.Drawing.Size(586, 157);
            this.tabSaídas.TabIndex = 0;
            this.tabSaídas.Text = "Saídas";
            this.tabSaídas.UseVisualStyleBackColor = true;
            // 
            // listaSaídas
            // 
            this.listaSaídas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaSaídas.Location = new System.Drawing.Point(0, 0);
            this.listaSaídas.Name = "listaSaídas";
            this.listaSaídas.Size = new System.Drawing.Size(586, 157);
            this.listaSaídas.TabIndex = 0;
            // 
            // tabRetornos
            // 
            this.tabRetornos.Controls.Add(this.listaRetornos);
            this.tabRetornos.Location = new System.Drawing.Point(4, 22);
            this.tabRetornos.Name = "tabRetornos";
            this.tabRetornos.Padding = new System.Windows.Forms.Padding(3);
            this.tabRetornos.Size = new System.Drawing.Size(586, 157);
            this.tabRetornos.TabIndex = 1;
            this.tabRetornos.Text = "Retornos";
            this.tabRetornos.UseVisualStyleBackColor = true;
            // 
            // listaRetornos
            // 
            this.listaRetornos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaRetornos.Location = new System.Drawing.Point(0, 0);
            this.listaRetornos.Name = "listaRetornos";
            this.listaRetornos.Size = new System.Drawing.Size(586, 157);
            this.listaRetornos.TabIndex = 0;
            // 
            // tabVendas
            // 
            this.tabVendas.Controls.Add(this.listaVendas);
            this.tabVendas.Location = new System.Drawing.Point(4, 22);
            this.tabVendas.Name = "tabVendas";
            this.tabVendas.Padding = new System.Windows.Forms.Padding(3);
            this.tabVendas.Size = new System.Drawing.Size(586, 157);
            this.tabVendas.TabIndex = 2;
            this.tabVendas.Text = "Vendas";
            this.tabVendas.UseVisualStyleBackColor = true;
            // 
            // listaVendas
            // 
            this.listaVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaVendas.Location = new System.Drawing.Point(1, 3);
            this.listaVendas.Name = "listaVendas";
            this.listaVendas.Size = new System.Drawing.Size(585, 154);
            this.listaVendas.TabIndex = 0;
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoAbrirBalanço);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 74);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Próximo passo";
            // 
            // opçãoAbrirBalanço
            // 
            this.opçãoAbrirBalanço.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrirBalanço.Descrição = "Contabilizar mercadorias";
            this.opçãoAbrirBalanço.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAbrirBalanço.Imagem")));
            this.opçãoAbrirBalanço.Location = new System.Drawing.Point(5, 50);
            this.opçãoAbrirBalanço.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAbrirBalanço.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrirBalanço.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrirBalanço.Name = "opçãoAbrirBalanço";
            this.opçãoAbrirBalanço.Size = new System.Drawing.Size(150, 24);
            this.opçãoAbrirBalanço.TabIndex = 2;
            this.opçãoAbrirBalanço.Click += new System.EventHandler(this.opção1_Click);
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoFiltrar);
            this.quadro2.Controls.Add(this.label1);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 97);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 154);
            this.quadro2.TabIndex = 2;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Filtro";
            this.quadro2.Visible = false;
            // 
            // opçãoFiltrar
            // 
            this.opçãoFiltrar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoFiltrar.Descrição = "Filtrar...";
            this.opçãoFiltrar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoFiltrar.Imagem")));
            this.opçãoFiltrar.Location = new System.Drawing.Point(10, 130);
            this.opçãoFiltrar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoFiltrar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoFiltrar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoFiltrar.Name = "opçãoFiltrar";
            this.opçãoFiltrar.Size = new System.Drawing.Size(150, 24);
            this.opçãoFiltrar.TabIndex = 3;
            this.opçãoFiltrar.Click += new System.EventHandler(this.opçãoFiltrar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 81);
            this.label1.TabIndex = 2;
            this.label1.Text = "Atualmente todos os documentos relacionados no sistema estão sendo exibidos. É po" +
                "ssível filtrar documentos relativas à pessoas específicas";
            // 
            // BaseBalanço
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior1);
            this.Controls.Add(this.tabControl1);
            this.Imagem = global::Apresentação.Administrativo.Properties.Resources.balança_pequena;
            this.Name = "BaseBalanço";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabSaídas.ResumeLayout(false);
            this.tabRetornos.ResumeLayout(false);
            this.tabVendas.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSaídas;
        private System.Windows.Forms.TabPage tabRetornos;
        private System.Windows.Forms.TabPage tabVendas;
        private Apresentação.Financeiro.Saída.ListaSaídas listaSaídas;
        private Apresentação.Financeiro.Retorno.ListaRetornos listaRetornos;
        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opçãoAbrirBalanço;
        private Apresentação.Financeiro.Venda.ListViewVendas listaVendas;
        private Apresentação.Formulários.Quadro quadro2;
        private Apresentação.Formulários.Opção opçãoFiltrar;
        private System.Windows.Forms.Label label1;
    }
}
