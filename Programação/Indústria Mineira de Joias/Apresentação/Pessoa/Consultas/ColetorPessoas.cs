using System;
using Apresenta��o.Formul�rios.Consultas;
using System.Collections.Generic;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa.Consultas
{
	/// <summary>
	/// Coleta pessoas do banco de dados
	/// </summary>
	public class ColetorPessoas : Coletor
	{
		// Constantes
        private readonly int    padr�oLimiteM�nimo = 80;
        private readonly int?   padr�oLimiteM�ximo = 105;
        private readonly int    padr�oDemoraM�ximaMs = 500;

		// Atributos
		private bool			            funcion�rios = false;	// Coletar somente funcion�rios
		private bool			            vendedores = false;	    // Coletar somente vendedores
        private ControladorLimiteColetor    controladorLimite;      // Controla o limite dos nomes

		// Delega��es
		public delegate void Recupera��oPessoasDelegate(List<Entidades.Pessoa.Pessoa> pessoas);
		private Recupera��oPessoasDelegate recupera��oPessoas;

		public ColetorPessoas(Recupera��oPessoasDelegate recupera��o)
		{
			// Atribui tratamento de recupera��o
			this.recupera��oPessoas = recupera��o;

            controladorLimite = new ControladorLimiteColetor(padr�oLimiteM�nimo, padr�oLimiteM�ximo, padr�oDemoraM�ximaMs);
		}

		/// <summary>
		/// Coletar somente funcion�rios
		/// </summary>
		public bool Funcion�rios
		{
			get { return funcion�rios; }
			set
			{
				if (funcion�rios != value)
				{
					funcion�rios = value;
					base.Cancelar();
				}
			}
		}

        /// <summary>
        /// Coletar somente vendedores
        /// </summary>
        public bool Vendedores
        {
            get { return vendedores; }
            set
            {
                if (vendedores != value)
                {
                    vendedores = value;
                    base.Cancelar();
                }
            }
        }

        /// <summary>
        /// Recupera as pessoas do banco de dados.
        /// </summary>
		protected override void Recuperar(string chave)
		{
			List<Entidades.Pessoa.Pessoa> pessoas;
            controladorLimite.CronometrarInicioObter();

            if (vendedores && !funcion�rios)
                pessoas = Entidades.Pessoa.Pessoa.ObterVendedores(chave, controladorLimite.LimiteDin�mico);
			else if (funcion�rios)
				pessoas = Funcion�rio.ObterFuncion�rios(chave, controladorLimite.LimiteDin�mico);
			else
                pessoas = BuscaTextual.ObterPessoas(chave, controladorLimite.LimiteDin�mico);

			recupera��oPessoas(pessoas);
            controladorLimite.CronometrarFimObter();
		}
	}
}
