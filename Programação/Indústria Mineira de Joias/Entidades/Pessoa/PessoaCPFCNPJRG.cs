using System;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Pessoa contendo CPF, CNPJ e RG, para fins de recuperação do banco de dados
    /// </summary>
    [Serializable]
	public class PessoaCPFCNPJRG : Pessoa
	{
		//Atributos
		protected string cpf = null, cnpj = null, rg = null;

		#region Propriedades
		public string CPF
		{
			get { return cpf; }
		}

		public string CNPJ
		{
			get { return cnpj; }
		}

		public string RG
		{
			get { return rg; }
		}

		public string Documento
		{
			get
			{
				if (cpf != null && cpf.Length > 0)
					return "CPF: " + cpf;
				else if (cnpj != null && cnpj.Length > 0)
					return "CNPJ: " + cnpj;
				else if (rg != null && rg.Length > 0)
					return "RG: " + rg;
				return "";
			}
		}

		#endregion


		/// <summary>
		/// Converte para pessoa-física.
		/// </summary>
		public static explicit operator PessoaFísica(PessoaCPFCNPJRG pessoa)
		{
			return PessoaFísica.ObterPessoa(pessoa.Código);
		}

		/// <summary>
		/// Converte para pessoa-jurídica.
		/// </summary>
		public static explicit operator PessoaJurídica(PessoaCPFCNPJRG pessoa)
		{
			return PessoaJurídica.ObterPessoa(pessoa.Código);
		}

        public static string FormatarCpfCnpj(string cpfCnpj)
        {
            if (cpfCnpj.Length == 11)
                return PessoaFísica.Formatar(cpfCnpj);
            else
                return PessoaJurídica.FormatarCNPJ(cpfCnpj);
        }
    }
}
