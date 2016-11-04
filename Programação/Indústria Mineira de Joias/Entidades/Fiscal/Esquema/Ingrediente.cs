using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;

namespace Entidades.Fiscal.Esquema
{
    [DbTabela("ingredienteesquemaproducaofiscal")]
    public class Ingrediente : DbManipulaçãoSimples
    {
        public Ingrediente()
        {
        }

        private string esquema;
        private string referencia;
        private decimal quantidade;
        private string descricao;
        private int tipounidade;
        private int cfop;

        public string Esquema => esquema;
        public string Referência => referencia;
        public decimal Quantidade => quantidade;
        public string Descrição => descricao;
        public int CFOP => cfop;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(tipounidade);

        public static List<Ingrediente> Obter(string esquema)
        {
            return Mapear<Ingrediente>(
                string.Format("select i.*, m.nome as descricao, m.tipounidade, m.cfop from ingredienteesquemaproducaofiscal i join mercadoria m on " + 
                " i.referencia=m.referencia where esquema={0}", DbTransformar(esquema)));
        }
    }
}
