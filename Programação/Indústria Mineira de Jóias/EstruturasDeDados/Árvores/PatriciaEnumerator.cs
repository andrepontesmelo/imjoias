using System;
using System.Collections;
using System.Collections.Generic;

namespace EstruturasDeDados.Árvores
{	
	[Serializable] 
	public class PatriciaEnumerator<TObjeto> : IEnumerator
	{
		Queue<NodoPatricia<TObjeto>> fila = new Queue<NodoPatricia<TObjeto>>();
		NodoPatricia<TObjeto> raiz;
		
		public PatriciaEnumerator()
		{
			raiz = null;
		}
		
		public PatriciaEnumerator(NodoPatricia<TObjeto> raiz)
		{
			this.raiz = raiz;
			fila.Enqueue(null);
			empilhar(raiz);
		}
		
		private void empilhar(NodoPatricia<TObjeto> nodo)
		{
			if (nodo.Bit < nodo.Esquerda.Bit)
				empilhar(nodo.Esquerda);
			
			fila.Enqueue(nodo);
			
			if (nodo.Bit < nodo.Direita.Bit)
				empilhar(nodo.Direita);
		}
		
		public int Count
		{
			get
			{
				return fila.Count;
			}
		}
		
		#region System.Collections.IEnumerator interface implementation
		public object Current
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
				empilhar(raiz);
		}
		
		public bool MoveNext()
		{
			if (fila.Count == 0)
				return false;
			
			fila.Dequeue();
			
			return fila.Count > 0;
		}
		#endregion		
	}
}
