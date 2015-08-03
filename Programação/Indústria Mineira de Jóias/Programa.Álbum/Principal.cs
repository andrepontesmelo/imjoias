using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Apresenta��o.�lbum;
using Apresenta��o.�lbum.Fotos;
using Apresenta��o.�lbum.Edi��o.Fotos;

namespace Programa.�lbum
{
	public class Frm�lbum : Apresenta��o.Formul�rios.BaseFormul�rio
    {
		private Apresenta��o.Formul�rios.Bot�o bot�oFot�grafo;
		private Apresenta��o.Formul�rios.Bot�o bot�oPendencias;
		private System.ComponentModel.IContainer components = null;
		private Apresenta��o.Formul�rios.Bot�o bot�o�lbuns;

		public Frm�lbum()
		{
			try
			{
				InitializeComponent();
			
				bot�oFot�grafo.AdicionarBaseInferior(Fot�grafo.Inst�ncia);

//				baseCat�logo = new Cat�logo();
//				bot�oCat�logo.AdicionarBaseInferior(baseCat�logo);

				// Existe incoer�ncia com o Controlador aqui. Verificar!
				// -- J�lio, 22/10/2005

				//bot�oCat�logo.Controlador.InserirBaseInferior(Fotos.Fot�grafo.Inst�ncia);
				
				/* Para que se inicie o programa Carregando() o album,
				 * � necess�rio que seu Handle esteja criado.
				 * (isso porque a thread secund�ria que recupera as entidades
				 * precisa encontrar a thread prim�via via Invoke)
				 * Para isso, o controle, no caso ListaFoto, deve j�
				 * estar associado a um controle, o que � feito no
				 * substituir base. Uma r�pida substitui��o � feita:
				 */
				
//				bot�oCat�logo.Controlador.Exibir();

				bot�oPendencias.AdicionarBaseInferior(new Apresenta��o.�lbum.Edi��o.Fotos.BaseProblemas());
                bot�o�lbuns.AdicionarBaseInferior(new Apresenta��o.�lbum.Edi��o.�lbuns.BaseSele��o�lbum());
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		protected override void AoCarregarCompletamente(Splash splash)
		{
			base.AoCarregarCompletamente (splash);

			bot�oPendencias.Controlador.Exibir();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm�lbum));
            this.bot�oFot�grafo = new Apresenta��o.Formul�rios.Bot�o();
            this.bot�oPendencias = new Apresenta��o.Formul�rios.Bot�o();
            this.bot�o�lbuns = new Apresenta��o.Formul�rios.Bot�o();
            this.topo.SuspendLayout();
            this.barraBot�es.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraBot�es
            // 
            this.barraBot�es.Bot�es = new Apresenta��o.Formul�rios.Bot�o[] {
        this.bot�oPendencias,
        this.bot�oFot�grafo,
        this.bot�o�lbuns};
            // 
            // bot�oFot�grafo
            // 
            this.bot�oFot�grafo.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�oFot�grafo.Imagem")));
            this.bot�oFot�grafo.Privil�gios = Entidades.Privil�gio.Permiss�o.Nenhuma;
            this.bot�oFot�grafo.Retornar�Primeira = true;
            this.bot�oFot�grafo.Texto = "Fot�grafo";
            // 
            // bot�oPendencias
            // 
            this.bot�oPendencias.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�oPendencias.Imagem")));
            this.bot�oPendencias.Privil�gios = Entidades.Privil�gio.Permiss�o.Nenhuma;
            this.bot�oPendencias.Retornar�Primeira = true;
            this.bot�oPendencias.Texto = "Pend�ncias";
            // 
            // bot�o�lbuns
            // 
            this.bot�o�lbuns.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�o�lbuns.Imagem")));
            this.bot�o�lbuns.Privil�gios = Entidades.Privil�gio.Permiss�o.Nenhuma;
            this.bot�o�lbuns.Texto = "�lbuns";
            // 
            // Frm�lbum
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "Frm�lbum";
            this.topo.ResumeLayout(false);
            this.barraBot�es.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        [STAThread]
		private static void Main(string [] args)
		{
            Apresenta��o.Formul�rios.Aplica��o.Executar(typeof(Frm�lbum), new Acesso.MySQL.MySQLUsu�rios());
		}
	}
}

