using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;

namespace Apresenta��o.Usu�rio.InterForm
{
	/// <summary>
	/// Base contendo ambiente do funcion�rio.
	/// </summary>
	public class BaseUsu�rio : Apresenta��o.Formul�rios.BaseInferior
	{
		/// <summary>
		/// Funcion�rio atual.
		/// </summary>
		private Entidades.Pessoa.Funcion�rio funcion�rio;

		// Componentes
        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tulo;
        protected Apresenta��o.Usu�rio.Agendamentos.ListaAgendamentosAtuais listaAgendamentos;
        protected Apresenta��o.Formul�rios.Quadro quadroPrivado;
        private Apresenta��o.Formul�rios.Op��o op��oAgendamentos;
        private Apresenta��o.Formul�rios.Op��o op��oRamal;
        private Apresenta��o.Formul�rios.Op��o op��oSenha;
        protected Apresenta��o.Formul�rios.Quadro quadroRamais;
        private Apresenta��o.Usu�rio.Funcion�rios.Ramais ramais;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Esta construtora permite que classes que herdem dessa
		/// possa ser trabalhada no Visual Studio.
		/// </summary>
		private BaseUsu�rio()
		{
			InitializeComponent();
		}

        protected new ControladorUsu�rio Controlador
        {
            get { return (ControladorUsu�rio)base.Controlador; }
        }

		/// <summary>
		/// Constr�i a base para um funcion�rio espec�fico.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio atual.</param>
		public BaseUsu�rio(Entidades.Pessoa.Funcion�rio funcion�rio)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			this.funcion�rio = funcion�rio;
			t�tulo.Descri��o = funcion�rio.Nome;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseUsu�rio));
            this.t�tulo = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.listaAgendamentos = new Apresenta��o.Usu�rio.Agendamentos.ListaAgendamentosAtuais();
            this.quadroPrivado = new Apresenta��o.Formul�rios.Quadro();
            this.op��oAgendamentos = new Apresenta��o.Formul�rios.Op��o();
            this.op��oRamal = new Apresenta��o.Formul�rios.Op��o();
            this.op��oSenha = new Apresenta��o.Formul�rios.Op��o();
            this.quadroRamais = new Apresenta��o.Formul�rios.Quadro();
            this.ramais = new Apresenta��o.Usu�rio.Funcion�rios.Ramais();
            this.esquerda.SuspendLayout();
            this.quadroPrivado.SuspendLayout();
            this.quadroRamais.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPrivado);
            this.esquerda.Size = new System.Drawing.Size(187, 392);
            this.esquerda.Controls.SetChildIndex(this.quadroPrivado, 0);
            // 
            // t�tulo
            // 
            this.t�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tulo.BackColor = System.Drawing.Color.White;
            this.t�tulo.Descri��o = "Fulano de tal";
            this.t�tulo.Imagem = ((System.Drawing.Image)(resources.GetObject("t�tulo.Imagem")));
            this.t�tulo.Location = new System.Drawing.Point(208, 16);
            this.t�tulo.Name = "t�tulo";
            this.t�tulo.Size = new System.Drawing.Size(568, 70);
            this.t�tulo.TabIndex = 6;
            this.t�tulo.T�tulo = "Ambiente do funcion�rio";
            // 
            // listaAgendamentos
            // 
            this.listaAgendamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaAgendamentos.BackColor = System.Drawing.Color.White;
            this.listaAgendamentos.Location = new System.Drawing.Point(185, 92);
            this.listaAgendamentos.Name = "listaAgendamentos";
            this.listaAgendamentos.Size = new System.Drawing.Size(349, 276);
            this.listaAgendamentos.TabIndex = 7;
            // 
            // quadroPrivado
            // 
            this.quadroPrivado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPrivado.bInfDirArredondada = true;
            this.quadroPrivado.bInfEsqArredondada = true;
            this.quadroPrivado.bSupDirArredondada = true;
            this.quadroPrivado.bSupEsqArredondada = true;
            this.quadroPrivado.Controls.Add(this.op��oAgendamentos);
            this.quadroPrivado.Controls.Add(this.op��oRamal);
            this.quadroPrivado.Controls.Add(this.op��oSenha);
            this.quadroPrivado.Cor = System.Drawing.Color.Black;
            this.quadroPrivado.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPrivado.LetraT�tulo = System.Drawing.Color.White;
            this.quadroPrivado.Location = new System.Drawing.Point(7, 13);
            this.quadroPrivado.MostrarBot�oMinMax = false;
            this.quadroPrivado.Name = "quadroPrivado";
            this.quadroPrivado.Size = new System.Drawing.Size(160, 99);
            this.quadroPrivado.TabIndex = 1;
            this.quadroPrivado.Tamanho = 30;
            this.quadroPrivado.T�tulo = "Acesso privado";
            // 
            // op��oAgendamentos
            // 
            this.op��oAgendamentos.BackColor = System.Drawing.Color.Transparent;
            this.op��oAgendamentos.Descri��o = "Editar agendamentos";
            this.op��oAgendamentos.Imagem = global::Apresenta��o.Usu�rio.Properties.Resources.DedoMenor;
            this.op��oAgendamentos.Location = new System.Drawing.Point(5, 29);
            this.op��oAgendamentos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oAgendamentos.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oAgendamentos.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oAgendamentos.Name = "op��oAgendamentos";
            this.op��oAgendamentos.Size = new System.Drawing.Size(150, 24);
            this.op��oAgendamentos.TabIndex = 2;
            this.op��oAgendamentos.Click += new System.EventHandler(this.op��oAgendamentos_Click);
            // 
            // op��oRamal
            // 
            this.op��oRamal.BackColor = System.Drawing.Color.Transparent;
            this.op��oRamal.Descri��o = "Alterar ramal";
            this.op��oRamal.Imagem = global::Apresenta��o.Usu�rio.Properties.Resources.bot�o___telefone;
            this.op��oRamal.Location = new System.Drawing.Point(5, 53);
            this.op��oRamal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oRamal.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRamal.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRamal.Name = "op��oRamal";
            this.op��oRamal.Size = new System.Drawing.Size(150, 24);
            this.op��oRamal.TabIndex = 3;
            this.op��oRamal.Click += new System.EventHandler(this.op��oRamal_Click);
            // 
            // op��oSenha
            // 
            this.op��oSenha.BackColor = System.Drawing.Color.Transparent;
            this.op��oSenha.Descri��o = "Alterar senha";
            this.op��oSenha.Imagem = global::Apresenta��o.Usu�rio.Properties.Resources.keys;
            this.op��oSenha.Location = new System.Drawing.Point(5, 77);
            this.op��oSenha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oSenha.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oSenha.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oSenha.Name = "op��oSenha";
            this.op��oSenha.Size = new System.Drawing.Size(150, 24);
            this.op��oSenha.TabIndex = 4;
            this.op��oSenha.Click += new System.EventHandler(this.op��oSenha_Click);
            // 
            // quadroRamais
            // 
            this.quadroRamais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroRamais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroRamais.bInfDirArredondada = true;
            this.quadroRamais.bInfEsqArredondada = true;
            this.quadroRamais.bSupDirArredondada = true;
            this.quadroRamais.bSupEsqArredondada = true;
            this.quadroRamais.Controls.Add(this.ramais);
            this.quadroRamais.Cor = System.Drawing.Color.Black;
            this.quadroRamais.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRamais.LetraT�tulo = System.Drawing.Color.White;
            this.quadroRamais.Location = new System.Drawing.Point(540, 92);
            this.quadroRamais.MostrarBot�oMinMax = false;
            this.quadroRamais.Name = "quadroRamais";
            this.quadroRamais.Size = new System.Drawing.Size(244, 276);
            this.quadroRamais.TabIndex = 8;
            this.quadroRamais.Tamanho = 30;
            this.quadroRamais.T�tulo = "Ramais Telef�nicos";
            // 
            // ramais
            // 
            this.ramais.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ramais.Location = new System.Drawing.Point(5, 27);
            this.ramais.Margin = new System.Windows.Forms.Padding(5);
            this.ramais.Name = "ramais";
            this.ramais.Size = new System.Drawing.Size(234, 244);
            this.ramais.TabIndex = 2;
            // 
            // BaseUsu�rio
            // 
            this.Controls.Add(this.t�tulo);
            this.Controls.Add(this.quadroRamais);
            this.Controls.Add(this.listaAgendamentos);
            this.Imagem = global::Apresenta��o.Usu�rio.Properties.Resources.empregado;
            this.Name = "BaseUsu�rio";
            this.Size = new System.Drawing.Size(800, 392);
            this.Controls.SetChildIndex(this.listaAgendamentos, 0);
            this.Controls.SetChildIndex(this.quadroRamais, 0);
            this.Controls.SetChildIndex(this.t�tulo, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroPrivado.ResumeLayout(false);
            this.quadroRamais.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// T�tulo da base inferior.
		/// </summary>
		[DefaultValue("Ambiente do funcion�rio")]
		public string T�tulo
		{
			get { return t�tulo.T�tulo; }
			set { t�tulo.T�tulo = value; }
		}

		#endregion

        private void op��oAgendamentos_Click(object sender, EventArgs e)
        {
            Controlador.MostrarAgendamentos();
        }

        private void op��oRamal_Click(object sender, EventArgs e)
        {
            using (Apresenta��o.Pessoa.Cadastro.EditarRamal dlg = new Apresenta��o.Pessoa.Cadastro.EditarRamal(Entidades.Pessoa.Funcion�rio.Funcion�rioAtual))
            {
                dlg.ShowDialog(this.ParentForm);
            }

            ramais.Atualizar();
        }

        private void op��oSenha_Click(object sender, EventArgs e)
        {
            using (Apresenta��o.Usu�rio.Funcion�rios.AlterarSenha dlg = new Apresenta��o.Usu�rio.Funcion�rios.AlterarSenha())
            {
                dlg.ShowDialog(this.ParentForm);
            }
        }


        ///// <summary>
        ///// Ocorre ao receber mensagem de observa��o do funcion�rio atual.
        ///// </summary>
        ///// <param name="sujeito">Sujeito da a��o.</param>
        ///// <param name="a��o">A��o tomada.</param>
        ///// <param name="dados">Dados da a��o.</param>
        //private void AoObservarFuncion�rio(ISujeito sujeito, int a��o, object dados)
        //{
        //    if (sujeito != funcion�rio)
        //        throw new Exception("O sujeito n�o � o funcion�rio observado!");

        //    AoObservarFuncion�rio((A��oFuncion�rio) a��o, dados);
        //}

        ///// <summary>
        ///// Ocorre ao observar uma a��o do funcion�rio atual.
        ///// </summary>
        ///// <param name="a��o">A��o do funcion�rio.</param>
        ///// <param name="dados">Dados da a��o.</param>
        //protected virtual void AoObservarFuncion�rio(A��oFuncion�rio a��o, object dados)
        //{
        //}
	}
}