using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Configuração;
using System.Data;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Data relevante para uma pessoa.
    /// </summary>
    [DbTabela("pessoadatarelevante")]
    public sealed class DataRelevante : DbManipulaçãoAutomática
    {
        [DbRelacionamento("codigo", "pessoa"), DbChavePrimária(false)]
        private Pessoa pessoa;

        [DbChavePrimária(false)]
        private DateTime data;

        [DbColuna("descricao")]
        private string descrição;

        private bool alertar = true;

        public DataRelevante() { }

        public DataRelevante(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        #region Propriedades

        /// <summary>
        /// Pessoa vinculada.
        /// </summary>
        public Pessoa Pessoa { get { return pessoa; } }

        /// <summary>
        /// Data relevante.
        /// </summary>
        public DateTime Data
        {
            get { return data; }
            set
            {
                if (Cadastrado)
                    throw new Acesso.Comum.Exceções.AlteraçãoChavePrimária(this);

                data = value;
            }
        }

        /// <summary>
        /// Descrição da data relevante.
        /// </summary>
        public string Descrição
        {
            get { return descrição; }
            set { descrição = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Define se esta data deve ser alertada.
        /// </summary>
        public bool Alertar
        {
            get { return alertar; }
            set { alertar = value; DefinirDesatualizado(); }
        }

        #endregion

        /// <summary>
        /// Obtém as datas relevantes de uma pessoa.
        /// </summary>
        public static DataRelevante[] ObterDatasRelevantes(Entidades.Pessoa.Pessoa pessoa)
        {
            return Mapear<DataRelevante>(
                "SELECT * FROM pessoadatarelevante WHERE pessoa = " +
                DbTransformar(pessoa.Código)).ToArray();
        }

        /// <summary>
        /// Obtém as datas relevantes da próxima semana.
        /// Setor nulo retorna informação para todos os setores.
        /// </summary>
        public static DataRelevante[] ObterPróximasDatasRelevantes(Setor setor, int dias)
        {
            List<DataRelevante> lista = null;
            // *  A consulta Mapear é feita em 0.2 segs, enquanto o mapear gasta 4 segs. *

            if (setor != null)
            {
                lista = ObterLista(
                            string.Format("SELECT d.*, p.*, pessoafisica.* FROM pessoadatarelevante d JOIN pessoa p ON d.pessoa = p.codigo  JOIN pessoafisica on p.codigo=pessoafisica.codigo WHERE CONCAT(YEAR(now()), '-', date_format(d.data, '%m-%d')) BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' AND d.alertar = true "
                + " AND p.setor = {2}",
                DadosGlobais.Instância.HoraDataAtual, DadosGlobais.Instância.HoraDataAtual.AddDays(dias),
                            setor.Código) + " UNION " +
                           string.Format("SELECT p.codigo AS pessoa, pf.nascimento AS data, 'Aniversário' as descricao, 1 AS alertar, p.*, pf.* FROM pessoa p JOIN pessoa on p.codigo=pessoa.codigo JOIN pessoafisica pf ON p.codigo = pf.codigo WHERE CONCAT(YEAR(now()), '-', date_format(pf.nascimento, '%m-%d')) BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' " +
                           " AND p.setor = {2}",
                            DadosGlobais.Instância.HoraDataAtual, DadosGlobais.Instância.HoraDataAtual.AddDays(dias),
                            setor.Código), 0, 4, 17);
            }
            else
            {
                lista = ObterLista(
                            string.Format("SELECT d.*, p.*, pessoafisica.* FROM pessoadatarelevante d JOIN pessoa p ON d.pessoa = p.codigo  JOIN pessoafisica on p.codigo=pessoafisica.codigo WHERE CONCAT(YEAR(now()), '-', date_format(d.data, '%m-%d')) BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' AND d.alertar = true ",
                            DadosGlobais.Instância.HoraDataAtual, DadosGlobais.Instância.HoraDataAtual.AddDays(dias)) + " UNION " +
                           
                            string.Format("SELECT p.codigo AS pessoa, pf.nascimento AS data, 'Aniversário' as descricao, 1 AS alertar, p.*, pf.* FROM pessoa p JOIN pessoa on p.codigo=pessoa.codigo JOIN pessoafisica pf ON p.codigo = pf.codigo WHERE CONCAT(YEAR(now()), '-', date_format(pf.nascimento, '%m-%d')) BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' ",
                            DadosGlobais.Instância.HoraDataAtual, DadosGlobais.Instância.HoraDataAtual.AddDays(dias))
                            , 0, 4, 17);
            }

            return lista.ToArray();
        }

        private static List<DataRelevante> ObterLista(string consulta, int inicioDataRelevante, int inicioPessoa, int inicioPessoaFisica)
        {
            List<DataRelevante> lista = new List<DataRelevante>();

            IDataReader leitor = null;
            IDbConnection conexao = Conexão;

            lock (conexao)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexao);
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = consulta;

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                            while (leitor.Read())
                            {
                                PessoaFísica pessoa = PessoaFísica.Obter(leitor, inicioPessoa, inicioPessoaFisica);

                                DataRelevante data = new DataRelevante(pessoa);
                                data.data = leitor.GetDateTime(inicioDataRelevante + 1);
                                data.descrição = leitor.GetString(inicioDataRelevante + 2);
                                data.alertar = leitor.GetBoolean(inicioDataRelevante + 3);

                                lista.Add(data);
                            }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexao);
                    }
                }
            }

            return lista;
        }
    }
}
