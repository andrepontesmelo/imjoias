using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresenta��o.Mercadoria.Manuten��o
{
    class ListaMercadoriaOrdenador : IComparer
    {
        private Dictionary<ListViewItem, MercadoriaManuten��o> hashItemManuten��o;

        public enum ColunaListView
        {
            Refer�ncia, Peso, Descri��o, Faixa, Grupo, Teor, ForaDeLinha
        }

        private ColunaListView coluna = ColunaListView.Refer�ncia;

        /// <summary>
        /// Constr�i o ordenador da ListView.
        /// </summary>
        public ListaMercadoriaOrdenador(Dictionary<ListViewItem, MercadoriaManuten��o> hashItemVenda)
        {
            this.hashItemManuten��o = hashItemVenda;
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
            MercadoriaManuten��o a, b;

            a = hashItemManuten��o[(ListViewItem) x];
            b = hashItemManuten��o[(ListViewItem) y];

            switch (coluna)
            {                
                case ColunaListView.Refer�ncia:
                   return a.Refer�ncia.CompareTo(b.Refer�ncia);

                case ColunaListView.Peso:
                    return a.Peso.CompareTo(b.Peso);

                case ColunaListView.Descri��o:
                    return a.Descri��o.CompareTo(b.Descri��o);

                case ColunaListView.Faixa:
                    if (a.Faixa != null && b.Faixa != null)
                        return a.Faixa.CompareTo(b.Faixa);
                    else 
                        return 1;

                case ColunaListView.Grupo:
                    if (a.Grupo.HasValue && b.Grupo.HasValue)
                        return a.Grupo.Value.CompareTo(b.Grupo.Value);
                    else
                        return 1;
                
                case ColunaListView.Teor:
                    return a.Teor.CompareTo(b.Teor);
                
                case ColunaListView.ForaDeLinha:
                    return a.ForaDeLinha.CompareTo(b.ForaDeLinha);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
