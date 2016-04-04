using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Pessoa;
using Entidades.Pessoa.Endereço;
using System.Collections.Generic;
using Apresentação.Formulários;

namespace Apresentação.Pessoa.Consultas
{
	/// <summary>
	/// Janela com resultado da pesquisa por pessoas.
	/// </summary>
	public class ProcurarPessoaResultados : Apresentação.Formulários.JanelaExplicativa
	{
		private Hashtable itensPessoa;
		private Ordenador ordenador;

		// Componentes
		private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colCidade;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.ListView lista;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói a janela de resultados da pesquisa.
		/// </summary>
		/// <param name="pessoas">Pessoas encontradas</param>
		public ProcurarPessoaResultados(List<Entidades.Pessoa.Pessoa> pessoas)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			ordenador                = new Ordenador(colNome);
			lista.ListViewItemSorter = ordenador;
			itensPessoa              = new Hashtable();

			Exibir(pessoas);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcurarPessoaResultados));
            this.lista = new System.Windows.Forms.ListView();
            this.colNome = new System.Windows.Forms.ColumnHeader();
            this.colCidade = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(140, 20);
            this.lblTítulo.Text = "Procurar pessoa";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(615, 48);
            this.lblDescrição.Text = "O resultado de sua pesquisa encontra-se exibido na lista abaixo.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // lista
            // 
            this.lista.AllowColumnReorder = true;
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colCidade});
            this.lista.FullRowSelect = true;
            this.lista.GridLines = true;
            this.lista.Location = new System.Drawing.Point(8, 96);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(687, 303);
            this.lista.TabIndex = 3;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 492;
            // 
            // colCidade
            // 
            this.colCidade.Text = "Cidade";
            this.colCidade.Width = 141;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(539, 407);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(620, 407);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            // 
            // ProcurarPessoaResultados
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(703, 437);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.Name = "ProcurarPessoaResultados";
            this.ShowInTaskbar = true;
            this.Text = "Resultado da pesquisa";
            this.Shown += new System.EventHandler(this.ProcurarPessoaResultados_Shown);
            this.Controls.SetChildIndex(this.lista, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Exibe pessoas na lista.
		/// </summary>
		/// <param name="pessoas">Pessoas a serem exibidas.</param>
		private void Exibir(List<Entidades.Pessoa.Pessoa>  pessoas)
		{
            Aguarde janela = new Apresentação.Formulários.Aguarde("Este processo não pode demorar", pessoas.Count, "Carregando cidades", "Experimente digitar o nome seguido de qualquer sobrenome, este processo será mais rápido da próxima vez.");
            janela.Abrir();

            // Carrega o endereços das pessoas.
            Entidades.Pessoa.Pessoa.CarregarEndereços(pessoas);

            foreach (Entidades.Pessoa.Pessoa pessoa in pessoas)
			{
                janela.Passo();
				ListViewItem item = new ListViewItem(new string [lista.Columns.Count]);

				// Atribuir nome
				item.Text = (pessoa != null && pessoa.Nome != null) ? pessoa.Nome : "";

                List<Entidades.Pessoa.Endereço.Endereço> endereços = pessoa.Endereços.ExtrairElementos();
                if (endereços.Count > 0
                    && endereços[0].Localidade != null
                    && endereços[0].Localidade.Estado != null)

                    item.SubItems[colCidade.Index].Text = endereços[0].Localidade.Nome + " - " + endereços[0].Localidade.Estado.Sigla;

				// Adicionar à lista
				lista.Items.Add(item);
				itensPessoa[item] = pessoa;
			}
			
			if (lista.Items.Count >= 1)
			{
				lista.Items[0].Selected = true;
				lista.Items[0].EnsureVisible();
			}

            janela.Close();
		}

		/// <summary>
		/// Ocorre ao clicar em alguma coluna.
		/// </summary>
		private void lista_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			if (ordenador.coluna.Index == e.Column)
				lista.Sorting = lista.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			else
			{
				ordenador.coluna = lista.Columns[e.Column];
				lista.Sort();
			}
		}

		/// <summary>
		/// Ocorre ao clicar duas vezes na lista.
		/// </summary>
		private void lista_DoubleClick(object sender, System.EventArgs e)
		{
			if (lista.SelectedItems.Count == 1)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		/// <summary>
		/// Ocorre ao alterar a seleção.
		/// </summary>
		private void lista_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnOK.Enabled = lista.SelectedItems.Count > 0;		
		}

		/// <summary>
		/// Pessoa selecionada.
		/// </summary>
		public Entidades.Pessoa.Pessoa PessoaSelecionada
		{
			get 
            { 
                Entidades.Pessoa.Pessoa pessoa = 
                    itensPessoa[lista.SelectedItems[0]] as Entidades.Pessoa.Pessoa;

                return pessoa;
            }
		}

		/// <summary>
		/// Ordenador da lista
		/// </summary>
		private class Ordenador : IComparer
		{
			public ColumnHeader coluna;

			/// <summary>
			/// Constrói o ordenador.
			/// </summary>
			/// <param name="coluna"></param>
			public Ordenador(ColumnHeader coluna)
			{
				this.coluna = coluna;
			}

			/// <summary>
			/// Compara dois objetos.
			/// </summary>
			public int Compare(object x, object y)
			{
				ListViewItem a, b;

				a = (ListViewItem) x;
				b = (ListViewItem) y;

				return a.SubItems[coluna.Index].Text.CompareTo(b.SubItems[coluna.Index].Text);
			}
		}

        private void ProcurarPessoaResultados_Shown(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0)
                lista.SelectedItems[0].EnsureVisible();
        }
	}
}

