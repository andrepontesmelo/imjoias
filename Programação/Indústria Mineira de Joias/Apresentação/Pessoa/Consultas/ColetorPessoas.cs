using System;
using Apresentação.Formulários.Consultas;
using System.Collections.Generic;

namespace Apresentação.Pessoa.Consultas
{
	/// <summary>
	/// Coleta pessoas do banco de dados
	/// </summary>
	public class ColetorPessoas : Apresentação.Formulários.Consultas.Coletor
	{
        /* O limite de itens deve ser pequeno. O grande gargalo da busca
         * está no mapeamento automatico das entidades recuperadas (Mapear())
         * Quanto mais itens recuperados, maior o tempo de demora do coletor.
         */

		// Constantes
        private readonly int    padrãoLimiteMínimo = 80;
        private readonly int?   padrãoLimiteMáximo = 160;
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
				pessoas = Entidades.Pessoa.Funcionário.ObterFuncionários(chave, controladorLimite.LimiteDinâmico);
			else
				//pessoas = Entidades.Pessoa.PessoaCPFCNPJRG.ObterPessoas(chave, controladorLimite.LimiteDinâmico);
                pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(chave, controladorLimite.LimiteDinâmico);

            //if (ulong.TryParse(chave, out código))
            //{
            //    Entidades.Pessoa.Pessoa pessoa = Entidades.Pessoa.Pessoa.ObterPessoa(código);

            //    if (pessoas.Count == 0)
            //        pessoas = new List<Entidades.Pessoa.Pessoa> { pessoa };
            //    else
            //    {
            //        List<Entidades.Pessoa.Pessoa> lista = new List<Entidades.Pessoa.Pessoa>(pessoas);
            //        lista.Add(pessoa);
            //        pessoas = lista.ToArray();
            //    }
            //}


			recuperaçãoPessoas(pessoas);
            controladorLimite.CronometrarFimObter();
		}
	}
}
