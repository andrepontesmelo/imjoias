using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Pagamentos
{
    public class Pagamento
    {
        public enum TipoEnum { Cheque, Dinheiro, NotaPromissoria };

        private TipoEnum tipo;
        private long cliente;
        private double valor;
        private DateTime data, dataCobrança;
        private bool pendente;


        public Pagamento(TipoEnum tipo, long cliente, double valor, DateTime data, DateTime dataCobrança)
        {
            this.tipo = tipo;
            this.cliente = cliente;
            this.valor = valor;
            this.data = data;
            this.dataCobrança = dataCobrança;

            this.pendente = (tipo == TipoEnum.NotaPromissoria);
        }

        public void Gravar(DataSet mysql)
        {
            DataRow novoPagamento = mysql.Tables["pagamento"].NewRow();
            novoPagamento["cliente"] = cliente;
            novoPagamento["valor"] = valor;
            novoPagamento["data"] = data;
            novoPagamento["pendente"] = pendente;
            novoPagamento["registradorpor"] = 999;

            mysql.Tables["pagamento"].Rows.Add(novoPagamento);

            DataRow novoPagamentoEspecifico = null;

            switch (tipo)
            {
                case TipoEnum.Dinheiro:
                    novoPagamentoEspecifico = mysql.Tables["dinheiro"].NewRow();
                    mysql.Tables["dinheiro"].Rows.Add(novoPagamentoEspecifico);
                    break;

                case TipoEnum.Cheque:
                    novoPagamentoEspecifico = mysql.Tables["cheque"].NewRow();
                    novoPagamentoEspecifico["vencimento"] = dataCobrança;
                    novoPagamentoEspecifico["cpf"] = DBNull.Value;
                    mysql.Tables["cheque"].Rows.Add(novoPagamentoEspecifico);
                    break;

                case TipoEnum.NotaPromissoria:
                    novoPagamentoEspecifico = mysql.Tables["notapromissoria"].NewRow();
                    novoPagamentoEspecifico["vencimento"] = dataCobrança;
                    mysql.Tables["notapromissoria"].Rows.Add(novoPagamentoEspecifico);
                    break;
            }

            novoPagamentoEspecifico["codigo"] = novoPagamento["codigo"];
        }

        public static TipoEnum ReconhecerTipo(string descrição)
        {
            descrição = descrição.ToLower();

            if (descrição.Contains("dinheiro"))
                return TipoEnum.Dinheiro;

            if (descrição.Contains("promi") || descrição.Contains("np"))
                return TipoEnum.NotaPromissoria;

            return TipoEnum.Cheque;
        }
    }
}
