using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Acerto;

namespace Entidades.Balanço
{
    public class SaquinhoBalanço : Saquinho
    {
        private double qtdSaída;
        private double qtdRetorno;
        private double qtdVenda;
        private double qtdSedex;
        private double índice;

        public double Índice { get { return Math.Round(índice, 2); } set { índice = value; } }

        public override string IdentificaçãoAgrupável()
        {
            return this.Mercadoria.Referência + Peso.ToString();
        }

        public double QtdVenda
        {
            get { return qtdVenda; }
            set { qtdVenda = value; }
        }

        public double QtdRetorno
        {
            get { return qtdRetorno; }
            set { qtdRetorno = value; }
        }

        public virtual double QtdAcerto
        {
            get { return qtdSaída + qtdSedex - qtdVenda - qtdRetorno; }
        }

        public double QtdSedex
        {
            get { return qtdSedex; }
            set { qtdSedex = value; }
        }

        private double peso;

        public override double Peso
        {
            get
            {
                return peso;
            }
            set
            {
                peso = value;
            }
        }
        public double QtdSaída
        {
            get { return qtdSaída; }
            set { qtdSaída = value; }
        }

        public SaquinhoBalanço(Mercadoria.Mercadoria m, double qtd, double peso, double índice)
            : base(m, qtd)
        {
            this.peso = peso;
            this.índice = índice;

            // Quantidade não tem o menor sentido. Apenas para ser adicionável na bandeja:
            this.Quantidade = 1;
        }


        public override void PreencherDataRow(System.Data.DataRow linha)
        {
            linha["referência"] = Mercadoria.Referência;
            linha["peso"] =  (Mercadoria.DePeso) ? Entidades.Mercadoria.Mercadoria.FormatarPeso(Peso) : "";
            linha["quantidade"] = Quantidade.ToString();
            linha["depeso"] = Mercadoria.DePeso;
            linha["saída"] = qtdSaída.ToString();
            linha["retorno"] = qtdRetorno.ToString();
            linha["venda"] = qtdVenda.ToString();
            linha["sedex"] = qtdSedex.ToString();
            linha["acerto"] = QtdAcerto.ToString();
        }
    }

    public class SaquinhoBalançoComparador : Comparer<SaquinhoBalanço>
    {

        public override int Compare(SaquinhoBalanço x, SaquinhoBalanço y)
        {
            int comparaçãoReferências = x.Mercadoria.ReferênciaNumérica.CompareTo(y.Mercadoria.ReferênciaNumérica);

            if (comparaçãoReferências != 0)
                return comparaçãoReferências;
            else
                return x.Peso.CompareTo(y.Peso);
        }
    }
}
