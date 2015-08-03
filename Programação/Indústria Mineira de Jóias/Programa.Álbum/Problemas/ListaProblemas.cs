using System;
using System.Windows.Forms;
using Entidades.Álbum;
using System.Collections;
using System.Globalization;
using Entidades;
using Entidades.Configuração;

namespace Programa.Álbum.Problemas
{
	/// <summary>
	/// Summary description for ListaErros.
	/// </summary>
	public class ListaProblemas : ListView
	{
		// Atributos
		private bool	carregado = false;

		// Propriedades
		public bool Carregado
		{
			get { return carregado; }
		}

		public ListaProblemas() : base()
		{
			this.MultiSelect = false;
			this.View = View.Details;

			this.Columns.Add("Data", 120, HorizontalAlignment.Left);
			this.Columns.Add("Referência", 100, HorizontalAlignment.Center);
			this.Columns.Add("Funcionário", 100, HorizontalAlignment.Center);
			this.Columns.Add("Descrição", 1000, HorizontalAlignment.Left);
		}

		public void Carregar()
		{
			// Cultura é necessária para o ToString correto.
            CultureInfo cultura = DadosGlobais.Instância.Cultura;

			ArrayList listaProblemas = ProblemaFoto.ObterProblemasPendentes();
			
			foreach (ProblemaFoto problema in listaProblemas)
			{
				ListViewItem item;

	
				item = new ListViewItem(problema.Data.ToString(cultura));
				item.SubItems.Add(problema.ReferênciaFormatada);
				item.SubItems.Add(problema.Usuário);
				item.SubItems.Add(problema.DescriçãoLinear);
				
				this.Items.Add(item);
			}
			
			carregado = true;
		}
	}
}
