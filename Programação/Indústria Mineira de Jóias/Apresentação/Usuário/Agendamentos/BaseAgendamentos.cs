using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting.Lifetime;

using Entidades;

namespace Apresentação.Usuário.Agendamentos
{
	/// <summary>
	/// Base inferior para agendamentos
	/// </summary>
	public sealed class BaseAgendamentos : Apresentação.Formulários.BaseInferior
	{
        private bool eventoOcorrendoCalendário;

        bool dentroEventoCalendário;								//criado para suprir bug do calendário

        private IContainer components;
        private Apresentação.Formulários.Quadro quadroAgendamentoAtual;
		private Apresentação.Formulários.Quadro quadroAgendamento;
		private System.Windows.Forms.MonthCalendar calendário;
		private Apresentação.Formulários.Opção opçãoNovoAgendamento;
		private Apresentação.Formulários.Opção opçãoAlterarAgendamentoAtual;
		private Apresentação.Formulários.Opção opçãoExcluirAgendamento;
		private Apresentação.Usuário.Agendamentos.ListaAgendamentos listaAgendamentos; 
		
		/// <summary>
		/// Constrói Agendamentos.
		/// </summary>
		public BaseAgendamentos()
		{
            components = null;

			InitializeComponent();
		
			eventoOcorrendoCalendário = false;				// resolve tilt do calendário
		}

        protected override void AoExibir()
        {
            base.AoExibir();

            CarregarListView(calendário.SelectionStart);
        }

		/// <summary>
		/// Libera recursos.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseAgendamentos));
            this.quadroAgendamentoAtual = new Apresentação.Formulários.Quadro();
            this.opçãoExcluirAgendamento = new Apresentação.Formulários.Opção();
            this.opçãoAlterarAgendamentoAtual = new Apresentação.Formulários.Opção();
            this.listaAgendamentos = new Apresentação.Usuário.Agendamentos.ListaAgendamentos();
            this.calendário = new System.Windows.Forms.MonthCalendar();
            this.quadroAgendamento = new Apresentação.Formulários.Quadro();
            this.opçãoNovoAgendamento = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadroAgendamentoAtual.SuspendLayout();
            this.quadroAgendamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroAgendamento);
            this.esquerda.Controls.Add(this.quadroAgendamentoAtual);
            this.esquerda.Size = new System.Drawing.Size(184, 432);
            this.esquerda.Controls.SetChildIndex(this.quadroAgendamentoAtual, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroAgendamento, 0);
            // 
            // quadroAgendamentoAtual
            // 
            this.quadroAgendamentoAtual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroAgendamentoAtual.bInfDirArredondada = true;
            this.quadroAgendamentoAtual.bInfEsqArredondada = true;
            this.quadroAgendamentoAtual.bSupDirArredondada = true;
            this.quadroAgendamentoAtual.bSupEsqArredondada = true;
            this.quadroAgendamentoAtual.Controls.Add(this.opçãoExcluirAgendamento);
            this.quadroAgendamentoAtual.Controls.Add(this.opçãoAlterarAgendamentoAtual);
            this.quadroAgendamentoAtual.Cor = System.Drawing.Color.Black;
            this.quadroAgendamentoAtual.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgendamentoAtual.LetraTítulo = System.Drawing.Color.White;
            this.quadroAgendamentoAtual.Location = new System.Drawing.Point(7, 75);
            this.quadroAgendamentoAtual.MostrarBotãoMinMax = false;
            this.quadroAgendamentoAtual.Name = "quadroAgendamentoAtual";
            this.quadroAgendamentoAtual.Size = new System.Drawing.Size(160, 71);
            this.quadroAgendamentoAtual.TabIndex = 4;
            this.quadroAgendamentoAtual.Tamanho = 30;
            this.quadroAgendamentoAtual.Título = "Agendamento Atual";
            this.quadroAgendamentoAtual.Visible = false;
            // 
            // opçãoExcluirAgendamento
            // 
            this.opçãoExcluirAgendamento.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluirAgendamento.Descrição = "Excluir";
            this.opçãoExcluirAgendamento.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoExcluirAgendamento.Imagem")));
            this.opçãoExcluirAgendamento.Location = new System.Drawing.Point(7, 50);
            this.opçãoExcluirAgendamento.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoExcluirAgendamento.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluirAgendamento.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluirAgendamento.Name = "opçãoExcluirAgendamento";
            this.opçãoExcluirAgendamento.Size = new System.Drawing.Size(150, 24);
            this.opçãoExcluirAgendamento.TabIndex = 6;
            this.opçãoExcluirAgendamento.Click += new System.EventHandler(this.opçãoExcluirAgendamento_Click);
            // 
            // opçãoAlterarAgendamentoAtual
            // 
            this.opçãoAlterarAgendamentoAtual.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAlterarAgendamentoAtual.Descrição = "Alterar";
            this.opçãoAlterarAgendamentoAtual.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAlterarAgendamentoAtual.Imagem")));
            this.opçãoAlterarAgendamentoAtual.Location = new System.Drawing.Point(7, 30);
            this.opçãoAlterarAgendamentoAtual.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoAlterarAgendamentoAtual.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAlterarAgendamentoAtual.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAlterarAgendamentoAtual.Name = "opçãoAlterarAgendamentoAtual";
            this.opçãoAlterarAgendamentoAtual.Size = new System.Drawing.Size(150, 16);
            this.opçãoAlterarAgendamentoAtual.TabIndex = 5;
            this.opçãoAlterarAgendamentoAtual.Click += new System.EventHandler(this.opçãoAlterarAgendamentoAtual_Click);
            // 
            // listaAgendamentos
            // 
            this.listaAgendamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaAgendamentos.BackColor = System.Drawing.Color.White;
            this.listaAgendamentos.Location = new System.Drawing.Point(192, 13);
            this.listaAgendamentos.Name = "listaAgendamentos";
            this.listaAgendamentos.Size = new System.Drawing.Size(329, 411);
            this.listaAgendamentos.TabIndex = 6;
            this.listaAgendamentos.MudouAgendamentoSelecionado += new Apresentação.Usuário.Agendamentos.ListaAgendamentos.Comando(this.listaAgendamentos_MudouAgendamentoSelecionado);
            // 
            // calendário
            // 
            this.calendário.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.calendário.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.calendário.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.calendário.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendário.Location = new System.Drawing.Point(533, 13);
            this.calendário.MaxSelectionCount = 1;
            this.calendário.Name = "calendário";
            this.calendário.TabIndex = 7;
            this.calendário.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendário_DateChanged);
            // 
            // quadroAgendamento
            // 
            this.quadroAgendamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroAgendamento.bInfDirArredondada = true;
            this.quadroAgendamento.bInfEsqArredondada = true;
            this.quadroAgendamento.bSupDirArredondada = true;
            this.quadroAgendamento.bSupEsqArredondada = true;
            this.quadroAgendamento.Controls.Add(this.opçãoNovoAgendamento);
            this.quadroAgendamento.Cor = System.Drawing.Color.Black;
            this.quadroAgendamento.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgendamento.LetraTítulo = System.Drawing.Color.White;
            this.quadroAgendamento.Location = new System.Drawing.Point(7, 13);
            this.quadroAgendamento.MostrarBotãoMinMax = false;
            this.quadroAgendamento.Name = "quadroAgendamento";
            this.quadroAgendamento.Size = new System.Drawing.Size(160, 56);
            this.quadroAgendamento.TabIndex = 5;
            this.quadroAgendamento.Tamanho = 30;
            this.quadroAgendamento.Título = "Agendamentos";
            // 
            // opçãoNovoAgendamento
            // 
            this.opçãoNovoAgendamento.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovoAgendamento.Descrição = "Novo agendamento";
            this.opçãoNovoAgendamento.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoNovoAgendamento.Imagem")));
            this.opçãoNovoAgendamento.Location = new System.Drawing.Point(7, 30);
            this.opçãoNovoAgendamento.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoNovoAgendamento.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovoAgendamento.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovoAgendamento.Name = "opçãoNovoAgendamento";
            this.opçãoNovoAgendamento.Size = new System.Drawing.Size(150, 24);
            this.opçãoNovoAgendamento.TabIndex = 2;
            this.opçãoNovoAgendamento.Click += new System.EventHandler(this.opçãoNovoAgendamento_Click);
            // 
            // BaseAgendamentos
            // 
            this.Controls.Add(this.listaAgendamentos);
            this.Controls.Add(this.calendário);
            this.Name = "BaseAgendamentos";
            this.Size = new System.Drawing.Size(760, 432);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.calendário, 0);
            this.Controls.SetChildIndex(this.listaAgendamentos, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroAgendamentoAtual.ResumeLayout(false);
            this.quadroAgendamento.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Carrega agendamentos no listview
		/// </summary>
		/// <param name="novaData"></param>
		void CarregarListView(DateTime novaData) 
		{
			Agendamento [] agendamentos;

			agendamentos = Agendamento.ObterAgendamentos(novaData);
			listaAgendamentos.PreencherListView(agendamentos);
			
			if (calendário.SelectionStart != novaData)
				calendário.SetDate(novaData);
		}

        /// <summary>
        /// Ocorer ao mudar o calendário.
        /// </summary>
		private void opçõesGenéricas_MudouCalendário(DateTime dataSelecionada)
		{
			if (eventoOcorrendoCalendário) 
			{
				this.Dispose();
				return;
			}
			else
			{
				eventoOcorrendoCalendário = true;
				CarregarListView(dataSelecionada);
				eventoOcorrendoCalendário = false;
			}
		}

		/// <summary>
		/// Altera um agendamento. 
		/// Para isso, abre a janela para usuário fazer alterações
		/// 
		/// Função usada em 2 lugares:
		///		- no balão, o usr pede mudança de horário
		///		- no evento OpçõesAgendamentos1 (Alterar)
		/// </summary>
		private void AbrirAlterar(Agendamento agendamentoAtual) 
		{
            using (InserirAgendamento dlg = new InserirAgendamento())
            {
                dlg.Descrição = agendamentoAtual.Descrição;
                dlg.Alarme = agendamentoAtual.Alarme;
                dlg.HoraEvento = agendamentoAtual.Data;

                dlg.ShowDialog();

                if (dlg.AtualizaçãoBemSucedida)
                {
                    agendamentoAtual.Data = dlg.HoraEvento;
                    agendamentoAtual.Descrição = dlg.Descrição;
                    if (dlg.Despertar)
                        agendamentoAtual.Alarme = dlg.Alarme;
                    else
                        agendamentoAtual.Alarme = DateTime.MinValue;

                    if (!agendamentoAtual.Cadastrado)
                        agendamentoAtual.Cadastrar();
                    else
                        agendamentoAtual.Atualizar();

                }
            }		

			CarregarListView(calendário.SelectionStart);
		}

		private void listaAgendamentos_MudouAgendamentoSelecionado()
		{
			quadroAgendamentoAtual.Visible = listaAgendamentos.EntidadesSelecionadas.Length != 0;
		}

		/// <summary>
		/// Ocorre ao clicar em novo agendamento.
		/// </summary>
		private void opçãoNovoAgendamento_Click(object sender, System.EventArgs e)
		{
			Agendamento novoAgendamento;

			using (InserirAgendamento dlg = new InserirAgendamento())
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					novoAgendamento      = new Agendamento();
					novoAgendamento.Data = dlg.HoraEvento;

					if (dlg.Despertar)
						novoAgendamento.Alarme = dlg.Alarme;

					novoAgendamento.Descrição = dlg.Descrição;
					novoAgendamento.Código    = -1;

					novoAgendamento.Cadastrar();
					
					CarregarListView(calendário.SelectionStart);
				}
			}		
		}

		/// <summary>
		/// Ocorre quando usuário clica em alterar agendamento.
		/// </summary>
		private void opçãoAlterarAgendamentoAtual_Click(object sender, System.EventArgs e)
		{
			if (listaAgendamentos.EntidadesSelecionadas.Length == 0)
			{
				MessageBox.Show("Selecione um agendamento antes");
				return;
			}

			foreach (Agendamento agendamento in listaAgendamentos.EntidadesSelecionadas) 
				AbrirAlterar(agendamento);
		}

		/// <summary>
		/// Ocorre ao clicar em excluir agendamento.
		/// </summary>
		private void opçãoExcluirAgendamento_Click(object sender, System.EventArgs e)
		{
			if (listaAgendamentos.EntidadesSelecionadas.Length == 0)
			{
				MessageBox.Show("Selecione um agendamento antes");
				return;
			}

			foreach (Agendamento agendamento in listaAgendamentos.EntidadesSelecionadas)
				agendamento.Descadastrar();

			CarregarListView(calendário.SelectionStart); 
		}

		//|André| Existe um bug nesse controle(calendário). as vezes, ele dispara esse evento n vezes (parece um loop),
		//uma chamada de evento por segundo. Para testar, clique em vários dias, e depois mude de mes.
		//mesmo sem que a data mude. 
		private void calendário_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			if (!dentroEventoCalendário)
			{
				dentroEventoCalendário = true;

				if (eventoOcorrendoCalendário) 
					return;
				else
				{
					eventoOcorrendoCalendário = true;
					CarregarListView(e.Start);
					eventoOcorrendoCalendário = false;
				}

				dentroEventoCalendário = false;
			}
		}

	}
}

