using System;
using System.Collections;
using System.Windows.Forms;

namespace Apresentação.Usuário.Agendamentos
{
	public class ListaAgendamentos : System.Windows.Forms.UserControl
	{
		private Hashtable hashItemAgendamento = new Hashtable();

		private Apresentação.Formulários.Quadro quadroAgendamentos;
		private System.Windows.Forms.ListView lstAgendamentos;
		private System.Windows.Forms.ColumnHeader colDescrição;
		private System.Windows.Forms.ColumnHeader colHora;
		private System.Windows.Forms.ColumnHeader colDesperta;
		private System.Windows.Forms.ColumnHeader colCódigo;
		private System.ComponentModel.Container components = null;

		//Eventos
		public delegate void Comando();
		public event Comando MudouAgendamentoSelecionado;


		public ListaAgendamentos()
		{
			InitializeComponent();
			
			if (this.DesignMode)
				return;
		}

		#region Propriedades

		/// <summary>
		/// Obtém um vetor das entidades dos itens selecionados.
		/// </summary>
		public Entidades.Agendamento [] EntidadesSelecionadas
		{
			get
			{
				Entidades.Agendamento [] seleção 
					= new Entidades.Agendamento[lstAgendamentos.SelectedItems.Count];
				
				int contador = 0;

				foreach (ListViewItem item in lstAgendamentos.SelectedItems)
					seleção[contador++] = (Entidades.Agendamento) hashItemAgendamento[item];

				return seleção;
			}
		}
	
		#endregion

		public void PreencherListView(Entidades.Agendamento [] agendamentos)
		{
			lstAgendamentos.Items.Clear();
			ListViewItem item;
			for (int x = 0; x < agendamentos.Length; x++)
			{
				item = new ListViewItem(agendamentos[x].Código.ToString());
				item.SubItems.Add(agendamentos[x].Data.ToString("dd/MM HH:mm"));
				if (agendamentos[x].Despertar == true)
				{
					item.SubItems.Add(agendamentos[x].Alarme.ToString("dd/MM HH:mm"));
				} 
				else
				{
					item.SubItems.Add(" - ");
				}
				item.SubItems.Add(agendamentos[x].Descrição);
				lstAgendamentos.Items.Add(item);
				hashItemAgendamento[item] = agendamentos[x];
			}
			
			if (this.Created && MudouAgendamentoSelecionado != null)
				MudouAgendamentoSelecionado();
		}

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
			this.quadroAgendamentos = new Apresentação.Formulários.Quadro();
			this.lstAgendamentos = new System.Windows.Forms.ListView();
			this.colCódigo = new System.Windows.Forms.ColumnHeader();
			this.colHora = new System.Windows.Forms.ColumnHeader();
			this.colDesperta = new System.Windows.Forms.ColumnHeader();
			this.colDescrição = new System.Windows.Forms.ColumnHeader();
			this.quadroAgendamentos.SuspendLayout();
			this.SuspendLayout();
			// 
			// quadroAgendamentos
			// 
			this.quadroAgendamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadroAgendamentos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(231)), ((System.Byte)(202)));
			this.quadroAgendamentos.bInfDirArredondada = true;
			this.quadroAgendamentos.bInfEsqArredondada = true;
			this.quadroAgendamentos.bSupDirArredondada = true;
			this.quadroAgendamentos.bSupEsqArredondada = true;
			this.quadroAgendamentos.Controls.Add(this.lstAgendamentos);
			this.quadroAgendamentos.Cor = System.Drawing.Color.Black;
			this.quadroAgendamentos.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroAgendamentos.LetraTítulo = System.Drawing.Color.White;
			this.quadroAgendamentos.Location = new System.Drawing.Point(0, 0);
			this.quadroAgendamentos.Name = "quadroAgendamentos";
			this.quadroAgendamentos.Size = new System.Drawing.Size(440, 368);
			this.quadroAgendamentos.TabIndex = 1;
			this.quadroAgendamentos.Tamanho = 30;
			this.quadroAgendamentos.Título = "Agendamentos";
			// 
			// lstAgendamentos
			// 
			this.lstAgendamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lstAgendamentos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lstAgendamentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.colCódigo,
																							  this.colHora,
																							  this.colDesperta,
																							  this.colDescrição});
			this.lstAgendamentos.FullRowSelect = true;
			this.lstAgendamentos.GridLines = true;
			this.lstAgendamentos.Location = new System.Drawing.Point(8, 32);
			this.lstAgendamentos.Name = "lstAgendamentos";
			this.lstAgendamentos.Size = new System.Drawing.Size(424, 328);
			this.lstAgendamentos.TabIndex = 1;
			this.lstAgendamentos.View = System.Windows.Forms.View.Details;
			this.lstAgendamentos.SelectedIndexChanged += new System.EventHandler(this.lstAgendamentos_SelectedIndexChanged);
			// 
			// colCódigo
			// 
			this.colCódigo.Text = "Código";
			this.colCódigo.Width = 0;
			// 
			// colHora
			// 
			this.colHora.Text = "Compromisso";
			this.colHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colHora.Width = 80;
			// 
			// colDesperta
			// 
			this.colDesperta.Text = "Lembrete";
			this.colDesperta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colDesperta.Width = 80;
			// 
			// colDescrição
			// 
			this.colDescrição.Text = "Descrição";
			this.colDescrição.Width = 1000;
			// 
			// ListaAgendamentos
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.quadroAgendamentos);
			this.Name = "ListaAgendamentos";
			this.Size = new System.Drawing.Size(440, 368);
			this.quadroAgendamentos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void lstAgendamentos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (MudouAgendamentoSelecionado != null)
			    MudouAgendamentoSelecionado();  
		}
	}
}
