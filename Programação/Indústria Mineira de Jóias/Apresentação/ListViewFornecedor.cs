using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Entidades.Mercadoria;

namespace Apresentação.Álbum.Edição
{
	/// <summary>
	/// Summary description for ListViewFornecedor.
	/// </summary>
	public class ListViewFornecedor : System.Windows.Forms.UserControl
	{
		// Eventos
		public delegate void SeleçãoFornecedor(string nomeFornecedor);
		public event SeleçãoFornecedor AoSelecionarFornecedor;

		// Controle
		private System.Windows.Forms.ListView lst;
		private System.Windows.Forms.ColumnHeader colNome;
		private System.ComponentModel.IContainer components;


		public ListViewFornecedor()
		{
			InitializeComponent();
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
			this.components = new System.ComponentModel.Container();
			this.lst = new System.Windows.Forms.ListView();
			this.colNome = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lst
			// 
			this.lst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																				  this.colNome});
			this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst.FullRowSelect = true;
			this.lst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lst.HideSelection = false;
			this.lst.LabelWrap = false;
			this.lst.Location = new System.Drawing.Point(0, 0);
			this.lst.MultiSelect = false;
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(368, 200);
			this.lst.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lst.TabIndex = 0;
			this.lst.View = System.Windows.Forms.View.Details;
			this.lst.Resize += new System.EventHandler(this.lst_Resize);
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			// 
			// colNome
			// 
			this.colNome.Text = "Fornecedor";
			// 
			// ListViewMercadoria
			// 
			this.Controls.Add(this.lst);
			this.Name = "ListViewFornecedor";
			this.Size = new System.Drawing.Size(368, 200);
			this.ResumeLayout(false);


		}
		#endregion

        private delegate void MostrarCallback(IList fornecedores);

		/// <summary>
		/// Mostra dados na ListView
		/// </summary>
		public void Mostrar(IList fornecedores)
		{
            if (this.InvokeRequired)
            {
                MostrarCallback método = new MostrarCallback(Mostrar);
                this.BeginInvoke(método, fornecedores);
            }
            else
            {
                // Limpar ítens
                lst.Items.Clear();

                for (int i = 0; i < fornecedores.Count; i++)
                {
                    Fornecedor fornecedor = (Fornecedor) fornecedores[i];

                    lst.Items.Add(fornecedor.Nome);

                    // A entidade é gravada na tag da lista.
                    //lst.Items[lst.Items.Count - 1].Tag = fornecedor;
                }
            }
		}

		/// <summary>
		/// Ocorre quando altera-se o tamanho
		/// </summary>
		private void lst_Resize(object sender, System.EventArgs e)
		{
			colNome.Width = lst.ClientSize.Width;
		}

		/// <summary>
		/// Ocorre quando altera-se a seleção
		/// </summary>
		private void lst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Update();

			if (AoSelecionarFornecedor != null && lst.SelectedItems.Count == 1)
				AoSelecionarFornecedor(lst.SelectedItems[0].Text);		
		}

		/// <summary>
		/// Seleciona próximo elemento
		/// </summary>
		public void SelecionarPróximo()
		{
			if (lst.Items.Count > 0)
			{
				if (lst.SelectedIndices.Count == 0)
					lst.Items[0].Selected = true;
				else
				{
					int idx = lst.SelectedIndices[0] + 1;

					if (idx < lst.Items.Count)
					{
						lst.SelectedItems.Clear();
						lst.Items[idx].Selected = true;
						lst.Items[idx].EnsureVisible();
					} 
					else
					{
						/* caso em que só existe 1 elemento na lista
						* e já está selecionado. O evento de sua nova
						* seleção deve ser enviado. Isto é intuitivo.
						*/ 
						lst_SelectedIndexChanged(null, null);
					}

				}
			}
		}

		/// <summary>
		/// Seleciona elemento anterior
		/// </summary>
		public void SelecionarAnterior()
		{
			if (lst.Items.Count > 0)
			{
				if (lst.SelectedIndices.Count == 0)
					lst.Items[0].Selected = true;
				else
				{
					int idx = lst.SelectedIndices[0] - 1;

					if (idx >= 0)
					{
						lst.SelectedItems.Clear();
						lst.Items[idx].Selected = true;
						lst.Items[idx].EnsureVisible();
					}
				}
			}
		}

		public ListView.ListViewItemCollection Items
		{
			get
			{
				return lst.Items;
			}
		}

	}


}
