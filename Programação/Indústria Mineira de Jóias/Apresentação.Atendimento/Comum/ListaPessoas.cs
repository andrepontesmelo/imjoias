using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Atendimento.Comum
{
	/// <summary>
	/// Lista de clientes
	/// </summary>
	[Serializable]
	public class ListaPessoas : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Tamanho ideal de um item.
		/// </summary>
		private const int tamanhoItemIdeal = 250;			// Pixels

		// Atributos
		protected ColeçãoListaPessoasItem	itens;
		private   Point                     posiçãoAtual;
		private   int                       itemTamanho;	// Tamanho do item
		private   int                       colunaAtual;
		private   SinalizaçãoCarga          sinalização;
		private   ListaPessoasItem          seleção;
		private   bool                      autoColunas = true;

		// Propriedades
		private int							colunas					= 2;
		private int							distânciaEntreColunas	= 15;

		// Eventos
		public delegate void PessoaSelecionadaDelegate(ListaPessoasItem item);
		public event PessoaSelecionadaDelegate PessoaSelecionada;
		public event PessoaSelecionadaDelegate PessoaIncluída;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constrói lista de clientes
		/// </summary>
		public ListaPessoas()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Construir atributos
			itens       = new ColeçãoListaPessoasItem(this);
			sinalização = null;
			seleção     = null;
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ListaPessoas
			// 
			this.AutoScroll = true;
			this.Name = "ListaPessoas";
			this.Size = new System.Drawing.Size(288, 152);
			this.Resize += new System.EventHandler(this.ListaClientes_Resize);
			this.Load += new System.EventHandler(this.ListaPessoas_Load);

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// Seleção atual.
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public ListaPessoasItem Seleção
		{
			get { return seleção; }
		}

		/// <summary>
		/// Itens
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public ColeçãoListaPessoasItem Itens
		{
			get { return itens; }
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
		/// Determina se o número de colunas será atribuído automaticamente.
		/// </summary>
		[DefaultValue(true), Description("Se verdadeiro, determina o número de colunas automaticamente.")]
		public bool AutoColunas
		{
			get { return autoColunas; }
			set
			{
				autoColunas = value;

				if (value)
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
			int colunas;

			if (autoColunas)
				colunas = (int) Math.Max(1, Math.Floor((double) ClientSize.Width / (double) tamanhoItemIdeal));
			else
				colunas = this.colunas;

			lock (this)
			{
				// Suspender o layoute
				this.SuspendLayout();

				// Calcular tamanho dos itens
				itemTamanho  = (this.ClientSize.Width - 1) / colunas - (distânciaEntreColunas * (colunas - 1)) / 2;
				posiçãoAtual = new Point(0, 0);
				colunaAtual  = 0;

				int contador = 0;

				foreach (ListaPessoasItem item in itens)
				{
					Posicionar(item, colunas);
					item.TabIndex = contador++;
				}

				// Reinicia o layout
				this.ResumeLayout();
			}
		}

		/// <param name="item">Item a ser exibido.</param>
		internal void Posicionar(ListaPessoasItem item, int colunas)
		{
			lock (this)
			{
				item.Location = posiçãoAtual;
				item.Width    = itemTamanho;

				if (++colunaAtual < colunas)
				{
					posiçãoAtual.X += itemTamanho + distânciaEntreColunas;
				}
				else
				{
					posiçãoAtual.X  = 0;
					posiçãoAtual.Y += item.Height + distânciaEntreColunas;
					colunaAtual     = 0;
				}
			}
		}

		/// <summary>
		/// Ocorre quando a lista é redimensionada
		/// </summary>
		private void ListaClientes_Resize(object sender, System.EventArgs e)
		{
			Reorganizar();
		}

		/// <summary>
		/// Ocorre quando um item é selecionado pelo mouse.
		/// </summary>
		/// <param name="item">Item selecionado</param>
		/// <remarks>Chamado pela coleção</remarks>
		internal void ItemSelecionado(ListaPessoasItem item)
		{
			seleção = item;

			if (PessoaSelecionada != null)
				PessoaSelecionada(item);
		}

		/// <summary>
		/// Ocorre quando um item é clicado duas vezes.
		/// </summary>
		/// <param name="item">Item selecionado.</param>
		/// <remarks>Chamado pela coleção.</remarks>
		internal void ItemDuploClique(ListaPessoasItem item)
		{
			seleção = item;

			if (PessoaSelecionada != null)
				PessoaSelecionada(item);

			OnDoubleClick(new EventArgs());
		}

		/// <summary>
		/// Ocorre quando a lista de pessoas é carregada.
		/// </summary>
		private void ListaPessoas_Load(object sender, System.EventArgs e)
		{
			// Mostrar uma demonstração caso em modo design
			if (DesignMode && itens.Count == 0)
			{
				itens.Add("Aqui pode vir um nome", "Aqui pode vir outro nome", "Aqui pode vir alguma descrição");
				itens.Add("Fulano", "Zé Mané da Cunha", "Eis mais uma demonstração");
				itens.Add("Hamlet", "Dom Casmurro", "Iracema");
			}

			Reorganizar();
		}

		/// <summary>
		/// Sinaliza que a lista está carregando.
		/// </summary>
		public void SinalizarCarga()
		{
			AdicionarSinalização(new SinalizaçãoCarga());
		}

		/// <summary>
		/// Sinaliza que a lista está carregando.
		/// </summary>
		/// <param name="descrição">Descrição personalizada.</param>
		public void SinalizarCarga(string descrição)
		{
			AdicionarSinalização(new SinalizaçãoCarga(descrição));
		}

		/// <summary>
		/// Sinaliza que a lista está carregando.
		/// </summary>
		/// <param name="título">Título personalizado.</param>
		/// <param name="descrição">Descrição personalizada.</param>
		public void SinalizarCarga(string título, string descrição)
		{
			AdicionarSinalização(new SinalizaçãoCarga(título, descrição));
		}

		/// <summary>
		/// Adiciona sinalização ao controle.
		/// </summary>
		/// <param name="sinalização">Sinalização a ser adicionada.</param>
		private void AdicionarSinalização(SinalizaçãoCarga sinalização)
		{
			lock (this)
			{
				if (sinalização != null)
					Dessinalizar();
			
				this.sinalização = sinalização;

				this.SuspendLayout();
				
				this.Controls.Add(sinalização);

				sinalização.Location = new Point(
					(ClientSize.Width - sinalização.Width) / 2,
					(ClientSize.Height - sinalização.Height) / 2);

				sinalização.BringToFront();

				this.ResumeLayout();
			}
		}

		/// <summary>
		/// Remove sinalização.
		/// </summary>
		public void Dessinalizar()
		{
			lock (this)
			{
				if (sinalização != null)
				{
					this.SuspendLayout();
					this.Controls.Remove(sinalização);
					this.ResumeLayout();
					
					sinalização.Dispose();

					sinalização = null;
				}
			}
		}

		/// <summary>
		/// Altera mensagem que está sendo exibida na sinalização.
		/// </summary>
		/// <param name="título">Título da sinalização.</param>
		/// <param name="descrição">Descrição da sinalização.</param>
		public void Ressinalizar(string título, string descrição)
		{
			if (sinalização == null)
				throw new NullReferenceException("Ressinalizar só pode ser chamado quando alguma sinalização for exibida.");

			sinalização.Título = título;
			sinalização.Descrição = descrição;
		}

		/// <summary>
		/// Auto-ordenação da lista de itens.
		/// </summary>
		[DefaultValue(true)]
		public bool AutoOrdenação
		{
			get { return itens.AutoOrdenação; }
			set { itens.AutoOrdenação = value; }
		}

		/// <summary>
		/// Dispara evento de pessoa incluída.
		/// </summary>
		/// <param name="item">Pessoa incluída.</param>
		internal void DispararPessoaIncluída(ListaPessoasItem item)
		{
			if (PessoaIncluída != null)
				PessoaIncluída(item);
		}
	}
}
