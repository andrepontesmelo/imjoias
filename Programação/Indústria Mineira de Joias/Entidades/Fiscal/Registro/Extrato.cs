﻿using Acesso.Comum;
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

        [DbAtributo(TipoAtributo.Ignorar)]
        private decimal estoque;

        public Extrato(string tipoextrato)
        {
            this.tipoextrato = tipoextrato;
        }

        public Extrato(string tipoextrato, int tipodocumento) : this(tipoextrato)
        {
            this.tipodocumento = tipodocumento;
        }

        public Extrato(string referencia, DateTime data, int quantidade)
        {
            this.referencia = referencia;
            this.data = data;
            this.quantidade = quantidade;
        }

        public Extrato()
        {
        }

        public TipoDocumento TipoDocumento => TipoDocumento.Obter(tipodocumento);
        public string TipoExtrato => tipoextrato;
        public DateTime Data => data;
        public decimal Valor => valor;
        public decimal Quantidade => quantidade;
        public decimal Estoque
        {
            get { return estoque; }
            set { estoque = value; }
        }

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

        public string ValorFormatado => FormatarMoeda(valor);

        public static List<Extrato> ObterEstoqueAcumulado(string referência, Fechamento fechamento)
        {
            var hashReferênciaEstoqueAnterior = InventárioAnterior.ObterHashReferênciaQuantidade(fechamento.Início);

            var resultado = Obter(referência, fechamento);
            CalcularEstoqueAcumulado(resultado, hashReferênciaEstoqueAnterior);

            return resultado;
        }

        private static List<Extrato> Obter(string referência, Fechamento fechamento)
        {
            return Mapear<Extrato>(string.Format("select e.*, mf.descricao, classificacaofiscal, tipounidade, mf.valor from extratoinventario e " +
                " left join mercadoria m on e.referencia = m.referencia " +
                " left join mercadoriafechamento mf on mf.referencia = e.referencia and mf.fechamento = {0} " +
                " where e.referencia = {1} and {2} order by e.referencia, data",
                fechamento.Código,
                referência == null ? "e.referencia" : DbTransformar(referência),
                DbDataEntre("data", fechamento.Início, fechamento.Fim.AddDays(1))));
        }

        public static List<Extrato> CalcularEstoqueAcumulado(List<Extrato> lista, 
            Dictionary<string, decimal> hashReferênciaEstoqueAnterior)
        {
            string últimaReferência = "";
            decimal acumulado = 0;

            foreach (Extrato e in lista)
            {
                if (e.Referência != últimaReferência)
                {
                    últimaReferência = e.Referência;
                    acumulado = 0;
                    hashReferênciaEstoqueAnterior.TryGetValue(e.Referência, out acumulado);
                }

                acumulado += e.Quantidade;
                e.Estoque = acumulado;
            }

            return lista;
        }

        private static DateTime RetirarTempo(DateTime fim)
        {
            fim = new DateTime(fim.Year, fim.Month, fim.Day);
            return fim;
        }
    }
}
