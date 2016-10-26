using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Apresenta��o.Mercadoria.Bandeja;
using Entidades;
using Apresenta��o.Financeiro;
using Apresenta��o.Impress�o.Relat�rios.Retorno;
using Apresenta��o.Formul�rios;
using Apresenta��o.Financeiro.Acerto;

namespace Apresenta��o.Financeiro.Retorno
{
	public class RetornoBaseInferior : BaseEditarRelacionamento
	{
        private Quadro quadroAcerto;
        private Op��o op��oContabilizar;

		// Componentes
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i a base de um retorno.
		/// </summary>
		public RetornoBaseInferior()
		{
			InitializeComponent();
		}

        protected override Apresenta��o.Impress�o.TipoDocumento TipoDocumento
        {
            get
            {
                return Apresenta��o.Impress�o.TipoDocumento.Retorno;
            }
        }

        protected new Entidades.Relacionamento.RelacionamentoAcerto Relacionamento
        {
            get
            {
                return base.Relacionamento as Entidades.Relacionamento.RelacionamentoAcerto;
            }
        }

        protected override bool ValidarPermiss�oDestravar()
        {
            return Entidades.Privil�gio.Permiss�oFuncion�rio.ValidarPermiss�o(Entidades.Privil�gio.Permiss�o.ConsignadoDestravar);
        }

        //protected override Entidades.Relacionamento.Relacionamento CriarEntidade()
        //{
        //    return new Entidades.Relacionamento.Retorno.Retorno();
        //}

        /// <summary>
        /// � a primeiro m�todo chamado nesta base inferior.
        /// Deve ser chamado externamente,
        /// Abre as bandejas e inicia observa��o.
        /// </summary>
        public override void Abrir(Entidades.Relacionamento.Relacionamento s)
        {
            AguardeDB.Mostrar();
            base.Abrir(s);
            AguardeDB.Fechar();

            Entidades.Relacionamento.Retorno.Retorno retorno = (Entidades.Relacionamento.Retorno.Retorno) s;

            t�tulo.T�tulo = retorno.Pessoa.Nome;

            if (retorno.Cadastrado)
                t�tulo.Descri��o = "Retorno de n�mero " + retorno.C�digo;
            else
            {
                t�tulo.Descri��o = "Retorno a ser cadastrado";
                retorno.DepoisDeCadastrar += new Acesso.Comum.DbManipula��o.DbManipula��oHandler(DepoisDeCadastrar);
            }

            quadroAcerto.Visible = Relacionamento.AcertoConsignado != null && !Relacionamento.AcertoConsignado.Acertado;
        }

        private void DepoisDeCadastrar(Acesso.Comum.DbManipula��o entidade)
        {
            t�tulo.Descri��o = "Retorno de n�mero " + Relacionamento.C�digo;
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
            this.quadroAcerto = new Apresenta��o.Formul�rios.Quadro();
            this.op��oContabilizar = new Apresenta��o.Formul�rios.Op��o();
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
            this.t�tulo.Imagem = global::Apresenta��o.Resource.retorno;
            this.t�tulo.Location = new System.Drawing.Point(193, 3);
            this.t�tulo.T�tulo = "Base inferior de retorno.";
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
            this.quadroAcerto.Controls.Add(this.op��oContabilizar);
            this.quadroAcerto.Cor = System.Drawing.Color.Black;
            this.quadroAcerto.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAcerto.LetraT�tulo = System.Drawing.Color.White;
            this.quadroAcerto.Location = new System.Drawing.Point(7, 305);
            this.quadroAcerto.MostrarBot�oMinMax = false;
            this.quadroAcerto.Name = "quadroAcerto";
            this.quadroAcerto.Size = new System.Drawing.Size(160, 54);
            this.quadroAcerto.TabIndex = 6;
            this.quadroAcerto.Tamanho = 30;
            this.quadroAcerto.T�tulo = "Acerto";
            // 
            // op��oContabilizar
            // 
            this.op��oContabilizar.BackColor = System.Drawing.Color.Transparent;
            this.op��oContabilizar.Descri��o = "Contabilizar mercadorias";
            this.op��oContabilizar.Imagem = global::Apresenta��o.Resource.CalculatorHS;
            this.op��oContabilizar.Location = new System.Drawing.Point(7, 30);
            this.op��oContabilizar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oContabilizar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oContabilizar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oContabilizar.Name = "op��oContabilizar";
            this.op��oContabilizar.Size = new System.Drawing.Size(150, 24);
            this.op��oContabilizar.TabIndex = 2;
            this.op��oContabilizar.Click += new System.EventHandler(this.op��oContabilizar_Click);
            // 
            // RetornoBaseInferior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RetornoBaseInferior";
            this.tabs.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.quadroTravamento.ResumeLayout(false);
            this.tabObserva��es.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.quadroAcerto.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void op��oContabilizar_Click(object sender, EventArgs e)
        {
            BaseResumoAcerto baseInferior = new BaseResumoAcerto();
            baseInferior.Carregar(Relacionamento.AcertoConsignado);
            SubstituirBase(baseInferior);
        }

        protected override void InserirDocumento(Apresenta��o.Formul�rios.JanelaImpress�o j)
        {
            Relat�rio relat�rio = new Apresenta��o.Impress�o.Relat�rios.Retorno.Relat�rio();

            new Apresenta��o.Impress�o.Relat�rios.Retorno.ControleImpress�oRetorno().PrepararImpress�o(relat�rio,
                (Entidades.Relacionamento.Retorno.Retorno) Relacionamento);

            j.T�tulo = "Impress�o de retorno";
            j.Descri��o = "";
            j.InserirDocumento(relat�rio, "Retorno");
        }
    }
}

