using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Venda
{
    class ListViewVendasOrdenador : IComparer
    {
        /// <summary>
        /// Mapeamento de item da ListView para venda.
        /// </summary>
        private Dictionary<ListViewItem, IDadosVenda> hashItemVenda;
        ListView lista;

        public ListView Lista
        {
            set
            {
                lista = value;
            }
        }

        public enum ColunaListView
        {
            Data, Código, Controle, Cliente, Vendedor, Valor, Comissão
        }

        private ColunaListView coluna = ColunaListView.Data;

        /// <summary>
        /// Constrói o ordenador da ListView.
        /// </summary>
        public ListViewVendasOrdenador(Dictionary<ListViewItem, IDadosVenda> hashItemVenda)
        {
            this.hashItemVenda = hashItemVenda;
        }

        /// <summary>
        /// Define a coluna de ordenamento.
        /// </summary>
        /// <param name="coluna">Coluna a ser ordenada.</param>
        public bool DefinirColuna(ColumnHeader coluna)
        {
            ColunaListView valor = (ColunaListView)Enum.Parse(typeof(ColunaListView), coluna.Name.Substring(3));
            bool resultado;

            resultado = this.coluna != valor;
            
            this.coluna = valor;

            return resultado;
        }

        public int Compare(object x, object y)
        {
            if (lista == null)
                return 0;

            if (lista.Sorting == SortOrder.Descending)
                return -1 * Comparar(x, y);
            else
                return Comparar(x, y);
        }

        /// <summary>
        /// Compara os itens da ListView.
        /// </summary>
        public int Comparar(object x, object y)
        {
            IDadosVenda a, b;

            a = hashItemVenda[(ListViewItem)x];
            b = hashItemVenda[(ListViewItem)y];

            switch (coluna)
            {
                case ColunaListView.Data:
                    return a.Data.CompareTo(b.Data);

                case ColunaListView.Código:
                    return a.Código.CompareTo(b.Código);

                case ColunaListView.Controle:
                    if (!a.Controle.HasValue && !b.Controle.HasValue)
                        return 0;

                    if (!a.Controle.HasValue)
                        return -1;

                    if (!b.Controle.HasValue)
                        return 1;

                    return a.Controle.Value.CompareTo(b.Controle.Value);

                case ColunaListView.Cliente:
                    return (a.NomeCliente != null && b.NomeCliente != null) ? 
                        a.NomeCliente.CompareTo(b.NomeCliente) : 0;

                case ColunaListView.Vendedor:
                    return (a.NomeVendedor != null && b.NomeVendedor != null) ? 
                        a.NomeVendedor.CompareTo(b.NomeVendedor) : 0;

                case ColunaListView.Valor:
                    return a.Valor.CompareTo(b.Valor);

                //case ColunaListView.Comissão:
                //    return a.Comissão.CompareTo(b.Comissão);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
