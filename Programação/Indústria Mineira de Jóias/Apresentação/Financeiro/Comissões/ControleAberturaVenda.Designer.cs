namespace Apresentação.Financeiro.Comissões
{
    partial class ControleAberturaVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControleAberturaVenda));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdicionarLançamento = new System.Windows.Forms.ToolStripButton();
            this.btnRemoverLançamento = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstVendasAbertas = new Apresentação.Financeiro.Comissões.ListaVendaComissão();
            this.lstVendasFechadas = new Apresentação.Financeiro.Comissões.ListaVendaComissão();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionarLançamento,
            this.btnRemoverLançamento});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(688, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdicionarLançamento
            // 
            this.btnAdicionarLançamento.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAdicionarLançamento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdicionarLançamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarLançamento.Image")));
            this.btnAdicionarLançamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionarLançamento.Name = "btnAdicionarLançamento";
            this.btnAdicionarLançamento.Size = new System.Drawing.Size(23, 22);
            this.btnAdicionarLançamento.Text = "Tornar fechados os lançamentos de comissão";
            this.btnAdicionarLançamento.Click += new System.EventHandler(this.btnAdicionarLançamento_Click);
            // 
            // btnRemoverLançamento
            // 
            this.btnRemoverLançamento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoverLançamento.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoverLançamento.Image")));
            this.btnRemoverLançamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoverLançamento.Name = "btnRemoverLançamento";
            this.btnRemoverLançamento.Size = new System.Drawing.Size(23, 22);
            this.btnRemoverLançamento.Text = "Tornar lançamentos de comissão em aberto.";
            this.btnRemoverLançamento.Click += new System.EventHandler(this.btnRemoverLançamento_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstVendasAbertas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstVendasFechadas);
            this.splitContainer1.Size = new System.Drawing.Size(688, 324);
            this.splitContainer1.SplitterDistance = 404;
            this.splitContainer1.TabIndex = 5;
            // 
            // lstVendasAbertas
            // 
            this.lstVendasAbertas.CorFundo = System.Drawing.SystemColors.Window;
            this.lstVendasAbertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVendasAbertas.Location = new System.Drawing.Point(0, 0);
            this.lstVendasAbertas.Name = "lstVendasAbertas";
            this.lstVendasAbertas.Size = new System.Drawing.Size(404, 324);
            this.lstVendasAbertas.TabIndex = 1;
            this.lstVendasAbertas.AoSolicitarAbrirVenda += new Apresentação.Financeiro.Comissões.Delegate.VendaDelegate(this.lstVendas_AoSolicitarAbrirVenda);
            this.lstVendasAbertas.AoSolicitarAbrirAtendimentoPessoa += new Apresentação.Financeiro.Comissões.Delegate.PessoaDelegate(this.lstVendas_AoSolicitarAbrirAtendimentoPessoa);
            this.lstVendasAbertas.AoDuploClique += new System.EventHandler(this.lstVendasAbertas_AoDuploClique);
            // 
            // lstVendasFechadas
            // 
            this.lstVendasFechadas.CorFundo = System.Drawing.Color.WhiteSmoke;
            this.lstVendasFechadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVendasFechadas.Location = new System.Drawing.Point(0, 0);
            this.lstVendasFechadas.Name = "lstVendasFechadas";
            this.lstVendasFechadas.Size = new System.Drawing.Size(280, 324);
            this.lstVendasFechadas.TabIndex = 0;
            this.lstVendasFechadas.AoSolicitarAbrirVenda += new Apresentação.Financeiro.Comissões.Delegate.VendaDelegate(this.lstVendas_AoSolicitarAbrirVenda);
            this.lstVendasFechadas.AoSolicitarAbrirAtendimentoPessoa += new Apresentação.Financeiro.Comissões.Delegate.PessoaDelegate(this.lstVendas_AoSolicitarAbrirAtendimentoPessoa);
            this.lstVendasFechadas.AoDuploClique += new System.EventHandler(this.lstVendasFechadas_AoDuploCliqueNoVazio);
            // 
            // ControleAberturaVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControleAberturaVenda";
            this.Size = new System.Drawing.Size(688, 349);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdicionarLançamento;
        private System.Windows.Forms.ToolStripButton btnRemoverLançamento;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ListaVendaComissão lstVendasAbertas;
        private ListaVendaComissão lstVendasFechadas;
    }
}
