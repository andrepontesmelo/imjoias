using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Entidades.Pagamentos;

namespace Apresentação.Financeiro.Pagamento
{
    class ListaPagamentoComparador : IComparer
    {
        ListView lista;

        /// <summary>
        /// Mapeamento de item da ListView para venda.
        /// </summary>
        private Dictionary<ListViewItem, ListaPagamentoItem> hashItemPagamento;

        // Ordem não importa
        public enum ColunaListView
        {
            Data, Descrição, Contador, Valor, Tipo, Vencimento, RegistradoPor, Vendas, Prorrogação, Dias, ValorHoje
        }

        private ColunaListView coluna = ColunaListView.Data;

        /// <summary>
        /// Constrói o ordenador da ListView.
        /// </summary>
        public ListaPagamentoComparador(Dictionary<ListViewItem, ListaPagamentoItem> hashItemPagamento, ListView lista)
        {
            this.hashItemPagamento = hashItemPagamento;
            this.lista = lista;
        }

        /// <summary>
        /// Define a coluna de ordenamento.
        /// </summary>
        /// <param name="coluna">Coluna a ser ordenada.</param>
        public bool DefinirColuna(ColumnHeader coluna)
        {
            ColunaListView valor = (ColunaListView) Enum.Parse(typeof(ColunaListView), coluna.Name.Substring(3));
            bool resultado;

            resultado = this.coluna != valor;

            this.coluna = valor;

            return resultado;        
        }

        public int Compare(object x, object y)
        {
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
            ListaPagamentoItem a, b;

            a = hashItemPagamento[(ListViewItem)x];
            b = hashItemPagamento[(ListViewItem)y];

            switch (coluna)
            {
                case ColunaListView.Data:
                    return a.Pagamento.Data.CompareTo(b.Pagamento.Data);

                case ColunaListView.Contador:
                    return 1;

                case ColunaListView.Descrição:
                    if (a.Pagamento.Descrição != null && b.Pagamento.Descrição != null)
                        return a.Pagamento.Descrição.CompareTo(b.Pagamento.Descrição);
                    else 
                        return 0;

                case ColunaListView.Valor:
                    return a.Pagamento.Valor.CompareTo(b.Pagamento.Valor);

                case ColunaListView.Tipo:
                    return a.Pagamento.Tipo.CompareTo(b.Pagamento.Tipo);

                case ColunaListView.Vencimento:
                    DateTime dataA = a.Vencimento.HasValue ? a.Vencimento.Value : a.Pagamento.Data;
                    DateTime dataB = b.Vencimento.HasValue ? b.Vencimento.Value : b.Pagamento.Data;

                    return dataA.CompareTo(dataB);

                case ColunaListView.RegistradoPor:
                    return a.Pagamento.RegistradoPor.CompareTo(b.Pagamento.RegistradoPor);

                case ColunaListView.Vendas:
                    return a.Pagamento.Venda.ToString().CompareTo(b.Pagamento.Venda.ToString());

                case ColunaListView.Prorrogação:
                    return a.ProrrogadoPara.GetValueOrDefault(a.Pagamento.Data).CompareTo(
                        b.ProrrogadoPara.GetValueOrDefault(b.Pagamento.Data));

                case ColunaListView.ValorHoje:
                    return a.ValorLíquido.CompareTo(b.ValorLíquido);

                case ColunaListView.Dias:
                    return a.Dias.CompareTo(b.Dias);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
