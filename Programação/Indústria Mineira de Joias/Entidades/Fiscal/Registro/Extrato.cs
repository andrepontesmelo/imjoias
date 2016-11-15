using Acesso.Comum;
using Entidades.Fiscal.Registro;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Extrato : RegistroAbstrato
    {
        private const string SIGLA_ENTRADA = "E";
        private const string SIGLA_SAÍDA = "S";
        private const string SIGLA_FABRICAÇÃO_ITEM = "TO";
        private const string SIGLA_CONSUMO_ITEM = "OT";
        private const string SIGLA_CUPOM = "CP";
        private const string SIGLA_NOTA_FISCAL = "NF";

        private int tipodocumento;
        private string tipoextrato;
        private DateTime data;
        private decimal quantidade;
        private decimal valor;

        public Extrato(string tipoextrato)
        {
            this.tipoextrato = tipoextrato;
        }

        public Extrato(string tipoextrato, int tipodocumento) : this(tipoextrato)
        {
            this.tipodocumento = tipodocumento;
        }

        public TipoDocumento TipoDocumento => TipoDocumento.Obter(tipodocumento);
        public string TipoExtrato => tipoextrato;
        public DateTime Data => data;
        public decimal Valor => valor;
        public decimal Quantidade => quantidade;

        public string EntradaSaída
        {
            get
            {
                switch (tipoextrato)
                {
                    case SIGLA_ENTRADA:
                    case SIGLA_FABRICAÇÃO_ITEM:
                        return SIGLA_ENTRADA;
                    case SIGLA_SAÍDA:
                    case SIGLA_CONSUMO_ITEM:
                        return SIGLA_SAÍDA;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public string TipoResumido
        {
            get
            {
                if (tipoextrato == SIGLA_CONSUMO_ITEM)
                    return SIGLA_CONSUMO_ITEM;

                if (tipoextrato == SIGLA_FABRICAÇÃO_ITEM)
                    return SIGLA_FABRICAÇÃO_ITEM;

                switch (tipodocumento)
                {
                    case (int) TipoDocumentoSistema.Cupom:
                        return SIGLA_CUPOM;
                    case (int) TipoDocumentoSistema.NFe:
                        return SIGLA_NOTA_FISCAL;
                    default:
                        return TipoDocumento.NomeResumido;
                }
            }
        }

        public string DataFormatada => string.Format("{0} {1}",
            data.ToShortDateString(), data.ToShortTimeString());

        public string ValorFormatado => FormatarMoeda((double) valor);

        public Extrato()
        {
        }

        public static List<Extrato> Obter(string referência, DateTime início, DateTime fim)
        {
            início = RetirarTempo(início);
            fim = RetirarTempo(fim).AddDays(1);

            return Mapear<Extrato>(
                string.Format("select e.*, nome, classificacaofiscal, tipounidade, CAST(p.novoPrecoCusto as DECIMAL(8,2)) as valor from extratoinventario e " +
                " left join mercadoria m on e.referencia=m.referencia left join novosPrecos p on e.referencia=p.mercadoria " +
                " where e.referencia={0} and data >= {1} and data < {2} order by e.referencia, data",
                referência != null ? DbTransformar(referência) : "e.referencia",
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
