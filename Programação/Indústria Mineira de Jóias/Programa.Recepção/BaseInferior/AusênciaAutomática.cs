using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Apresenta��o.Atendimento.Comum;
using Apresenta��o.Atendimento.Atendente;
using Entidades.Pessoa;

namespace Programa.Recep��o.BaseInferior
{
	/// <summary>
	/// Base para confirmar aus�ncia autom�tica de funcion�rio.
	/// </summary>
	sealed class Aus�nciaAutom�tica : Apresenta��o.Formul�rios.BaseInferior, IComparer
	{
		// Atributos
		private ArrayList         listaFuncion�rios;

        public delegate void Funcion�rioDelegate(Funcion�rio funcion�rio);

		// Designer
		private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
		private Apresenta��o.Atendimento.Comum.ListaPessoas listaPessoas;
		private Apresenta��o.Formul�rios.Quadro quadro;
		private Apresenta��o.Formul�rios.Op��o op��oAtribuirAus�ncia;
		private Apresenta��o.Formul�rios.Op��o op��oAtribuirAus�nciaTodos;
		private System.Windows.Forms.Timer timer;
		private Apresenta��o.Formul�rios.Quadro quadroES;
		private Apresenta��o.Formul�rios.Op��o op��oVoltar;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i a base inferior.
		/// </summary>
		public Aus�nciaAutom�tica()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			listaFuncion�rios    = new ArrayList();
		}

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
		public override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
		{
			base.AoCarregarCompletamente(splash);

            try
            {
                lock (this)
                {
                    foreach (Funcion�rio funcion�rio in Funcion�rio.ObterFuncion�rios(true, false))
                        if (funcion�rio.Situa��o != EstadoFuncion�rio.Ausente)
                            listaFuncion�rios.Add(funcion�rio);

                    Entidades.Pessoa.TabelaHor�rio.Recuperar(listaFuncion�rios);

                    listaFuncion�rios.Sort(this);
                }

                if (VerificarAus�ncias() != null)
                    Exibir();

                timer.Enabled = true;
            }
            catch (Exception e)
            {
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
            }
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Aus�nciaAutom�tica));
			this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
			this.listaPessoas = new Apresenta��o.Atendimento.Comum.ListaPessoas();
			this.quadro = new Apresenta��o.Formul�rios.Quadro();
			this.op��oAtribuirAus�nciaTodos = new Apresenta��o.Formul�rios.Op��o();
			this.op��oAtribuirAus�ncia = new Apresenta��o.Formul�rios.Op��o();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.quadroES = new Apresenta��o.Formul�rios.Quadro();
			this.op��oVoltar = new Apresenta��o.Formul�rios.Op��o();
			this.esquerda.SuspendLayout();
			this.quadro.SuspendLayout();
			this.quadroES.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			this.esquerda.Controls.Add(this.quadroES);
			this.esquerda.Controls.Add(this.quadro);
			
			// 
			// t�tuloBaseInferior
			// 
			this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
			this.t�tuloBaseInferior.Descri��o = "O hor�rio de trabalho terminou para os funcion�rios abaixo. Para confirmar a aus�" +
				"ncia, basta clicar duas vezes nos nomes dos ausentes.";
			this.t�tuloBaseInferior.Imagem = ((System.Drawing.Image)(resources.GetObject("t�tuloBaseInferior.Imagem")));
			this.t�tuloBaseInferior.Location = new System.Drawing.Point(200, 8);
			this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
			this.t�tuloBaseInferior.Size = new System.Drawing.Size(584, 70);
			this.t�tuloBaseInferior.TabIndex = 6;
			this.t�tuloBaseInferior.T�tulo = "Hor�rio de trabalho";
			// 
			// listaPessoas
			// 
			this.listaPessoas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listaPessoas.AutoScroll = true;
			this.listaPessoas.Location = new System.Drawing.Point(200, 96);
			this.listaPessoas.Name = "listaPessoas";
			this.listaPessoas.Size = new System.Drawing.Size(584, 184);
			this.listaPessoas.TabIndex = 7;
			this.listaPessoas.PessoaInclu�da += new Apresenta��o.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaPessoas_PessoaInclu�da);
			this.listaPessoas.PessoaSelecionada += new Apresenta��o.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaPessoas_PessoaSelecionada);
			// 
			// quadro
			// 
			this.quadro.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadro.bInfDirArredondada = true;
			this.quadro.bInfEsqArredondada = true;
			this.quadro.bSupDirArredondada = true;
			this.quadro.bSupEsqArredondada = true;
			this.quadro.Controls.Add(this.op��oAtribuirAus�nciaTodos);
			this.quadro.Controls.Add(this.op��oAtribuirAus�ncia);
			this.quadro.Cor = System.Drawing.Color.Black;
			this.quadro.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadro.LetraT�tulo = System.Drawing.Color.White;
			this.quadro.Location = new System.Drawing.Point(8, 16);
			this.quadro.MostrarBot�oMinMax = false;
			this.quadro.Name = "quadro";
			this.quadro.Size = new System.Drawing.Size(160, 96);
			this.quadro.TabIndex = 0;
			this.quadro.Tamanho = 30;
			this.quadro.T�tulo = "Confirmar aus�ncia";
			// 
			// op��oAtribuirAus�nciaTodos
			// 
			this.op��oAtribuirAus�nciaTodos.BackColor = System.Drawing.Color.Transparent;
			this.op��oAtribuirAus�nciaTodos.Descri��o = "Atribuir aus�ncia a todos";
			this.op��oAtribuirAus�nciaTodos.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oAtribuirAus�nciaTodos.Imagem")));
			this.op��oAtribuirAus�nciaTodos.Location = new System.Drawing.Point(8, 64);
			this.op��oAtribuirAus�nciaTodos.Name = "op��oAtribuirAus�nciaTodos";
			this.op��oAtribuirAus�nciaTodos.Size = new System.Drawing.Size(150, 32);
			this.op��oAtribuirAus�nciaTodos.TabIndex = 3;
			// 
			// op��oAtribuirAus�ncia
			// 
			this.op��oAtribuirAus�ncia.BackColor = System.Drawing.Color.Transparent;
			this.op��oAtribuirAus�ncia.Descri��o = "Atribuir aus�ncia � sele��o";
			this.op��oAtribuirAus�ncia.Enabled = false;
			this.op��oAtribuirAus�ncia.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oAtribuirAus�ncia.Imagem")));
			this.op��oAtribuirAus�ncia.Location = new System.Drawing.Point(8, 32);
			this.op��oAtribuirAus�ncia.Name = "op��oAtribuirAus�ncia";
			this.op��oAtribuirAus�ncia.Size = new System.Drawing.Size(150, 32);
			this.op��oAtribuirAus�ncia.TabIndex = 2;
            //// 
            //// timer
            //// 
            //this.timer.Interval = 60000;
            //this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// quadroES
			// 
			this.quadroES.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroES.bInfDirArredondada = true;
			this.quadroES.bInfEsqArredondada = true;
			this.quadroES.bSupDirArredondada = true;
			this.quadroES.bSupEsqArredondada = true;
			this.quadroES.Controls.Add(this.op��oVoltar);
			this.quadroES.Cor = System.Drawing.Color.Black;
			this.quadroES.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroES.LetraT�tulo = System.Drawing.Color.White;
			this.quadroES.Location = new System.Drawing.Point(8, 120);
			this.quadroES.MostrarBot�oMinMax = false;
			this.quadroES.Name = "quadroES";
			this.quadroES.Size = new System.Drawing.Size(160, 64);
			this.quadroES.TabIndex = 1;
			this.quadroES.Tamanho = 30;
			this.quadroES.T�tulo = "Entrada e sa�da";
			// 
			// op��oVoltar
			// 
			this.op��oVoltar.BackColor = System.Drawing.Color.Transparent;
			this.op��oVoltar.Descri��o = "Voltar � tela de entrada e sa�da de visitantes";
			this.op��oVoltar.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oVoltar.Imagem")));
			this.op��oVoltar.Location = new System.Drawing.Point(8, 32);
			this.op��oVoltar.Name = "op��oVoltar";
			this.op��oVoltar.Size = new System.Drawing.Size(150, 32);
			this.op��oVoltar.TabIndex = 2;
			this.op��oVoltar.Click += new System.EventHandler(this.op��oVoltar_Click);
			// 
			// Aus�nciaAutom�tica
			// 
			this.Controls.Add(this.listaPessoas);
			this.Controls.Add(this.t�tuloBaseInferior);
			this.Name = "Aus�nciaAutom�tica";
			this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
			this.Controls.SetChildIndex(this.listaPessoas, 0);
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.esquerda.ResumeLayout(false);
			this.quadro.ResumeLayout(false);
			this.quadroES.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao selecionar uma pessoa.
		/// </summary>
		private void listaPessoas_PessoaSelecionada(Apresenta��o.Atendimento.Comum.ListaPessoasItem item)
		{
			op��oAtribuirAus�ncia.Enabled = item != null;
		}

		#region IComparer Members

		/// <summary>
		/// Compara dois funcion�rios pelo hor�rio mais pr�ximo de acabar.
		/// </summary>
		public int Compare(object x, object y)
		{
			try
			{
				Funcion�rio a, b;
				Hor�rio ha, hb;
				DateTime agora = DateTime.Now;

				a = (Funcion�rio) x;
				b = (Funcion�rio) y;

				ha = a.TabelaHor�rio.ObterHor�rioAtual();
				hb = b.TabelaHor�rio.ObterHor�rioAtual();

				if (ha == null && hb == null)
					return 0;

				if (hb == null)
					return -1;

				if (ha == null)
					return 1;

				// Comparar dia da semana
				if (ha.DiaSemana == agora.DayOfWeek && hb.DiaSemana != agora.DayOfWeek)
					return -1;
			
				else if (ha.DiaSemana != agora.DayOfWeek && hb.DiaSemana == agora.DayOfWeek)
					return 1;

				else if (ha.DiaSemana != agora.DayOfWeek)
					return ha.DiaSemana - hb.DiaSemana;

				// Comparar hora de t�rmino
				if (ha.FimHora != hb.FimHora)
					return ha.FimHora - hb.FimHora;
				else
					return ha.FimMinuto - hb.FimMinuto;
			}
			catch (Exception e)
			{
				MessageBox.Show("Ocorreu um erro enquanto organizava a tabela de hor�rio.\n\n" + e.ToString());
				throw new Exception("Ocorreu um erro enquanto organizava a tabela de hor�rio.", e);
			}
		}

		#endregion

		/// <summary>
		/// Verifica funcion�rios que podem se tornar ausentes devido
		/// ao hor�rio expirado.
		/// </summary>
		/// <returns>
		/// Lista de funcion�rios cujo hor�rio se expirou ou nulo,
		/// se n�o houver nenhum.</returns>
		private IList VerificarAus�ncias()
		{
			lock (this)
			{
				if (listaFuncion�rios.Count > 0)
				{
					int          idx = 0;
					Funcion�rio  entidade;
					Hor�rio      hor�rio;
					ArrayList    funcRemover;		// Funcion�rios a serem removidos.

					entidade    = (Funcion�rio) listaFuncion�rios[idx];
					hor�rio     = entidade.TabelaHor�rio.ObterHor�rioAtual();
					funcRemover = null;

					while (entidade != null && hor�rio != null && !hor�rio.Compreende(DateTime.Now))
					{
						/* Deve-se notificar apenas aqueles funcion�rios que
						 * n�o estiverem em atendimento. Para tanto, utiliza-se
						  * a vari�vel "idx" para fazer este controle.
						  */
						if (entidade.Situa��o != EstadoFuncion�rio.Atendendo)
						{
							if (funcRemover == null)
								funcRemover = new ArrayList();

                            funcRemover.Add(entidade);
                            //listaPessoas.Itens.Add(entidade);
							listaFuncion�rios.RemoveAt(idx);
						}
						else
							idx++;

						if (listaFuncion�rios.Count > idx)
						{
							entidade = (Funcion�rio)listaFuncion�rios[idx];
							hor�rio  = entidade.TabelaHor�rio.ObterHor�rioAtual();
						}
						else
						{
							entidade = null;
							hor�rio  = null;
						}
					}

					return funcRemover;
				}
			}

			return null;
		}

		/// <summary>
		/// Questiona se deseja atribuir aus�ncia a funcion�rio.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio cujo hor�rio de trabalho se expirou.</param>
		private void QuestionarFuncion�rio(Funcion�rio funcion�rio)
		{
			Formul�rios.EntradaSa�da.Notifica��oHor�rio dlg;

			dlg = new Programa.Recep��o.Formul�rios.EntradaSa�da.Notifica��oHor�rio(funcion�rio);

            dlg.Show();
		}

		/// <summary>
		/// Ocorre quando usu�rio clica em voltar � base inicial.
		/// </summary>
		private void op��oVoltar_Click(object sender, System.EventArgs e)
		{
			SubstituirBaseParaInicial();
		}

		/// <summary>
		/// Ocorre quando uma pessoa � inclu�da.
		/// </summary>
		/// <param name="item">Pessoa inclu�da.</param>
		private void listaPessoas_PessoaInclu�da(Apresenta��o.Atendimento.Comum.ListaPessoasItem item)
		{
			Apresenta��o.Atendimento.Atendente.ListaFuncion�rioItem itemFunc;

			itemFunc = (Apresenta��o.Atendimento.Atendente.ListaFuncion�rioItem) item;

			/* O funcion�rio n�o possui a tabela de hor�rio. Para n�o pedi-la
			 * novamente no banco de dados, pegar da lista local de funcion�rio.
			 */
			foreach (Entidades.Pessoa.Funcion�rio funcion�rio in listaFuncion�rios)
				if (funcion�rio.C�digo == itemFunc.Funcion�rio.C�digo)
				{
					itemFunc.Descri��o = funcion�rio.TabelaHor�rio.ObterHor�rioAtual().ToString();
					break;
				}
		}
	}
}

