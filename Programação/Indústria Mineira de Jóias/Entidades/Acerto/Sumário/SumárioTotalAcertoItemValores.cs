using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Acerto.Sumário
{
    public class SumárioTotalAcertoItemValores : DbManipulaçãoAutomática
    {
        protected double indice;

        public double Indice
        {
            get { return indice; }
            set { indice = value; }
        }
        protected double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        protected double preco;

        public double Preço
        {
            get { return preco; }
            set { preco = value; }
        }
        protected double qtd;

        public double Qtd
        {
            get { return qtd; }
            set { qtd = value; }
        }

        public SumárioTotalAcertoItemValores()
        {

        }

        public SumárioTotalAcertoItemValores Soma(SumárioTotalAcertoItemValores outro)
        {
            SumárioTotalAcertoItemValores soma = new SumárioTotalAcertoItemValores();
            soma.Qtd = Qtd + outro.Qtd;
            soma.Peso = Peso + outro.Peso;
            soma.Indice = indice + outro.Indice;
            soma.Preço = Preço + outro.Preço;

            return soma;
        }

        internal SumárioTotalAcertoItemValores Subtrai(SumárioTotalAcertoItemValores outro)
        {
            SumárioTotalAcertoItemValores subtração = new SumárioTotalAcertoItemValores();
            subtração.Qtd = Qtd - outro.Qtd;
            subtração.Peso = Peso - outro.Peso;
            subtração.Indice = indice - outro.Indice;
            subtração.Preço = Preço - outro.Preço;

            return subtração;
        }

        public static SumárioTotalAcertoItemValores ObterSaldo(SumárioTotalAcertoItemValores saída,
        SumárioTotalAcertoItemValores retorno,
        SumárioTotalAcertoItemValores venda)
        {
            return saída.Subtrai(retorno).Subtrai(venda);
        }
    }
}
