using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using Acesso.Comum;

namespace Apresentação.Álbum
{
	/// <summary>
	/// ListaFoto é um controle de exibição e navegação do album. 
	/// 
	/// Existem duas threads:
	/// threadMiniaturas
	/// threadEntidades
	/// 
	/// threadEntidades
	/// funciona só quando a lista é carregada.
	/// Ela se encarrega de obter as entidades 'foto' do banco-de-dados
	/// 
	/// threadMiniaturas
	/// funciona sempre com o intuito de obter no banco de dados as miniaturas 
	/// das fotos exibidas. O código das entidades que precisam de fotos são empilhadas
	/// na pilha volátil pilhaCódMiniaturasPendentes. 
	/// </summary>
	public class ListaFoto : System.Windows.Forms.UserControl, IDisposable
	{
		// Atributos
		private	volatile ColeçãoItemFoto		itensFoto;
		private	ItemFoto						seleção = null;
		// Indica se lísta já contem todos os dados
		private bool							listagemAberta = false;
		
		// Posicionamento dos itens
		private	int                 itemTamanho;
		private	int                 colunaAtual;
		private	Point               posiçãoAtual;
		// Atributos vinculados à propriedade
		private int					colunas					= 4;
		private int					distânciaEntreColunas	= 15;
		
		/// <summary>
		/// Existe uma pilha onde para carregar as miniaturas dos controles.
		/// 
		/// Adicionar na pilha:
		/// - Assim que o item é mostrado na tela (itensFoto_ItemPaint)
		/// 
		/// Retirar da pilha:
		/// - Assim que o item some da tela
		/// - Assim que a miniatura do item é obtida.
		/// </summary>
		private volatile ArrayList pilhaCódMiniaturasPendentes = new ArrayList();
	
		// Delegates
		private delegate void FotosObtidas(ArrayList itensFoto);
		private delegate void MiniaturaObtida(int código, DbFoto miniatura);

		private FotosObtidas métodoObteveItemFoto;
		private MiniaturaObtida métodoObteveMiniatura;
		
		public event EventHandler ItemClicado;
	
		#region Propriedades

		/// <summary>
		/// Seleção atual.
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public ItemFoto Seleção
		{
			get 
			{ 
				if ((seleção == null) || (!seleção.Visible))
					return null;
				else
					return seleção;
			}
		}

		/// <summary>
		/// itensFoto
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public ColeçãoItemFoto ItensFoto
		{
			get { return itensFoto; }
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
		/// Reorganiza a visualização da lista de fotos
		/// 
		/// - Calcula a largura dos itens, que está em função da distância entre colunas 
		/// e do número de colunas.
		/// - Posicionar(cada item)
		/// - Refaz TabIndex de cada item
		/// </summary>
		public void Reorganizar()
		{
			if (!listagemAberta) return;

			Apresentação.Formulários.Aguarde aguarde = 
				new Apresentação.Formulários.Aguarde("Reorganizando miniaturas", itensFoto.Count);

			// Mostra a janela
            aguarde.Abrir();

			lock (this)
			{		
				// Suspender o layoute
				this.SuspendLayout();

				// Calcular a nova largura dos itensFoto
				itemTamanho  = (this.ClientSize.Width - 1) / this.colunas - 
					(this.distânciaEntreColunas * (this.colunas - 1)) / 2;

				if (this.Controls.Count > 0)
				{
					// Existem filhos, pode ser que o scrool não esteja na posição zero
					this.ScrollControlIntoView(this.Controls[0]);
				}
				
				posiçãoAtual = new Point(0, 0);
				
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
		/// Some com as referências que não começem com o 'inicioRef'
		/// </summary>
		/// <param name="inicioRef">Referência formatada</param>
		public void Filtrar(string inicioRef)
		{
			Apresentação.Formulários.Aguarde aguarde = 
				new Apresentação.Formulários.Aguarde("Filtrando fotos", itensFoto.Count);

			// Abre a janela
            aguarde.Abrir();

			this.SuspendLayout();
			foreach (ItemFoto item in itensFoto)
			{
				item.Visible = item.Entidade.ReferênciaFormatada.StartsWith(inicioRef);
				aguarde.Passo();
			}

			// Não precisa: é feito pelo Reorganizar!
			//this.ResumeLayout();

			// Fecha a janela
            aguarde.Fechar();

			Reorganizar();
		}

		/// <summary>
		/// Coloca o itemFoto na 'posiçãoAtual' e atualiza a posiçãoAtual.
		/// </summary>
		internal void Posicionar(ItemFoto item)
		{
			lock (this)
			{
				item.Location = posiçãoAtual;
				item.Width    = itemTamanho;

				if (++colunaAtual < this.colunas)
				{
					posiçãoAtual.X += itemTamanho + this.distânciaEntreColunas;
				}
				else
				{
					posiçãoAtual.X  = 0;
					posiçãoAtual.Y += item.Height + distânciaEntreColunas;
					colunaAtual     = 0;
				}
			}
		}

		
		public ListaFoto()
		{
			InitializeComponent();
			
			// Métodos invocados por threads.
			métodoObteveItemFoto = new FotosObtidas(AoObterEntidades);
			métodoObteveMiniatura = new MiniaturaObtida(MiniaturaFoiObtida);

			itensFoto = new ColeçãoItemFoto(this);
			itensFoto.ItemClicado += new EventHandler(itensFoto_ItemClicado);
			itensFoto.ItemEscondeu += new EventHandler(itensFoto_ItemEscondeu);
			itensFoto.ItemApareceu +=new EventHandler(itensFoto_ItemApareceu);
		}

		
		/// <summary>
		/// Pega a lista de 'Foto' obtida, gera uma entidade ItemFoto para cada
		/// e adiciona na coleção de itemFoto (objeto global itensFoto)
		/// </summary>
		/// <remarks>É chamado pela threadEntidades assim que as entidades foram obtidas</remarks>
		/// <param name="itensFoto"></param>
		private void AoObterEntidades(ArrayList obtidos)
		{
            using (Apresentação.Formulários.Aguarde aguarde =
                new Apresentação.Formulários.Aguarde("Abrindo miniaturas", obtidos.Count + 1))
            {
                aguarde.Show();
                aguarde.Refresh();

                ArrayList listaItensFoto = new ArrayList();

                foreach (Entidades.Álbum.Foto foto in obtidos)
                {
                    listaItensFoto.Add(new ItemFoto(foto));
                    aguarde.Passo();
                }

                aguarde.Passo("Inserindo fotos na coleção");
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
		/// <param name="código">chave primária da tabela foto</param>
		/// <param name="miniatura">miniatura recem obtida</param>
		private void MiniaturaFoiObtida(int código, DbFoto miniatura)
		{
			ItemFoto itemFoto = itensFoto.ObterItemFoto(código);
		
			itemFoto.Entidade.Miniatura = miniatura;
			itemFoto.MostrarMiniatura();
		}

		/// <summary>
		/// Roda assim que abre a lista, na abertura do programa. 
		/// Toda a preparação da thread está na #region Thread.
		/// 
		/// Deve carregar as entidades fotos, sem a foto em sí,
		/// e pedir que um método do domínio principal 
		/// crie o item da lista e adicione-o na lista.
		/// </summary>
		private void ProcessamentoThreadEntidades()
		{
			//ArrayList fotosCarregadas = Entidades.Álbum.Foto.ObterFotosSemFoto();

            //métodoObteveItemFoto(fotosCarregadas);
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
		/// Interrompe a threadMiniaturas com segurança.
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
			domíniothreadMiniaturas = Thread.GetDomain();
			
			int tentativas = 0;
			while (Acesso.Comum.Usuários.UsuárioAtual == null)
			{
				Thread.Sleep(500);
				tentativas++;
					
				if (tentativas == 6) throw new Exception("Não foi possível obter o usuário na threadMiniaturas 2");
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
                        if ((pilhaCódMiniaturasPendentes.Count > 200) && (pilhaCódMiniaturasPendentes.Count % 50) == 0) MessageBox.Show("Existem " + pilhaCódMiniaturasPendentes.Count.ToString() + " miniaturas em fila");
#endif

						uint código = (uint) pilhaCódMiniaturasPendentes[pilhaCódMiniaturasPendentes.Count - 1];
						pilhaCódMiniaturasPendentes.RemoveAt(pilhaCódMiniaturasPendentes.Count - 1);
						
						DbFoto miniatura = Entidades.Álbum.Foto.ObterMiniatura(código);
						
						this.Invoke(métodoObteveMiniatura, new object [] {código, miniatura} );

					} while (pilhaCódMiniaturasPendentes.Count != 0);
				}
			}
		}

		private void CarregarthreadMiniaturas()
		{
			// threadMiniaturas de obtenção de miniaturas
			threadMiniaturas = new Thread(new ThreadStart(LoopThreadMiniaturas));
            threadMiniaturas.Name = "ListaFoto - threadMiniaturas - obtenção de miniaturas";
            //threadMiniaturas.Priority = ThreadPriority.Normal;
			threadMiniaturas.Start();

			while (domíniothreadMiniaturas == null) Thread.Sleep(150);

			int tentativas = 0;
			while (Acesso.Comum.Usuários.UsuárioAtual == null)
			{
				Thread.Sleep(500);
				tentativas++;
					
				if (tentativas == 6) throw new Exception("Não foi possível obter o usuário na threadMiniaturas 1");
			}

			// Registra o usuário não nulo no contexto da threadMiniaturas
			domíniothreadMiniaturas.SetData("usuário", Acesso.Comum.Usuários.UsuárioAtual);
		}

		private volatile	AppDomain	domíniothreadMiniaturas = null;
		private				Thread		threadMiniaturas = null;

		// Lista de miniaturas esperando para obtenção de miniatura.
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
			seleção = (ItemFoto) sender;

			if (ItemClicado != null)
			ItemClicado(sender, e);
		}

		private void itensFoto_ItemEscondeu(object sender, EventArgs e)
		{
			if (pilhaCódMiniaturasPendentes.Contains(sender))
				pilhaCódMiniaturasPendentes.Remove(sender);
		}

		/// <summary>
		/// insere o código da foto do item na pilha de pendência de miniatura caso necessário.
		/// </summary>
		private void itensFoto_ItemApareceu(object sender, EventArgs e)
		{
			ItemFoto item = (ItemFoto) sender;
			
			// Caso já tenha sido carregada ou já está na pendência, faz nada.
			if (item.Entidade.MiniaturaObtida) 	return;
			
			//if (!pilhaCódMiniaturasPendentes.Contains(item.Entidade.Código)) 
				pilhaCódMiniaturasPendentes.Add(item.Entidade.Código);

			if (threadMiniaturas == null) CarregarthreadMiniaturas();
			InterromperthreadMiniaturas();

		}
	}
}
