using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Consultas
{
	/// <summary>
	/// Summary description for ListViewFuncionários.
	/// </summary>
	public class ListViewFuncionários : System.Windows.Forms.UserControl, IComparer
	{
		// Atributos
		private List<Funcionário>   funcionários = null;
		private Hashtable			linhas;
		private Setor				ênfaseSetor = null;
		private Font				fontÊnfase;
		private int					ordenaçãoColuna = 0;

		// Designer
		private System.Windows.Forms.ListView lstFuncionários;
		public System.Windows.Forms.ColumnHeader colNome;
        public System.Windows.Forms.ColumnHeader colSetor;
		public System.Windows.Forms.ColumnHeader colRamal;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ListViewFuncionários()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			if (this.DesignMode)
				return;

			linhas = new Hashtable();

			fontÊnfase = new Font(lstFuncionários.Font, FontStyle.Bold);

			lstFuncionários.ListViewItemSorter = this;
		}

		/// <summary>
		/// Lista de funcionários
		/// </summary>
		public IEnumerable<Funcionário> Funcionários
		{
			get
			{
				return funcionários;
			}
			set
			{
				if (this.DesignMode)
					return;

				if (value == null)
					return;

				if (funcionários != null)
				{
					linhas.Clear();
					lstFuncionários.Items.Clear();
				}

				funcionários = new List<Funcionário>();

				foreach (Funcionário funcionário in value)
					AdicionarFuncionário(funcionário);
			}
		}

        /// <summary>
        /// Adiciona funcionário à lista.
        /// </summary>
        /// <param name="funcionário">Funcionário à ser adicionado.</param>
		private void AdicionarFuncionário(Funcionário funcionário)
		{
			ListViewItem linha;

			// Inserir linha
			linha = new ListViewItem(funcionário.Nome);
			linha.SubItems.Add(funcionário.Ramal.ToString());
			linha.SubItems.Add(funcionário.Setor != null ?
				funcionário.Setor.Nome :
				"");

			if (ênfaseSetor != null)
				linha.Font = (funcionário.Setor == ênfaseSetor ?
				fontÊnfase : lstFuncionários.Font);

			lstFuncionários.Items.Add(linha);
			linhas[funcionário.Código] = linha;
			linhas[linha] = funcionário;

			funcionários.Add(funcionário);
		}

		/// <summary>
		/// Ênfase nos funcionários de um setor específico
		/// </summary>
		public Setor ÊnfaseSetor
		{
			get { return ênfaseSetor; }
			set
			{
				ênfaseSetor = value;

				if (this.DesignMode)
					return;

				if (value != null)
				{
					foreach (ListViewItem linha in lstFuncionários.Items)
					{
						Funcionário funcionário;
						
						funcionário = (Funcionário) linhas[linha];

						linha.Font = (funcionário.Setor == ênfaseSetor ?
							fontÊnfase : lstFuncionários.Font);
					}
				}
				else
				{
					foreach (ListViewItem linha in lstFuncionários.Items)
						linha.Font = lstFuncionários.Font;
				}
			}
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
            this.lstFuncionários = new System.Windows.Forms.ListView();
            this.colNome = new System.Windows.Forms.ColumnHeader();
            this.colRamal = new System.Windows.Forms.ColumnHeader();
            this.colSetor = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstVendedores
            // 
            this.lstFuncionários.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colRamal,
            this.colSetor});
            this.lstFuncionários.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFuncionários.FullRowSelect = true;
            this.lstFuncionários.HideSelection = false;
            this.lstFuncionários.Location = new System.Drawing.Point(0, 0);
            this.lstFuncionários.MultiSelect = false;
            this.lstFuncionários.Name = "lstFuncionários";
            this.lstFuncionários.Size = new System.Drawing.Size(336, 96);
            this.lstFuncionários.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstFuncionários.TabIndex = 1;
            this.lstFuncionários.UseCompatibleStateImageBehavior = false;
            this.lstFuncionários.View = System.Windows.Forms.View.Details;
            this.lstFuncionários.DoubleClick += new System.EventHandler(this.lstFuncionários_DoubleClick);
            this.lstFuncionários.SelectedIndexChanged += new System.EventHandler(this.lstFuncionários_SelectedIndexChanged);
            this.lstFuncionários.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstFuncionários_ColumnClick);
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 178;
            // 
            // colRamal
            // 
            this.colRamal.Text = "Ramal";
            this.colRamal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRamal.Width = 53;
            // 
            // colSetor
            // 
            this.colSetor.Text = "Setor";
            this.colSetor.Width = 86;
            // 
            // ListViewFuncionários
            // 
            this.Controls.Add(this.lstFuncionários);
            this.Name = "ListViewFuncionários";
            this.Size = new System.Drawing.Size(336, 96);
            this.VisibleChanged += new System.EventHandler(this.ListViewFuncionários_VisibleChanged);
            this.ResumeLayout(false);

		}
		#endregion

		public event EventHandler SelectedIndexChanged;

		private void lstFuncionários_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SelectedIndexChanged != null)
				SelectedIndexChanged(sender, e);
		}

		private void lstFuncionários_DoubleClick(object sender, System.EventArgs e)
		{
			this.OnDoubleClick(e);
		}

		public Funcionário FuncionárioSelecionado
		{
			get
			{
				if (lstFuncionários.SelectedItems.Count != 1)
					return null;

				return (Funcionário) linhas[lstFuncionários.SelectedItems[0]];
			}
		}

		public override object InitializeLifetimeService()
		{
			return null;
		}

		/// <summary>
		/// Procura um funcionário cujo nome se inicia
		/// com um especificado.
		/// </summary>
		/// <param name="nome">Prefixo do nome a ser
		/// procurado nos funcionários</param>
		public void Procurar(string nome)
		{
			foreach (ListViewItem linha in lstFuncionários.Items)
			{
				if (string.Compare(linha.Text, 0, nome, 0, nome.Length, true) == 0)
				{
					linha.Selected = true;
					linha.Focused = true;
					linha.EnsureVisible();
					return;
				}
			}
		}

		private void lstFuncionários_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			if (ordenaçãoColuna == e.Column)
			{
				if (lstFuncionários.Sorting == SortOrder.Descending)
					lstFuncionários.Sorting = SortOrder.Ascending;
				else
					lstFuncionários.Sorting = SortOrder.Descending;
			}
			else
			{
				ordenaçãoColuna = e.Column;
				lstFuncionários.Sorting = SortOrder.Ascending;
			}

			lstFuncionários.Sort();
		}

		#region IComparer Members

		public int Compare(object x, object y)
		{
			return ((ListViewItem) x).SubItems[ordenaçãoColuna].Text.CompareTo(((ListViewItem) y).SubItems[ordenaçãoColuna].Text);
		}

		#endregion

		/// <summary>
		/// Ocorre quando a lista muda sua visibilidade
		/// </summary>
		private void ListViewFuncionários_VisibleChanged(object sender, System.EventArgs e)
		{
			if (this.Visible && lstFuncionários.SelectedItems.Count > 0)
				lstFuncionários.SelectedItems[0].EnsureVisible();
		}
	}
}
