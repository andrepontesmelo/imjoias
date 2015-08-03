using System;
using System.Collections;
using System.Collections.Generic;
using Apresenta��o.Formul�rios.Consultas;
using System.Windows.Forms;
using Entidades;

namespace Apresenta��o.Mercadoria
{
	/// <summary>
	/// Coletor de mercadorias.
	/// </summary>
	/// <remarks>
	/// Esta classe � utilizada por TxtMercadoria.
	/// </remarks>
	internal class ColetorMercadoria : Apresenta��o.Formul�rios.Consultas.Coletor
	{
		// Constantes
		
		/// <summary>
		/// Limite de itens a buscar.
		/// Ter em mente que a apresenta��o dever� processar, para cada 
		/// item obtido, a sua imagem, redimensionando, o que gasta processamento.
		/// </summary>
        private const int padr�oLimiteM�nimo = 7;
        private const int padr�oLimiteM�ximo = 50;
        private const int padr�oDemoraM�ximaMs = 100;

		// Atributos
		private ListViewMercadoria          lst;
        private ControladorLimiteColetor    controladorLimite;      // Controla o limite de entidades
        private Tabela tabela;

        public Tabela Tabela { get { return tabela; } set { tabela = value; } }
			
		/// <summary>
		/// Constr�i o coletor de mercadorias
		/// </summary>
		public ColetorMercadoria(ListViewMercadoria lst, Tabela tabela)
		{
            controladorLimite = new ControladorLimiteColetor(padr�oLimiteM�nimo, padr�oLimiteM�ximo, padr�oDemoraM�ximaMs);

#if DEBUG
			if (lst == null)
				throw new ArgumentNullException("Coletor constru�do com lista nula!");
#endif

			this.lst = lst;

            this.tabela = tabela;
		}

        //private static Dictionary<string, Entidades.Mercadoria.Mercadoria[]> cache = new Dictionary<string, Entidades.Mercadoria.Mercadoria[]>();
		
		/// <summary>
		/// Recupera dados do banco de dados
		/// </summary>
		/// <param name="chave">Chave a ser procurada</param>
		protected override void Recuperar(string chave)
		{
			Entidades.Mercadoria.Mercadoria[] mercadorias;
            //ReaproveitarDadosCallback reaproveitar;

			if (chave.Length == 0)
				return;

#if DEBUG
            Console.WriteLine("==========================");
            Console.WriteLine("ColetorMercadoria: In�cio!");
            Console.WriteLine("{0} mercadorias na lista anterior", lst.Items.Count);
#endif

            // Desnecess�rio ap�s uso da �rvore patr�cia.
//            reaproveitar = new ReaproveitarDadosCallback(ReaproveitarDados);

//            if (lst.BeginInvoke(reaproveitar, new object[] { chave }).Equals(true))
//            {
//#if DEBUG
//                Console.WriteLine("ColetorMercadoria: Reaproveitando dados!");
//                Console.WriteLine("{0} mercadorias", lst.Items.Count);
//                Console.WriteLine("==========================");
//#endif
//                return;
//            }
		
            //if (!cache.TryGetValue(chave, out mercadorias))
            //{
                controladorLimite.CronometrarInicioObter();
                mercadorias = Entidades.Mercadoria.Mercadoria.ObterMercadorias(chave, controladorLimite.LimiteDin�mico, tabela);

            //    cache[chave] = mercadorias;
            //}

			lst.Mostrar(mercadorias);

            if (mercadorias.Length > 0)
                mercadorias[0].Preparar();

#if DEBUG
            Console.WriteLine("ColetorMercadoria: T�rmino!");
            Console.WriteLine("{0} mercadorias", mercadorias.Length);
            Console.WriteLine("==========================");
#endif

            controladorLimite.CronometrarFimObter();
		}

		private delegate bool ReaproveitarDadosCallback(string chave);

		/// <summary>
		/// Reaproveita os dados j� existentes na lista.
		/// </summary>
		/// <returns>Se foi poss�vel reaproveitar os dados.</returns>
		private bool ReaproveitarDados(string chave)
		{
			// N�o recuperar caso todos os itens tenham o mesmo prefixo.
			if (lst.Items.Count > 0 && chave.Length > �ltimaChave.Length && �ltimaChave.Length > 0)
			{
				if (lst.Items[0].Text.StartsWith(chave) && lst.Items[lst.Items.Count - 1].Text.StartsWith(chave))
					return true;
			}

			// Caso seja continua��o do prefixo, verificar se j� est� na lista.
			if (lst.Items.Count > 0 && chave.StartsWith(�ltimaChave) && �ltimaChave.Length > 0)
			{
                ListViewItem[] remo��o = new ListViewItem[lst.Items.Count];

                /* O reaproveitamento s� � considerado OK quando
                 * o �ltimo item n�o � removido, indicando que
                 * certamente n�o h� mais elementos com este prefixo
                 * depois do �ltimo j� exibido.
                 */
                bool ok = false;
				int removidos = 0;

				foreach (ListViewItem item in lst.Items)
				{
					if (!item.Text.StartsWith(chave))
					{
						remo��o[removidos++] = item;
						ok = true;
					}
					else
						ok = false;
				}

				/* Se nenhum item foi removido depois de ter encontrado o prefixo,
				 * ent�o mais itens podem existir que n�o foram recuperados na
				 * pesquisa passada.
				 */
				if (lst.Items.Count > removidos && ok)
				{
					for (int i = 0; i < removidos; i++)
						lst.Items.Remove(remo��o[i]);

					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Recupera primeira refer�ncia somente
		/// </summary>
		/// <param name="chave">Chave de procura</param>
		/// <returns>Refer�ncia</returns>
		public string RecuperarPrimeiroSomente(string chave)
		{
#if DEBUG
            System.Diagnostics.Debug.Assert(!chave.Contains("."), "Chave deveria ser refer�ncia num�rica");
#endif
			if (Pesquisando || chave != Chave || lst.Items.Count == 0)
			{
				Cancelar();
				
				return Entidades.Mercadoria.Mercadoria.ObterRefer�nciaPr�xima(chave);
			}

			// Se a pesquisa j� tiver sido feita, recuperar da ListView
			return lst.Items[0].Text;
		}

		public override string ToString()
		{
			return "ColetorMercadoria";
		}
	}
}

