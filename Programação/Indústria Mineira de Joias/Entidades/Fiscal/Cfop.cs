using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Cfop : DbManipulaçãoAutomática
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public Cfop()
        { }

        public static List<Cfop> Obter()
        {
            return Mapear<Cfop>("select * from fiscal_cfop");
        }

        public static Cfop Obter(int codigo)
        {
            return MapearÚnicaLinha<Cfop>("select * from fiscal_cfop where codigo=" + codigo.ToString());
        }
    }
}
