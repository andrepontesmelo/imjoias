namespace Apresentação.Financeiro.Venda
{
    partial class BaseEditarVenda
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEditarVenda));
            this.tabDevolução = new System.Windows.Forms.TabPage();
            this.digitaçãoDevolução = new Apresentação.Financeiro.Venda.DigitaçãoVenda();
            this.tabPagamentos = new System.Windows.Forms.TabPage();
            this.listaPagamentos = new Apresentação.Financeiro.Pagamento.ListaPagamento();
            this.tabVenda = new System.Windows.Forms.TabPage();
            this.dadosVenda = new Apresentação.Financeiro.Venda.DadosVenda();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.quadroPagamento = new Apresentação.Formulários.Quadro();
            this.opçãoFormaPagamento = new Apresentação.Formulários.Opção();
            this.tabDébitos = new System.Windows.Forms.TabPage();
            this.listaDébitos = new Apresentação.Financeiro.Venda.ListaDébitos();
            this.listaCréditos = new Apresentação.Financeiro.Venda.ListaCréditos();
            this.tabCréditos = new System.Windows.Forms.TabPage();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoGastarCréditosCliente = new Apresentação.Formulários.Opção();
            this.opçãoCobrançaAutomática = new Apresentação.Formulários.Opção();
            this.tabs.SuspendLayout();
            this.tabItens.SuspendLayout();
            this.quadroDestravar.SuspendLayout();
            this.tabObservações.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.tabDevolução.SuspendLayout();
            this.tabPagamentos.SuspendLayout();
            this.tabVenda.SuspendLayout();
            this.quadroPagamento.SuspendLayout();
            this.tabDébitos.SuspendLayout();
            this.tabCréditos.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Location = new System.Drawing.Point(199, -5);
            this.título.Size = new System.Drawing.Size(494, 70);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabVenda);
            this.tabs.Controls.Add(this.tabDébitos);
            this.tabs.Controls.Add(this.tabCréditos);
            this.tabs.Controls.Add(this.tabDevolução);
            this.tabs.Controls.Add(this.tabPagamentos);
            this.tabs.ImageList = this.imageList1;
            this.tabs.Location = new System.Drawing.Point(193, 71);
            this.tabs.Size = new System.Drawing.Size(500, 480);
            this.tabs.Controls.SetChildIndex(this.tabObservações, 0);
            this.tabs.Controls.SetChildIndex(this.tabPagamentos, 0);
            this.tabs.Controls.SetChildIndex(this.tabDevolução, 0);
            this.tabs.Controls.SetChildIndex(this.tabCréditos, 0);
            this.tabs.Controls.SetChildIndex(this.tabDébitos, 0);
            this.tabs.Controls.SetChildIndex(this.tabVenda, 0);
            this.tabs.Controls.SetChildIndex(this.tabItens, 0);
            // 
            // tabItens
            // 
            this.tabItens.ImageIndex = 2;
            this.tabItens.Location = new System.Drawing.Point(4, 23);
            this.tabItens.Size = new System.Drawing.Size(492, 453);
            this.tabItens.Text = "(+) Itens";
            // 
            // opçãoDestravar
            // 
            this.opçãoDestravar.Privilégio = Entidades.Privilégio.Permissão.VendasDestravar;
            this.quadroDestravar.Controls.SetChildIndex(this.opçãoDestravar, 0);
            // 
            // digitação
            // 
            this.digitação.Size = new System.Drawing.Size(486, 447);
            // 
            // tabObservações
            // 
            this.tabObservações.Location = new System.Drawing.Point(4, 23);
            this.tabObservações.Size = new System.Drawing.Size(492, 453);
            // 
            // txtObservação
            // 
            this.txtObservação.Size = new System.Drawing.Size(486, 447);
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadroPagamento);
            this.esquerda.Size = new System.Drawing.Size(187, 564);
            this.esquerda.Controls.SetChildIndex(this.quadroPagamento, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroDestravar, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            // 
            // tabDevolução
            // 
            this.tabDevolução.Controls.Add(this.digitaçãoDevolução);
            this.tabDevolução.ImageIndex = 3;
            this.tabDevolução.Location = new System.Drawing.Point(4, 22);
            this.tabDevolução.Name = "tabDevolução";
            this.tabDevolução.Size = new System.Drawing.Size(582, 548);
            this.tabDevolução.TabIndex = 1;
            this.tabDevolução.Text = "(-) Devolução";
            this.tabDevolução.UseVisualStyleBackColor = true;
            // 
            // digitaçãoDevolução
            // 
            this.digitaçãoDevolução.BackColor = System.Drawing.Color.Transparent;
            this.digitaçãoDevolução.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digitaçãoDevolução.Location = new System.Drawing.Point(0, 0);
            this.digitaçãoDevolução.MinimumSize = new System.Drawing.Size(350, 300);
            this.digitaçãoDevolução.MostrarPreço = true;
            this.digitaçãoDevolução.Name = "digitaçãoDevolução";
            this.digitaçãoDevolução.PermitirSeleçãoTabela = false;
            this.digitaçãoDevolução.Size = new System.Drawing.Size(582, 548);
            this.digitaçãoDevolução.TabIndex = 0;
            this.digitaçãoDevolução.TipoExibiçãoAtual = Apresentação.Financeiro.DigitaçãoComum.TipoExibição.TipoAgrupado;
            // 
            // tabPagamentos
            // 
            this.tabPagamentos.Controls.Add(this.listaPagamentos);
            this.tabPagamentos.ImageIndex = 0;
            this.tabPagamentos.Location = new System.Drawing.Point(4, 23);
            this.tabPagamentos.Name = "tabPagamentos";
            this.tabPagamentos.Size = new System.Drawing.Size(492, 453);
            this.tabPagamentos.TabIndex = 2;
            this.tabPagamentos.Text = "(-) Pagamentos";
            this.tabPagamentos.UseVisualStyleBackColor = true;
            // 
            // listaPagamentos
            // 
            this.listaPagamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaPagamentos.BackColor = System.Drawing.Color.Transparent;
            this.listaPagamentos.Location = new System.Drawing.Point(3, 3);
            this.listaPagamentos.MostrarToolStrip = true;
            this.listaPagamentos.Name = "listaPagamentos";
            this.listaPagamentos.Size = new System.Drawing.Size(486, 447);
            this.listaPagamentos.TabIndex = 0;
            // 
            // tabVenda
            // 
            this.tabVenda.Controls.Add(this.dadosVenda);
            this.tabVenda.ImageIndex = 1;
            this.tabVenda.Location = new System.Drawing.Point(4, 22);
            this.tabVenda.Name = "tabVenda";
            this.tabVenda.Size = new System.Drawing.Size(582, 548);
            this.tabVenda.TabIndex = 3;
            this.tabVenda.Text = "Dados da venda";
            this.tabVenda.UseVisualStyleBackColor = true;
            // 
            // dadosVenda
            // 
            this.dadosVenda.AutoScroll = true;
            this.dadosVenda.BackColor = System.Drawing.Color.Transparent;
            this.dadosVenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dadosVenda.Location = new System.Drawing.Point(0, 0);
            this.dadosVenda.Name = "dadosVenda";
            this.dadosVenda.Size = new System.Drawing.Size(582, 548);
            this.dadosVenda.TabIndex = 0;
            this.dadosVenda.AoAlterarVendedor += new System.EventHandler(this.dadosVenda_AoAlterarVendedor);
            this.dadosVenda.AoAlterarCliente += new System.EventHandler(this.dadosVenda_AoAlterarCliente);
            this.dadosVenda.CotaçãoAlterada += new Apresentação.Financeiro.Venda.DadosVenda.CotaçãoAlteradaDelegate(this.dadosVenda_CotaçãoAlterada);
            this.dadosVenda.AoAlterarAcerto += new System.EventHandler(this.dadosVenda_AoAlterarAcerto);
            this.dadosVenda.AoAlterarDataVenda += new System.EventHandler(this.dadosVenda_AoAlterarDataVenda);
            this.dadosVenda.AoAlterarDiasSemJurosOuTaxaJuros += new System.EventHandler(this.dadosVenda_AoAlterarDiasSemJuros);
            this.dadosVenda.AoAlterarTabela += new System.EventHandler(this.dadosVenda_AoAlterarTabela);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "moedaunica.gif");
            this.imageList1.Images.SetKeyName(1, "ShowRulelinesHS.bmp");
            this.imageList1.Images.SetKeyName(2, "Flag_greenHS.png");
            this.imageList1.Images.SetKeyName(3, "Flag_redHS.png");
            this.imageList1.Images.SetKeyName(4, "Flag_blueHS.png");
            // 
            // quadroPagamento
            // 
            this.quadroPagamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPagamento.bInfDirArredondada = true;
            this.quadroPagamento.bInfEsqArredondada = true;
            this.quadroPagamento.bSupDirArredondada = true;
            this.quadroPagamento.bSupEsqArredondada = true;
            this.quadroPagamento.Controls.Add(this.opçãoFormaPagamento);
            this.quadroPagamento.Cor = System.Drawing.Color.Black;
            this.quadroPagamento.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPagamento.LetraTítulo = System.Drawing.Color.White;
            this.quadroPagamento.Location = new System.Drawing.Point(7, 407);
            this.quadroPagamento.MostrarBotãoMinMax = false;
            this.quadroPagamento.Name = "quadroPagamento";
            this.quadroPagamento.Size = new System.Drawing.Size(160, 59);
            this.quadroPagamento.TabIndex = 6;
            this.quadroPagamento.Tamanho = 30;
            this.quadroPagamento.Título = "Pagamento";
            // 
            // opçãoFormaPagamento
            // 
            this.opçãoFormaPagamento.BackColor = System.Drawing.Color.Transparent;
            this.opçãoFormaPagamento.Descrição = "Escolher forma de pagamento...";
            this.opçãoFormaPagamento.Imagem = global::Apresentação.Financeiro.Properties.Resources.moedaunica;
            this.opçãoFormaPagamento.Location = new System.Drawing.Point(5, 29);
            this.opçãoFormaPagamento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoFormaPagamento.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoFormaPagamento.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoFormaPagamento.Name = "opçãoFormaPagamento";
            this.opçãoFormaPagamento.Size = new System.Drawing.Size(150, 30);
            this.opçãoFormaPagamento.TabIndex = 2;
            this.opçãoFormaPagamento.Click += new System.EventHandler(this.opçãoFormaPagamento_Click);
            // 
            // tabDébitos
            // 
            this.tabDébitos.Controls.Add(this.listaDébitos);
            this.tabDébitos.ImageIndex = 4;
            this.tabDébitos.Location = new System.Drawing.Point(4, 22);
            this.tabDébitos.Name = "tabDébitos";
            this.tabDébitos.Size = new System.Drawing.Size(582, 548);
            this.tabDébitos.TabIndex = 4;
            this.tabDébitos.Text = "(+) Débitos";
            this.tabDébitos.UseVisualStyleBackColor = true;
            // 
            // listaDébitos
            // 
            this.listaDébitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaDébitos.Location = new System.Drawing.Point(0, 0);
            this.listaDébitos.Name = "listaDébitos";
            this.listaDébitos.Size = new System.Drawing.Size(582, 548);
            this.listaDébitos.TabIndex = 0;
            // 
            // listaCréditos
            // 
            this.listaCréditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaCréditos.Location = new System.Drawing.Point(0, 0);
            this.listaCréditos.Name = "listaCréditos";
            this.listaCréditos.Size = new System.Drawing.Size(582, 548);
            this.listaCréditos.TabIndex = 0;
            // 
            // tabCréditos
            // 
            this.tabCréditos.Controls.Add(this.listaCréditos);
            this.tabCréditos.ImageIndex = 4;
            this.tabCréditos.Location = new System.Drawing.Point(4, 22);
            this.tabCréditos.Name = "tabCréditos";
            this.tabCréditos.Size = new System.Drawing.Size(582, 548);
            this.tabCréditos.TabIndex = 5;
            this.tabCréditos.Text = "(-) Créditos";
            this.tabCréditos.UseVisualStyleBackColor = true;
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoGastarCréditosCliente);
            this.quadro2.Controls.Add(this.opçãoCobrançaAutomática);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 472);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 92);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Cobrança";
            // 
            // opçãoGastarCréditosCliente
            // 
            this.opçãoGastarCréditosCliente.BackColor = System.Drawing.Color.Transparent;
            this.opçãoGastarCréditosCliente.Descrição = "Gastar créditos do cliente nesta venda";
            this.opçãoGastarCréditosCliente.Imagem = global::Apresentação.Financeiro.Properties.Resources.moedaunica;
            this.opçãoGastarCréditosCliente.Location = new System.Drawing.Point(5, 62);
            this.opçãoGastarCréditosCliente.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoGastarCréditosCliente.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoGastarCréditosCliente.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoGastarCréditosCliente.Name = "opçãoGastarCréditosCliente";
            this.opçãoGastarCréditosCliente.Size = new System.Drawing.Size(150, 30);
            this.opçãoGastarCréditosCliente.TabIndex = 3;
            this.opçãoGastarCréditosCliente.Click += new System.EventHandler(this.opçãoGastarCréditosCliente_Click);
            // 
            // opçãoCobrançaAutomática
            // 
            this.opçãoCobrançaAutomática.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCobrançaAutomática.Descrição = "Cobrar pagamentos pendentes como débitos";
            this.opçãoCobrançaAutomática.Imagem = global::Apresentação.Financeiro.Properties.Resources.moedaunica;
            this.opçãoCobrançaAutomática.Location = new System.Drawing.Point(5, 31);
            this.opçãoCobrançaAutomática.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCobrançaAutomática.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCobrançaAutomática.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCobrançaAutomática.Name = "opçãoCobrançaAutomática";
            this.opçãoCobrançaAutomática.Size = new System.Drawing.Size(150, 30);
            this.opçãoCobrançaAutomática.TabIndex = 2;
            this.opçãoCobrançaAutomática.Click += new System.EventHandler(this.opçãoCobrançaAutomática_Click);
            // 
            // BaseEditarVenda
            // 
            this.Name = "BaseEditarVenda";
            this.Size = new System.Drawing.Size(710, 564);
            this.tabs.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.quadroDestravar.ResumeLayout(false);
            this.tabObservações.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.tabDevolução.ResumeLayout(false);
            this.tabPagamentos.ResumeLayout(false);
            this.tabVenda.ResumeLayout(false);
            this.quadroPagamento.ResumeLayout(false);
            this.tabDébitos.ResumeLayout(false);
            this.tabCréditos.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.TabPage tabDevolução;
        private DigitaçãoVenda digitaçãoDevolução;
        private System.Windows.Forms.TabPage tabVenda;
        private System.Windows.Forms.TabPage tabPagamentos;
        private System.Windows.Forms.ImageList imageList1;
        private DadosVenda dadosVenda;
        private Apresentação.Financeiro.Pagamento.ListaPagamento listaPagamentos;
        private Apresentação.Formulários.Quadro quadroPagamento;
        private Apresentação.Formulários.Opção opçãoFormaPagamento;
        private System.Windows.Forms.TabPage tabDébitos;
        private System.Windows.Forms.TabPage tabCréditos;
        private ListaDébitos listaDébitos;
        private ListaCréditos listaCréditos;
        private Apresentação.Formulários.Quadro quadro2;
        private Apresentação.Formulários.Opção opçãoCobrançaAutomática;
        private Apresentação.Formulários.Opção opçãoGastarCréditosCliente;
    }
}
