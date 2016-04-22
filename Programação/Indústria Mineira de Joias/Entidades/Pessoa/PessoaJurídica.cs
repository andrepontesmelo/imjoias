using System;
using System.Data;
using Acesso.Comum.Cache;
using System.Collections.Generic;

namespace Entidades.Pessoa
{
    [Serializable, Cache�vel("ObterPessoaSemCache"), Cache�vel("ObterPessoaPorCNPJSemCache")]
	public class PessoaJur�dica : Pessoa
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
                        throw new Exception("CNPJ inv�lido.");

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
		/// Obt�m pessoa-jur�dica a partir do CNPJ.
		/// </summary>
		/// <param name="cnpj">CNPJ da pessoa-jur�dica.</param>
		/// <returns>Pessoa-jur�dica.</returns>
		public static PessoaJur�dica ObterPessoaPorCNPJ(string cnpj)
        {
            return (PessoaJur�dica) CacheDb.Inst�ncia.ObterEntidade(typeof(PessoaJur�dica), cnpj);
        }

        private static PessoaJur�dica ObterPessoaPorCNPJSemCache(string cnpj)
		{
            cnpj = FormatarCNPJ(cnpj);
            
			IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM pessoa p, pessoajuridica pj"
                        + " WHERE p.codigo = pj.codigo"
                        + " AND pj.cnpj = " + DbTransformar(cnpj);

                    return Mapear�nicaLinha<PessoaJur�dica>(cmd);
                }
            }
		}

        public static List<Pessoa> ObterPessoasPorCNPJ(string cnpj)
        {
            string cnpjFormatado = FormatarCNPJ(cnpj);

            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
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
		/// Obt�m uma pessoa a partir de um c�digo.
		/// </summary>
		/// <param name="c�digo">C�digo da pessoa.</param>
		/// <returns>Retorna uma pessoa-jur�dica.</returns>
        public new static PessoaJur�dica ObterPessoa(ulong c�digo)
        {
            return (PessoaJur�dica)CacheDb.Inst�ncia.ObterEntidade(typeof(PessoaJur�dica), c�digo);
        }

        private new static PessoaJur�dica ObterPessoaSemCache(ulong c�digo)
		{
            return Pessoa.ObterPessoaSemCache(c�digo) as PessoaJur�dica;
            
            //string comando = "SELECT * FROM pessoa p, pessoajuridica pj"
            //    + " WHERE p.codigo = pj.codigo"
            //    + " AND p.codigo = " + DbTransformar(c�digo);

            //return Mapear�nicaLinha<PessoaJur�dica>(comando);
		}

        /// <summary>
        /// Valida o CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ formatado ou n�o.</param>
        /// <returns>Se o CNPJ � v�lido.</returns>
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

            #region N�o funciona

            //int[] n�mero;
            //int d1, d2;
            //int soma;

            //if (!ExtrairN�merosCNPJ(cnpj, out n�mero))
            //    return false;

            //soma = n�mero[0] * 5 + n�mero[1] * 4 + n�mero[2] * 3
            //    + n�mero[3] * 2 + n�mero[4] * 9 + n�mero[5] * 8
            //    + n�mero[6] * 7 + n�mero[7] * 6 + n�mero[8] * 5
            //    + n�mero[9] * 4 + n�mero[10] * 3 + n�mero[11] * 2;

            //soma %= 11;

            //d1 = soma < 2 ? 0 : 11 - soma;

            //soma = n�mero[0] * 6 + n�mero[1] * 5 + n�mero[2] * 4
            //    + n�mero[3] * 3 + n�mero[4] * 2 + n�mero[5] * 9
            //    + n�mero[6] * 8 + n�mero[7] * 7 + n�mero[8] * 6
            //    + n�mero[9] * 5 + n�mero[10] * 4 + n�mero[11] * 3
            //    + n�mero[12] * 2;

            //soma %= 11;

            //d2 = soma < 2 ? 0 : 11 - soma;

            //return d1 == n�mero[12] && d2 == n�mero[13];

            #endregion

            #region C�digo em VB
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
        /// Extrai n�meros do CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ formatado ou n�o.</param>
        /// <param name="n�mero">Vetor que armazenar� os n�meros do CNPJ.</param>
        /// <returns>Se foi poss�vel extrair os 13 n�meros do CNPJ.</returns>
        private static bool ExtrairN�merosCNPJ(string cnpj, out int[] n�mero)
        {
            int i = 0;

            n�mero = new int[13];

            try
            {
                foreach (char c in cnpj)
                    if (char.IsNumber(c))
                        n�mero[i++] = c - '0';

                return i == 13;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica exist�ncia de CNPJ.
        /// </summary>
        /// <returns>Se o CNPJ j� est� cadastrado.</returns>
        public static bool VerificarExist�nciaCNPJ(PessoaJur�dica entidade)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
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
                DbTransformar(C�digo) + ", " +
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

        protected virtual void LerAtributos(IDataReader leitor, int inicioAtributoPessoa, int inicioAtributoPessoaJur�dica)
        {
          base.LerAtributos(leitor, inicioAtributoPessoa);

          if (!leitor.IsDBNull(inicioAtributoPessoaJur�dica + 1))
              cnpj = leitor.GetString(inicioAtributoPessoaJur�dica + 1);

          if (!leitor.IsDBNull(inicioAtributoPessoaJur�dica + 2))
                fantasia = leitor.GetString(inicioAtributoPessoaJur�dica + 2);

          if (!leitor.IsDBNull(inicioAtributoPessoaJur�dica + 3))
                inscEstadual = leitor.GetString(inicioAtributoPessoaJur�dica + 3);

          if (!leitor.IsDBNull(inicioAtributoPessoaJur�dica + 4))
                inscMunicipal = leitor.GetString(inicioAtributoPessoaJur�dica + 4);
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

            PessoaJur�dica entidade = new PessoaJur�dica();

            // Preenche os atributos da tabela pessoa.
            entidade.LerAtributos(leitor, inicioPessoa, inicioPessoaJuridica);

            entidade.DefinirCadastrado();
            entidade.DefinirAtualizado();

            return entidade;
        }
    }
}
