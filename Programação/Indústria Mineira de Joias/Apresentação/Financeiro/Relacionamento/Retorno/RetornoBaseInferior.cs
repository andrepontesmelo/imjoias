using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Apresentação.Mercadoria.Bandeja;
using Entidades;
using Apresentação.Financeiro;
using Apresentação.Impressão.Relatórios.Retorno;
using Apresentação.Formulários;
using Apresentação.Financeiro.Acerto;

namespace Apresentação.Financeiro.Retorno
{
	public class RetornoBaseInferior : BaseEditarRelacionamento
	{
        private Quadro quadroAcerto;
        private Opção opçãoContabilizar;

		// Componentes
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói a base de um retorno.
		/// </summary>
		public RetornoBaseInferior()
		{
			InitializeComponent();
		}

        protected override Apresentação.Impressão.TipoDocumento TipoDocumento
        {
            get
            {
                return Apresentação.Impressão.TipoDocumento.Retorno;
            }
        }

        protected new Entidades.Relacionamento.RelacionamentoAcerto Relacionamento
        {
            get
            {
                return base.Relacionamento as Entidades.Relacionamento.RelacionamentoAcerto;
            }
        }

        protected override bool ValidarPermissãoDestravar()
        {
            return Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.ConsignadoDestravar);
        }

        //protected override Entidades.Relacionamento.Relacionamento CriarEntidade()
        //{
        //    return new Entidades.Relacionamento.Retorno.Retorno();
        //}

        /// <summary>
        /// É a primeiro método chamado nesta base inferior.
        /// Deve ser chamado externamente,
        /// Abre as bandejas e inicia observação.
        /// </summary>
        public override void Abrir(Entidades.Relacionamento.Relacionamento s)
        {
            AguardeDB.Mostrar();
            base.Abrir(s);
            AguardeDB.Fechar();

            Entidades.Relacionamento.Retorno.Retorno retorno = (Entidades.Relacionamento.Retorno.Retorno) s;

            título.Título = retorno.Pessoa.Nome;

            if (retorno.Cadastrado)
                título.Descrição = "Retorno de número " + retorno.Código;
            else
            {
                título.Descrição = "Retorno a ser cadastrado";
                retorno.DepoisDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(DepoisDeCadastrar);
            }

            quadroAcerto.Visible = Relacionamento.AcertoConsignado != null && !Relacionamento.AcertoConsignado.Acertado;
        }

        private void DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            título.Descrição = "Retorno de número " + Relacionamento.Código;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
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
            this.opçãoContabilizar = new Apresentação.Formulários.Opção();
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
            this.título.Imagem = global::Apresentação.Resource.retorno;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Título = "Base inferior de retorno.";
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
            this.quadroAcerto.Controls.Add(this.opçãoContabilizar);
            this.quadroAcerto.Cor = System.Drawing.Color.Black;
            this.quadroAcerto.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAcerto.LetraTítulo = System.Drawing.Color.White;
            this.quadroAcerto.Location = new System.Drawing.Point(7, 305);
            this.quadroAcerto.MostrarBotãoMinMax = false;
            this.quadroAcerto.Name = "quadroAcerto";
            this.quadroAcerto.Size = new System.Drawing.Size(160, 54);
            this.quadroAcerto.TabIndex = 6;
            this.quadroAcerto.Tamanho = 30;
            this.quadroAcerto.Título = "Acerto";
            // 
            // opçãoContabilizar
            // 
            this.opçãoContabilizar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoContabilizar.Descrição = "Contabilizar mercadorias";
            this.opçãoContabilizar.Imagem = global::Apresentação.Resource.CalculatorHS;
            this.opçãoContabilizar.Location = new System.Drawing.Point(7, 30);
            this.opçãoContabilizar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoContabilizar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoContabilizar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoContabilizar.Name = "opçãoContabilizar";
            this.opçãoContabilizar.Size = new System.Drawing.Size(150, 24);
            this.opçãoContabilizar.TabIndex = 2;
            this.opçãoContabilizar.Click += new System.EventHandler(this.opçãoContabilizar_Click);
            // 
            // RetornoBaseInferior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RetornoBaseInferior";
            this.tabs.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.quadroTravamento.ResumeLayout(false);
            this.tabObservações.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.quadroAcerto.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void opçãoContabilizar_Click(object sender, EventArgs e)
        {
            BaseResumoAcerto baseInferior = new BaseResumoAcerto();
            baseInferior.Carregar(Relacionamento.AcertoConsignado);
            SubstituirBase(baseInferior);
        }

        protected override void InserirDocumento(Apresentação.Formulários.JanelaImpressão j)
        {
            Relatório relatório = new Apresentação.Impressão.Relatórios.Retorno.Relatório();

            new Apresentação.Impressão.Relatórios.Retorno.ControleImpressãoRetorno().PrepararImpressão(relatório,
                (Entidades.Relacionamento.Retorno.Retorno) Relacionamento);

            j.Título = "Impressão de retorno";
            j.Descrição = "";
            j.InserirDocumento(relatório, "Retorno");
        }
    }
}

