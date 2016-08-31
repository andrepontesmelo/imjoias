using Acesso.Comum.Cache;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;

namespace Entidades.Mercadoria.Componente
{
    [Cache�vel("Obter")]
    public class ComponenteCusto : Componente
    {
        private string multiplicarcomponentecusto;
        private double valor;

        private static Dictionary<string, ComponenteCusto> hashC�digoComponente = null;
        private static List<ComponenteCusto> lista = null;

        public string MultiplicarComponenteCusto
        {
            get { return multiplicarcomponentecusto; }
            set
            {
                if (value == multiplicarcomponentecusto)
                    return;

                multiplicarcomponentecusto = value;
                DefinirDesatualizado();
            }
        }

        public static void CadastrarAtualizarTransa��o�nica(List<ComponenteCusto> lstPend�nciaCadastro, 
            List<ComponenteCusto> lstPend�nciaAtualiza��o)
        {
            IDbConnection conex�o = Conex�o;
            IDbTransaction transa��o = conex�o.BeginTransaction();

            CadastrarTransa��o(lstPend�nciaCadastro, transa��o);
            AtualizarTransa��o(lstPend�nciaAtualiza��o, transa��o);

            transa��o.Commit();
        }

        public static void LiberarCache()
        {
            hashC�digoComponente = null;
            lista = null;
        }

        private static void AtualizarTransa��o(List<ComponenteCusto> lstPend�nciaAtualiza��o, IDbTransaction transa��o)
        {
            ExecutarComandoTransa��o(ObterComandoAtualiza��o(lstPend�nciaAtualiza��o), transa��o);
        }

        private static string ObterComandoAtualiza��o(List<ComponenteCusto> lstPend�nciaAtualiza��o)
        {
            StringBuilder cmd = new StringBuilder();

            foreach (ComponenteCusto c in lstPend�nciaAtualiza��o)
            {
                cmd.Append(string.Format("update componente set nome='{0}' where codigo='{1}';", c.Nome, c.C�digo));

                cmd.Append(string.Format("update componentecusto set multiplicarcomponentecusto={0}, valor='{1}' where codigo='{2}';",
                    ObterSQLMultiplicadorComponenteCusto(c), DbTransformar(c.Valor), c.C�digo));
            }

            return cmd.ToString();
        }

        private static void CadastrarTransa��o(List<ComponenteCusto> lstPend�nciaCadastro, IDbTransaction transa��o)
        {
            ExecutarComandoTransa��o(ObterComandoCadastro(lstPend�nciaCadastro), transa��o);
        }

        private static string ObterComandoCadastro(List<ComponenteCusto> lstPend�nciaCadastro)
        {
            StringBuilder cmd = new StringBuilder();

            foreach (ComponenteCusto c in lstPend�nciaCadastro)
            {
                cmd.Append(string.Format("insert into componente (codigo, nome) values ('{0}', '{1}');", c.C�digo, c.Nome));

                cmd.Append(string.Format("insert into componentecusto (codigo, multiplicarcomponentecusto, valor) VALUES ('{0}', {1}, '{2}');",
                    c.C�digo, ObterSQLMultiplicadorComponenteCusto(c), DbTransformar(c.Valor)));
            }

            return cmd.ToString();
        }

        private static string ObterSQLMultiplicadorComponenteCusto(ComponenteCusto c)
        {
            if (String.IsNullOrWhiteSpace(c.MultiplicarComponenteCusto))
                return "NULL";

            return string.Format("'{0}'", c.MultiplicarComponenteCusto.Trim().ToUpper());
        }

        public double Valor
        {
            get { return valor; }
            set 
            {
                if (value.Equals(valor))
                    return;

                valor = value;
                DefinirDesatualizado();
            }
        }

        public static List<ComponenteCusto> Lista
        {
            get
            {
                if (lista == null)
                    Carregar();

                return lista;
            }
        }

        private static Dictionary<string, ComponenteCusto> ObterHash()
        {
            if (hashC�digoComponente == null)
                Carregar();

            return hashC�digoComponente;
        }

        private static void Carregar()
        {
            lista = Mapear<ComponenteCusto>("select * from componentecusto c join componente n on c.codigo=n.codigo");
            hashC�digoComponente = CriarHash(lista);
        }

        public static new ComponenteCusto Obter(string c�digo)
        {
            ComponenteCusto retorno = null;

            ObterHash().TryGetValue(c�digo, out retorno);

            return retorno;
        }

        private static Dictionary<string, ComponenteCusto> CriarHash(List<ComponenteCusto> componentes)
        {
            hashC�digoComponente = new Dictionary<string, ComponenteCusto>(componentes.Count);

            foreach (ComponenteCusto c in componentes)
                hashC�digoComponente.Add(c.C�digo, c);

            return hashC�digoComponente;
        }

        public static implicit operator ComponenteCusto(string c�digo)
        {
            return ObterHash()[c�digo] as ComponenteCusto;
        }
    }
}
