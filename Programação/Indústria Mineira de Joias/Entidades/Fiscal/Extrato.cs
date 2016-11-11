using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Extrato : DbManipulaçãoSimples
    {
        private int tipodocumento;
        private string tipoextrato;
        private string referencia;
        private DateTime data;
        private decimal quantidade;
        private decimal valor;

        public TipoDocumento TipoDocumento => TipoDocumento.Obter(tipodocumento);

        public string TipoExtrato => tipoextrato;
        public string Referência => referencia;
        public DateTime Data => data;
        public decimal Quantidade => quantidade;
        public decimal Valor => valor;

        public string DataFormatada => string.Format("{0} {1}",
            data.ToShortDateString(), data.ToShortTimeString());

        public Extrato()
        {
        }

        public static List<Extrato> Obter(string referência, DateTime início, DateTime fim)
        {
            início = RetirarTempo(início);
            fim = RetirarTempo(fim).AddDays(1);

            return Mapear<Extrato>(
                string.Format("select * from extratoinventario where referencia={0} and data >= {1} and data < {2}",
                DbTransformar(referência),
                DbTransformar(início),
                DbTransformar(fim)));
        }

        private static DateTime RetirarTempo(DateTime fim)
        {
            fim = new DateTime(fim.Year, fim.Month, fim.Day);
            return fim;
        }
    }
}
