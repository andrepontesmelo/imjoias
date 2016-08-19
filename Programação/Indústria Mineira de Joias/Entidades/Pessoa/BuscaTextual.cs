using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades.Pessoa
{
    public class BuscaTextual : Pessoa
    {
        public static readonly int LIMITE_PADRÃO_PESSOAS = 400;
        private static readonly string PREFIXO_CIDADE = "cidade:";

        private enum TipoBusca
        {
            CódigoPessoa,
            TextualGeral,
            Cidade
        }

        public static List<Pessoa> ObterPessoas(string nome)
        {
            return ObterPessoas(nome, LIMITE_PADRÃO_PESSOAS);
        }

        public static List<Pessoa> ObterPessoas(string chaveBusca, int limite)
        {
            if (String.IsNullOrEmpty(chaveBusca))
                return new List<Pessoa>(Representante.ObterRepresentantes());

            IDataReader leitor = null;
            List<Pessoa> pessoas;
            chaveBusca = LimparBusca(chaveBusca);

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())

                {
                    try
                    {
                        pessoas = TentaBuscar(chaveBusca, limite, leitor, cmd);
                    }
                    finally
                    {
                        Finalizar(leitor, conexão);
                    }
                }

                CarregarEndereços(pessoas);

                return pessoas;
            }
        }

        private static List<Pessoa> TentaBuscar(string chaveBusca, int limite, IDataReader leitor, IDbCommand cmd)
        {
            StringBuilder comando = new StringBuilder();

            TipoBusca tipo = ObterTipo(chaveBusca);

            if (tipo != TipoBusca.CódigoPessoa)
                comando.Append("select * from (");

            AdicionaSeleção(comando);
            AdicionaCondição(chaveBusca, comando, tipo);
            AdicionaLimite(limite, comando);

            cmd.CommandText = comando.ToString();

            return ObterPessoas(cmd, leitor);
        }

        private static TipoBusca ObterTipo(string chaveBusca)
        {
            if (chaveBusca.StartsWith(PREFIXO_CIDADE, StringComparison.CurrentCultureIgnoreCase))
                return TipoBusca.Cidade;

            long código;
            if (long.TryParse(chaveBusca, out código))
                return TipoBusca.CódigoPessoa;

            return TipoBusca.TextualGeral;
        }

        private static string LimparBusca(string chaveBusca)
        {
            chaveBusca = chaveBusca.Trim();
            chaveBusca = chaveBusca.Replace("%", "").Replace("'", "").Replace("\"", "").Replace("\\", "").Replace("  ", " ").Replace("  ", " ");
            return chaveBusca;
        }

        private static void AdicionaSeleção(StringBuilder comando)
        {
            comando.Append("SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, " +
                " p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, " +
                " pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE  ");
        }

        private static void AdicionaCondição(string chaveBusca, StringBuilder comando, TipoBusca tipo)
        {
            long código;
            long.TryParse(chaveBusca, out código);

            switch (tipo)
            {
                case TipoBusca.CódigoPessoa:
                    CondiçãoChaveNumérica(comando, código);
                    break;

                case TipoBusca.Cidade:
                    CondiçãoCidade(chaveBusca, comando);
                    break;

                case TipoBusca.TextualGeral:
                    CondiçãoChaveTextual(chaveBusca, comando);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private static void CondiçãoCidade(string chaveBusca, StringBuilder comando)
        {
            chaveBusca = chaveBusca.ToLower().Replace(PREFIXO_CIDADE, "").Trim();
            string chaveComCoringas = chaveBusca.Replace(' ', '%');

            comando.Append(" p.codigo in (select e.pessoa from endereco e join localidade l on e.localidade=l.codigo where l.nome like '%");
            comando.Append(chaveComCoringas);
            comando.Append("%' ) ) aa  ");
        }

        private static void Finalizar(IDataReader leitor, IDbConnection conexão)
        {
            if (leitor != null)
                leitor.Close();

            Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
        }

        private static List<Pessoa> ObterPessoas(IDbCommand cmd, IDataReader leitor)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            using (leitor = cmd.ExecuteReader())
            {
                while (leitor.Read())
                    pessoas.Add(Pessoa.ObterPessoa(leitor, 0, TotalAtributos, TotalAtributos + PessoaFísica.TotalAtributos));
            }

            return pessoas;
        }

        private static void AdicionaLimite(int limite, StringBuilder comando)
        {
            comando.Append(" limit ");
            comando.Append(limite.ToString());
        }

        private static void CondiçãoChaveTextual(string chaveBusca, StringBuilder comando)
        {
            string chaveComCoringas = chaveBusca.Replace(' ', '%');

            // nilma%
            comando.Append(" nome LIKE '");
            comando.Append(chaveBusca);
            comando.Append("%' ");

            if (chaveBusca.Contains(" "))
            {
                // nilma%souza%
                comando.Append(" OR nome LIKE '");
                comando.Append(chaveComCoringas.Substring(0, chaveComCoringas.Length));
                comando.Append("%' ");
            }

            comando.Append(" ORDER BY nome ");
            comando.Append(") aa ");

            BuscaTextualNomePessoa(chaveBusca, comando);
            BuscaTextualFantasia(chaveBusca, comando);
            BuscaTextualEmail(chaveBusca, comando);
            BuscaTextualObservações(chaveBusca, comando);
        }

        private static void CondiçãoChaveNumérica(StringBuilder comando, long código)
        {
            comando.Append(" p.codigo= ");
            comando.Append(DbTransformar(código));
        }

        private static void BuscaTextualNomePessoa(string chaveBusca, StringBuilder comando)
        {
            AdicionaUnião(comando);
            comando.Append(" match(nome) against ('" + chaveBusca + "') ");
        }

        private static void AdicionaUnião(StringBuilder comando)
        {
            comando.Append(" UNION select * FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE ");
        }

        private static void BuscaTextualFantasia(string chaveBusca, StringBuilder comando)
        {
            AdicionaUnião(comando);
            comando.Append(" match(fantasia) against ('" + chaveBusca + "') ");
        }

        private static void BuscaTextualEmail(string chaveBusca, StringBuilder comando)
        {
            AdicionaUnião(comando);
            comando.Append(" match(email) against ('" + chaveBusca + "') ");
        }

        private static void BuscaTextualObservações(string chaveBusca, StringBuilder comando)
        {
            AdicionaUnião(comando);
            comando.Append(" match(observacoes) against ('" + chaveBusca + "') ");
        }
    }
}
