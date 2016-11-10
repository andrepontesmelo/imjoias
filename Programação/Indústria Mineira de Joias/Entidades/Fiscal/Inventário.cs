using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;
using Entidades.Fiscal.Produção;

namespace Entidades.Fiscal
{
    public class Inventário : DbManipulaçãoSimples
    {
        private string referencia;
        private decimal quantidade;
        private string nome;
        private string classificacaofiscal;
        private int tipounidade;
        private double valor;
        private double valortotal;

        public Inventário()
        {
        }

        public string Referência => referencia;
        public decimal Quantidade => quantidade;
        public string Descrição => nome;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(tipounidade);
        public string ValorFormatado => valor.ToString("C");
        public double ValorUnitário => valor;
        public double ValorTotal => valortotal;
        public string ValorTotalFormatado => valortotal.ToString("C");

        public string ClassificaçãoFiscal
        {
            get { return classificacaofiscal; }
            set { classificacaofiscal = value; }
        }


        public static List<Inventário> Obter(DateTime? dataLimite)
        {
            return Mapear<Inventário>(string.Format("call inventario({0})", 
                dataLimite == null ? "NOW()" : DbTransformar(dataLimite.Value)));
        }

        public ItemProduçãoFiscal ObterItemProdução()
        {
            return new ItemProduçãoFiscal(Referência, Math.Abs(Quantidade));
        }

        public string ClassificaçãoFiscalFormatada
        {
            get
            {
                var classificação = classificacaofiscal == null ? "" : ClassificaçãoFiscal;

                if (classificação.Length < 10)
                    classificação = classificação.PadLeft(10, '0');
                    
                return string.Format("{0}.{1}.{2}.{3}.{4}",
                    classificação.Substring(0, 3),
                    classificação.Substring(3, 2),
                    classificação.Substring(5, 1),
                    classificação.Substring(6, 2),
                    classificação.Substring(8, 2));
            }
        }
    }
}
