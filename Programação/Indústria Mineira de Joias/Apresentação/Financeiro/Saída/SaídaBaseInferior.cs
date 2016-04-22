using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Saída;
using Entidades.Configuração;
using Entidades.Pessoa;
using Entidades.Privilégio;
using System;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Saída
{
    /// <summary>
    /// Controle para relacionar mercadoria de uma de saída.
    /// Ao ser aberto, já deve-se saber para quem está sendo relacionada a saída.
    /// Este controle 
    /// Propõe-se o uso de dois conceitos:
    ///		- Pedido travado: é aquele que não pode ser mais alterado. Caso necessário uma modificação, 
    ///		é necessário criar novo pedido apartir do anterior. Um pedido nunca pode ser modificado
    ///		 por segurança.
    ///		
    ///		- Pedido acertado: é aquele que já foi pago. Trata-se de uma precaução: assim que o usuário pede 
    ///		um acerto, que envolvem venda, pedido e retorno, caso seja erroneamente computado algum item_venda 
    ///		ou item_retorno que seja referente à um pedido já acertado, o programa deve emitir uma mensagem de erro.
    /// </summary>
    public class SaídaBaseInferior : BaseEditarRelacionamento
	{
        private Quadro quadroAcerto;
        private Opção opçãoRemarcarAcerto;
        private System.ComponentModel.IContainer components = null;

        protected new Entidades.Relacionamento.RelacionamentoAcerto Relacionamento
        {
            get
            {
                return base.Relacionamento as Entidades.Relacionamento.RelacionamentoAcerto;
            }
        }

		/// <summary>
		/// Constrói a base de uma saída.
		/// </summary>
		public SaídaBaseInferior()
		{
			InitializeComponent();
            verificadorMercadoria.Enabled = false;
		}

        protected override bool ValidarPermissãoDestravar()
        {
            return PermissãoFuncionário.ValidarPermissão(Permissão.ConsignadoDestravar);
        }

        protected override Apresentação.Impressão.TipoDocumento TipoDocumento
        {
            get { return Apresentação.Impressão.TipoDocumento.Saída; }
        }

		/// <summary>
		/// É a primeiro método chamado nesta base inferior.
		/// Deve ser chamado externamente,
		/// Abre as bandejas e inicia observação.
		/// </summary>
		public override void Abrir(Entidades.Relacionamento.Relacionamento relacionamento)
		{
            Entidades.Relacionamento.Saída.Saída s = (Entidades.Relacionamento.Saída.Saída)relacionamento;
            AguardeDB.Mostrar();

            try
            {
                base.Abrir(s);
                verificadorMercadoria.Enabled = false;

                if (!s.Cadastrado && s.Cotação == 0)
                    s.Cotação = Entidades.Financeiro.Cotação.ObterCotaçãoVigente(s.TabelaPreço.Moeda);

                digitação.Cotação = s.Cotação;

                título.Título = s.Pessoa.Nome;

                if (s.Cadastrado)
                    título.Descrição = "Saída de número " + s.Código;
                else
                {
                    título.Descrição = "Saída ainda não cadastrada";
                    s.DepoisDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(DepoisDeCadastrar);
                }
            } 
            finally
            {
                AguardeDB.Fechar();
            }

            if (s.Itens.Count == 0)
                try
                {
                    Pessoa.AlertaClassificação.Alertar(s.Pessoa, Classificação.TipoAlerta.Saída);
                }
                catch (PermissãoNegada)
                {
                    AtualizarTravamento(true);
                }

            quadroAcerto.Visible = (s.AcertoConsignado != null && s.AcertoConsignado.Saídas.ContarElementos() <= 1 && s.AcertoConsignado.DataMarcação.Date == DadosGlobais.Instância.HoraDataAtual.Date);
        }

        private void DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            Entidades.Relacionamento.Saída.Saída s = (Entidades.Relacionamento.Saída.Saída)entidade;

            título.Descrição = "Saída de número " + Relacionamento.Código;

            quadroAcerto.Visible = (s.AcertoConsignado != null && s.AcertoConsignado.Saídas.ContarElementos() <= 1 && s.AcertoConsignado.DataMarcação.Date == DadosGlobais.Instância.HoraDataAtual.Date);
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
            this.quadroAcerto = new Apresentação.Formulários.Quadro();
            this.opçãoRemarcarAcerto = new Apresentação.Formulários.Opção();
            this.tabs.SuspendLayout();
            this.tabItens.SuspendLayout();
            this.quadroTravamento.SuspendLayout();
            this.tabObservações.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.quadroAcerto.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Imagem = global::Apresentação.Resource.saída;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Size = new System.Drawing.Size(586, 70);
            this.quadroTravamento.Controls.SetChildIndex(this.lblTravamento, 0);
            this.quadroTravamento.Controls.SetChildIndex(this.opçãoDestravar, 0);
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
            this.quadroAcerto.Controls.Add(this.opçãoRemarcarAcerto);
            this.quadroAcerto.Cor = System.Drawing.Color.Black;
            this.quadroAcerto.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAcerto.LetraTítulo = System.Drawing.Color.White;
            this.quadroAcerto.Location = new System.Drawing.Point(7, 305);
            this.quadroAcerto.MostrarBotãoMinMax = false;
            this.quadroAcerto.Name = "quadroAcerto";
            this.quadroAcerto.Size = new System.Drawing.Size(160, 58);
            this.quadroAcerto.TabIndex = 6;
            this.quadroAcerto.Tamanho = 30;
            this.quadroAcerto.Título = "Acerto";
            // 
            // opçãoRemarcarAcerto
            // 
            this.opçãoRemarcarAcerto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRemarcarAcerto.Descrição = "Remarcar";
            this.opçãoRemarcarAcerto.Imagem = global::Apresentação.Resource.Acerto__Pequeno_;
            this.opçãoRemarcarAcerto.Location = new System.Drawing.Point(7, 30);
            this.opçãoRemarcarAcerto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRemarcarAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRemarcarAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRemarcarAcerto.Name = "opçãoRemarcarAcerto";
            this.opçãoRemarcarAcerto.Size = new System.Drawing.Size(150, 24);
            this.opçãoRemarcarAcerto.TabIndex = 2;
            this.opçãoRemarcarAcerto.Click += new System.EventHandler(this.opçãoRemarcarAcerto_Click);
            // 
            // SaídaBaseInferior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SaídaBaseInferior";
            this.tabs.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.quadroTravamento.ResumeLayout(false);
            this.tabObservações.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.quadroAcerto.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void opçãoRemarcarAcerto_Click(object sender, EventArgs e)
        {
            using (Acerto.CriarAcerto dlg = new Acerto.CriarAcerto(Relacionamento.AcertoConsignado))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    Relacionamento.AcertoConsignado.Previsão = dlg.Previsão;
                    Relacionamento.AcertoConsignado.Atualizar();
                }
            }
        }

        protected override void InserirDocumento(JanelaImpressão j)
        {
            Relatório relatório = new Relatório();

            new ControleImpressãoSaída().PrepararImpressão(relatório,
                (Entidades.Relacionamento.Saída.Saída) Relacionamento);

            j.Título = "Impressão de saída";
            j.Descrição = "";
            j.InserirDocumento(relatório, "Saída");
        }
    }
}