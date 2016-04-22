using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Programa.Recep��o
{
	/// <summary>
	/// Janela principal da recep��o.
	/// </summary>
	public class Recep��o : Apresenta��o.Formul�rios.BaseFormul�rio
	{
        private Apresenta��o.Usu�rio.Agendamentos.ControleAgendamento controleAgendamento;

		private Apresenta��o.Formul�rios.Bot�o bot�oAgenda;
		private Apresenta��o.Formul�rios.Bot�o bot�oLembretes;
		private Apresenta��o.Formul�rios.Bot�o bot�oTelefonema;
		private Apresenta��o.Formul�rios.Bot�o bot�oEntradaSa�da;
		private Apresenta��o.Formul�rios.Bot�o bot�oRod�zio;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Recep��o()
		{
            BaseInferior.EntradaSa�da bES;
            BaseInferior.Aus�nciaAutom�tica bAA;

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			/* Para que a aus�ncia autom�tica seja mostrada logo que o
			 * programa comece quando h� funcion�rios presentes fora
			 * de seu hor�rio de trabalho, � necess�rio que o controlador
			 * de entrada e sa�da permita a exibi��o sem retornar � primeira,
			 * visto que � executado o m�todo Exibir do controlador logo ao
			 * t�rmino da carga.
			 */
			bot�oEntradaSa�da.Controlador.Retornar�Primeira = false;

			bot�oAgenda.AdicionarBaseInferior(new BaseInferior.Agenda());
			//bot�oLembretes.AdicionarBaseInferior(new BaseInferior.Agendamentos());
			bot�oTelefonema.AdicionarBaseInferior(new BaseInferior.Telefonemas());
			bot�oEntradaSa�da.AdicionarBaseInferior(bES = new BaseInferior.EntradaSa�da());
            bot�oEntradaSa�da.AdicionarBaseInferior(bAA = new BaseInferior.Aus�nciaAutom�tica());
			bot�oRod�zio.Controlador = new ControladorBot�oRod�zio();

			bot�oEntradaSa�da.Controlador.PermitirAutoExibi��o = true;

            controleAgendamento = new Apresenta��o.Usu�rio.Agendamentos.ControleAgendamento(bot�oLembretes.Controlador);
            bot�oLembretes.AdicionarBaseInferior(new Apresenta��o.Usu�rio.Agendamentos.BaseAgendamentos());

            bES.Considerar(bAA);
        }

		protected override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
		{
			base.AoCarregarCompletamente(splash);

            if (!bot�oEntradaSa�da.Controlador.Exibindo)
			    bot�oEntradaSa�da.Controlador.Exibir();
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Recep��o));
			this.bot�oAgenda = new Apresenta��o.Formul�rios.Bot�o();
			this.bot�oLembretes = new Apresenta��o.Formul�rios.Bot�o();
			this.bot�oTelefonema = new Apresenta��o.Formul�rios.Bot�o();
			this.bot�oEntradaSa�da = new Apresenta��o.Formul�rios.Bot�o();
			this.bot�oRod�zio = new Apresenta��o.Formul�rios.Bot�o();
			this.topo.SuspendLayout();
			this.barraBot�es.SuspendLayout();
			this.SuspendLayout();
			// 
			// topo
			// 
			this.topo.Name = "topo";
			// 
			// barraBot�es
			// 
			this.barraBot�es.Bot�es = new Apresenta��o.Formul�rios.Bot�o[] {
																			   this.bot�oAgenda,
																			   this.bot�oLembretes,
																			   this.bot�oTelefonema,
																			   this.bot�oEntradaSa�da,
																			   this.bot�oRod�zio};
			this.barraBot�es.Name = "barraBot�es";
			// 
			// bot�oAgenda
			// 
			this.bot�oAgenda.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�oAgenda.Imagem")));
			this.bot�oAgenda.Retornar�Primeira = true;
			this.bot�oAgenda.Texto = "Agenda de Telefone";
			// 
			// bot�oLembretes
			// 
			this.bot�oLembretes.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�oLembretes.Imagem")));
			this.bot�oLembretes.Retornar�Primeira = true;
			this.bot�oLembretes.Texto = "Lembretes";
			// 
			// bot�oTelefonema
			// 
			this.bot�oTelefonema.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�oTelefonema.Imagem")));
			this.bot�oTelefonema.Retornar�Primeira = true;
			this.bot�oTelefonema.Texto = "Registrar Telefonema";
			// 
			// bot�oEntradaSa�da
			// 
			this.bot�oEntradaSa�da.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�oEntradaSa�da.Imagem")));
			this.bot�oEntradaSa�da.Retornar�Primeira = true;
			this.bot�oEntradaSa�da.Texto = "Entrada e Sa�da";
			// 
			// bot�oRod�zio
			// 
			this.bot�oRod�zio.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�oRod�zio.Imagem")));
			this.bot�oRod�zio.Retornar�Primeira = true;
			this.bot�oRod�zio.Texto = "Rod�zio";
			// 
			// Recep��o
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 446);
			this.MinimumSize = new System.Drawing.Size(800, 480);
			this.Name = "Recep��o";
			this.Text = "Ind�stria Mineira de Joias - Recep��o";
			this.topo.ResumeLayout(false);
			this.barraBot�es.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

        [STAThreadAttribute]
        private static void Main(string [] args)
		{
			Apresenta��o.Formul�rios.Aplica��o.Executar(typeof(Programa.Recep��o.Recep��o), new Acesso.MySQL.MySQLUsu�rios(), false, true);
		}
	}
}
