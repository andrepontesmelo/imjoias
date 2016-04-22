using System;
using System.Collections;

namespace Entidades.Árvores
{
	/// <summary>
	/// Nodo da árvore PATRICIA
	/// </summary>
	[Serializable]
	public class NodoPatricia<TObjeto>
	{
		private BitArray bitChave;
        private TObjeto obj;
		private NodoPatricia<TObjeto> esquerda;	// Folha Esquerda
		private NodoPatricia<TObjeto> direita;	// Folha Direita
		private int bit;				// Bit de comparação

        /// <summary>
        /// Constrói o NodoPatricia com a chave e o bit de diferença.
        /// </summary>
        /// <param name="bitChave">Chave</param>
        /// <param name="bit">Índice do bit diferente</param>
        public NodoPatricia(BitArray bitChave, int bit)
        {
            this.bitChave = bitChave != null ? (BitArray)bitChave.Clone() : null;
            this.bit = bit;

            esquerda = this;
            direita = this;
        }

		/// <summary>
		/// Constrói o NodoPatricia com a chave e o bit de diferença.
		/// </summary>
		/// <param name="bitChave">Chave</param>
		/// <param name="obj">Objeto a ser armazenado</param>
		/// <param name="bit">Índice do bit diferente</param>
        public NodoPatricia(BitArray bitChave, TObjeto obj, int bit) : this(bitChave, bit)
		{
			this.obj = obj;
		}
	
		/// <summary>
		/// Acessa a chave
		/// </summary>
		public string Chave
		{
			get
			{
				string strChave = "";
				char byteChave = (char) 0;
			
				if (bitChave == null)
					return "<raiz>";
			
				for (int i = 0; i < bitChave.Length; i++)
				{
					byteChave |= (char) ((bitChave[i] ? 1 : 0) << (7 - (i % 8)));
				
					if (i % 8 == 7)
					{
						strChave += byteChave;
						byteChave = (char) 0;
					}
				}
			
				return strChave;
			}
		}
	
		/// <summary>
		/// Acessa um bit da chave
		/// </summary>
		public bool this[int index]
		{
			get
			{
				return (bitChave != null && index >= 0 && index < bitChave.Length) ? bitChave[index] : false;
			}
		}

		/// <summary>
		/// Obtém cópia da chave em vetor de bits
		/// </summary>
		public BitArray BitChave
		{
			get
			{
				return bitChave;
			}
		}

		private static void AtribuirFilho(ref NodoPatricia<TObjeto> filho, NodoPatricia<TObjeto> valor)
		{
			if (filho[valor.bit])
			{
				valor.direita = filho;
			}
			else
				valor.esquerda = filho;

			filho = valor;
		}
		
		/// <summary>
		/// Obtém a sub-árvore à esquerda
		/// </summary>
		public NodoPatricia<TObjeto> Esquerda
		{
			get
			{
				return esquerda;
			}
			set
			{
				AtribuirFilho(ref esquerda, value);
			}
		}
		
		/// <summary>
		/// Obtém a sub-árvore à direita
		/// </summary>
		public NodoPatricia<TObjeto> Direita
		{
			get
			{
				return direita;
			}
			set
			{
				AtribuirFilho(ref direita, value);
			}
		}

		/// <summary>
		/// Bit de comparação ou de diferença
		/// </summary>
		public int Bit
		{
			get
			{
				return bit;
			}
		}
	
		/// <summary>
		/// Obtém o objeto armazenado
		/// </summary>
        public TObjeto Objeto 
		{
			get 
			{
				return obj;
			}
			set
			{
				obj = value;
			}
		}
	
		/// <summary>
		/// Obtém o tamanho da chave
		/// </summary>
		public int Length 
		{
			get 
			{
				return bitChave != null ? bitChave.Length : 0;
			}
		}

        public override string ToString()
        {
            return Chave;
        }
	}
}
