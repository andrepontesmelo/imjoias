using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Neg�cio;
using Neg�cio.Controle;
using Neg�cio.Observador;
using Observador;

namespace Apresenta��o.Atendimento.Clientes
{
	/// <summary>
	/// Lista de clientes
	/// </summary>
	[Serializable]
	public class ListaClientes : System.Windows.Forms.UserControl
	{
		// Atributos
		private Cole��oListaClientes�tem	�tens;
		private IAtendimento				controle;
		private EventoObserva��o			observa��oVisitante;

		// Propriedades
		private int							colunas					= 2;
		private int							dist�nciaEntreColunas	= 15;

		// Eventos
		public delegate void ClienteSelecionadoDelegate(IVisitante cliente);
		public event ClienteSelecionadoDelegate ClienteSelecionado;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constr�i lista de clientes
		/// </summary>
		public ListaClientes()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Construir cole��o
			�tens = new Cole��oListaClientes�tem(this);

			// Prepara evento observa��o
			observa��oVisitante = new Observador.EventoObserva��o(controle_Observa��oVisitante);

			// Preparar comunica��o com controle
			try
			{
				PrepararControle();
			}
			catch {}
		}

		/// <summary>
		/// Prepara comunica��o com controle e obt�m dados residentes na mem�ria
		/// </summary>
		private void PrepararControle()
		{
			// Prepara comunica��o
			controle = (IAtendimento) Controle.Conectar(
                "Atendimento", typeof(Neg�cio.Controle.IAtendimento),
				8200);

			// Prepara observa��o
			controle.Observa��oVisitante += observa��oVisitante;

			// Importar visitantes do controle
			ImportarVisitantes();
		}

		/// <summary>
		/// Importa visitantes do controle
		/// </summary>
		private void ImportarVisitantes()
		{
			foreach (IVisitante visitante in controle.ObterVisitantes())
				�tens.Add(visitante);
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
			
			controle.Observa��oVisitante -= observa��oVisitante;
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
		/// �tens
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public Cole��oListaClientes�tem �tens
		{
			get { return �tens; }
		}

		/// <summary>
		/// N�mero de colunas a mostrar
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
		/// Dist�ncia entre colunas
		/// </summary>
		[DefaultValue(15)]
		public int Dist�nciaEntreColunas
		{
			get { return dist�nciaEntreColunas; }
			set
			{
				dist�nciaEntreColunas = value;
				Reorganizar();
			}
		}

		#endregion

		/// <summary>
		/// Reorganiza a visualiza��o da lista de clientes
		/// </summary>
		internal void Reorganizar()
		{
			int �temTamanho;				// Tamanho do �tem
			Point posi��o;
			int coluna = 0;

			// Suspender o layoute
			this.SuspendLayout();

			// Calcular tamanho dos �tens
			�temTamanho = this.Width / this.colunas - this.dist�nciaEntreColunas * (this.colunas - 1);
			posi��o = new Point(0, 0);

			foreach (ListaClientes�tem �tem in �tens)
			{
				�tem.Location = posi��o;
				�tem.Width    = �temTamanho;

				if (++coluna < this.colunas)
				{
					posi��o.X += �temTamanho + this.dist�nciaEntreColunas;
				}
				else
				{
					posi��o.X = 0;
					posi��o.Y += �tem.Height + dist�nciaEntreColunas;
					coluna = 0;
				}
			}

			// Reinicia o layout
			this.ResumeLayout();
		}

		/// <summary>
		/// Ocorre quando a lista � redimensionada
		/// </summary>
		private void ListaClientes_Resize(object sender, System.EventArgs e)
		{
			Reorganizar();
		}

		/// <summary>
		/// Ocorre quando um visitante altera seu estado
		/// </summary>
		public void controle_Observa��oVisitante(Observador.ISujeito sujeito, int a��o, object dados)
		{
			switch ((A��oVisitante) a��o)
			{
				case A��oVisitante.Entrou:
					�tens.Add((IVisitante) sujeito);
					break;
			}
		}

		/// <summary>
		/// Ocorre quando um �tem � selecionado
		/// </summary>
		/// <param name="�tem">�tem selecionado</param>
		/// <remarks>Chamado pela cole��o</remarks>
		internal void �temSelecionado(ListaClientes�tem �tem)
		{
			if (ClienteSelecionado != null)
				ClienteSelecionado(�tem.Visitante);
		}
	}
}
