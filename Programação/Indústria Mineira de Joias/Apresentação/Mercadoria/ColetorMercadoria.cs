using Apresenta��o.Formul�rios.Consultas;
using Entidades;
using System;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria
{
    internal class ColetorMercadoria : Coletor
	{
        private const int padr�oLimiteM�nimo = 7;
        private const int padr�oLimiteM�ximo = 50;
        private const int padr�oDemoraM�ximaMs = 100;

		private ListViewMercadoria lst;
        private ControladorLimiteColetor controladorLimite;
        private Tabela tabela;
        public bool SomenteDeLinha { get; set; }

        public Tabela Tabela { get { return tabela; } set { tabela = value; } }
			
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

		protected override void Recuperar(string chave)
		{
			Entidades.Mercadoria.Mercadoria[] mercadorias;

			if (chave.Length == 0)
				return;

#if DEBUG
            Console.WriteLine("==========================");
            Console.WriteLine("ColetorMercadoria: In�cio!");
            Console.WriteLine("{0} mercadorias na lista anterior", lst.Items.Count);
#endif

            controladorLimite.CronometrarInicioObter();
            mercadorias = Entidades.Mercadoria.Mercadoria.ObterMercadorias(chave, controladorLimite.LimiteDin�mico, tabela, SomenteDeLinha);

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

		private bool ReaproveitarDados(string chave)
		{
			if (lst.Items.Count > 0 && chave.Length > �ltimaChave.Length && �ltimaChave.Length > 0)
			{
				if (lst.Items[0].Text.StartsWith(chave) && lst.Items[lst.Items.Count - 1].Text.StartsWith(chave))
					return true;
			}

			if (lst.Items.Count > 0 && chave.StartsWith(�ltimaChave) && �ltimaChave.Length > 0)
			{
                ListViewItem[] remo��o = new ListViewItem[lst.Items.Count];

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

				if (lst.Items.Count > removidos && ok)
				{
					for (int i = 0; i < removidos; i++)
						lst.Items.Remove(remo��o[i]);

					return true;
				}
			}

			return false;
		}

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

			return lst.Items[0].Text;
		}

		public override string ToString()
		{
			return "ColetorMercadoria";
		}
	}
}

