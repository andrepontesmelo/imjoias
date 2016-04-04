using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Text.RegularExpressions;
using System.Data;

namespace Entidades.Pessoa.Endereço
{
    /// <summary>
    /// Entidade que contém informações de endereço de uma pessoa.
    /// </summary>
    [DbTabela("endereco")]
    public class Endereço : DbManipulaçãoAutomática
    {
        /// <summary>
        /// Pessoa vinculada ao endereço.
        /// </summary>
        [DbRelacionamento(true, "codigo", "pessoa")]
        private Pessoa pessoa;

        [DbChavePrimária(false)]
        private uint id = 0;

        /// <summary>
        /// Descrição do endereço.
        /// </summary>
        [DbColuna("descricao")]
        private string descrição;

        private string logradouro;
        private string cep;
        private string bairro;

        [DbColuna("numero")]
        private string número;
        private string complemento;

        [DbRelacionamento("código", "localidade")]
        private Localidade localidade;

        [DbColuna("observacoes")]
        private string observações;

        public Endereço() { }

        public Endereço(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        #region Propriedades

        /// <summary>
        /// Pessoa que possui este endereço.
        /// </summary>
        public Pessoa Pessoa { get { return pessoa; } set { pessoa = value; DefinirCadastrado(false); } }

        /// <summary>
        /// Descrição deste endereço.
        /// </summary>
        public string Descrição { get { return descrição; } set { descrição = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Identificação do endereço da pessoa.
        /// </summary>
        protected uint EndereçoID { get { return id; } }

        public string Logradouro { get { return logradouro; } set { logradouro = value; DefinirDesatualizado(); } }
        public string CEP { get { return cep; } set { cep = value; DefinirDesatualizado(); } }
        public string Bairro { get { return bairro; } set { bairro = value; DefinirDesatualizado(); } }
        public string Número { get { return número; } set { número = value; DefinirDesatualizado(); } }
        public string Complemento { get { return complemento; } set { complemento = FormatarComplemento(value); DefinirDesatualizado(); } }
        public Localidade Localidade { get { return localidade; } set { localidade = value; DefinirDesatualizado(); } }
        public string Observações { get { return observações; } set { observações = value; DefinirDesatualizado(); } }

        #endregion

        #region Recuperação


        /// <summary>
        /// Obtem em consulta única todos os endereços de todas as pessoas.
        /// Dado o código da pessoa, retorna sua lista de endereços
        /// </summary>
        public static Dictionary<ulong, DbComposição<Endereço>> ObterEndereços(List<Pessoa> pessoas)
        {
            // Dado o código da pessoa, retorna sua lista de endereços
            Dictionary<ulong, DbComposição<Endereço>> hash = new Dictionary<ulong, DbComposição<Endereço>>();
            Dictionary<ulong, Pessoa> hashCódigoPessoa = new Dictionary<ulong, Pessoa>();

            if (pessoas.Count == 0)
                return hash;

            foreach (Pessoa p in pessoas)
                hashCódigoPessoa[p.Código] = p;

            IDbConnection conexão = Conexão;
            IDataReader leitor = null;
            List<ulong> localidadesCódigo = new List<ulong>();

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    try
                    {
                        bool primeiro = true;
                        StringBuilder consulta = new StringBuilder("SELECT * FROM endereco " +
                            " JOIN localidade on endereco.localidade=localidade.codigo WHERE pessoa IN (");

                        foreach (Pessoa p in pessoas)
                        {
                            if (!primeiro)
                                consulta.Append(", ");

                            consulta.Append(DbTransformar(p.Código));
                            primeiro = false;
                        }
                        consulta.Append(")");

                        cmd.CommandText = consulta.ToString();

                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                Endereço novo = new Endereço();
                                uint idPessoa = (uint)leitor.GetInt32(0);
                                novo.id = (uint)leitor.GetInt32(1);
                                novo.pessoa = hashCódigoPessoa[idPessoa];
                                novo.descrição = leitor.GetString(2);
                                novo.logradouro = leitor.GetString(3);
                                novo.cep = leitor.IsDBNull(4) ? null : leitor.GetString(4);
                                novo.bairro = leitor.IsDBNull(5) ? null : leitor.GetString(5);
                                novo.número = leitor.IsDBNull(6) ? null : leitor.GetString(6);
                                novo.complemento = leitor.IsDBNull(7) ? null : leitor.GetString(7);
                                // 9: código da localidade, mas repete no 10 que é o JOIN da localidade em sí.
                                novo.observações = leitor.IsDBNull(9) ? null : leitor.GetString(9);

                                novo.localidade = Localidade.Obter(leitor, 10);

                                DbComposição<Endereço> listaEndereços = null;

                                if (!hash.TryGetValue(idPessoa, out listaEndereços))
                                {
                                    listaEndereços = new DbComposição<Endereço>();
                                    hash[idPessoa] = listaEndereços;
                                }

                                listaEndereços.AdicionarJáCadastrado(novo);
                            }

                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }

            return hash;
        }

        public static Endereço[] ObterEndereços(Pessoa pessoa)
        {
            return Mapear<Endereço>("select * from endereco where pessoa = " + DbTransformar(pessoa.Código)).ToArray();
        }

        #endregion

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            if (localidade == null)
                throw new ArgumentNullException("Localidade não pode ser nula em um endereço.");

            if (!localidade.Cadastrado)
                CadastrarEntidade(cmd, localidade);

            cmd.CommandText = "SELECT MAX(id) FROM endereco WHERE pessoa = " + DbTransformar(pessoa.Código);
            object mId = cmd.ExecuteScalar();

            if (mId != null && mId != DBNull.Value)
                id = Convert.ToUInt32(mId) + 1;

            base.Cadastrar(cmd);
        }

        private static string FormatarComplemento(string value)
        {
            if (value != null)
            {
                Regex regex;
                Match match;

                regex = new Regex(
                    @"((?<loja>(LOJA|LJ(\.)?|LOJ(\.)?|L(\.?)))"
                    + @"|(?<sala>(SALA|SL(\.)?))"
                    + @"|(?<apto>(AP(TO|T)?(\.)?|APARTAMENTO))"
                    + @"|(?<bloco>BL(OCO|\.)?)\s*(?<numbloco>(\d+|\w+))\s*(?<apto>(AP(TO|T)?(\.)?|APARTAMENTO))"
                    + @")?\s*(?<num>\d+)(?<resto>(\s*\w*)+)",
                    RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
                match = regex.Match(value);

                if (!match.Success || !match.Groups["num"].Success)
                    return value;

                if (match.Groups["loja"].Success)
                    return String.Format("Loja {0}{1}", match.Groups["num"], match.Groups["resto"]);

                if (match.Groups["sala"].Success)
                    return String.Format("Sala {0}{1}", match.Groups["num"], match.Groups["resto"]);

                if (match.Groups["bloco"].Success && match.Groups["apto"].Success)
                    return String.Format("Bloco {0} Apto. {1}{2}", match.Groups["numbloco"], match.Groups["num"], match.Groups["resto"]);

                if (match.Groups["apto"].Success)
                    return String.Format("Apto. {0}{1}", match.Groups["num"], match.Groups["resto"]);
            }

            return value;
        }

        public override string ToString()
        {
            return Logradouro + " " + Número
            + " - Bairro " + Bairro + 
            " - " + Localidade.Nome + 
            " - " + Localidade.Estado.Sigla + 
            " - CEP " + CEP;
        }

        public bool Inválido
        {
            get
            {
                return (String.IsNullOrWhiteSpace(logradouro) || descrição == null || localidade == null);
            }
        }
    }
}
