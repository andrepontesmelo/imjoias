using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresentação.Mercadoria.Manutenção
{
    class ListaMercadoriaOrdenador : IComparer
    {
        private Dictionary<ListViewItem, MercadoriaManutenção> hashItemManutenção;

        public enum ColunaListView
        {
            Referência, Peso, Descrição, Faixa, Grupo, Teor, ForaDeLinha
        }

        private ColunaListView coluna = ColunaListView.Referência;

        /// <summary>
        /// Constrói o ordenador da ListView.
        /// </summary>
        public ListaMercadoriaOrdenador(Dictionary<ListViewItem, MercadoriaManutenção> hashItemVenda)
        {
            this.hashItemManutenção = hashItemVenda;
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
            MercadoriaManutenção a, b;

            a = hashItemManutenção[(ListViewItem) x];
            b = hashItemManutenção[(ListViewItem) y];

            switch (coluna)
            {                
                case ColunaListView.Referência:
                   return a.Referência.CompareTo(b.Referência);

                case ColunaListView.Peso:
                    return a.Peso.CompareTo(b.Peso);

                case ColunaListView.Descrição:
                    return a.Descrição.CompareTo(b.Descrição);

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
