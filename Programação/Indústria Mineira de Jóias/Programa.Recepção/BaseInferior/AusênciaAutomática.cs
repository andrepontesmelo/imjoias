using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Apresentação.Atendimento.Comum;
using Apresentação.Atendimento.Atendente;
using Entidades.Pessoa;

namespace Programa.Recepção.BaseInferior
{
	/// <summary>
	/// Base para confirmar ausência automática de funcionário.
	/// </summary>
	sealed class AusênciaAutomática : Apresentação.Formulários.BaseInferior, IComparer
	{
		// Atributos
		private ArrayList         listaFuncionários;

        public delegate void FuncionárioDelegate(Funcionário funcionário);

		// Designer
		private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
		private Apresentação.Atendimento.Comum.ListaPessoas listaPessoas;
		private Apresentação.Formulários.Quadro quadro;
		private Apresentação.Formulários.Opção opçãoAtribuirAusência;
		private Apresentação.Formulários.Opção opçãoAtribuirAusênciaTodos;
		private System.Windows.Forms.Timer timer;
		private Apresentação.Formulários.Quadro quadroES;
		private Apresentação.Formulários.Opção opçãoVoltar;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói a base inferior.
		/// </summary>
		public AusênciaAutomática()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			listaFuncionários    = new ArrayList();
		}

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
		public override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
		{
			base.AoCarregarCompletamente(splash);

            try
            {
                lock (this)
                {
                    foreach (Funcionário funcionário in Funcionário.ObterFuncionários(true, false))
                        if (funcionário.Situação != EstadoFuncionário.Ausente)
                            listaFuncionários.Add(funcionário);

                    Entidades.Pessoa.TabelaHorário.Recuperar(listaFuncionários);

                    listaFuncionários.Sort(this);
                }

                if (VerificarAusências() != null)
                    Exibir();

                timer.Enabled = true;
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AusênciaAutomática));
			this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
			this.listaPessoas = new Apresentação.Atendimento.Comum.ListaPessoas();
			this.quadro = new Apresentação.Formulários.Quadro();
			this.opçãoAtribuirAusênciaTodos = new Apresentação.Formulários.Opção();
			this.opçãoAtribuirAusência = new Apresentação.Formulários.Opção();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.quadroES = new Apresentação.Formulários.Quadro();
			this.opçãoVoltar = new Apresentação.Formulários.Opção();
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
			// títuloBaseInferior
			// 
			this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
			this.títuloBaseInferior.Descrição = "O horário de trabalho terminou para os funcionários abaixo. Para confirmar a ausê" +
				"ncia, basta clicar duas vezes nos nomes dos ausentes.";
			this.títuloBaseInferior.Imagem = ((System.Drawing.Image)(resources.GetObject("títuloBaseInferior.Imagem")));
			this.títuloBaseInferior.Location = new System.Drawing.Point(200, 8);
			this.títuloBaseInferior.Name = "títuloBaseInferior";
			this.títuloBaseInferior.Size = new System.Drawing.Size(584, 70);
			this.títuloBaseInferior.TabIndex = 6;
			this.títuloBaseInferior.Título = "Horário de trabalho";
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
			this.listaPessoas.PessoaIncluída += new Apresentação.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaPessoas_PessoaIncluída);
			this.listaPessoas.PessoaSelecionada += new Apresentação.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaPessoas_PessoaSelecionada);
			// 
			// quadro
			// 
			this.quadro.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadro.bInfDirArredondada = true;
			this.quadro.bInfEsqArredondada = true;
			this.quadro.bSupDirArredondada = true;
			this.quadro.bSupEsqArredondada = true;
			this.quadro.Controls.Add(this.opçãoAtribuirAusênciaTodos);
			this.quadro.Controls.Add(this.opçãoAtribuirAusência);
			this.quadro.Cor = System.Drawing.Color.Black;
			this.quadro.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadro.LetraTítulo = System.Drawing.Color.White;
			this.quadro.Location = new System.Drawing.Point(8, 16);
			this.quadro.MostrarBotãoMinMax = false;
			this.quadro.Name = "quadro";
			this.quadro.Size = new System.Drawing.Size(160, 96);
			this.quadro.TabIndex = 0;
			this.quadro.Tamanho = 30;
			this.quadro.Título = "Confirmar ausência";
			// 
			// opçãoAtribuirAusênciaTodos
			// 
			this.opçãoAtribuirAusênciaTodos.BackColor = System.Drawing.Color.Transparent;
			this.opçãoAtribuirAusênciaTodos.Descrição = "Atribuir ausência a todos";
			this.opçãoAtribuirAusênciaTodos.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAtribuirAusênciaTodos.Imagem")));
			this.opçãoAtribuirAusênciaTodos.Location = new System.Drawing.Point(8, 64);
			this.opçãoAtribuirAusênciaTodos.Name = "opçãoAtribuirAusênciaTodos";
			this.opçãoAtribuirAusênciaTodos.Size = new System.Drawing.Size(150, 32);
			this.opçãoAtribuirAusênciaTodos.TabIndex = 3;
			// 
			// opçãoAtribuirAusência
			// 
			this.opçãoAtribuirAusência.BackColor = System.Drawing.Color.Transparent;
			this.opçãoAtribuirAusência.Descrição = "Atribuir ausência à seleção";
			this.opçãoAtribuirAusência.Enabled = false;
			this.opçãoAtribuirAusência.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAtribuirAusência.Imagem")));
			this.opçãoAtribuirAusência.Location = new System.Drawing.Point(8, 32);
			this.opçãoAtribuirAusência.Name = "opçãoAtribuirAusência";
			this.opçãoAtribuirAusência.Size = new System.Drawing.Size(150, 32);
			this.opçãoAtribuirAusência.TabIndex = 2;
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
			this.quadroES.Controls.Add(this.opçãoVoltar);
			this.quadroES.Cor = System.Drawing.Color.Black;
			this.quadroES.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroES.LetraTítulo = System.Drawing.Color.White;
			this.quadroES.Location = new System.Drawing.Point(8, 120);
			this.quadroES.MostrarBotãoMinMax = false;
			this.quadroES.Name = "quadroES";
			this.quadroES.Size = new System.Drawing.Size(160, 64);
			this.quadroES.TabIndex = 1;
			this.quadroES.Tamanho = 30;
			this.quadroES.Título = "Entrada e saída";
			// 
			// opçãoVoltar
			// 
			this.opçãoVoltar.BackColor = System.Drawing.Color.Transparent;
			this.opçãoVoltar.Descrição = "Voltar à tela de entrada e saída de visitantes";
			this.opçãoVoltar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVoltar.Imagem")));
			this.opçãoVoltar.Location = new System.Drawing.Point(8, 32);
			this.opçãoVoltar.Name = "opçãoVoltar";
			this.opçãoVoltar.Size = new System.Drawing.Size(150, 32);
			this.opçãoVoltar.TabIndex = 2;
			this.opçãoVoltar.Click += new System.EventHandler(this.opçãoVoltar_Click);
			// 
			// AusênciaAutomática
			// 
			this.Controls.Add(this.listaPessoas);
			this.Controls.Add(this.títuloBaseInferior);
			this.Name = "AusênciaAutomática";
			this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
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
		private void listaPessoas_PessoaSelecionada(Apresentação.Atendimento.Comum.ListaPessoasItem item)
		{
			opçãoAtribuirAusência.Enabled = item != null;
		}

		#region IComparer Members

		/// <summary>
		/// Compara dois funcionários pelo horário mais próximo de acabar.
		/// </summary>
		public int Compare(object x, object y)
		{
			try
			{
				Funcionário a, b;
				Horário ha, hb;
				DateTime agora = DateTime.Now;

				a = (Funcionário) x;
				b = (Funcionário) y;

				ha = a.TabelaHorário.ObterHorárioAtual();
				hb = b.TabelaHorário.ObterHorárioAtual();

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

				// Comparar hora de término
				if (ha.FimHora != hb.FimHora)
					return ha.FimHora - hb.FimHora;
				else
					return ha.FimMinuto - hb.FimMinuto;
			}
			catch (Exception e)
			{
				MessageBox.Show("Ocorreu um erro enquanto organizava a tabela de horário.\n\n" + e.ToString());
				throw new Exception("Ocorreu um erro enquanto organizava a tabela de horário.", e);
			}
		}

		#endregion

		/// <summary>
		/// Verifica funcionários que podem se tornar ausentes devido
		/// ao horário expirado.
		/// </summary>
		/// <returns>
		/// Lista de funcionários cujo horário se expirou ou nulo,
		/// se não houver nenhum.</returns>
		private IList VerificarAusências()
		{
			lock (this)
			{
				if (listaFuncionários.Count > 0)
				{
					int          idx = 0;
					Funcionário  entidade;
					Horário      horário;
					ArrayList    funcRemover;		// Funcionários a serem removidos.

					entidade    = (Funcionário) listaFuncionários[idx];
					horário     = entidade.TabelaHorário.ObterHorárioAtual();
					funcRemover = null;

					while (entidade != null && horário != null && !horário.Compreende(DateTime.Now))
					{
						/* Deve-se notificar apenas aqueles funcionários que
						 * não estiverem em atendimento. Para tanto, utiliza-se
						  * a variável "idx" para fazer este controle.
						  */
						if (entidade.Situação != EstadoFuncionário.Atendendo)
						{
							if (funcRemover == null)
								funcRemover = new ArrayList();

                            funcRemover.Add(entidade);
                            //listaPessoas.Itens.Add(entidade);
							listaFuncionários.RemoveAt(idx);
						}
						else
							idx++;

						if (listaFuncionários.Count > idx)
						{
							entidade = (Funcionário)listaFuncionários[idx];
							horário  = entidade.TabelaHorário.ObterHorárioAtual();
						}
						else
						{
							entidade = null;
							horário  = null;
						}
					}

					return funcRemover;
				}
			}

			return null;
		}

		/// <summary>
		/// Questiona se deseja atribuir ausência a funcionário.
		/// </summary>
		/// <param name="funcionário">Funcionário cujo horário de trabalho se expirou.</param>
		private void QuestionarFuncionário(Funcionário funcionário)
		{
			Formulários.EntradaSaída.NotificaçãoHorário dlg;

			dlg = new Programa.Recepção.Formulários.EntradaSaída.NotificaçãoHorário(funcionário);

            dlg.Show();
		}

		/// <summary>
		/// Ocorre quando usuário clica em voltar à base inicial.
		/// </summary>
		private void opçãoVoltar_Click(object sender, System.EventArgs e)
		{
			SubstituirBaseParaInicial();
		}

		/// <summary>
		/// Ocorre quando uma pessoa é incluída.
		/// </summary>
		/// <param name="item">Pessoa incluída.</param>
		private void listaPessoas_PessoaIncluída(Apresentação.Atendimento.Comum.ListaPessoasItem item)
		{
			Apresentação.Atendimento.Atendente.ListaFuncionárioItem itemFunc;

			itemFunc = (Apresentação.Atendimento.Atendente.ListaFuncionárioItem) item;

			/* O funcionário não possui a tabela de horário. Para não pedi-la
			 * novamente no banco de dados, pegar da lista local de funcionário.
			 */
			foreach (Entidades.Pessoa.Funcionário funcionário in listaFuncionários)
				if (funcionário.Código == itemFunc.Funcionário.Código)
				{
					itemFunc.Descrição = funcionário.TabelaHorário.ObterHorárioAtual().ToString();
					break;
				}
		}
	}
}

