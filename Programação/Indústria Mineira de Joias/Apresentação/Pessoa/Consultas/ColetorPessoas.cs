using System;
using Apresentação.Formulários.Consultas;
using System.Collections.Generic;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Consultas
{
	/// <summary>
	/// Coleta pessoas do banco de dados
	/// </summary>
	public class ColetorPessoas : Coletor
	{
		// Constantes
        private readonly int    padrãoLimiteMínimo = 80;
        private readonly int?   padrãoLimiteMáximo = 105;
        private readonly int    padrãoDemoraMáximaMs = 500;

		// Atributos
		private bool			            funcionários = false;	// Coletar somente funcionários
		private bool			            vendedores = false;	    // Coletar somente vendedores
        private ControladorLimiteColetor    controladorLimite;      // Controla o limite dos nomes

		// Delegações
		public delegate void RecuperaçãoPessoasDelegate(List<Entidades.Pessoa.Pessoa> pessoas);
		private RecuperaçãoPessoasDelegate recuperaçãoPessoas;

		public ColetorPessoas(RecuperaçãoPessoasDelegate recuperação)
		{
			// Atribui tratamento de recuperação
			this.recuperaçãoPessoas = recuperação;

            controladorLimite = new ControladorLimiteColetor(padrãoLimiteMínimo, padrãoLimiteMáximo, padrãoDemoraMáximaMs);
		}

		/// <summary>
		/// Coletar somente funcionários
		/// </summary>
		public bool Funcionários
		{
			get { return funcionários; }
			set
			{
				if (funcionários != value)
				{
					funcionários = value;
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

            if (vendedores && !funcionários)
                pessoas = Entidades.Pessoa.Pessoa.ObterVendedores(chave, controladorLimite.LimiteDinâmico);
			else if (funcionários)
				pessoas = Funcionário.ObterFuncionários(chave, controladorLimite.LimiteDinâmico);
			else
                pessoas = BuscaTextual.ObterPessoas(chave, controladorLimite.LimiteDinâmico);

			recuperaçãoPessoas(pessoas);
            controladorLimite.CronometrarFimObter();
		}
	}
}
