using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.DAO.EF
{
    public class AdaptadorColecao<I, T> : ICollection<I> where T : I
    {
        public ICollection<T> Colecao { get; set; }
        public Func<T, I, bool> contains { get; set; }

        /// <summary>
        /// Constrói o adaptador de coleção.
        /// </summary>
        /// <param name="colecao">Coleção a ser adaptada.</param>
        /// <param name="contains">Função que compara dois elementos para verificar se ele já se encontra na lista.</param>
        public AdaptadorColecao(ICollection<T> colecao, Func<T, I, bool> contains)
        {
            this.Colecao = colecao;
            this.contains = contains;
        }

        #region ICollection<I> Members

        public virtual void Add(I item)
        {
            Colecao.Add((T)item);
        }

        public void Clear()
        {
            Colecao.Clear();
        }

        public virtual bool Contains(I item)
        {
            //return Colecao.Contains((T)item);
            if (item is T)
                return Colecao.Contains((T)item);
            else
                return Colecao.Any(t => contains(t, item));
        }

        public void CopyTo(I[] array, int arrayIndex)
        {
            var itens = Colecao.Skip(arrayIndex).ToArray();

            for (int i = arrayIndex; i < array.Length; i++)
                array[i] = itens[i - arrayIndex];
        }

        public int Count
        {
            get { return Colecao.Count; }
        }

        public bool IsReadOnly
        {
            get { return Colecao.IsReadOnly; }
        }

        public virtual bool Remove(I item)
        {
            return Colecao.Remove((T)item);
        }

        #endregion

        #region IEnumerable<I> Members

        public IEnumerator<I> GetEnumerator()
        {
            return Colecao.Cast<I>().GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Colecao.GetEnumerator();
        }

        #endregion
    }
}
