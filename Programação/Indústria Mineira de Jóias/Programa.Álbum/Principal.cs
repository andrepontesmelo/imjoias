using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Álbum;
using Apresentação.Álbum.Fotos;
using Apresentação.Álbum.Edição.Fotos;

namespace Programa.Álbum
{
	public class FrmÁlbum : Apresentação.Formulários.BaseFormulário
    {
		private Apresentação.Formulários.Botão botãoFotógrafo;
		private Apresentação.Formulários.Botão botãoPendencias;
		private System.ComponentModel.IContainer components = null;
		private Apresentação.Formulários.Botão botãoÁlbuns;

		public FrmÁlbum()
		{
			try
			{
				InitializeComponent();
			
				botãoFotógrafo.AdicionarBaseInferior(Fotógrafo.Instância);

//				baseCatálogo = new Catálogo();
//				botãoCatálogo.AdicionarBaseInferior(baseCatálogo);

				// Existe incoerência com o Controlador aqui. Verificar!
				// -- Júlio, 22/10/2005

				//botãoCatálogo.Controlador.InserirBaseInferior(Fotos.Fotógrafo.Instância);
				
				/* Para que se inicie o programa Carregando() o album,
				 * é necessário que seu Handle esteja criado.
				 * (isso porque a thread secundária que recupera as entidades
				 * precisa encontrar a thread primávia via Invoke)
				 * Para isso, o controle, no caso ListaFoto, deve já
				 * estar associado a um controle, o que é feito no
				 * substituir base. Uma rápida substituição é feita:
				 */
				
//				botãoCatálogo.Controlador.Exibir();

				botãoPendencias.AdicionarBaseInferior(new Apresentação.Álbum.Edição.Fotos.BaseProblemas());
                botãoÁlbuns.AdicionarBaseInferior(new Apresentação.Álbum.Edição.Álbuns.BaseSeleçãoÁlbum());
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		protected override void AoCarregarCompletamente(Splash splash)
		{
			base.AoCarregarCompletamente (splash);

			botãoPendencias.Controlador.Exibir();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmÁlbum));
            this.botãoFotógrafo = new Apresentação.Formulários.Botão();
            this.botãoPendencias = new Apresentação.Formulários.Botão();
            this.botãoÁlbuns = new Apresentação.Formulários.Botão();
            this.topo.SuspendLayout();
            this.barraBotões.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraBotões
            // 
            this.barraBotões.Botões = new Apresentação.Formulários.Botão[] {
        this.botãoPendencias,
        this.botãoFotógrafo,
        this.botãoÁlbuns};
            // 
            // botãoFotógrafo
            // 
            this.botãoFotógrafo.Imagem = ((System.Drawing.Image)(resources.GetObject("botãoFotógrafo.Imagem")));
            this.botãoFotógrafo.Privilégios = Entidades.Privilégio.Permissão.Nenhuma;
            this.botãoFotógrafo.RetornarÀPrimeira = true;
            this.botãoFotógrafo.Texto = "Fotógrafo";
            // 
            // botãoPendencias
            // 
            this.botãoPendencias.Imagem = ((System.Drawing.Image)(resources.GetObject("botãoPendencias.Imagem")));
            this.botãoPendencias.Privilégios = Entidades.Privilégio.Permissão.Nenhuma;
            this.botãoPendencias.RetornarÀPrimeira = true;
            this.botãoPendencias.Texto = "Pendências";
            // 
            // botãoÁlbuns
            // 
            this.botãoÁlbuns.Imagem = ((System.Drawing.Image)(resources.GetObject("botãoÁlbuns.Imagem")));
            this.botãoÁlbuns.Privilégios = Entidades.Privilégio.Permissão.Nenhuma;
            this.botãoÁlbuns.Texto = "Álbuns";
            // 
            // FrmÁlbum
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FrmÁlbum";
            this.topo.ResumeLayout(false);
            this.barraBotões.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        [STAThread]
		private static void Main(string [] args)
		{
            Apresentação.Formulários.Aplicação.Executar(typeof(FrmÁlbum), new Acesso.MySQL.MySQLUsuários());
		}
	}
}

