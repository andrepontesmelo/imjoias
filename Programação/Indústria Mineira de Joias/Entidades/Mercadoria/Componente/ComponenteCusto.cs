using Acesso.Comum.Cache;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;

namespace Entidades.Mercadoria.Componente
{
    [Cacheável("Obter")]
    public class ComponenteCusto : Componente
    {
        private string multiplicarcomponentecusto;
        private double valor;

        private static Dictionary<string, ComponenteCusto> hashCódigoComponente = null;
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

        public static void CadastrarAtualizarTransaçãoÚnica(List<ComponenteCusto> lstPendênciaCadastro, 
            List<ComponenteCusto> lstPendênciaAtualização)
        {
            IDbConnection conexão = Conexão;
            IDbTransaction transação = conexão.BeginTransaction();

            CadastrarTransação(lstPendênciaCadastro, transação);
            AtualizarTransação(lstPendênciaAtualização, transação);

            transação.Commit();
        }

        public static void LiberarCache()
        {
            hashCódigoComponente = null;
            lista = null;
        }

        private static void AtualizarTransação(List<ComponenteCusto> lstPendênciaAtualização, IDbTransaction transação)
        {
            ExecutarComandoTransação(ObterComandoAtualização(lstPendênciaAtualização), transação);
        }

        private static string ObterComandoAtualização(List<ComponenteCusto> lstPendênciaAtualização)
        {
            StringBuilder cmd = new StringBuilder();

            foreach (ComponenteCusto c in lstPendênciaAtualização)
            {
                cmd.Append(string.Format("update componente set nome='{0}' where codigo='{1}';", c.Nome, c.Código));

                cmd.Append(string.Format("update componentecusto set multiplicarcomponentecusto={0}, valor='{1}' where codigo='{2}';",
                    ObterSQLMultiplicadorComponenteCusto(c), DbTransformar(c.Valor), c.Código));
            }

            return cmd.ToString();
        }

        private static void CadastrarTransação(List<ComponenteCusto> lstPendênciaCadastro, IDbTransaction transação)
        {
            ExecutarComandoTransação(ObterComandoCadastro(lstPendênciaCadastro), transação);
        }

        private static string ObterComandoCadastro(List<ComponenteCusto> lstPendênciaCadastro)
        {
            StringBuilder cmd = new StringBuilder();

            foreach (ComponenteCusto c in lstPendênciaCadastro)
            {
                cmd.Append(string.Format("insert into componente (codigo, nome) values ('{0}', '{1}');", c.Código, c.Nome));

                cmd.Append(string.Format("insert into componentecusto (codigo, multiplicarcomponentecusto, valor) VALUES ('{0}', {1}, '{2}');",
                    c.Código, ObterSQLMultiplicadorComponenteCusto(c), DbTransformar(c.Valor)));
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
            if (hashCódigoComponente == null)
                Carregar();

            return hashCódigoComponente;
        }

        private static void Carregar()
        {
            lista = Mapear<ComponenteCusto>("select * from componentecusto c join componente n on c.codigo=n.codigo");
            hashCódigoComponente = CriarHash(lista);
        }

        public static new ComponenteCusto Obter(string código)
        {
            ComponenteCusto retorno = null;

            ObterHash().TryGetValue(código, out retorno);

            return retorno;
        }

        private static Dictionary<string, ComponenteCusto> CriarHash(List<ComponenteCusto> componentes)
        {
            hashCódigoComponente = new Dictionary<string, ComponenteCusto>(componentes.Count);

            foreach (ComponenteCusto c in componentes)
                hashCódigoComponente.Add(c.Código, c);

            return hashCódigoComponente;
        }

        public static implicit operator ComponenteCusto(string código)
        {
            return ObterHash()[código] as ComponenteCusto;
        }
    }
}
