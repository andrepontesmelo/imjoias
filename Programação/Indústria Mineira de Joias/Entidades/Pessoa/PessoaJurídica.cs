using System;
using System.Data;
using Acesso.Comum.Cache;
using System.Collections.Generic;
using Entidades.Configuração;

namespace Entidades.Pessoa
{
    [Serializable, Cacheável("ObterPessoaSemCache"), Cacheável("ObterPessoaPorCNPJSemCache")]
	public class PessoaJurídica : Pessoa
	{
        protected string fantasia;
        
        protected string cnpj;
        protected string inscEstadual;
        protected string inscMunicipal;
        protected ulong? preposto;

        public string Fantasia
        {
            get { return fantasia; }
            set { fantasia = value; DefinirDesatualizado(); }
        }

        public ulong? Preposto
        {
            get { return preposto; }
            set {
                preposto = value;
                DefinirDesatualizado();
            }
        }

		public string CNPJ
		{
			get { return cnpj; }
            set
            {
                if (value == null)
                {
                    cnpj = null;
                    DefinirDesatualizado();
                } else
                {
                    string cnpjFormatado = FormatarCNPJ(value);

                    if (!ValidarCNPJ(cnpjFormatado))
                        throw new Exception("CNPJ inválido.");

                    cnpj = LimparFormataçãoCnpj(cnpjFormatado);
                    DefinirDesatualizado();
                }
            }
		}

        public string InscEstadual
        {
            get { return inscEstadual; }
            set { inscEstadual = value; DefinirDesatualizado(); }
        }

        public string InscMunicipal
        {
            get { return inscMunicipal; }
            set { inscMunicipal = value; DefinirDesatualizado(); }
        }


        private static PessoaJurídica empresa = null;
        public static PessoaJurídica ObterEmpresa()
        {
            if (empresa == null)
                empresa = ObterPessoaPorCNPJ(DadosGlobais.Instância.CNPJEmpresa);

            return empresa;
        }

        public static PessoaJurídica ObterPessoaPorCNPJ(string cnpj)
        {
            return (PessoaJurídica) CacheDb.Instância.ObterEntidade(typeof(PessoaJurídica), cnpj);
        }

        private static PessoaJurídica ObterPessoaPorCNPJSemCache(string cnpj)
		{
            cnpj = FormatarCNPJ(cnpj);
            
			IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM pessoa p, pessoajuridica pj"
                        + " WHERE p.codigo = pj.codigo"
                        + " AND pj.cnpj = " + DbTransformar(LimparFormataçãoCnpj(cnpj));

                    return MapearÚnicaLinha<PessoaJurídica>(cmd);
                }
            }
		}

        public static List<Pessoa> ObterPessoasPorCNPJ(string cnpj)
        {
            string cnpjLimpo = LimparFormataçãoCnpj(cnpj);

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT p.* FROM pessoa p, pessoajuridica pj"
                        + " WHERE p.codigo = pj.codigo"
                        + " AND pj.cnpj = " + DbTransformar(cnpjLimpo)
                        + " OR pj.cnpj LIKE '%" + cnpj + "%' ";

                    return Mapear<Pessoa>(cmd);
                }
            }
        }

        public new static PessoaJurídica ObterPessoa(ulong código)
        {
            return (PessoaJurídica)CacheDb.Instância.ObterEntidade(typeof(PessoaJurídica), código);
        }

        private new static PessoaJurídica ObterPessoaSemCache(ulong código)
		{
            return Pessoa.ObterPessoaSemCache(código) as PessoaJurídica;
		}

        public static bool ValidarCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = LimparFormataçãoCnpj(cnpj);

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static string LimparFormataçãoCnpj(string cnpj)
        {
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            return cnpj;
        }

        private static bool ExtrairNúmerosCNPJ(string cnpj, out int[] número)
        {
            int i = 0;

            número = new int[13];

            try
            {
                foreach (char c in cnpj)
                    if (char.IsNumber(c))
                        número[i++] = c - '0';

                return i == 13;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public static bool VerificarExistênciaCNPJ(PessoaJurídica entidade)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM pessoajuridica WHERE cnpj = "
                        + DbTransformar(entidade.cnpj);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            cmd.CommandText = "INSERT INTO pessoajuridica (codigo, fantasia, cnpj, " +
                "inscEstadual, inscMunicipal, preposto) VALUES (" +
                DbTransformar(Código) + ", " +
                DbTransformar(Fantasia) + ", " +
                DbTransformar(CNPJ) + ", " +
                DbTransformar(InscEstadual) + ", " +
                DbTransformar(InscMunicipal) + "," +
                DbTransformar(Preposto) + ")";

            cmd.ExecuteNonQuery();
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Atualizar(cmd);

            cmd.CommandText = "UPDATE pessoajuridica SET " +
                "fantasia = " + DbTransformar(fantasia) + ", " +
                "cnpj = " + DbTransformar(cnpj) + ", " +
                "inscEstadual = " + DbTransformar(inscEstadual) + ", " +
                "inscMunicipal = " + DbTransformar(inscMunicipal) + ", " + 
                "preposto = " + DbTransformar(preposto) + 
                " WHERE codigo = " + DbTransformar(codigo);

            cmd.ExecuteNonQuery();
        
        }

        protected virtual void LerAtributos(IDataReader leitor, int inicioAtributoPessoa, int inicioAtributoPessoaJurídica)
        {
          base.LerAtributos(leitor, inicioAtributoPessoa);

          if (!leitor.IsDBNull(inicioAtributoPessoaJurídica + 1))
              cnpj = leitor.GetString(inicioAtributoPessoaJurídica + 1);

          if (!leitor.IsDBNull(inicioAtributoPessoaJurídica + 2))
                fantasia = leitor.GetString(inicioAtributoPessoaJurídica + 2);

          if (!leitor.IsDBNull(inicioAtributoPessoaJurídica + 3))
                inscEstadual = leitor.GetString(inicioAtributoPessoaJurídica + 3);

          if (!leitor.IsDBNull(inicioAtributoPessoaJurídica + 4))
                inscMunicipal = leitor.GetString(inicioAtributoPessoaJurídica + 4);

            if (!leitor.IsDBNull(inicioAtributoPessoaJurídica + 5))
                preposto = (ulong?) leitor.GetInt64(inicioAtributoPessoaJurídica + 5);
        }

        public static string FormatarCNPJ(string cnpf)
        {
            if (String.IsNullOrWhiteSpace(cnpf))
                return "";

            cnpf = cnpf.Replace(".", "").Replace("/", "").Replace("-", "");

            if (cnpf.Length < 14)
                cnpf = cnpf + new String(' ', 14 - cnpf.Length);

            return cnpf.Substring(0, 2) + "." +
                cnpf.Substring(2, 3) + "." +
                cnpf.Substring(5, 3) + "/" +
                cnpf.Substring(8, 4) + "-" +
                cnpf.Substring(12, 2); 
        }

        public static Pessoa Obter(IDataReader leitor, int inicioPessoa, int inicioPessoaJuridica)
        {
            if (leitor.IsDBNull(inicioPessoa))
                return null;

            PessoaJurídica entidade = new PessoaJurídica();

            entidade.LerAtributos(leitor, inicioPessoa, inicioPessoaJuridica);

            entidade.DefinirCadastrado();
            entidade.DefinirAtualizado();

            return entidade;
        }
    }
}
