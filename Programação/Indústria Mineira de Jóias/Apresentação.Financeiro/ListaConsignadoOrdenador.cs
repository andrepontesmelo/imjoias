using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Relacionamento;
using System.Windows.Forms;
using System.Collections;

namespace Apresentação.Financeiro
{
    class ListaConsignadoOrdenador : IComparer
    {
        /// <summary>
        /// Mapeamento de item da ListView para venda.
        /// </summary>
        private Dictionary<ListViewItem, Relacionamento> hashItemRelacionamento;

        public enum ColunaListView
        {
            Código, Acerto, Funcionário, Status, Data, Pessoa
        }

        private ColunaListView coluna = ColunaListView.Código;

        /// <summary>
        /// Constrói o ordenador da ListView.
        /// </summary>
        public ListaConsignadoOrdenador(Dictionary<ListViewItem, Relacionamento> hashItemRelacionamento)
        {
            this.hashItemRelacionamento = hashItemRelacionamento;
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
            Relacionamento a, b;

            a = hashItemRelacionamento[(ListViewItem) x];
            b = hashItemRelacionamento[(ListViewItem) y];

            switch (coluna)
            {
                case ColunaListView.Código:
                    return a.Código.CompareTo(b.Código);

                case ColunaListView.Acerto:
                    if (a.AcertoConsignado == null) return -1;
                    if (b.AcertoConsignado == null) return 1;
                    return a.AcertoConsignado.Código.CompareTo(b.AcertoConsignado.Código);

                case ColunaListView.Funcionário:
                    return a.DigitadoPor.CompareTo(b.DigitadoPor);

                case ColunaListView.Status:
                    return a.TravadoEmCache.CompareTo(b.TravadoEmCache);

                case ColunaListView.Data:
                    return (a.Data.CompareTo(b.Data));

                case ColunaListView.Pessoa:
                    return a.Pessoa.Nome.CompareTo(b.Pessoa.Nome);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
