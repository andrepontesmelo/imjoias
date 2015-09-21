using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Acerto.Sumário
{
    public class SumárioTotalAcerto
    {
        private AcertoConsignado acerto;

        private Dictionary<string, SumárioTotalAcertoItemValores> hashValores = null;

        public SumárioTotalAcerto(AcertoConsignado acerto)
        {
            this.acerto = acerto;
        }

        private string GeraChave(string tipo, bool depeso)
        {
            return tipo + depeso.ToString();
        }

        public void Obter()
        {
#if DEBUG
            if (hashValores != null)
                throw new Exception("Obter sendo chamado mais de uma vez");
#endif

            hashValores = new Dictionary<string, SumárioTotalAcertoItemValores>();

            List<SumárioTotalAcertoItem> itens = SumárioTotalAcertoItem.Obter(acerto);
            foreach (SumárioTotalAcertoItem i in itens)
            {
                string chave = GeraChave(i.Tipo, i.Depeso);
                hashValores.Add(chave, i);
            }
        }

        public SumárioTotalAcertoItemValores ObterValores(EnumTipoSumário tipo, bool depeso)
        {
#if DEBUG
            if (hashValores == null)
                throw new Exception("Chave Obter() antes.");
#endif

            SumárioTotalAcertoItemValores resultado;
            if (!hashValores.TryGetValue(GeraChave(tipo.ToString(), depeso), out resultado))
                resultado = new SumárioTotalAcertoItemValores();

            return resultado;
        }

        public SumárioTotalAcertoItemValores ObterValores(EnumTipoSumário tipo)
        {
            SumárioTotalAcertoItemValores dePeso = ObterValores(tipo, true);
            SumárioTotalAcertoItemValores dePeça = ObterValores(tipo, false);

            return dePeso.Soma(dePeça);
        }

        public SumárioTotalAcertoItemValores ObterSaldo(bool depeso)
        {
            return SumárioTotalAcertoItem.ObterSaldo(
                ObterValores(EnumTipoSumário.Saida, depeso),
                ObterValores(EnumTipoSumário.Retorno, depeso),
                ObterValores(EnumTipoSumário.Venda, depeso));
        }

    }
}
