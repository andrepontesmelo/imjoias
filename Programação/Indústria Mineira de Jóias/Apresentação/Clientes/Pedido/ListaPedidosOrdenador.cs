using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public class ListaPedidosOrdenador : IComparer
    {
        private Dictionary<ListViewItem, Entidades.PedidoConserto.Pedido> hashPedidos;

        public enum ColunaListView
        {
            Código, DataRegistro, Previsão, Entrega, Representante, Cliente, Descrição
        }

        private ColunaListView coluna = ColunaListView.DataRegistro;

        /// <summary>
        /// Constrói o ordenador da ListView.
        /// </summary>
        public ListaPedidosOrdenador(Dictionary<ListViewItem, Entidades.PedidoConserto.Pedido> hashPedidos)
        {
            this.hashPedidos = hashPedidos;
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

        /// <summary>
        /// Compara os itens da ListView.
        /// </summary>
        public int Compare(object x, object y)
        {
            Entidades.PedidoConserto.Pedido a, b;

            a = hashPedidos[(ListViewItem)x];
            b = hashPedidos[(ListViewItem)y];

            switch (coluna)
            {
                case ColunaListView.Código:
                    return a.Código.CompareTo(b.Código);

                case ColunaListView.DataRegistro:
                    return a.DataRecepção.CompareTo(b.DataRecepção);

                case ColunaListView.Entrega:
                    DateTime dataA = a.DataEntrega.HasValue ? a.DataEntrega.Value : DateTime.MinValue;
                    DateTime dataB = b.DataEntrega.HasValue ? b.DataEntrega.Value : DateTime.MinValue;

                    return (dataA.CompareTo(dataB));
                    
                case ColunaListView.Previsão:
                    return a.DataPrevisão.CompareTo(b.DataPrevisão);

                case ColunaListView.Representante:
                        return (a.Representante == null ? "" : a.Representante.Nome).CompareTo(
                            (b.Representante == null ? "" : b.Representante.Nome));

                case ColunaListView.Cliente:
                        string nomePrimeiro = a.Cliente == null ? (a.NomeDoCliente == null ? "" : a.NomeDoCliente) : a.Cliente.Nome;
                        string nomeSegundo = b.Cliente == null ? (b.NomeDoCliente == null ? "" : b.NomeDoCliente) : b.Cliente.Nome;

                    return (nomePrimeiro.CompareTo(nomeSegundo));

                case ColunaListView.Descrição:
                    return (String.IsNullOrEmpty(a.Observações) ? "" : a.Observações).CompareTo
                        ((String.IsNullOrEmpty(b.Observações) ? "" : b.Observações));

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
