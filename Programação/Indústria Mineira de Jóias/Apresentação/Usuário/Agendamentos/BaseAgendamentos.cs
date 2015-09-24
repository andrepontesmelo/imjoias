using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting.Lifetime;

using Entidades;

namespace Apresenta��o.Usu�rio.Agendamentos
{
	/// <summary>
	/// Base inferior para agendamentos
	/// </summary>
	public sealed class BaseAgendamentos : Apresenta��o.Formul�rios.BaseInferior
	{
        private bool eventoOcorrendoCalend�rio;

        bool dentroEventoCalend�rio;								//criado para suprir bug do calend�rio

        private IContainer components;
        private Apresenta��o.Formul�rios.Quadro quadroAgendamentoAtual;
		private Apresenta��o.Formul�rios.Quadro quadroAgendamento;
		private System.Windows.Forms.MonthCalendar calend�rio;
		private Apresenta��o.Formul�rios.Op��o op��oNovoAgendamento;
		private Apresenta��o.Formul�rios.Op��o op��oAlterarAgendamentoAtual;
		private Apresenta��o.Formul�rios.Op��o op��oExcluirAgendamento;
		private Apresenta��o.Usu�rio.Agendamentos.ListaAgendamentos listaAgendamentos; 
		
		/// <summary>
		/// Constr�i Agendamentos.
		/// </summary>
		public BaseAgendamentos()
		{
            components = null;

			InitializeComponent();
		
			eventoOcorrendoCalend�rio = false;				// resolve tilt do calend�rio
		}

        protected override void AoExibir()
        {
            base.AoExibir();

            CarregarListView(calend�rio.SelectionStart);
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
            this.quadroAgendamentoAtual = new Apresenta��o.Formul�rios.Quadro();
            this.op��oExcluirAgendamento = new Apresenta��o.Formul�rios.Op��o();
            this.op��oAlterarAgendamentoAtual = new Apresenta��o.Formul�rios.Op��o();
            this.listaAgendamentos = new Apresenta��o.Usu�rio.Agendamentos.ListaAgendamentos();
            this.calend�rio = new System.Windows.Forms.MonthCalendar();
            this.quadroAgendamento = new Apresenta��o.Formul�rios.Quadro();
            this.op��oNovoAgendamento = new Apresenta��o.Formul�rios.Op��o();
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
            this.quadroAgendamentoAtual.Controls.Add(this.op��oExcluirAgendamento);
            this.quadroAgendamentoAtual.Controls.Add(this.op��oAlterarAgendamentoAtual);
            this.quadroAgendamentoAtual.Cor = System.Drawing.Color.Black;
            this.quadroAgendamentoAtual.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgendamentoAtual.LetraT�tulo = System.Drawing.Color.White;
            this.quadroAgendamentoAtual.Location = new System.Drawing.Point(7, 75);
            this.quadroAgendamentoAtual.MostrarBot�oMinMax = false;
            this.quadroAgendamentoAtual.Name = "quadroAgendamentoAtual";
            this.quadroAgendamentoAtual.Size = new System.Drawing.Size(160, 71);
            this.quadroAgendamentoAtual.TabIndex = 4;
            this.quadroAgendamentoAtual.Tamanho = 30;
            this.quadroAgendamentoAtual.T�tulo = "Agendamento Atual";
            this.quadroAgendamentoAtual.Visible = false;
            // 
            // op��oExcluirAgendamento
            // 
            this.op��oExcluirAgendamento.BackColor = System.Drawing.Color.Transparent;
            this.op��oExcluirAgendamento.Descri��o = "Excluir";
            this.op��oExcluirAgendamento.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oExcluirAgendamento.Imagem")));
            this.op��oExcluirAgendamento.Location = new System.Drawing.Point(7, 50);
            this.op��oExcluirAgendamento.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oExcluirAgendamento.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oExcluirAgendamento.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oExcluirAgendamento.Name = "op��oExcluirAgendamento";
            this.op��oExcluirAgendamento.Size = new System.Drawing.Size(150, 24);
            this.op��oExcluirAgendamento.TabIndex = 6;
            this.op��oExcluirAgendamento.Click += new System.EventHandler(this.op��oExcluirAgendamento_Click);
            // 
            // op��oAlterarAgendamentoAtual
            // 
            this.op��oAlterarAgendamentoAtual.BackColor = System.Drawing.Color.Transparent;
            this.op��oAlterarAgendamentoAtual.Descri��o = "Alterar";
            this.op��oAlterarAgendamentoAtual.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oAlterarAgendamentoAtual.Imagem")));
            this.op��oAlterarAgendamentoAtual.Location = new System.Drawing.Point(7, 30);
            this.op��oAlterarAgendamentoAtual.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oAlterarAgendamentoAtual.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oAlterarAgendamentoAtual.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oAlterarAgendamentoAtual.Name = "op��oAlterarAgendamentoAtual";
            this.op��oAlterarAgendamentoAtual.Size = new System.Drawing.Size(150, 16);
            this.op��oAlterarAgendamentoAtual.TabIndex = 5;
            this.op��oAlterarAgendamentoAtual.Click += new System.EventHandler(this.op��oAlterarAgendamentoAtual_Click);
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
            this.listaAgendamentos.MudouAgendamentoSelecionado += new Apresenta��o.Usu�rio.Agendamentos.ListaAgendamentos.Comando(this.listaAgendamentos_MudouAgendamentoSelecionado);
            // 
            // calend�rio
            // 
            this.calend�rio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.calend�rio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.calend�rio.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.calend�rio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calend�rio.Location = new System.Drawing.Point(533, 13);
            this.calend�rio.MaxSelectionCount = 1;
            this.calend�rio.Name = "calend�rio";
            this.calend�rio.TabIndex = 7;
            this.calend�rio.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calend�rio_DateChanged);
            // 
            // quadroAgendamento
            // 
            this.quadroAgendamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroAgendamento.bInfDirArredondada = true;
            this.quadroAgendamento.bInfEsqArredondada = true;
            this.quadroAgendamento.bSupDirArredondada = true;
            this.quadroAgendamento.bSupEsqArredondada = true;
            this.quadroAgendamento.Controls.Add(this.op��oNovoAgendamento);
            this.quadroAgendamento.Cor = System.Drawing.Color.Black;
            this.quadroAgendamento.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgendamento.LetraT�tulo = System.Drawing.Color.White;
            this.quadroAgendamento.Location = new System.Drawing.Point(7, 13);
            this.quadroAgendamento.MostrarBot�oMinMax = false;
            this.quadroAgendamento.Name = "quadroAgendamento";
            this.quadroAgendamento.Size = new System.Drawing.Size(160, 56);
            this.quadroAgendamento.TabIndex = 5;
            this.quadroAgendamento.Tamanho = 30;
            this.quadroAgendamento.T�tulo = "Agendamentos";
            // 
            // op��oNovoAgendamento
            // 
            this.op��oNovoAgendamento.BackColor = System.Drawing.Color.Transparent;
            this.op��oNovoAgendamento.Descri��o = "Novo agendamento";
            this.op��oNovoAgendamento.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oNovoAgendamento.Imagem")));
            this.op��oNovoAgendamento.Location = new System.Drawing.Point(7, 30);
            this.op��oNovoAgendamento.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oNovoAgendamento.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oNovoAgendamento.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oNovoAgendamento.Name = "op��oNovoAgendamento";
            this.op��oNovoAgendamento.Size = new System.Drawing.Size(150, 24);
            this.op��oNovoAgendamento.TabIndex = 2;
            this.op��oNovoAgendamento.Click += new System.EventHandler(this.op��oNovoAgendamento_Click);
            // 
            // BaseAgendamentos
            // 
            this.Controls.Add(this.listaAgendamentos);
            this.Controls.Add(this.calend�rio);
            this.Name = "BaseAgendamentos";
            this.Size = new System.Drawing.Size(760, 432);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.calend�rio, 0);
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
			
			if (calend�rio.SelectionStart != novaData)
				calend�rio.SetDate(novaData);
		}

        /// <summary>
        /// Ocorer ao mudar o calend�rio.
        /// </summary>
		private void op��esGen�ricas_MudouCalend�rio(DateTime dataSelecionada)
		{
			if (eventoOcorrendoCalend�rio) 
			{
				this.Dispose();
				return;
			}
			else
			{
				eventoOcorrendoCalend�rio = true;
				CarregarListView(dataSelecionada);
				eventoOcorrendoCalend�rio = false;
			}
		}

		/// <summary>
		/// Altera um agendamento. 
		/// Para isso, abre a janela para usu�rio fazer altera��es
		/// 
		/// Fun��o usada em 2 lugares:
		///		- no bal�o, o usr pede mudan�a de hor�rio
		///		- no evento Op��esAgendamentos1 (Alterar)
		/// </summary>
		private void AbrirAlterar(Agendamento agendamentoAtual) 
		{
            using (InserirAgendamento dlg = new InserirAgendamento())
            {
                dlg.Descri��o = agendamentoAtual.Descri��o;
                dlg.Alarme = agendamentoAtual.Alarme;
                dlg.HoraEvento = agendamentoAtual.Data;

                dlg.ShowDialog();

                if (dlg.Atualiza��oBemSucedida)
                {
                    agendamentoAtual.Data = dlg.HoraEvento;
                    agendamentoAtual.Descri��o = dlg.Descri��o;
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

			CarregarListView(calend�rio.SelectionStart);
		}

		private void listaAgendamentos_MudouAgendamentoSelecionado()
		{
			quadroAgendamentoAtual.Visible = listaAgendamentos.EntidadesSelecionadas.Length != 0;
		}

		/// <summary>
		/// Ocorre ao clicar em novo agendamento.
		/// </summary>
		private void op��oNovoAgendamento_Click(object sender, System.EventArgs e)
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

					novoAgendamento.Descri��o = dlg.Descri��o;
					novoAgendamento.C�digo    = -1;

					novoAgendamento.Cadastrar();
					
					CarregarListView(calend�rio.SelectionStart);
				}
			}		
		}

		/// <summary>
		/// Ocorre quando usu�rio clica em alterar agendamento.
		/// </summary>
		private void op��oAlterarAgendamentoAtual_Click(object sender, System.EventArgs e)
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
		private void op��oExcluirAgendamento_Click(object sender, System.EventArgs e)
		{
			if (listaAgendamentos.EntidadesSelecionadas.Length == 0)
			{
				MessageBox.Show("Selecione um agendamento antes");
				return;
			}

			foreach (Agendamento agendamento in listaAgendamentos.EntidadesSelecionadas)
				agendamento.Descadastrar();

			CarregarListView(calend�rio.SelectionStart); 
		}

		//|Andr�| Existe um bug nesse controle(calend�rio). as vezes, ele dispara esse evento n vezes (parece um loop),
		//uma chamada de evento por segundo. Para testar, clique em v�rios dias, e depois mude de mes.
		//mesmo sem que a data mude. 
		private void calend�rio_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			if (!dentroEventoCalend�rio)
			{
				dentroEventoCalend�rio = true;

				if (eventoOcorrendoCalend�rio) 
					return;
				else
				{
					eventoOcorrendoCalend�rio = true;
					CarregarListView(e.Start);
					eventoOcorrendoCalend�rio = false;
				}

				dentroEventoCalend�rio = false;
			}
		}

	}
}

