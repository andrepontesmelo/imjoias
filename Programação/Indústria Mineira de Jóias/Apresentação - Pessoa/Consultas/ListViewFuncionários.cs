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

namespace Apresenta��o.Pessoa.Consultas
{
	/// <summary>
	/// Summary description for ListViewFuncion�rios.
	/// </summary>
	public class ListViewFuncion�rios : System.Windows.Forms.UserControl, IComparer
	{
		// Atributos
		private List<Funcion�rio>   funcion�rios = null;
		private Hashtable			linhas;
		private Setor				�nfaseSetor = null;
		private Font				font�nfase;
		private int					ordena��oColuna = 0;

		// Designer
		private System.Windows.Forms.ListView lstFuncion�rios;
		public System.Windows.Forms.ColumnHeader colNome;
        public System.Windows.Forms.ColumnHeader colSetor;
		public System.Windows.Forms.ColumnHeader colRamal;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ListViewFuncion�rios()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			if (this.DesignMode)
				return;

			linhas = new Hashtable();

			font�nfase = new Font(lstFuncion�rios.Font, FontStyle.Bold);

			lstFuncion�rios.ListViewItemSorter = this;
		}

		/// <summary>
		/// Lista de funcion�rios
		/// </summary>
		public IEnumerable<Funcion�rio> Funcion�rios
		{
			get
			{
				return funcion�rios;
			}
			set
			{
				if (this.DesignMode)
					return;

				if (value == null)
					return;

				if (funcion�rios != null)
				{
					linhas.Clear();
					lstFuncion�rios.Items.Clear();
				}

				funcion�rios = new List<Funcion�rio>();

				foreach (Funcion�rio funcion�rio in value)
					AdicionarFuncion�rio(funcion�rio);
			}
		}

        /// <summary>
        /// Adiciona funcion�rio � lista.
        /// </summary>
        /// <param name="funcion�rio">Funcion�rio � ser adicionado.</param>
		private void AdicionarFuncion�rio(Funcion�rio funcion�rio)
		{
			ListViewItem linha;

			// Inserir linha
			linha = new ListViewItem(funcion�rio.Nome);
			linha.SubItems.Add(funcion�rio.Ramal.ToString());
			linha.SubItems.Add(funcion�rio.Setor != null ?
				funcion�rio.Setor.Nome :
				"");

			if (�nfaseSetor != null)
				linha.Font = (funcion�rio.Setor == �nfaseSetor ?
				font�nfase : lstFuncion�rios.Font);

			lstFuncion�rios.Items.Add(linha);
			linhas[funcion�rio.C�digo] = linha;
			linhas[linha] = funcion�rio;

			funcion�rios.Add(funcion�rio);
		}

		/// <summary>
		/// �nfase nos funcion�rios de um setor espec�fico
		/// </summary>
		public Setor �nfaseSetor
		{
			get { return �nfaseSetor; }
			set
			{
				�nfaseSetor = value;

				if (this.DesignMode)
					return;

				if (value != null)
				{
					foreach (ListViewItem linha in lstFuncion�rios.Items)
					{
						Funcion�rio funcion�rio;
						
						funcion�rio = (Funcion�rio) linhas[linha];

						linha.Font = (funcion�rio.Setor == �nfaseSetor ?
							font�nfase : lstFuncion�rios.Font);
					}
				}
				else
				{
					foreach (ListViewItem linha in lstFuncion�rios.Items)
						linha.Font = lstFuncion�rios.Font;
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
            this.lstFuncion�rios = new System.Windows.Forms.ListView();
            this.colNome = new System.Windows.Forms.ColumnHeader();
            this.colRamal = new System.Windows.Forms.ColumnHeader();
            this.colSetor = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstVendedores
            // 
            this.lstFuncion�rios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colRamal,
            this.colSetor});
            this.lstFuncion�rios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFuncion�rios.FullRowSelect = true;
            this.lstFuncion�rios.HideSelection = false;
            this.lstFuncion�rios.Location = new System.Drawing.Point(0, 0);
            this.lstFuncion�rios.MultiSelect = false;
            this.lstFuncion�rios.Name = "lstFuncion�rios";
            this.lstFuncion�rios.Size = new System.Drawing.Size(336, 96);
            this.lstFuncion�rios.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstFuncion�rios.TabIndex = 1;
            this.lstFuncion�rios.UseCompatibleStateImageBehavior = false;
            this.lstFuncion�rios.View = System.Windows.Forms.View.Details;
            this.lstFuncion�rios.DoubleClick += new System.EventHandler(this.lstFuncion�rios_DoubleClick);
            this.lstFuncion�rios.SelectedIndexChanged += new System.EventHandler(this.lstFuncion�rios_SelectedIndexChanged);
            this.lstFuncion�rios.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstFuncion�rios_ColumnClick);
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
            // ListViewFuncion�rios
            // 
            this.Controls.Add(this.lstFuncion�rios);
            this.Name = "ListViewFuncion�rios";
            this.Size = new System.Drawing.Size(336, 96);
            this.VisibleChanged += new System.EventHandler(this.ListViewFuncion�rios_VisibleChanged);
            this.ResumeLayout(false);

		}
		#endregion

		public event EventHandler SelectedIndexChanged;

		private void lstFuncion�rios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SelectedIndexChanged != null)
				SelectedIndexChanged(sender, e);
		}

		private void lstFuncion�rios_DoubleClick(object sender, System.EventArgs e)
		{
			this.OnDoubleClick(e);
		}

		public Funcion�rio Funcion�rioSelecionado
		{
			get
			{
				if (lstFuncion�rios.SelectedItems.Count != 1)
					return null;

				return (Funcion�rio) linhas[lstFuncion�rios.SelectedItems[0]];
			}
		}

		public override object InitializeLifetimeService()
		{
			return null;
		}

		/// <summary>
		/// Procura um funcion�rio cujo nome se inicia
		/// com um especificado.
		/// </summary>
		/// <param name="nome">Prefixo do nome a ser
		/// procurado nos funcion�rios</param>
		public void Procurar(string nome)
		{
			foreach (ListViewItem linha in lstFuncion�rios.Items)
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

		private void lstFuncion�rios_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			if (ordena��oColuna == e.Column)
			{
				if (lstFuncion�rios.Sorting == SortOrder.Descending)
					lstFuncion�rios.Sorting = SortOrder.Ascending;
				else
					lstFuncion�rios.Sorting = SortOrder.Descending;
			}
			else
			{
				ordena��oColuna = e.Column;
				lstFuncion�rios.Sorting = SortOrder.Ascending;
			}

			lstFuncion�rios.Sort();
		}

		#region IComparer Members

		public int Compare(object x, object y)
		{
			return ((ListViewItem) x).SubItems[ordena��oColuna].Text.CompareTo(((ListViewItem) y).SubItems[ordena��oColuna].Text);
		}

		#endregion

		/// <summary>
		/// Ocorre quando a lista muda sua visibilidade
		/// </summary>
		private void ListViewFuncion�rios_VisibleChanged(object sender, System.EventArgs e)
		{
			if (this.Visible && lstFuncion�rios.SelectedItems.Count > 0)
				lstFuncion�rios.SelectedItems[0].EnsureVisible();
		}
	}
}
