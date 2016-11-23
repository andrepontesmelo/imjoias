using Acesso.Comum;
using Entidades.Fiscal.Tipo;

namespace Entidades.Fiscal.Registro
{
    public abstract class RegistroAbstrato : DbManipulaçãoSimples
    {
        protected string referencia;
        protected string descricao;
        protected int tipounidade;
        protected string classificacaofiscal;

        public string ClassificaçãoFiscal
        {
            get { return classificacaofiscal; }
            set { classificacaofiscal = value; }
        }

        protected string FormatarMoeda(decimal valor)
        {
            return valor.ToString("C");
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


        public string Referência => referencia;
        public string Descrição => descricao;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(tipounidade);
    }
}
