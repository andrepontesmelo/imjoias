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

        public string Esquema => esquema;
        public string Referência => referencia;
        public decimal Quantidade => quantidade;
        public string Descrição => descricao;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(tipounidade);

        public static List<Ingrediente> Obter(string esquema)
        {
            return Mapear<Ingrediente>(
                string.Format("select i.*, m.nome as descricao, m.tipounidade from ingredienteesquemaproducaofiscal i join mercadoria m on " + 
                " i.referencia=m.referencia where esquema={0}", DbTransformar(esquema)));
        }
    }
}
