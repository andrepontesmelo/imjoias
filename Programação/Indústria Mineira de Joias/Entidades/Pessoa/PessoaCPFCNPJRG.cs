using System;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Pessoa contendo CPF, CNPJ e RG, para fins de recupera��o do banco de dados
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
		/// Converte para pessoa-f�sica.
		/// </summary>
		public static explicit operator PessoaF�sica(PessoaCPFCNPJRG pessoa)
		{
			return PessoaF�sica.ObterPessoa(pessoa.C�digo);
		}

		/// <summary>
		/// Converte para pessoa-jur�dica.
		/// </summary>
		public static explicit operator PessoaJur�dica(PessoaCPFCNPJRG pessoa)
		{
			return PessoaJur�dica.ObterPessoa(pessoa.C�digo);
		}

        public static string FormatarCpfCnpj(string cpfCnpj)
        {
            if (cpfCnpj.Length == 11)
                return PessoaF�sica.Formatar(cpfCnpj);
            else
                return PessoaJur�dica.FormatarCNPJ(cpfCnpj);
        }
    }
}
