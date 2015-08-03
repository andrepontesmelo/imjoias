using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using Acesso.Comum;

namespace Apresenta��o.�lbum
{
	/// <summary>
	/// ListaFoto � um controle de exibi��o e navega��o do album. 
	/// 
	/// Existem duas threads:
	/// threadMiniaturas
	/// threadEntidades
	/// 
	/// threadEntidades
	/// funciona s� quando a lista � carregada.
	/// Ela se encarrega de obter as entidades 'foto' do banco-de-dados
	/// 
	/// threadMiniaturas
	/// funciona sempre com o intuito de obter no banco de dados as miniaturas 
	/// das fotos exibidas. O c�digo das entidades que precisam de fotos s�o empilhadas
	/// na pilha vol�til pilhaC�dMiniaturasPendentes. 
	/// </summary>
	public class ListaFoto : System.Windows.Forms.UserControl, IDisposable
	{
		// Atributos
		private	volatile Cole��oItemFoto		itensFoto;
		private	ItemFoto						sele��o = null;
		// Indica se l�sta j� contem todos os dados
		private bool							listagemAberta = false;
		
		// Posicionamento dos itens
		private	int                 itemTamanho;
		private	int                 colunaAtual;
		private	Point               posi��oAtual;
		// Atributos vinculados � propriedade
		private int					colunas					= 4;
		private int					dist�nciaEntreColunas	= 15;
		
		/// <summary>
		/// Existe uma pilha onde para carregar as miniaturas dos controles.
		/// 
		/// Adicionar na pilha:
		/// - Assim que o item � mostrado na tela (itensFoto_ItemPaint)
		/// 
		/// Retirar da pilha:
		/// - Assim que o item some da tela
		/// - Assim que a miniatura do item � obtida.
		/// </summary>
		private volatile ArrayList pilhaC�dMiniaturasPendentes = new ArrayList();
	
		// Delegates
		private delegate void FotosObtidas(ArrayList itensFoto);
		private delegate void MiniaturaObtida(int c�digo, DbFoto miniatura);

		private FotosObtidas m�todoObteveItemFoto;
		private MiniaturaObtida m�todoObteveMiniatura;
		
		public event EventHandler ItemClicado;
	
		#region Propriedades

		/// <summary>
		/// Sele��o atual.
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public ItemFoto Sele��o
		{
			get 
			{ 
				if ((sele��o == null) || (!sele��o.Visible))
					return null;
				else
					return sele��o;
			}
		}

		/// <summary>
		/// itensFoto
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public Cole��oItemFoto ItensFoto
		{
			get { return itensFoto; }
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
		/// Reorganiza a visualiza��o da lista de fotos
		/// 
		/// - Calcula a largura dos itens, que est� em fun��o da dist�ncia entre colunas 
		/// e do n�mero de colunas.
		/// - Posicionar(cada item)
		/// - Refaz TabIndex de cada item
		/// </summary>
		public void Reorganizar()
		{
			if (!listagemAberta) return;

			Apresenta��o.Formul�rios.Aguarde aguarde = 
				new Apresenta��o.Formul�rios.Aguarde("Reorganizando miniaturas", itensFoto.Count);

			// Mostra a janela
            aguarde.Abrir();

			lock (this)
			{		
				// Suspender o layoute
				this.SuspendLayout();

				// Calcular a nova largura dos itensFoto
				itemTamanho  = (this.ClientSize.Width - 1) / this.colunas - 
					(this.dist�nciaEntreColunas * (this.colunas - 1)) / 2;

				if (this.Controls.Count > 0)
				{
					// Existem filhos, pode ser que o scrool n�o esteja na posi��o zero
					this.ScrollControlIntoView(this.Controls[0]);
				}
				
				posi��oAtual = new Point(0, 0);
				
				colunaAtual  = 0;

				int contador = 0;

				
				foreach (ItemFoto item in itensFoto)
				{
					if (item.Visible)
					{
						Posicionar(item);
						item.TabIndex = contador++;
						aguarde.Passo();
					}
				}

				// Reinicia o layout
				this.ResumeLayout();

				aguarde.Close(); aguarde.Dispose();
			}
		}

		/// <summary>
		/// Some com as refer�ncias que n�o come�em com o 'inicioRef'
		/// </summary>
		/// <param name="inicioRef">Refer�ncia formatada</param>
		public void Filtrar(string inicioRef)
		{
			Apresenta��o.Formul�rios.Aguarde aguarde = 
				new Apresenta��o.Formul�rios.Aguarde("Filtrando fotos", itensFoto.Count);

			// Abre a janela
            aguarde.Abrir();

			this.SuspendLayout();
			foreach (ItemFoto item in itensFoto)
			{
				item.Visible = item.Entidade.Refer�nciaFormatada.StartsWith(inicioRef);
				aguarde.Passo();
			}

			// N�o precisa: � feito pelo Reorganizar!
			//this.ResumeLayout();

			// Fecha a janela
            aguarde.Fechar();

			Reorganizar();
		}

		/// <summary>
		/// Coloca o itemFoto na 'posi��oAtual' e atualiza a posi��oAtual.
		/// </summary>
		internal void Posicionar(ItemFoto item)
		{
			lock (this)
			{
				item.Location = posi��oAtual;
				item.Width    = itemTamanho;

				if (++colunaAtual < this.colunas)
				{
					posi��oAtual.X += itemTamanho + this.dist�nciaEntreColunas;
				}
				else
				{
					posi��oAtual.X  = 0;
					posi��oAtual.Y += item.Height + dist�nciaEntreColunas;
					colunaAtual     = 0;
				}
			}
		}

		
		public ListaFoto()
		{
			InitializeComponent();
			
			// M�todos invocados por threads.
			m�todoObteveItemFoto = new FotosObtidas(AoObterEntidades);
			m�todoObteveMiniatura = new MiniaturaObtida(MiniaturaFoiObtida);

			itensFoto = new Cole��oItemFoto(this);
			itensFoto.ItemClicado += new EventHandler(itensFoto_ItemClicado);
			itensFoto.ItemEscondeu += new EventHandler(itensFoto_ItemEscondeu);
			itensFoto.ItemApareceu +=new EventHandler(itensFoto_ItemApareceu);
		}

		
		/// <summary>
		/// Pega a lista de 'Foto' obtida, gera uma entidade ItemFoto para cada
		/// e adiciona na cole��o de itemFoto (objeto global itensFoto)
		/// </summary>
		/// <remarks>� chamado pela threadEntidades assim que as entidades foram obtidas</remarks>
		/// <param name="itensFoto"></param>
		private void AoObterEntidades(ArrayList obtidos)
		{
            using (Apresenta��o.Formul�rios.Aguarde aguarde =
                new Apresenta��o.Formul�rios.Aguarde("Abrindo miniaturas", obtidos.Count + 1))
            {
                aguarde.Show();
                aguarde.Refresh();

                ArrayList listaItensFoto = new ArrayList();

                foreach (Entidades.�lbum.Foto foto in obtidos)
                {
                    listaItensFoto.Add(new ItemFoto(foto));
                    aguarde.Passo();
                }

                aguarde.Passo("Inserindo fotos na cole��o");
                listagemAberta = true;

                itensFoto.AddRange(listaItensFoto);
                aguarde.Fechar();
            }
		}

		/// <summary>
		/// i)   obtem o itemFoto da miniatura
		/// ii)  registra a miniatura no itemFoto
		/// iii) solicita item para exibe a foto
		/// </summary>
		/// <param name="c�digo">chave prim�ria da tabela foto</param>
		/// <param name="miniatura">miniatura recem obtida</param>
		private void MiniaturaFoiObtida(int c�digo, DbFoto miniatura)
		{
			ItemFoto itemFoto = itensFoto.ObterItemFoto(c�digo);
		
			itemFoto.Entidade.Miniatura = miniatura;
			itemFoto.MostrarMiniatura();
		}

		/// <summary>
		/// Roda assim que abre a lista, na abertura do programa. 
		/// Toda a prepara��o da thread est� na #region Thread.
		/// 
		/// Deve carregar as entidades fotos, sem a foto em s�,
		/// e pedir que um m�todo do dom�nio principal 
		/// crie o item da lista e adicione-o na lista.
		/// </summary>
		private void ProcessamentoThreadEntidades()
		{
			//ArrayList fotosCarregadas = Entidades.�lbum.Foto.ObterFotosSemFoto();

            //m�todoObteveItemFoto(fotosCarregadas);
		}

		#region Thread -> threadEntidades 
		
		// Thread
		private				Thread				threadEntidades;

		/// <summary>
		/// Em thread separada, carrega a lista das entidades
		/// 'fotos' do banco de dados, (sem as fotos nem miniaturas)
		/// e ainda gera os controles ItemFoto. 
		/// </summary>
		public void CarregarLista()
		{
			if (DesignMode) return;

			threadEntidades  = new Thread(new ThreadStart(ProcessamentoThreadEntidades));
            threadEntidades.Name = "ListaFoto - threadEntidades - carrega fotos sem miniaturas";
            //threadEntidades.Priority = ThreadPriority.Normal;

			threadEntidades.Start();
		}

		#endregion

		#region Thread -> threadMiniaturas

		/// <summary>
		/// Interrompe a threadMiniaturas com seguran�a.
		/// </summary>
		private void InterromperthreadMiniaturas()
		{
			if (!pesquisandoMiniaturas)
			{
				pesquisandoMiniaturas = true;
				threadMiniaturas.Interrupt();
			} 
		}

		private void LoopThreadMiniaturas()
		{
			dom�niothreadMiniaturas = Thread.GetDomain();
			
			int tentativas = 0;
			while (Acesso.Comum.Usu�rios.Usu�rioAtual == null)
			{
				Thread.Sleep(500);
				tentativas++;
					
				if (tentativas == 6) throw new Exception("N�o foi poss�vel obter o usu�rio na threadMiniaturas 2");
			}

			
			while (true)
			{
				try
				{
					pesquisandoMiniaturas = false;
					Thread.Sleep(Timeout.Infinite);
				}
				catch (ThreadInterruptedException)
				{
					pesquisandoMiniaturas = true;

					do
					{
#if DEBUG
                        if ((pilhaC�dMiniaturasPendentes.Count > 200) && (pilhaC�dMiniaturasPendentes.Count % 50) == 0) MessageBox.Show("Existem " + pilhaC�dMiniaturasPendentes.Count.ToString() + " miniaturas em fila");
#endif

						uint c�digo = (uint) pilhaC�dMiniaturasPendentes[pilhaC�dMiniaturasPendentes.Count - 1];
						pilhaC�dMiniaturasPendentes.RemoveAt(pilhaC�dMiniaturasPendentes.Count - 1);
						
						DbFoto miniatura = Entidades.�lbum.Foto.ObterMiniatura(c�digo);
						
						this.Invoke(m�todoObteveMiniatura, new object [] {c�digo, miniatura} );

					} while (pilhaC�dMiniaturasPendentes.Count != 0);
				}
			}
		}

		private void CarregarthreadMiniaturas()
		{
			// threadMiniaturas de obten��o de miniaturas
			threadMiniaturas = new Thread(new ThreadStart(LoopThreadMiniaturas));
            threadMiniaturas.Name = "ListaFoto - threadMiniaturas - obten��o de miniaturas";
            //threadMiniaturas.Priority = ThreadPriority.Normal;
			threadMiniaturas.Start();

			while (dom�niothreadMiniaturas == null) Thread.Sleep(150);

			int tentativas = 0;
			while (Acesso.Comum.Usu�rios.Usu�rioAtual == null)
			{
				Thread.Sleep(500);
				tentativas++;
					
				if (tentativas == 6) throw new Exception("N�o foi poss�vel obter o usu�rio na threadMiniaturas 1");
			}

			// Registra o usu�rio n�o nulo no contexto da threadMiniaturas
			dom�niothreadMiniaturas.SetData("usu�rio", Acesso.Comum.Usu�rios.Usu�rioAtual);
		}

		private volatile	AppDomain	dom�niothreadMiniaturas = null;
		private				Thread		threadMiniaturas = null;

		// Lista de miniaturas esperando para obten��o de miniatura.
		private volatile bool			pesquisandoMiniaturas = false;


		#endregion

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				// Desliga a thread de entidades
				if (threadEntidades != null)
				{
					try
					{
						threadEntidades.Abort();
					}
					catch {};

					if ((threadEntidades.ThreadState & ThreadState.WaitSleepJoin) > 0)
						threadEntidades.Interrupt();

					threadEntidades = null;
				}

				// Desliga a threadMiniaturas
				if (threadMiniaturas != null)
				{
					try
					{
						threadMiniaturas.Abort();
					}
					catch {};

					if ((threadMiniaturas.ThreadState & ThreadState.WaitSleepJoin) > 0)
						threadMiniaturas.Interrupt();

					threadMiniaturas = null;
				}


				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );

		}

		#region Component Designer generated code
		
		private System.ComponentModel.Container components = null;

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ListaFoto
			// 
			this.AutoScroll = true;
			this.Name = "ListaFoto";
			this.Size = new System.Drawing.Size(304, 248);

		}
		#endregion

		private void itensFoto_ItemClicado(object sender, EventArgs e)
		{
			sele��o = (ItemFoto) sender;

			if (ItemClicado != null)
			ItemClicado(sender, e);
		}

		private void itensFoto_ItemEscondeu(object sender, EventArgs e)
		{
			if (pilhaC�dMiniaturasPendentes.Contains(sender))
				pilhaC�dMiniaturasPendentes.Remove(sender);
		}

		/// <summary>
		/// insere o c�digo da foto do item na pilha de pend�ncia de miniatura caso necess�rio.
		/// </summary>
		private void itensFoto_ItemApareceu(object sender, EventArgs e)
		{
			ItemFoto item = (ItemFoto) sender;
			
			// Caso j� tenha sido carregada ou j� est� na pend�ncia, faz nada.
			if (item.Entidade.MiniaturaObtida) 	return;
			
			//if (!pilhaC�dMiniaturasPendentes.Contains(item.Entidade.C�digo)) 
				pilhaC�dMiniaturasPendentes.Add(item.Entidade.C�digo);

			if (threadMiniaturas == null) CarregarthreadMiniaturas();
			InterromperthreadMiniaturas();

		}
	}
}
