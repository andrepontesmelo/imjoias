
namespace Apresenta��o.Administrativo
{
    partial class BaseAdministrativa
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseAdministrativa));
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.quadroOp��oImporta��o = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.quadroFiscalExporta��oAtacadoBR500 = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.quadroFiscalExportacaoEconnectVarejo = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.quadroExportaVenda = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.quadroOp��oBalan�o = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.quadroComiss�o = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.quadroControleEstoque = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.quadroFiscal = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 631);
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "Escolha uma tarefa administrativa.";
            this.t�tuloBaseInferior.�coneArredondado = false;
            this.t�tuloBaseInferior.Imagem = global::Apresenta��o.Resource.gravata1;
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(207, 12);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(883, 70);
            this.t�tuloBaseInferior.TabIndex = 6;
            this.t�tuloBaseInferior.T�tulo = "Administrativo";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.quadroOp��oImporta��o);
            this.flowLayoutPanel1.Controls.Add(this.quadroFiscalExporta��oAtacadoBR500);
            this.flowLayoutPanel1.Controls.Add(this.quadroFiscalExportacaoEconnectVarejo);
            this.flowLayoutPanel1.Controls.Add(this.quadroExportaVenda);
            this.flowLayoutPanel1.Controls.Add(this.quadroOp��oBalan�o);
            this.flowLayoutPanel1.Controls.Add(this.quadroComiss�o);
            this.flowLayoutPanel1.Controls.Add(this.quadroControleEstoque);
            this.flowLayoutPanel1.Controls.Add(this.quadroFiscal);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(207, 103);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(904, 495);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // quadroOp��oImporta��o
            // 
            this.quadroOp��oImporta��o.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quadroOp��oImporta��o.BackgroundImage")));
            this.quadroOp��oImporta��o.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroOp��oImporta��o.Descri��o = "Importa pre�os do sistema legado. � necess�rio indicar a pasta dos arquivos cadme" +
    "r.dbf, ccusto.dbf e gramas.dbf";
            this.quadroOp��oImporta��o.�cone = ((System.Drawing.Image)(resources.GetObject("quadroOp��oImporta��o.�cone")));
            this.quadroOp��oImporta��o.Location = new System.Drawing.Point(3, 3);
            this.quadroOp��oImporta��o.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroOp��oImporta��o.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroOp��oImporta��o.Name = "quadroOp��oImporta��o";
            this.quadroOp��oImporta��o.Size = new System.Drawing.Size(295, 70);
            this.quadroOp��oImporta��o.TabIndex = 1;
            this.quadroOp��oImporta��o.T�tulo = "Integra��o";
            this.quadroOp��oImporta��o.Click += new System.EventHandler(this.quadroOp��oImporta��o_Click);
            // 
            // quadroFiscalExporta��oAtacadoBR500
            // 
            this.quadroFiscalExporta��oAtacadoBR500.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroFiscalExporta��oAtacadoBR500.Descri��o = "Gerador de arquivos para PDV do varejo no antigo formato BR-500";
            this.quadroFiscalExporta��oAtacadoBR500.�cone = ((System.Drawing.Image)(resources.GetObject("quadroFiscalExporta��oAtacadoBR500.�cone")));
            this.quadroFiscalExporta��oAtacadoBR500.Location = new System.Drawing.Point(3, 79);
            this.quadroFiscalExporta��oAtacadoBR500.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroFiscalExporta��oAtacadoBR500.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroFiscalExporta��oAtacadoBR500.Name = "quadroFiscalExporta��oAtacadoBR500";
            this.quadroFiscalExporta��oAtacadoBR500.Size = new System.Drawing.Size(295, 70);
            this.quadroFiscalExporta��oAtacadoBR500.TabIndex = 2;
            this.quadroFiscalExporta��oAtacadoBR500.T�tulo = "PDV BR-500 - Varejo";
            this.quadroFiscalExporta��oAtacadoBR500.Click += new System.EventHandler(this.quadroFiscalExporta��oAtacadoBR500_Click);
            // 
            // quadroFiscalExportacaoEconnectVarejo
            // 
            this.quadroFiscalExportacaoEconnectVarejo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroFiscalExportacaoEconnectVarejo.Descri��o = "Gerador de arquivos para PDV de atacado no formato e-connect.";
            this.quadroFiscalExportacaoEconnectVarejo.�cone = ((System.Drawing.Image)(resources.GetObject("quadroFiscalExportacaoEconnectVarejo.�cone")));
            this.quadroFiscalExportacaoEconnectVarejo.Location = new System.Drawing.Point(3, 155);
            this.quadroFiscalExportacaoEconnectVarejo.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroFiscalExportacaoEconnectVarejo.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroFiscalExportacaoEconnectVarejo.Name = "quadroFiscalExportacaoEconnectVarejo";
            this.quadroFiscalExportacaoEconnectVarejo.Size = new System.Drawing.Size(295, 70);
            this.quadroFiscalExportacaoEconnectVarejo.TabIndex = 4;
            this.quadroFiscalExportacaoEconnectVarejo.T�tulo = "PDV e-connect - Atacado";
            this.quadroFiscalExportacaoEconnectVarejo.Click += new System.EventHandler(this.quadroFiscalExportacaoEconnectVarejo_Click);
            // 
            // quadroExportaVenda
            // 
            this.quadroExportaVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroExportaVenda.Descri��o = "Gerador de nota fiscal eletr�nica";
            this.quadroExportaVenda.�cone = ((System.Drawing.Image)(resources.GetObject("quadroExportaVenda.�cone")));
            this.quadroExportaVenda.Location = new System.Drawing.Point(3, 231);
            this.quadroExportaVenda.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroExportaVenda.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroExportaVenda.Name = "quadroExportaVenda";
            this.quadroExportaVenda.Size = new System.Drawing.Size(295, 70);
            this.quadroExportaVenda.TabIndex = 5;
            this.quadroExportaVenda.T�tulo = "Gerador NF-e";
            this.quadroExportaVenda.Click += new System.EventHandler(this.quadroExportaVenda_Click);
            // 
            // quadroOp��oBalan�o
            // 
            this.quadroOp��oBalan�o.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroOp��oBalan�o.Descri��o = "Exibe relat�rio com o resumo de mercadorias de consignado.";
            this.quadroOp��oBalan�o.�cone = ((System.Drawing.Image)(resources.GetObject("quadroOp��oBalan�o.�cone")));
            this.quadroOp��oBalan�o.Location = new System.Drawing.Point(3, 307);
            this.quadroOp��oBalan�o.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroOp��oBalan�o.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroOp��oBalan�o.Name = "quadroOp��oBalan�o";
            this.quadroOp��oBalan�o.Size = new System.Drawing.Size(295, 70);
            this.quadroOp��oBalan�o.TabIndex = 0;
            this.quadroOp��oBalan�o.T�tulo = "Balan�o";
            this.quadroOp��oBalan�o.Click += new System.EventHandler(this.quadroOp��oBalan�o_Click);
            // 
            // quadroComiss�o
            // 
            this.quadroComiss�o.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroComiss�o.Descri��o = "C�lculo de comiss�o";
            this.quadroComiss�o.�cone = global::Apresenta��o.Resource.comissao;
            this.quadroComiss�o.Location = new System.Drawing.Point(3, 383);
            this.quadroComiss�o.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroComiss�o.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroComiss�o.Name = "quadroComiss�o";
            this.quadroComiss�o.Size = new System.Drawing.Size(295, 70);
            this.quadroComiss�o.TabIndex = 3;
            this.quadroComiss�o.T�tulo = "Comiss�o";
            this.quadroComiss�o.Click += new System.EventHandler(this.quadroComiss�o_Click);
            // 
            // quadroControleEstoque
            // 
            this.quadroControleEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroControleEstoque.Descri��o = "Controle de estoque";
            this.quadroControleEstoque.�cone = ((System.Drawing.Image)(resources.GetObject("quadroControleEstoque.�cone")));
            this.quadroControleEstoque.Location = new System.Drawing.Point(304, 3);
            this.quadroControleEstoque.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroControleEstoque.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroControleEstoque.Name = "quadroControleEstoque";
            this.quadroControleEstoque.Size = new System.Drawing.Size(295, 70);
            this.quadroControleEstoque.TabIndex = 6;
            this.quadroControleEstoque.T�tulo = "Estoque";
            this.quadroControleEstoque.Click += new System.EventHandler(this.quadroControleEstoque_Click);
            // 
            // quadroFiscal
            // 
            this.quadroFiscal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroFiscal.Descri��o = "Acesso aos dados fiscais da empresa";
            this.quadroFiscal.�cone = ((System.Drawing.Image)(resources.GetObject("quadroFiscal.�cone")));
            this.quadroFiscal.Location = new System.Drawing.Point(304, 79);
            this.quadroFiscal.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroFiscal.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroFiscal.Name = "quadroFiscal";
            this.quadroFiscal.Size = new System.Drawing.Size(295, 70);
            this.quadroFiscal.TabIndex = 7;
            this.quadroFiscal.T�tulo = "Fiscal";
            this.quadroFiscal.Click += new System.EventHandler(this.quadroFiscal_Click);
            // 
            // BaseAdministrativa
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Imagem = global::Apresenta��o.Resource.gravata1;
            this.Name = "BaseAdministrativa";
            this.Size = new System.Drawing.Size(1114, 631);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Apresenta��o.Formul�rios.QuadroOp��o quadroOp��oBalan�o;
        private Apresenta��o.Formul�rios.QuadroOp��o quadroOp��oImporta��o;
        private Apresenta��o.Formul�rios.QuadroOp��o quadroFiscalExporta��oAtacadoBR500;
        private Apresenta��o.Formul�rios.QuadroOp��o quadroComiss�o;
        private Formul�rios.QuadroOp��o quadroFiscalExportacaoEconnectVarejo;
        private Formul�rios.QuadroOp��o quadroExportaVenda;
        private Formul�rios.QuadroOp��o quadroControleEstoque;
        private Formul�rios.QuadroOp��o quadroFiscal;
    }
}
