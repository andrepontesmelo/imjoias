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
                + "SELECT m.referencia, m.peso, m.depeso, t.coeficiente AS indice FROM mercadoria m JOIN tabelamercadoria t ON m.referencia = t.mercadoria WHERE m.foradelinha = 0 AND m.depeso = 0 AND t.tabela = " + DbTransformar(tabela.Código);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO tmpPesquisaMercadoria "
                + "SELECT m.referencia, f.peso, m.depeso, t.coeficiente * f.peso AS indice FROM foto f JOIN mercadoria m ON f.mercadoria = m.referencia JOIN tabelamercadoria t ON m.referencia = t.mercadoria WHERE m.foradelinha = 0 AND m.depeso = 1 AND f.peso IS NOT NULL AND t.tabela = " + DbTransformar(tabela.Código);
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
            int cnt = 0;

            str.Append("DELETE FROM tmpPesquisaMercadoria WHERE SUBSTR(referencia, 7, 2) NOT IN (");

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

            cmd.CommandText = str.ToString();
            cmd.ExecuteNonQuery();
        }

        public void FiltrarMetais(Metal[] metais)
        {
            StringBuilder str = new StringBuilder();
            int cnt = 0;

            str.Append("DELETE FROM tmpPesquisaMercadoria WHERE SUBSTR(referencia, 9, 1) NOT IN (");

            foreach (Metal metal in metais)
            {
                if (cnt++ > 0)
                    str.Append(", ");

                str.Append(DbTransformar(metal.Código));
            }

            str.Append(")");

            cmd.CommandText = str.ToString();
            cmd.ExecuteNonQuery();
        }

        public void FiltrarTipos(MercadoriaTipo[] tipos)
        {
            StringBuilder str = new StringBuilder();
            int cnt = 0;

            str.Append("DELETE FROM tmpPesquisaMercadoria WHERE SUBSTR(referencia, 2, 2) NOT IN (");

            foreach (MercadoriaTipo tipo in tipos)
            {
                if (cnt++ > 0)
                    str.Append(", ");

                str.Append(DbTransformar(tipo.Código));
            }

            str.Append(")");

            cmd.CommandText = str.ToString();
            cmd.ExecuteNonQuery();
        }

        struct DadosMercadoria
        {
            public string Referência;
            public double Peso;
            public bool DePeso;
        }

        public List<Mercadoria> ObterMercadorias()
        {
            List<DadosMercadoria> referências = new List<DadosMercadoria>();

            cmd.CommandText = "SELECT referencia, peso, depeso FROM tmpPesquisaMercadoria";

            using (IDataReader leitor = cmd.ExecuteReader())
            {
                try
                {
                    while (leitor.Read())
                    {
                        DadosMercadoria dados;
                        dados.Referência = leitor.GetString(0);
                        dados.Peso = leitor.GetDouble(1);
                        dados.DePeso = leitor.GetBoolean(2);
                        referências.Add(dados);
                    }
                }
                finally
                {
                    leitor.Close();
                }
            }

            List<Mercadoria> mercadorias = new List<Mercadoria>(referências.Count);

            foreach (DadosMercadoria dados in referências)
            {
                if (dados.DePeso)
                    mercadorias.Add(Mercadoria.ObterMercadoria(dados.Referência, dados.Peso, tabela));
                else
                    mercadorias.Add(Mercadoria.ObterMercadoria(dados.Referência, tabela));
            }

            return mercadorias;
        }
    }
}
