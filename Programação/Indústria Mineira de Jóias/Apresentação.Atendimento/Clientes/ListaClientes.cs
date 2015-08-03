using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Negócio;
using Negócio.Controle;
using Negócio.Observador;
using Observador;

namespace Apresentação.Atendimento.Clientes
{
	/// <summary>
	/// Lista de clientes
	/// </summary>
	[Serializable]
	public class ListaClientes : System.Windows.Forms.UserControl
	{
		// Atributos
		private ColeçãoListaClientesÍtem	ítens;
		private IAtendimento				controle;
		private EventoObservação			observaçãoVisitante;

		// Propriedades
		private int							colunas					= 2;
		private int							distânciaEntreColunas	= 15;

		// Eventos
		public delegate void ClienteSelecionadoDelegate(IVisitante cliente);
		public event ClienteSelecionadoDelegate ClienteSelecionado;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constrói lista de clientes
		/// </summary>
		public ListaClientes()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Construir coleção
			ítens = new ColeçãoListaClientesÍtem(this);

			// Prepara evento observação
			observaçãoVisitante = new Observador.EventoObservação(controle_ObservaçãoVisitante);

			// Preparar comunicação com controle
			try
			{
				PrepararControle();
			}
			catch {}
		}

		/// <summary>
		/// Prepara comunicação com controle e obtém dados residentes na memória
		/// </summary>
		private void PrepararControle()
		{
			// Prepara comunicação
			controle = (IAtendimento) Controle.Conectar(
                "Atendimento", typeof(Negócio.Controle.IAtendimento),
				8200);

			// Prepara observação
			controle.ObservaçãoVisitante += observaçãoVisitante;

			// Importar visitantes do controle
			ImportarVisitantes();
		}

		/// <summary>
		/// Importa visitantes do controle
		/// </summary>
		private void ImportarVisitantes()
		{
			foreach (IVisitante visitante in controle.ObterVisitantes())
				ítens.Add(visitante);
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
			
			controle.ObservaçãoVisitante -= observaçãoVisitante;
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ListaClientes
			// 
			this.Name = "ListaClientes";
			this.Size = new System.Drawing.Size(288, 152);
			this.Resize += new System.EventHandler(this.ListaClientes_Resize);

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// Ítens
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public ColeçãoListaClientesÍtem Ítens
		{
			get { return ítens; }
		}

		/// <summary>
		/// Número de colunas a mostrar
		/// </summary>
		[DefaultValue(2)]
		public int Colunas
		{
			get { return colunas; }
			set
			{
				colunas = value;
				Reorganizar();
			}
		}

		/// <summary>
		/// Distância entre colunas
		/// </summary>
		[DefaultValue(15)]
		public int DistânciaEntreColunas
		{
			get { return distânciaEntreColunas; }
			set
			{
				distânciaEntreColunas = value;
				Reorganizar();
			}
		}

		#endregion

		/// <summary>
		/// Reorganiza a visualização da lista de clientes
		/// </summary>
		internal void Reorganizar()
		{
			int ítemTamanho;				// Tamanho do ítem
			Point posição;
			int coluna = 0;

			// Suspender o layoute
			this.SuspendLayout();

			// Calcular tamanho dos ítens
			ítemTamanho = this.Width / this.colunas - this.distânciaEntreColunas * (this.colunas - 1);
			posição = new Point(0, 0);

			foreach (ListaClientesÍtem ítem in ítens)
			{
				ítem.Location = posição;
				ítem.Width    = ítemTamanho;

				if (++coluna < this.colunas)
				{
					posição.X += ítemTamanho + this.distânciaEntreColunas;
				}
				else
				{
					posição.X = 0;
					posição.Y += ítem.Height + distânciaEntreColunas;
					coluna = 0;
				}
			}

			// Reinicia o layout
			this.ResumeLayout();
		}

		/// <summary>
		/// Ocorre quando a lista é redimensionada
		/// </summary>
		private void ListaClientes_Resize(object sender, System.EventArgs e)
		{
			Reorganizar();
		}

		/// <summary>
		/// Ocorre quando um visitante altera seu estado
		/// </summary>
		public void controle_ObservaçãoVisitante(Observador.ISujeito sujeito, int ação, object dados)
		{
			switch ((AçãoVisitante) ação)
			{
				case AçãoVisitante.Entrou:
					ítens.Add((IVisitante) sujeito);
					break;
			}
		}

		/// <summary>
		/// Ocorre quando um ítem é selecionado
		/// </summary>
		/// <param name="ítem">Ítem selecionado</param>
		/// <remarks>Chamado pela coleção</remarks>
		internal void ÍtemSelecionado(ListaClientesÍtem ítem)
		{
			if (ClienteSelecionado != null)
				ClienteSelecionado(ítem.Visitante);
		}
	}
}
