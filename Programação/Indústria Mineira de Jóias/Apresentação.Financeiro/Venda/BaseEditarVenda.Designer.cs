namespace Apresenta��o.Financeiro.Venda
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
            this.tabDevolu��o = new System.Windows.Forms.TabPage();
            this.digita��oDevolu��o = new Apresenta��o.Financeiro.Venda.Digita��oVenda();
            this.tabPagamentos = new System.Windows.Forms.TabPage();
            this.listaPagamentos = new Apresenta��o.Financeiro.Pagamento.ListaPagamento();
            this.tabVenda = new System.Windows.Forms.TabPage();
            this.dadosVenda = new Apresenta��o.Financeiro.Venda.DadosVenda();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.quadroPagamento = new Apresenta��o.Formul�rios.Quadro();
            this.op��oFormaPagamento = new Apresenta��o.Formul�rios.Op��o();
            this.tabD�bitos = new System.Windows.Forms.TabPage();
            this.listaD�bitos = new Apresenta��o.Financeiro.Venda.ListaD�bitos();
            this.listaCr�ditos = new Apresenta��o.Financeiro.Venda.ListaCr�ditos();
            this.tabCr�ditos = new System.Windows.Forms.TabPage();
            this.quadro2 = new Apresenta��o.Formul�rios.Quadro();
            this.op��oGastarCr�ditosCliente = new Apresenta��o.Formul�rios.Op��o();
            this.op��oCobran�aAutom�tica = new Apresenta��o.Formul�rios.Op��o();
            this.tabs.SuspendLayout();
            this.tabItens.SuspendLayout();
            this.quadroDestravar.SuspendLayout();
            this.tabObserva��es.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.tabDevolu��o.SuspendLayout();
            this.tabPagamentos.SuspendLayout();
            this.tabVenda.SuspendLayout();
            this.quadroPagamento.SuspendLayout();
            this.tabD�bitos.SuspendLayout();
            this.tabCr�ditos.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // t�tulo
            // 
            this.t�tulo.Location = new System.Drawing.Point(199, -5);
            this.t�tulo.Size = new System.Drawing.Size(494, 70);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabVenda);
            this.tabs.Controls.Add(this.tabD�bitos);
            this.tabs.Controls.Add(this.tabCr�ditos);
            this.tabs.Controls.Add(this.tabDevolu��o);
            this.tabs.Controls.Add(this.tabPagamentos);
            this.tabs.ImageList = this.imageList1;
            this.tabs.Location = new System.Drawing.Point(193, 71);
            this.tabs.Size = new System.Drawing.Size(500, 480);
            this.tabs.Controls.SetChildIndex(this.tabObserva��es, 0);
            this.tabs.Controls.SetChildIndex(this.tabPagamentos, 0);
            this.tabs.Controls.SetChildIndex(this.tabDevolu��o, 0);
            this.tabs.Controls.SetChildIndex(this.tabCr�ditos, 0);
            this.tabs.Controls.SetChildIndex(this.tabD�bitos, 0);
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
            // op��oDestravar
            // 
            this.op��oDestravar.Privil�gio = Entidades.Privil�gio.Permiss�o.VendasDestravar;
            this.quadroDestravar.Controls.SetChildIndex(this.op��oDestravar, 0);
            // 
            // digita��o
            // 
            this.digita��o.Size = new System.Drawing.Size(486, 447);
            // 
            // tabObserva��es
            // 
            this.tabObserva��es.Location = new System.Drawing.Point(4, 23);
            this.tabObserva��es.Size = new System.Drawing.Size(492, 453);
            // 
            // txtObserva��o
            // 
            this.txtObserva��o.Size = new System.Drawing.Size(486, 447);
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
            // tabDevolu��o
            // 
            this.tabDevolu��o.Controls.Add(this.digita��oDevolu��o);
            this.tabDevolu��o.ImageIndex = 3;
            this.tabDevolu��o.Location = new System.Drawing.Point(4, 22);
            this.tabDevolu��o.Name = "tabDevolu��o";
            this.tabDevolu��o.Size = new System.Drawing.Size(582, 548);
            this.tabDevolu��o.TabIndex = 1;
            this.tabDevolu��o.Text = "(-) Devolu��o";
            this.tabDevolu��o.UseVisualStyleBackColor = true;
            // 
            // digita��oDevolu��o
            // 
            this.digita��oDevolu��o.BackColor = System.Drawing.Color.Transparent;
            this.digita��oDevolu��o.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digita��oDevolu��o.Location = new System.Drawing.Point(0, 0);
            this.digita��oDevolu��o.MinimumSize = new System.Drawing.Size(350, 300);
            this.digita��oDevolu��o.MostrarPre�o = true;
            this.digita��oDevolu��o.Name = "digita��oDevolu��o";
            this.digita��oDevolu��o.PermitirSele��oTabela = false;
            this.digita��oDevolu��o.Size = new System.Drawing.Size(582, 548);
            this.digita��oDevolu��o.TabIndex = 0;
            this.digita��oDevolu��o.TipoExibi��oAtual = Apresenta��o.Financeiro.Digita��oComum.TipoExibi��o.TipoAgrupado;
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
            this.dadosVenda.Cota��oAlterada += new Apresenta��o.Financeiro.Venda.DadosVenda.Cota��oAlteradaDelegate(this.dadosVenda_Cota��oAlterada);
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
            this.quadroPagamento.Controls.Add(this.op��oFormaPagamento);
            this.quadroPagamento.Cor = System.Drawing.Color.Black;
            this.quadroPagamento.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPagamento.LetraT�tulo = System.Drawing.Color.White;
            this.quadroPagamento.Location = new System.Drawing.Point(7, 407);
            this.quadroPagamento.MostrarBot�oMinMax = false;
            this.quadroPagamento.Name = "quadroPagamento";
            this.quadroPagamento.Size = new System.Drawing.Size(160, 59);
            this.quadroPagamento.TabIndex = 6;
            this.quadroPagamento.Tamanho = 30;
            this.quadroPagamento.T�tulo = "Pagamento";
            // 
            // op��oFormaPagamento
            // 
            this.op��oFormaPagamento.BackColor = System.Drawing.Color.Transparent;
            this.op��oFormaPagamento.Descri��o = "Escolher forma de pagamento...";
            this.op��oFormaPagamento.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.moedaunica;
            this.op��oFormaPagamento.Location = new System.Drawing.Point(5, 29);
            this.op��oFormaPagamento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oFormaPagamento.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oFormaPagamento.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oFormaPagamento.Name = "op��oFormaPagamento";
            this.op��oFormaPagamento.Size = new System.Drawing.Size(150, 30);
            this.op��oFormaPagamento.TabIndex = 2;
            this.op��oFormaPagamento.Click += new System.EventHandler(this.op��oFormaPagamento_Click);
            // 
            // tabD�bitos
            // 
            this.tabD�bitos.Controls.Add(this.listaD�bitos);
            this.tabD�bitos.ImageIndex = 4;
            this.tabD�bitos.Location = new System.Drawing.Point(4, 22);
            this.tabD�bitos.Name = "tabD�bitos";
            this.tabD�bitos.Size = new System.Drawing.Size(582, 548);
            this.tabD�bitos.TabIndex = 4;
            this.tabD�bitos.Text = "(+) D�bitos";
            this.tabD�bitos.UseVisualStyleBackColor = true;
            // 
            // listaD�bitos
            // 
            this.listaD�bitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaD�bitos.Location = new System.Drawing.Point(0, 0);
            this.listaD�bitos.Name = "listaD�bitos";
            this.listaD�bitos.Size = new System.Drawing.Size(582, 548);
            this.listaD�bitos.TabIndex = 0;
            // 
            // listaCr�ditos
            // 
            this.listaCr�ditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaCr�ditos.Location = new System.Drawing.Point(0, 0);
            this.listaCr�ditos.Name = "listaCr�ditos";
            this.listaCr�ditos.Size = new System.Drawing.Size(582, 548);
            this.listaCr�ditos.TabIndex = 0;
            // 
            // tabCr�ditos
            // 
            this.tabCr�ditos.Controls.Add(this.listaCr�ditos);
            this.tabCr�ditos.ImageIndex = 4;
            this.tabCr�ditos.Location = new System.Drawing.Point(4, 22);
            this.tabCr�ditos.Name = "tabCr�ditos";
            this.tabCr�ditos.Size = new System.Drawing.Size(582, 548);
            this.tabCr�ditos.TabIndex = 5;
            this.tabCr�ditos.Text = "(-) Cr�ditos";
            this.tabCr�ditos.UseVisualStyleBackColor = true;
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.op��oGastarCr�ditosCliente);
            this.quadro2.Controls.Add(this.op��oCobran�aAutom�tica);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraT�tulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 472);
            this.quadro2.MostrarBot�oMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 92);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.T�tulo = "Cobran�a";
            // 
            // op��oGastarCr�ditosCliente
            // 
            this.op��oGastarCr�ditosCliente.BackColor = System.Drawing.Color.Transparent;
            this.op��oGastarCr�ditosCliente.Descri��o = "Gastar cr�ditos do cliente nesta venda";
            this.op��oGastarCr�ditosCliente.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.moedaunica;
            this.op��oGastarCr�ditosCliente.Location = new System.Drawing.Point(5, 62);
            this.op��oGastarCr�ditosCliente.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oGastarCr�ditosCliente.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oGastarCr�ditosCliente.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oGastarCr�ditosCliente.Name = "op��oGastarCr�ditosCliente";
            this.op��oGastarCr�ditosCliente.Size = new System.Drawing.Size(150, 30);
            this.op��oGastarCr�ditosCliente.TabIndex = 3;
            this.op��oGastarCr�ditosCliente.Click += new System.EventHandler(this.op��oGastarCr�ditosCliente_Click);
            // 
            // op��oCobran�aAutom�tica
            // 
            this.op��oCobran�aAutom�tica.BackColor = System.Drawing.Color.Transparent;
            this.op��oCobran�aAutom�tica.Descri��o = "Cobrar pagamentos pendentes como d�bitos";
            this.op��oCobran�aAutom�tica.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.moedaunica;
            this.op��oCobran�aAutom�tica.Location = new System.Drawing.Point(5, 31);
            this.op��oCobran�aAutom�tica.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oCobran�aAutom�tica.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oCobran�aAutom�tica.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oCobran�aAutom�tica.Name = "op��oCobran�aAutom�tica";
            this.op��oCobran�aAutom�tica.Size = new System.Drawing.Size(150, 30);
            this.op��oCobran�aAutom�tica.TabIndex = 2;
            this.op��oCobran�aAutom�tica.Click += new System.EventHandler(this.op��oCobran�aAutom�tica_Click);
            // 
            // BaseEditarVenda
            // 
            this.Name = "BaseEditarVenda";
            this.Size = new System.Drawing.Size(710, 564);
            this.tabs.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.quadroDestravar.ResumeLayout(false);
            this.tabObserva��es.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.tabDevolu��o.ResumeLayout(false);
            this.tabPagamentos.ResumeLayout(false);
            this.tabVenda.ResumeLayout(false);
            this.quadroPagamento.ResumeLayout(false);
            this.tabD�bitos.ResumeLayout(false);
            this.tabCr�ditos.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.TabPage tabDevolu��o;
        private Digita��oVenda digita��oDevolu��o;
        private System.Windows.Forms.TabPage tabVenda;
        private System.Windows.Forms.TabPage tabPagamentos;
        private System.Windows.Forms.ImageList imageList1;
        private DadosVenda dadosVenda;
        private Apresenta��o.Financeiro.Pagamento.ListaPagamento listaPagamentos;
        private Apresenta��o.Formul�rios.Quadro quadroPagamento;
        private Apresenta��o.Formul�rios.Op��o op��oFormaPagamento;
        private System.Windows.Forms.TabPage tabD�bitos;
        private System.Windows.Forms.TabPage tabCr�ditos;
        private ListaD�bitos listaD�bitos;
        private ListaCr�ditos listaCr�ditos;
        private Apresenta��o.Formul�rios.Quadro quadro2;
        private Apresenta��o.Formul�rios.Op��o op��oCobran�aAutom�tica;
        private Apresenta��o.Formul�rios.Op��o op��oGastarCr�ditosCliente;
    }
}
