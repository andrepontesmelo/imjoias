using System;
using System.Windows.Forms;
using Entidades.Álbum;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Entidades;
using Entidades.Configuração;

namespace Apresentação.Álbum.Edição.Fotos
{
	/// <summary>
	/// Summary description for ListaErros.`
	/// </summary>
	public class ListaProblemas : ListView
	{
		// Atributos
		private bool	carregado = false;
        private Dictionary<ListViewItem, ProblemaFoto> hashListViewItemProblema;
        private Dictionary<ProblemaFoto, ListViewItem> hashProblemaListViewItem;

		// Propriedades
		public bool Carregado
		{
			get { return carregado; }
		}

		public ListaProblemas() : base()
		{

            InitializeComponent();
		}

		public void Carregar()
		{
			// Cultura é necessária para o ToString correto.
            CultureInfo cultura = DadosGlobais.Instância.Cultura;

			ArrayList listaProblemas = ProblemaFoto.ObterProblemasPendentes();
            hashListViewItemProblema = new Dictionary<ListViewItem, ProblemaFoto>(listaProblemas.Count);
            hashProblemaListViewItem = new Dictionary<ProblemaFoto, ListViewItem>(listaProblemas.Count);

			foreach (ProblemaFoto problema in listaProblemas)
			{
				ListViewItem item;
	
				item = new ListViewItem(problema.Data.ToString(cultura));
				item.SubItems.Add(problema.ReferênciaFormatada);
				item.SubItems.Add(Entidades.Pessoa.Funcionário.ObterFuncionárioPorUsuário(problema.Usuário).PrimeiroNome);
				item.SubItems.Add(problema.DescriçãoLinear);

                hashListViewItemProblema.Add(item, problema);
                hashProblemaListViewItem.Add(problema, item);

				this.Items.Add(item);
			}
			
			carregado = true;
		}

        public void Remover(ProblemaFoto entidade)
        {
            ListViewItem item = hashProblemaListViewItem[entidade];

            Items[item.Index].Remove();

            hashListViewItemProblema.Remove(item);
            hashProblemaListViewItem.Remove(entidade);
        }

        public ProblemaFoto ItemSelecionado
        {
            get
            {
                if (SelectedItems.Count == 0)
                    return null;

                ListViewItem item = SelectedItems[0];
                return hashListViewItemProblema[item];

            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ListaProblemas
            // 
            this.FullRowSelect = true;
            this.View = System.Windows.Forms.View.List;
            this.Columns.Add("Data", 120, HorizontalAlignment.Left);
            this.Columns.Add("Referência", 100, HorizontalAlignment.Center);
            this.Columns.Add("Funcionário", 100, HorizontalAlignment.Center);
            this.Columns.Add("Descrição", 1000, HorizontalAlignment.Left);
            this.ResumeLayout(false);

        }
	}
}
