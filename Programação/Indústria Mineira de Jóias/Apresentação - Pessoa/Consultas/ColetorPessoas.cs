using System;
using Apresenta��o.Formul�rios.Consultas;
using System.Collections.Generic;

namespace Apresenta��o.Pessoa.Consultas
{
	/// <summary>
	/// Coleta pessoas do banco de dados
	/// </summary>
	internal class ColetorPessoas : Apresenta��o.Formul�rios.Consultas.Coletor
	{
        /* O limite de itens deve ser pequeno. O grande gargalo da busca
         * est� no mapeamento automatico das entidades recuperadas (Mapear())
         * Quanto mais itens recuperados, maior o tempo de demora do coletor.
         */

		// Constantes
        private readonly int    padr�oLimiteM�nimo = 30;
        private readonly int?   padr�oLimiteM�ximo = 2000;
        private readonly int    padr�oDemoraM�ximaMs = 100;

		// Atributos
		private bool			            funcion�rios = false;	// Coletar somente funcion�rios
		private bool			            vendedores = false;	    // Coletar somente vendedores
        private ControladorLimiteColetor    controladorLimite;      // Controla o limite dos nomes

		// Delega��es
		public delegate void Recupera��oPessoasDelegate(Entidades.Pessoa.Pessoa [] pessoas);
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
			Entidades.Pessoa.Pessoa[] pessoas;
            ulong c�digo;

            controladorLimite.CronometrarInicioObter();

            if (vendedores && !funcion�rios)
                pessoas = Entidades.Pessoa.Pessoa.ObterVendedores(chave, controladorLimite.LimiteDin�mico);
			else if (funcion�rios)
				pessoas = Entidades.Pessoa.Funcion�rio.ObterFuncion�rios(chave, controladorLimite.LimiteDin�mico);
			else
				//pessoas = Entidades.Pessoa.PessoaCPFCNPJRG.ObterPessoas(chave, controladorLimite.LimiteDin�mico);
                pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(chave, controladorLimite.LimiteDin�mico).ToArray();

            if (ulong.TryParse(chave, out c�digo))
            {
                Entidades.Pessoa.Pessoa pessoa = Entidades.Pessoa.Pessoa.ObterPessoa(c�digo);

                if (pessoas.Length == 0)
                    pessoas = new Entidades.Pessoa.Pessoa[] { pessoa };
                else
                {
                    List<Entidades.Pessoa.Pessoa> lista = new List<Entidades.Pessoa.Pessoa>(pessoas);
                    lista.Add(pessoa);
                    pessoas = lista.ToArray();
                }
            }


			recupera��oPessoas(pessoas);
            controladorLimite.CronometrarFimObter();
		}
	}
}
