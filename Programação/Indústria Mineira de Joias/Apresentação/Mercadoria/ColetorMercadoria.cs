using Apresentação.Formulários.Consultas;
using Entidades;
using System;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
    internal class ColetorMercadoria : Coletor
	{
        private const int padrãoLimiteMínimo = 7;
        private const int padrãoLimiteMáximo = 50;
        private const int padrãoDemoraMáximaMs = 100;

		private ListViewMercadoria lst;
        private ControladorLimiteColetor controladorLimite;
        private Tabela tabela;
        public bool SomenteDeLinha { get; set; }

        public Tabela Tabela { get { return tabela; } set { tabela = value; } }
			
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

		protected override void Recuperar(string chave)
		{
			Entidades.Mercadoria.Mercadoria[] mercadorias;

			if (chave.Length == 0)
				return;

#if DEBUG
            Console.WriteLine("==========================");
            Console.WriteLine("ColetorMercadoria: Início!");
            Console.WriteLine("{0} mercadorias na lista anterior", lst.Items.Count);
#endif

            controladorLimite.CronometrarInicioObter();
            mercadorias = Entidades.Mercadoria.Mercadoria.ObterMercadorias(chave, controladorLimite.LimiteDinâmico, tabela, SomenteDeLinha);

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

		private bool ReaproveitarDados(string chave)
		{
			if (lst.Items.Count > 0 && chave.Length > ÚltimaChave.Length && ÚltimaChave.Length > 0)
			{
				if (lst.Items[0].Text.StartsWith(chave) && lst.Items[lst.Items.Count - 1].Text.StartsWith(chave))
					return true;
			}

			if (lst.Items.Count > 0 && chave.StartsWith(ÚltimaChave) && ÚltimaChave.Length > 0)
			{
                ListViewItem[] remoção = new ListViewItem[lst.Items.Count];

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

				if (lst.Items.Count > removidos && ok)
				{
					for (int i = 0; i < removidos; i++)
						lst.Items.Remove(remoção[i]);

					return true;
				}
			}

			return false;
		}

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

			return lst.Items[0].Text;
		}

		public override string ToString()
		{
			return "ColetorMercadoria";
		}
	}
}

