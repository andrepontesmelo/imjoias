using System;
using System.Collections;
using System.Collections.Generic;
using Apresentação.Formulários.Consultas;
using System.Windows.Forms;
using Entidades;

namespace Apresentação.Mercadoria
{
	/// <summary>
	/// Coletor de mercadorias.
	/// </summary>
	/// <remarks>
	/// Esta classe é utilizada por TxtMercadoria.
	/// </remarks>
	internal class ColetorMercadoria : Apresentação.Formulários.Consultas.Coletor
	{
		// Constantes
		
		/// <summary>
		/// Limite de itens a buscar.
		/// Ter em mente que a apresentação deverá processar, para cada 
		/// item obtido, a sua imagem, redimensionando, o que gasta processamento.
		/// </summary>
        private const int padrãoLimiteMínimo = 7;
        private const int padrãoLimiteMáximo = 50;
        private const int padrãoDemoraMáximaMs = 100;

		// Atributos
		private ListViewMercadoria          lst;
        private ControladorLimiteColetor    controladorLimite;      // Controla o limite de entidades
        private Tabela tabela;

        public Tabela Tabela { get { return tabela; } set { tabela = value; } }
			
		/// <summary>
		/// Constrói o coletor de mercadorias
		/// </summary>
		public ColetorMercadoria(ListViewMercadoria lst, Tabela tabela)
		{
            controladorLimite = new ControladorLimiteColetor(padrãoLimiteMínimo, padrãoLimiteMáximo, padrãoDemoraMáximaMs);

#if DEBUG
			if (lst == null)
				throw new ArgumentNullException("Coletor construído com lista nula!");
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
            Console.WriteLine("ColetorMercadoria: Início!");
            Console.WriteLine("{0} mercadorias na lista anterior", lst.Items.Count);
#endif

            // Desnecessário após uso da árvore patrícia.
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
                mercadorias = Entidades.Mercadoria.Mercadoria.ObterMercadorias(chave, controladorLimite.LimiteDinâmico, tabela);

            //    cache[chave] = mercadorias;
            //}

			lst.Mostrar(mercadorias);

            if (mercadorias.Length > 0)
                mercadorias[0].Preparar();

#if DEBUG
            Console.WriteLine("ColetorMercadoria: Término!");
            Console.WriteLine("{0} mercadorias", mercadorias.Length);
            Console.WriteLine("==========================");
#endif

            controladorLimite.CronometrarFimObter();
		}

		private delegate bool ReaproveitarDadosCallback(string chave);

		/// <summary>
		/// Reaproveita os dados já existentes na lista.
		/// </summary>
		/// <returns>Se foi possível reaproveitar os dados.</returns>
		private bool ReaproveitarDados(string chave)
		{
			// Não recuperar caso todos os itens tenham o mesmo prefixo.
			if (lst.Items.Count > 0 && chave.Length > ÚltimaChave.Length && ÚltimaChave.Length > 0)
			{
				if (lst.Items[0].Text.StartsWith(chave) && lst.Items[lst.Items.Count - 1].Text.StartsWith(chave))
					return true;
			}

			// Caso seja continuação do prefixo, verificar se já está na lista.
			if (lst.Items.Count > 0 && chave.StartsWith(ÚltimaChave) && ÚltimaChave.Length > 0)
			{
                ListViewItem[] remoção = new ListViewItem[lst.Items.Count];

                /* O reaproveitamento só é considerado OK quando
                 * o último item não é removido, indicando que
                 * certamente não há mais elementos com este prefixo
                 * depois do último já exibido.
                 */
                bool ok = false;
				int removidos = 0;

				foreach (ListViewItem item in lst.Items)
				{
					if (!item.Text.StartsWith(chave))
					{
						remoção[removidos++] = item;
						ok = true;
					}
					else
						ok = false;
				}

				/* Se nenhum item foi removido depois de ter encontrado o prefixo,
				 * então mais itens podem existir que não foram recuperados na
				 * pesquisa passada.
				 */
				if (lst.Items.Count > removidos && ok)
				{
					for (int i = 0; i < removidos; i++)
						lst.Items.Remove(remoção[i]);

					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Recupera primeira referência somente
		/// </summary>
		/// <param name="chave">Chave de procura</param>
		/// <returns>Referência</returns>
		public string RecuperarPrimeiroSomente(string chave)
		{
#if DEBUG
            System.Diagnostics.Debug.Assert(!chave.Contains("."), "Chave deveria ser referência numérica");
#endif
			if (Pesquisando || chave != Chave || lst.Items.Count == 0)
			{
				Cancelar();
				
				return Entidades.Mercadoria.Mercadoria.ObterReferênciaPróxima(chave);
			}

			// Se a pesquisa já tiver sido feita, recuperar da ListView
			return lst.Items[0].Text;
		}

		public override string ToString()
		{
			return "ColetorMercadoria";
		}
	}
}

