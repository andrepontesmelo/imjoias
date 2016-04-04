using System;
using System.Collections;

namespace Entidades.Árvores
{
	/// <summary>
	/// Patricia PATRICIA - Estrutura de dados
	/// </summary>
	[Serializable] 
	public class Patricia<TObjeto> : ICollection
	{
		private NodoPatricia<TObjeto> raiz;
		private int nElementos;
		private bool permitirAcentos;
		
		/// <summary>
		/// Constrói a árvore vazia
		/// </summary>
		public Patricia()
		{
			raiz = new NodoPatricia<TObjeto>(null, -1);
			permitirAcentos = true;
		}

		public Patricia(bool permitirAcentos)
		{
			raiz = new NodoPatricia<TObjeto>(null, 1);

			this.permitirAcentos = permitirAcentos ;
		}

		/// <summary>
		/// Transforma uma string em um vetor de bits
		/// </summary>
		/// <param name="chave">Chave textual</param>
		/// <returns>Vetor de bits correspondente à chave em string</returns>
		protected BitArray String2Bit(string strChave)
		{
			int bitTamanho;
			BitArray bitChave;
			char [] chave;
			
			chave = (strChave.ToUpper()).ToCharArray();

			if (!permitirAcentos)
				RemoverAcentos(chave);

			bitTamanho = chave.Length * 8;
			bitChave = new BitArray(bitTamanho);

			for (int i = 0; i < bitTamanho; i++)
				bitChave[i] = ((chave[i / 8] & (1 << (7 - (i % 8)))) != 0);
			
			return bitChave;
		}

		protected void RemoverAcentos(char [] chave)
		{
			// Remover acentos
			for (int i = 0; i < chave.Length; i++)
			{
				switch (chave[i])
				{
					case 'Á':
					case 'Ã':
					case 'À':
					case 'Â':
					case 'Ä':
						chave[i] = 'A';
						break;

					case 'É':
					case 'È':
					case 'Ê':
					case 'Ë':
						chave[i] = 'E';
						break;

					case 'Í':
					case 'Ì':
					case 'Î':
					case 'Ï':
						chave[i] = 'I';
						break;

					case 'Ó':
					case 'Õ':
					case 'Ò':
					case 'Ô':
					case 'Ö':
						chave[i] = 'O';
						break;

					case 'Ú':
					case 'Ù':
					case 'Û':
					case 'Ü':
						chave[i] = 'U';
						break;

					case 'Ç':
						chave[i] = 'C';
						break;

					case 'Ñ':
						chave[i] = 'N';
						break;
				}
			}
		}

		/// <summary>
		/// Insere objeto na árvore
		/// </summary>
		/// <param name="chave">Chave textual que identifica o objeto</param>
		/// <param name="obj">Objeto a ser armazenado</param>
        public void Add(string chave, TObjeto obj)
		{
			BitArray bitChave = String2Bit(chave);
			NodoPatricia<TObjeto> aux = Percorrer(bitChave);
			NodoPatricia<TObjeto> novo;
			int bit;
			
			// Comparar as chaves
			bit = CompararChaves(bitChave, aux);
			
			// Verificar unicidade
			if (bit < 0)
				throw new ExceçãoElementoJáExistente(aux.Objeto);

			// Encontrar nodo mais semelhante
			aux = Percorrer(bitChave, bit);
	
			// Criar novo NodoPatricia
			novo = new NodoPatricia<TObjeto>(bitChave, obj, bit);
			nElementos++;
			
			if (novo[aux.Bit])
				aux.Direita = novo;	// O NodoPatricia arruma o resto
			else
				aux.Esquerda = novo; // O NodoPatricia arruma o resto
		}
		
		/// <summary>
		/// Compara duas chaves.
		/// </summary>
		/// <returns>Retorna o bit diferente ou -1 se forem iguais</returns>
		protected internal static int CompararChaves(BitArray c1, NodoPatricia<TObjeto> c2)
		{
			int min = c1.Length < c2.Length ? c1.Length : c2.Length;

			for (int i = 0; i < min; i++)
				if (c1[i] != c2[i])
					return i;
			
			for (int i = min; i < c1.Length; i++)
				if (c1[i])
					return i;

			for (int i = min; i < c2.Length; i++)
				if (c2[i])
					return i;

			return -1;
		}

		/// <summary>
		/// Compara duas chaves.
		/// </summary>
		/// <returns>Retorna o bit diferente ou -1 se forem iguais</returns>
		protected internal static int CompararChaves(BitArray c1, NodoPatricia<TObjeto> c2, int bitInicial)
		{
			int min = c1.Length < c2.Length ? c1.Length : c2.Length;

			for (int i = bitInicial; i < min; i++)
				if (c1[i] != c2[i])
					return i;
			
			for (int i = min; i < c1.Length; i++)
				if (c1[i])
					return i;

			for (int i = min; i < c2.Length; i++)
				if (c2[i])
					return i;

			return -1;
		}

		/// <summary>
		/// Percorre a árvore em busca de um NodoPatricia
		/// </summary>
		/// <param name="chave">Chave a ser procurada</param>
		/// <returns>Nodo encontrado</returns>
		protected NodoPatricia<TObjeto> Percorrer(BitArray chave)
		{
			NodoPatricia<TObjeto> aux = raiz.Esquerda;
			int bit = -1;

			// Descer a árvore
			while (bit < aux.Bit)
			{
				bit = aux.Bit;

				aux = ((aux.Bit < chave.Length) && (chave[aux.Bit]))
					? aux.Direita : aux.Esquerda;				
			}
			
			return aux;
		}

		/// <summary>
		/// Percorre a árvore em busca de um NodoPatricia
		/// </summary>
		/// <param name="chave">Chave a ser procurada</param>
		/// <param name="anterior">Referência para o nodo anterior</param>
		/// <returns>Nodo encontrado</returns>
		protected NodoPatricia<TObjeto> Percorrer(BitArray chave, ref NodoPatricia<TObjeto> anterior)
		{
			NodoPatricia<TObjeto> aux;
			
			aux = raiz.Esquerda;
			anterior = raiz;

			// Descer a árvore
			while (anterior.Bit < aux.Bit)
			{
				anterior = aux;

				aux = ((aux.Bit < chave.Length) && (chave[aux.Bit]))
					? aux.Direita : aux.Esquerda;				
			}
			
			return aux;
		}

		/// <summary>
		/// Percorre a árvore em busca de um NodoPatricia
		/// até um determinado bit
		/// </summary>
		/// <param name="chave">Chave a ser procurada</param>
		/// <param name="bitMaximo">Limites de bits a verificar</param>
		/// <returns>Nodo encontrado ou o nodo em que a busca foi encerrada</returns>
		protected NodoPatricia<TObjeto> Percorrer(BitArray chave, int bitMaximo)
		{
			NodoPatricia<TObjeto> aux = raiz.Esquerda, anterior = raiz;
			
			// Descer a árvore
			while ((anterior.Bit < aux.Bit) && (aux.Bit < bitMaximo))
			{
				anterior = aux;
				aux = ((aux.Bit < chave.Length) && (chave[aux.Bit]))
					? aux.Direita : aux.Esquerda;				
			} 
			
			return anterior;
		}

		/// <summary>
		/// Procura objeto identificado por uma chave
		/// </summary>
		/// <param name="chave">Chave que identifica objeto</param>
		/// <returns>Objeto identificado pela chave</returns>
        public bool TryGetValue(string chave, out TObjeto objeto)
		{
			BitArray bitChave = String2Bit(chave);
			NodoPatricia<TObjeto> aux = Percorrer(bitChave);

            if (ChavesIguais(bitChave, aux.BitChave))
            {
                objeto = aux.Objeto;
                return true;
            }
            else
            {
                objeto = default(TObjeto);
                return false;
            }
		}

        /// <summary>
        /// Verifica se contém uma determinada chave na árvore.
        /// </summary>
        /// <param name="chave">Chave a ser verificada.</param>
        /// <returns>Verdadeiro se contém a chave.</returns>
        public bool Contains(string chave)
        {
			BitArray bitChave = String2Bit(chave);
			NodoPatricia<TObjeto> aux = Percorrer(bitChave);

            return ChavesIguais(bitChave, aux.BitChave);
        }

		protected bool ChavesIguais(BitArray b1, BitArray b2)
		{
			bool cmp = false;

			if (b1 == null || b2 == null)
				return false;

			if (b1.Length != b2.Length)
				return false;

			for (int i = 0; i < b1.Length; i++)
				cmp |= b1[i] ^ b2[i];


			return !cmp;
		}

		/// <summary>
		/// Substitui objeto identificado por uma chave.
		/// </summary>
		/// <param name="chave">Chave que identifica objeto</param>
		/// <param name="objeto">Objeto a ser armazenado</param>
        public void Substituir(string chave, TObjeto objeto)
		{
			BitArray bitChave = String2Bit(chave);
			NodoPatricia<TObjeto> aux = Percorrer(bitChave);

			if (aux.Chave == chave)
				aux.Objeto = objeto;
		}
		
		public PatriciaPrefixoEnumerator<TObjeto> GetPrefixo(string prefixo)
		{
			BitArray bitChave = String2Bit(prefixo);
			NodoPatricia<TObjeto> aux = raiz.Esquerda;
			int bit, bitAnterior = -1;

			/* Encontrar sub-árvore que contém prefixo semelhante.
			 * O bit de diferença indica em que ponto a chave é
			 * diferente, logo pode ser usada para identificar
			 * quando o prefixo estiver presente.
			 */
			bit = CompararChaves(bitChave, aux);

			while (bit < bitChave.Length && bitChave.Length > aux.Bit 
				&& bitAnterior < aux.Bit && bit != -1)
			{
				do
				{
					bitAnterior = aux.Bit;
					aux = bitChave[aux.Bit] ? aux.Direita : aux.Esquerda;
				} while (aux.Bit < bit && bitAnterior < aux.Bit);
				bit = CompararChaves(bitChave, aux, bit);
			} 

			// Neste ponto, aux indica o primeiro elemento que contém o prefixo

			// Verificar validade dos dados (raíz é nula)
			if (aux == raiz || bitChave.Length <= aux.Bit || (bit < bitChave.Length && bit != -1))
				return new PatriciaPrefixoEnumerator<TObjeto>();
			else
				return new PatriciaPrefixoEnumerator<TObjeto>(aux, bitChave);
		}

        public TObjeto GetFirstPrefix(string prefixo)
        {
            BitArray bitChave = String2Bit(prefixo);
            NodoPatricia<TObjeto> aux = raiz.Esquerda;
            int bit, bitAnterior = -1;

            /* Encontrar sub-árvore que contém prefixo semelhante.
             * O bit de diferença indica em que ponto a chave é
             * diferente, logo pode ser usada para identificar
             * quando o prefixo estiver presente.
             */
            bit = CompararChaves(bitChave, aux);

            while (bit < bitChave.Length && bitChave.Length > aux.Bit
                && bitAnterior < aux.Bit && bit != -1)
            {
                do
                {
                    bitAnterior = aux.Bit;
                    aux = bitChave[aux.Bit] ? aux.Direita : aux.Esquerda;
                } while (aux.Bit < bit && bitAnterior < aux.Bit);
                bit = CompararChaves(bitChave, aux, bit);
            }

            // Neste ponto, aux indica o primeiro elemento que contém o prefixo

            // Verificar validade dos dados (raíz é nula)
            if (aux == raiz || bitChave.Length <= aux.Bit || (bit < bitChave.Length && bit != -1))
                return default(TObjeto);
            else
                return aux.Objeto;
        }

		#region System.Collections.ICollection interface implementation
		public int Count 
		{
			get 
			{
				return nElementos;
			}
		}
		
		public object SyncRoot 
		{
			get 
			{
				return null;
			}
		}
		
		public bool IsSynchronized 
		{
			get 
			{
				return false;
			}
		}
		
		public void CopyTo(System.Array array, int index)
		{
			throw new Exception("Not implemented!");
		}
		#endregion
		
		
		#region System.Collections.IEnumerable interface implementation
		public System.Collections.IEnumerator GetEnumerator()
		{
			if (nElementos == 0)
				return new PatriciaEnumerator<TObjeto>();
			
			return new PatriciaEnumerator<TObjeto>(raiz.Esquerda);
		}
		#endregion
	}
}

