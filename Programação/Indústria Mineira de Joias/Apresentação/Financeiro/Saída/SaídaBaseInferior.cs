using Apresenta��o.Formul�rios;
using Apresenta��o.Impress�o.Relat�rios.Sa�da;
using Entidades.Configura��o;
using Entidades.Pessoa;
using Entidades.Privil�gio;
using System;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Sa�da
{
    /// <summary>
    /// Controle para relacionar mercadoria de uma de sa�da.
    /// Ao ser aberto, j� deve-se saber para quem est� sendo relacionada a sa�da.
    /// Este controle 
    /// Prop�e-se o uso de dois conceitos:
    ///		- Pedido travado: � aquele que n�o pode ser mais alterado. Caso necess�rio uma modifica��o, 
    ///		� necess�rio criar novo pedido apartir do anterior. Um pedido nunca pode ser modificado
    ///		 por seguran�a.
    ///		
    ///		- Pedido acertado: � aquele que j� foi pago. Trata-se de uma precau��o: assim que o usu�rio pede 
    ///		um acerto, que envolvem venda, pedido e retorno, caso seja erroneamente computado algum item_venda 
    ///		ou item_retorno que seja referente � um pedido j� acertado, o programa deve emitir uma mensagem de erro.
    /// </summary>
    public class Sa�daBaseInferior : BaseEditarRelacionamento
	{
        private Quadro quadroAcerto;
        private Op��o op��oRemarcarAcerto;
        private System.ComponentModel.IContainer components = null;

        protected new Entidades.Relacionamento.RelacionamentoAcerto Relacionamento
        {
            get
            {
                return base.Relacionamento as Entidades.Relacionamento.RelacionamentoAcerto;
            }
        }

		/// <summary>
		/// Constr�i a base de uma sa�da.
		/// </summary>
		public Sa�daBaseInferior()
		{
			InitializeComponent();
            verificadorMercadoria.Enabled = false;
		}

        protected override bool ValidarPermiss�oDestravar()
        {
            return Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.ConsignadoDestravar);
        }

        protected override Apresenta��o.Impress�o.TipoDocumento TipoDocumento
        {
            get { return Apresenta��o.Impress�o.TipoDocumento.Sa�da; }
        }

		/// <summary>
		/// � a primeiro m�todo chamado nesta base inferior.
		/// Deve ser chamado externamente,
		/// Abre as bandejas e inicia observa��o.
		/// </summary>
		public override void Abrir(Entidades.Relacionamento.Relacionamento relacionamento)
		{
            Entidades.Relacionamento.Sa�da.Sa�da s = (Entidades.Relacionamento.Sa�da.Sa�da)relacionamento;
            AguardeDB.Mostrar();

            try
            {
                base.Abrir(s);
                verificadorMercadoria.Enabled = false;

                if (!s.Cadastrado && s.Cota��o == 0)
                    s.Cota��o = Entidades.Financeiro.Cota��o.ObterCota��oVigente(s.TabelaPre�o.Moeda);

                digita��o.Cota��o = s.Cota��o;

                t�tulo.T�tulo = s.Pessoa.Nome;

                if (s.Cadastrado)
                    t�tulo.Descri��o = "Sa�da de n�mero " + s.C�digo;
                else
                {
                    t�tulo.Descri��o = "Sa�da ainda n�o cadastrada";
                    s.DepoisDeCadastrar += new Acesso.Comum.DbManipula��o.DbManipula��oHandler(DepoisDeCadastrar);
                }
            } 
            finally
            {
                AguardeDB.Fechar();
            }

            if (s.Itens.Count == 0)
                try
                {
                    Pessoa.AlertaClassifica��o.Alertar(s.Pessoa, Classifica��o.TipoAlerta.Sa�da);
                }
                catch (Permiss�oNegada)
                {
                    AtualizarTravamento(true);
                }

            quadroAcerto.Visible = (s.AcertoConsignado != null && s.AcertoConsignado.Sa�das.ContarElementos() <= 1 && s.AcertoConsignado.DataMarca��o.Date == DadosGlobais.Inst�ncia.HoraDataAtual.Date);
        }

        private void DepoisDeCadastrar(Acesso.Comum.DbManipula��o entidade)
        {
            Entidades.Relacionamento.Sa�da.Sa�da s = (Entidades.Relacionamento.Sa�da.Sa�da)entidade;

            t�tulo.Descri��o = "Sa�da de n�mero " + Relacionamento.C�digo;

            quadroAcerto.Visible = (s.AcertoConsignado != null && s.AcertoConsignado.Sa�das.ContarElementos() <= 1 && s.AcertoConsignado.DataMarca��o.Date == DadosGlobais.Inst�ncia.HoraDataAtual.Date);
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			
            base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.quadroAcerto = new Apresenta��o.Formul�rios.Quadro();
            this.op��oRemarcarAcerto = new Apresenta��o.Formul�rios.Op��o();
            this.tabs.SuspendLayout();
            this.tabItens.SuspendLayout();
            this.quadroTravamento.SuspendLayout();
            this.tabObserva��es.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.quadroAcerto.SuspendLayout();
            this.SuspendLayout();
            // 
            // t�tulo
            // 
            this.t�tulo.Imagem = global::Apresenta��o.Resource.sa�da;
            this.t�tulo.Location = new System.Drawing.Point(193, 3);
            this.t�tulo.Size = new System.Drawing.Size(586, 70);
            this.quadroTravamento.Controls.SetChildIndex(this.lblTravamento, 0);
            this.quadroTravamento.Controls.SetChildIndex(this.op��oDestravar, 0);
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroAcerto);
            this.esquerda.Controls.SetChildIndex(this.quadroAcerto, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroTravamento, 0);
            // 
            // quadroAcerto
            // 
            this.quadroAcerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroAcerto.bInfDirArredondada = true;
            this.quadroAcerto.bInfEsqArredondada = true;
            this.quadroAcerto.bSupDirArredondada = true;
            this.quadroAcerto.bSupEsqArredondada = true;
            this.quadroAcerto.Controls.Add(this.op��oRemarcarAcerto);
            this.quadroAcerto.Cor = System.Drawing.Color.Black;
            this.quadroAcerto.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAcerto.LetraT�tulo = System.Drawing.Color.White;
            this.quadroAcerto.Location = new System.Drawing.Point(7, 305);
            this.quadroAcerto.MostrarBot�oMinMax = false;
            this.quadroAcerto.Name = "quadroAcerto";
            this.quadroAcerto.Size = new System.Drawing.Size(160, 58);
            this.quadroAcerto.TabIndex = 6;
            this.quadroAcerto.Tamanho = 30;
            this.quadroAcerto.T�tulo = "Acerto";
            // 
            // op��oRemarcarAcerto
            // 
            this.op��oRemarcarAcerto.BackColor = System.Drawing.Color.Transparent;
            this.op��oRemarcarAcerto.Descri��o = "Remarcar";
            this.op��oRemarcarAcerto.Imagem = global::Apresenta��o.Resource.Acerto__Pequeno_;
            this.op��oRemarcarAcerto.Location = new System.Drawing.Point(7, 30);
            this.op��oRemarcarAcerto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oRemarcarAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRemarcarAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRemarcarAcerto.Name = "op��oRemarcarAcerto";
            this.op��oRemarcarAcerto.Size = new System.Drawing.Size(150, 24);
            this.op��oRemarcarAcerto.TabIndex = 2;
            this.op��oRemarcarAcerto.Click += new System.EventHandler(this.op��oRemarcarAcerto_Click);
            // 
            // Sa�daBaseInferior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Sa�daBaseInferior";
            this.tabs.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.quadroTravamento.ResumeLayout(false);
            this.tabObserva��es.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.quadroAcerto.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void op��oRemarcarAcerto_Click(object sender, EventArgs e)
        {
            using (Acerto.CriarAcerto dlg = new Acerto.CriarAcerto(Relacionamento.AcertoConsignado))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    Relacionamento.AcertoConsignado.Previs�o = dlg.Previs�o;
                    Relacionamento.AcertoConsignado.Atualizar();
                }
            }
        }

        protected override void InserirDocumento(JanelaImpress�o j)
        {
            Relat�rio relat�rio = new Relat�rio();

            new ControleImpress�oSa�da().PrepararImpress�o(relat�rio,
                (Entidades.Relacionamento.Sa�da.Sa�da) Relacionamento);

            j.T�tulo = "Impress�o de sa�da";
            j.Descri��o = "";
            j.InserirDocumento(relat�rio, "Sa�da");
        }
    }
}