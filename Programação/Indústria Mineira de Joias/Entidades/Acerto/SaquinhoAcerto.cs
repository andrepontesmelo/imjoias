using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Acerto;

namespace Entidades.Acerto
{
    public class SaquinhoAcerto : Saquinho
    {
        private double qtdSa�da;
        private double qtdRetorno;
        private double qtdVenda;
        private double qtdDevolvida;
        private double �ndice;

        public double �ndice { get { return Math.Round(�ndice, 2); } set { �ndice = value; } }

        public override string Identifica��oAgrup�vel()
        {
            return this.Mercadoria.Refer�ncia + Peso.ToString();
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
            get { return qtdSa�da - qtdVenda - qtdRetorno; }
        }

        public double QtdDevolvida
        {
            get { return qtdDevolvida; }
            set { qtdDevolvida = value; }
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
        public double QtdSa�da
        {
            get { return qtdSa�da; }
            set { qtdSa�da = value; }
        }

        public SaquinhoAcerto(Mercadoria.Mercadoria m, double qtd, double peso, double �ndice)
            : base(m, qtd)
        {
            this.peso = peso;
            this.�ndice = �ndice;

            // Quantidade n�o tem o menor sentido. Apenas para ser adicion�vel na bandeja:
            this.Quantidade = 1;
        }

        public override void PreencherDataRow(System.Data.DataRow linha)
        {
            linha["refer�ncia"] = Mercadoria.Refer�ncia;
            linha["peso"] =  (Mercadoria.DePeso) ? Entidades.Mercadoria.Mercadoria.FormatarPeso(Peso) : "";
            linha["quantidade"] = Quantidade.ToString();
            linha["depeso"] = Mercadoria.DePeso;
            linha["sa�da"] = qtdSa�da.ToString();
            linha["retorno"] = qtdRetorno.ToString();
            linha["venda"] = qtdVenda.ToString();
            linha["devolu��o"] = qtdDevolvida.ToString();
            linha["acerto"] = QtdAcerto.ToString();
        }

        public static SaquinhoAcerto Construir(Entidades.Acerto.F�rmulaAcerto f�rmula, Entidades.Mercadoria.Mercadoria mercadoria, double qtd, double peso, double �ndice)
        {
            if (f�rmula == F�rmulaAcerto.Padr�o)
                return new SaquinhoAcerto(mercadoria, qtd, peso, �ndice);
            else if (f�rmula == F�rmulaAcerto.IgualAVenda)
                return new SaquinhoAcertoIgualVenda(mercadoria, qtd, peso, �ndice);
            else
                throw new Exception("Tipo de acerto n�o suportado");
        }
    }

    public class SaquinhoAcertoComparador : Comparer<SaquinhoAcerto>
    {

        public override int Compare(SaquinhoAcerto x, SaquinhoAcerto y)
        {
            int compara��oRefer�ncias = x.Mercadoria.Refer�nciaNum�rica.CompareTo(y.Mercadoria.Refer�nciaNum�rica);

            if (compara��oRefer�ncias != 0)
                return compara��oRefer�ncias;
            else
                return x.Peso.CompareTo(y.Peso);
        }
    }
}
