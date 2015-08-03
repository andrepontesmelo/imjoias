using System;
using System.Windows.Forms;
using Entidades.�lbum;
using System.Collections;
using System.Globalization;
using Entidades;
using Entidades.Configura��o;

namespace Programa.�lbum.Problemas
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
			this.Columns.Add("Refer�ncia", 100, HorizontalAlignment.Center);
			this.Columns.Add("Funcion�rio", 100, HorizontalAlignment.Center);
			this.Columns.Add("Descri��o", 1000, HorizontalAlignment.Left);
		}

		public void Carregar()
		{
			// Cultura � necess�ria para o ToString correto.
            CultureInfo cultura = DadosGlobais.Inst�ncia.Cultura;

			ArrayList listaProblemas = ProblemaFoto.ObterProblemasPendentes();
			
			foreach (ProblemaFoto problema in listaProblemas)
			{
				ListViewItem item;

	
				item = new ListViewItem(problema.Data.ToString(cultura));
				item.SubItems.Add(problema.Refer�nciaFormatada);
				item.SubItems.Add(problema.Usu�rio);
				item.SubItems.Add(problema.Descri��oLinear);
				
				this.Items.Add(item);
			}
			
			carregado = true;
		}
	}
}
