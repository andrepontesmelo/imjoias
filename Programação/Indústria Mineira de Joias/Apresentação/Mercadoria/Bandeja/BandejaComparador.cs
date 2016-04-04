using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Entidades.Pagamentos;
using Entidades;

namespace Apresentação.Mercadoria.Bandeja
{
    class BandejaComparador : IComparer
    {
        ListView lista;

        /// <summary>
        /// Mapeamento de item da ListView para venda.
        /// </summary>
        private Dictionary<ListViewItem, ISaquinho> hashSaquinho;

        /// <summary>
        /// Constrói o ordenador da ListView.
        /// </summary>
        public BandejaComparador(Dictionary<ListViewItem, ISaquinho> hashSaquinho, 
            ListView lista)
        {
            this.hashSaquinho = hashSaquinho;
            this.lista = lista;
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
            ISaquinho a, b;

            a = hashSaquinho[(ListViewItem)x];
            b = hashSaquinho[(ListViewItem)y];

            int comparaçãoReferências =
                a.Mercadoria.ReferênciaNumérica.CompareTo(b.Mercadoria.ReferênciaNumérica);

            if (comparaçãoReferências == 0)
                return a.Peso.CompareTo(b.Peso);
            else
                return comparaçãoReferências;
        }
    }
}
