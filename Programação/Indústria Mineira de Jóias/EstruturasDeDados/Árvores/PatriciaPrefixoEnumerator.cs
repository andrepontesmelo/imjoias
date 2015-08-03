using System;
using System.Collections.Generic;
using System.Collections;

namespace EstruturasDeDados.�rvores
{
	[Serializable] 
	public class PatriciaPrefixoEnumerator<TObjeto> : IEnumerator<TObjeto>
	{
		Queue<NodoPatricia<TObjeto>> fila = new Queue<NodoPatricia<TObjeto>>();
		NodoPatricia<TObjeto> raiz;
		BitArray bitChave;
		
		public PatriciaPrefixoEnumerator ()
		{
			raiz = null;
            fila.Enqueue(null);
		}
		
		public PatriciaPrefixoEnumerator (NodoPatricia<TObjeto> raiz, BitArray bitChave)
		{
			this.raiz = raiz;
			this.bitChave = bitChave;

			fila.Enqueue(null);

			/* Veja coment�rio no procedimento Empilhar */
			fila.Enqueue(raiz);
			
			Empilhar(raiz);
		}
		
		private void Empilhar(NodoPatricia<TObjeto> nodo)
		{
            /* Para enumerar as chaves de prefixo semelhante,
             * deve-se considerar somente o lado de caminhamento
             * do nodo na �rvore.
             */
			if (nodo.Bit < nodo.Esquerda.Bit
				&& (nodo.Bit >= bitChave.Length || !bitChave[nodo.Bit]))
				Empilhar(nodo.Esquerda);

            /* O prefixo s� � semelhante se o bit de diferen�a for
             * maior que o prefixo desejado, uma vez que o nodo da
             * sub-ra�z � o primeiro nodo semelhante e seus filhos
             * possuem bits diferentes. Se o bit diferente estiver
             * no prefixo desejado, este nodo n�o possui o mesmo
             * prefixo.
             * 
             * Exceto se este for a subra�z! Este elemento ser� inserido
             * antes do procedimento de empilhamento.
             */
            if (nodo.Bit >= bitChave.Length)
                fila.Enqueue(nodo);

            if (nodo.Bit < nodo.Direita.Bit
				&& (nodo.Bit >= bitChave.Length || bitChave[nodo.Bit]))
				Empilhar(nodo.Direita);
		}
		
		public int Count
		{
			get
			{
				return fila.Count - 1;
			}
		}
		
		#region System.Collections.IEnumerator interface implementation
		public TObjeto Current
		{
			get
			{
				NodoPatricia<TObjeto> nodo = (NodoPatricia<TObjeto>) fila.Peek();
				
				return nodo.Objeto;
			}
		}
		
		public void Reset()
		{
			fila.Clear();
			fila.Enqueue(null);
			
			if (raiz != null)
				Empilhar(raiz);
		}
		
		public bool MoveNext()
		{
			if (fila.Count == 0)
				return false;
			
			fila.Dequeue();
			
			return fila.Count > 0;
		}
		#endregion		
	
        #region IDisposable Members

        public void Dispose()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerator Members

        object IEnumerator.Current
        {
            get
            {
                NodoPatricia<TObjeto> nodo = (NodoPatricia<TObjeto>)fila.Peek();

                return nodo.Objeto;
            }
        }

        #endregion
    }
}
