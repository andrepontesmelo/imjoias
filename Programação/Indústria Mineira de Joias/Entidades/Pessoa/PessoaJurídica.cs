using System;
using System.Data;
using Acesso.Comum.Cache;
using System.Collections.Generic;

namespace Entidades.Pessoa
{
    [Serializable, Cacheável("ObterPessoaSemCache"), Cacheável("ObterPessoaPorCNPJSemCache")]
	public class PessoaJurídica : Pessoa
	{
        /// <summary>
        /// Nome fantasia.
        /// </summary>
        protected string fantasia;
        
        protected string cnpj;
        protected string inscEstadual;
        protected string inscMunicipal;

        public string Fantasia
        {
            get { return fantasia; }
            set { fantasia = value; DefinirDesatualizado(); }
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

                    cnpj = cnpjFormatado;
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

        /// <summary>
		/// Obtém pessoa-jurídica a partir do CNPJ.
		/// </summary>
		/// <param name="cnpj">CNPJ da pessoa-jurídica.</param>
		/// <returns>Pessoa-jurídica.</returns>
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
                        + " AND pj.cnpj = " + DbTransformar(cnpj);

                    return MapearÚnicaLinha<PessoaJurídica>(cmd);
                }
            }
		}

        public static List<Pessoa> ObterPessoasPorCNPJ(string cnpj)
        {
            string cnpjFormatado = FormatarCNPJ(cnpj);

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT p.* FROM pessoa p, pessoajuridica pj"
                        + " WHERE p.codigo = pj.codigo"
                        + " AND pj.cnpj = " + DbTransformar(cnpjFormatado)
                        + " OR pj.cnpj LIKE '%" + cnpj + "%' ";

                    return Mapear<Pessoa>(cmd);
                }
            }
        }

		/// <summary>
		/// Obtém uma pessoa a partir de um código.
		/// </summary>
		/// <param name="código">Código da pessoa.</param>
		/// <returns>Retorna uma pessoa-jurídica.</returns>
        public new static PessoaJurídica ObterPessoa(ulong código)
        {
            return (PessoaJurídica)CacheDb.Instância.ObterEntidade(typeof(PessoaJurídica), código);
        }

        private new static PessoaJurídica ObterPessoaSemCache(ulong código)
		{
            return Pessoa.ObterPessoaSemCache(código) as PessoaJurídica;
            
            //string comando = "SELECT * FROM pessoa p, pessoajuridica pj"
            //    + " WHERE p.codigo = pj.codigo"
            //    + " AND p.codigo = " + DbTransformar(código);

            //return MapearÚnicaLinha<PessoaJurídica>(comando);
		}

        /// <summary>
        /// Valida o CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ formatado ou não.</param>
        /// <returns>Se o CNPJ é válido.</returns>
        public static bool ValidarCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

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

            #region Não funciona

            //int[] número;
            //int d1, d2;
            //int soma;

            //if (!ExtrairNúmerosCNPJ(cnpj, out número))
            //    return false;

            //soma = número[0] * 5 + número[1] * 4 + número[2] * 3
            //    + número[3] * 2 + número[4] * 9 + número[5] * 8
            //    + número[6] * 7 + número[7] * 6 + número[8] * 5
            //    + número[9] * 4 + número[10] * 3 + número[11] * 2;

            //soma %= 11;

            //d1 = soma < 2 ? 0 : 11 - soma;

            //soma = número[0] * 6 + número[1] * 5 + número[2] * 4
            //    + número[3] * 3 + número[4] * 2 + número[5] * 9
            //    + número[6] * 8 + número[7] * 7 + número[8] * 6
            //    + número[9] * 5 + número[10] * 4 + número[11] * 3
            //    + número[12] * 2;

            //soma %= 11;

            //d2 = soma < 2 ? 0 : 11 - soma;

            //return d1 == número[12] && d2 == número[13];

            #endregion

            #region Código em VB
            /*
        Dim Numero(13) As Integer
        Dim soma As Integer
        Dim i As Integer
        Dim valida As Boolean
        Dim resultado1 As Integer
        Dim resultado2 As Integer

        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(cnpj.Substring(i, 1))
        Next

        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 + _
                   Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2

        soma = soma - (11 * (Int(soma / 11)))

        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            resultado1 = 11 - soma
        End If

        If resultado1 = Numero(12) Then
          soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 + _
                       Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2

            soma = soma - (11 * (Int(soma / 11)))

            If soma = 0 Or soma = 1 Then

                resultado2 = 0

            Else

                resultado2 = 11 - soma

            End If

            If resultado2 = Numero(13) Then

                Return True

            Else

                Return False

            End If

        Else

            Return False

        End If
            */
            #endregion
        }

        /// <summary>
        /// Extrai números do CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ formatado ou não.</param>
        /// <param name="número">Vetor que armazenará os números do CNPJ.</param>
        /// <returns>Se foi possível extrair os 13 números do CNPJ.</returns>
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

        /// <summary>
        /// Verifica existência de CNPJ.
        /// </summary>
        /// <returns>Se o CNPJ já está cadastrado.</returns>
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
                "inscEstadual, inscMunicipal) VALUES (" +
                DbTransformar(Código) + ", " +
                DbTransformar(Fantasia) + ", " +
                DbTransformar(CNPJ) + ", " +
                DbTransformar(InscEstadual) + ", " +
                DbTransformar(InscMunicipal)+ ")";

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
                "inscMunicipal = " + DbTransformar(inscMunicipal) +
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
        }

        private static string FormatarCNPJ(string cnpf)
        {
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

            // Preenche os atributos da tabela pessoa.
            entidade.LerAtributos(leitor, inicioPessoa, inicioPessoaJuridica);

            entidade.DefinirCadastrado();
            entidade.DefinirAtualizado();

            return entidade;
        }
    }
}
