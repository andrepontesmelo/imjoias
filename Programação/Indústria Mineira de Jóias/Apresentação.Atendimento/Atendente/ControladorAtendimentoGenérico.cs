using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

using Apresentação.Atendimento.Clientes;
using Apresentação.Formulários;
using Entidades.Pessoa;

namespace Apresentação.Atendimento.Atendente
{
	/// <summary>
	/// Controlador de atendimento para bases inferiores.
	/// </summary>
	public class ControladorAtendimentoGenérico : ControladorBaseInferior
	{
		private BaseSeleçãoClienteSetor baseSeleçãoClienteSetor;
		private BaseAtendimento         baseAtendimento;
        private bool                    modoAtendimento = false;

		/// <summary>
		/// Constrói o controlador da base inferior para relacionar.
		/// </summary>
		public ControladorAtendimentoGenérico()
		{
			baseSeleçãoClienteSetor = new Apresentação.Atendimento.Clientes.BaseSeleçãoClienteSetor();
			baseSeleçãoClienteSetor.Escolhida += new Apresentação.Atendimento.Clientes.BaseSeleçãoCliente.EscolhaPessoa(IniciarAtendimento);

			baseAtendimento = new BaseAtendimento();

			this.RetornarÀPrimeira = false;
		}

		/// <summary>
		/// Ocorre ao carregar o controlador.
		/// </summary>
		protected override void AoCarregarCompletamente(Splash splash)
		{
            InserirBaseInferior(baseSeleçãoClienteSetor);
            InserirBaseInferior(baseAtendimento);
            
            /* A inserção de base inferior deve ocorrer antes de chamar
             * o AoCarregarCompletamente da base.
             */
            base.AoCarregarCompletamente(splash);
		}

		/// <summary>
		/// Inicia atendimento de uma epssoa.
		/// </summary>
		/// <param name="pessoa">Pessoa escolhida.</param>
		protected void IniciarAtendimento(Entidades.Pessoa.Pessoa pessoa)
		{
            // Evitando que cache de pessoa seja utilizada no atendimento
            if (pessoa is Entidades.Pessoa.PessoaFísica ||
                (pessoa is Entidades.Pessoa.PessoaCPFCNPJRG && ((PessoaCPFCNPJRG) pessoa).CPF != null))
                baseAtendimento.Preparar(Entidades.Pessoa.PessoaFísica.ObterPessoaSemCache(pessoa.Código));
            else
                baseAtendimento.Preparar(Entidades.Pessoa.PessoaJurídica.ObterPessoaSemCache(pessoa.Código));

			SubstituirBaseAtual(baseAtendimento);
			MostrarBaseFormulário(baseAtendimento);
		}

        /// <summary>
        /// Mostra seleção de cliente.
        /// </summary>
        public void ExibirSeleçãoCliente()
        {
            MostrarBaseFormulário(baseSeleçãoClienteSetor);
        }

        /// <summary>
        /// Define o modo de atendimento.
        /// </summary>
        [DefaultValue(false)]
        public bool ModoAtendimento
        {
            get { return modoAtendimento; }
            set { modoAtendimento = value; }
        }
	}
}