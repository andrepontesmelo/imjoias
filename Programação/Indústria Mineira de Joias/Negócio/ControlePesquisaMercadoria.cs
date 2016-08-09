using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using Entidades;
using Entidades.Mercadoria;

namespace Negócio
{
    public class ControlePesquisaMercadoria : DbManipulaçãoSimples, IDisposable
    {
        private IDbCommand cmd;
        private Tabela tabela;
        private IDbConnection cn = null;

        public ControlePesquisaMercadoria(Tabela tabela)
        {
            this.tabela = tabela;

            CriarTabela();
        }

        private void CriarTabela()
        {
            if (cmd == null)
            {
                cn = Conexão;
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(cn);
                cmd = Conexão.CreateCommand();
            }

            cmd.CommandText = "CREATE TEMPORARY TABLE IF NOT EXISTS tmpPesquisaMercadoria "
                + "SELECT m.referencia, m.peso, m.depeso, t.coeficiente AS indice FROM mercadoria m JOIN " + 
                " tabelamercadoria t ON m.referencia = t.mercadoria WHERE m.foradelinha = 0 AND m.depeso = 0 " + 
                " AND t.tabela = " + DbTransformar(tabela.Código);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO tmpPesquisaMercadoria "
                + "SELECT m.referencia, m.peso, m.depeso, t.coeficiente * m.peso AS indice FROM mercadoria m JOIN " + 
                " tabelamercadoria t ON m.referencia = t.mercadoria WHERE m.foradelinha = 0 AND m.depeso = 1 " +
                " AND m.peso IS NOT NULL AND t.tabela = " + DbTransformar(tabela.Código);

            cmd.ExecuteNonQuery();

        }

        public void Dispose()
        {
            cmd.CommandText = "DROP TABLE tmpPesquisaMercadoria";
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            if (cn != null)
                Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(cn);
        }

        public void FiltrarÍndice(double índice)
        {
            cmd.CommandText = "DELETE FROM tmpPesquisaMercadoria WHERE indice > " + DbTransformar(índice);
            cmd.ExecuteNonQuery();
        }

        public void FiltrarPedras(Pedra[] pedras)
        {
            StringBuilder str = new StringBuilder();

            str.Append("DELETE FROM tmpPesquisaMercadoria WHERE SUBSTR(referencia, 7, 2) NOT IN (");

            FiltrarPedras(pedras, str);

            cmd.CommandText = str.ToString();
            cmd.ExecuteNonQuery();
        }

        private static void FiltrarPedras(Pedra[] pedras, StringBuilder str)
        {
            int cnt = 0;

            foreach (Pedra pedra in pedras)
            {
                foreach (string código in pedra.ObterCódigosReferência())
                {
                    if (cnt++ > 0)
                        str.Append(", ");

                    str.Append(DbTransformar(código));
                }
            }

            str.Append(")");
        }

        public void FiltrarMetais(Metal[] metais)
        {
            StringBuilder str = new StringBuilder();

            str.Append("DELETE FROM tmpPesquisaMercadoria WHERE SUBSTR(referencia, 9, 1) NOT IN (");
            FiltrarMetais(metais, str);

            cmd.CommandText = str.ToString();
            cmd.ExecuteNonQuery();
        }

        private static void FiltrarMetais(Metal[] metais, StringBuilder str)
        {
            int cnt = 0;

            foreach (Metal metal in metais)
            {
                if (cnt++ > 0)
                    str.Append(", ");

                str.Append(DbTransformar(metal.Código));
            }

            str.Append(")");
        }

        public void FiltrarTipos(MercadoriaTipo[] tipos)
        {
            StringBuilder str = new StringBuilder();

            str.Append("DELETE FROM tmpPesquisaMercadoria WHERE SUBSTR(referencia, 2, 2) NOT IN (");

            FiltrarTipos(tipos, str);

            cmd.CommandText = str.ToString();
            cmd.ExecuteNonQuery();
        }

        private static void FiltrarTipos(MercadoriaTipo[] tipos, StringBuilder str)
        {
            int cnt = 0;

            foreach (MercadoriaTipo tipo in tipos)
            {
                if (cnt++ > 0)
                    str.Append(", ");

                str.Append(DbTransformar(tipo.Código));
            }

            str.Append(")");
        }

        public Mercadoria[] ObterMercadorias()
        {
            return ObterMercadorias(ObterReferências());
        }

        private Mercadoria[] ObterMercadorias(List<string> referências)
        {
            Mercadoria[] mercadorias = new Mercadoria[referências.Count];
            int x = 0;

            foreach (string referência in referências)
            {
                Mercadoria m = Mercadoria.ObterMercadoriaComCache(referência, tabela);
                mercadorias[x++] = m;
            }

            return mercadorias;
        }

        private List<string> ObterReferências()
        {
            List<string> referências = new List<string>();

            cmd.CommandText = "SELECT referencia FROM tmpPesquisaMercadoria";

            using (IDataReader leitor = cmd.ExecuteReader())
            {
                try
                {
                    while (leitor.Read())
                        referências.Add(leitor.GetString(0));
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();
                }
            }

            return referências;
        }
    }
}
