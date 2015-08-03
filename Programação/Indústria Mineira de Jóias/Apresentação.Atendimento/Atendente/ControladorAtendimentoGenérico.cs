using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

using Apresenta��o.Atendimento.Clientes;
using Apresenta��o.Formul�rios;
using Entidades.Pessoa;

namespace Apresenta��o.Atendimento.Atendente
{
	/// <summary>
	/// Controlador de atendimento para bases inferiores.
	/// </summary>
	public class ControladorAtendimentoGen�rico : ControladorBaseInferior
	{
		private BaseSele��oClienteSetor baseSele��oClienteSetor;
		private BaseAtendimento         baseAtendimento;
        private bool                    modoAtendimento = false;

		/// <summary>
		/// Constr�i o controlador da base inferior para relacionar.
		/// </summary>
		public ControladorAtendimentoGen�rico()
		{
			baseSele��oClienteSetor = new Apresenta��o.Atendimento.Clientes.BaseSele��oClienteSetor();
			baseSele��oClienteSetor.Escolhida += new Apresenta��o.Atendimento.Clientes.BaseSele��oCliente.EscolhaPessoa(IniciarAtendimento);

			baseAtendimento = new BaseAtendimento();

			this.Retornar�Primeira = false;
		}

		/// <summary>
		/// Ocorre ao carregar o controlador.
		/// </summary>
		protected override void AoCarregarCompletamente(Splash splash)
		{
            InserirBaseInferior(baseSele��oClienteSetor);
            InserirBaseInferior(baseAtendimento);
            
            /* A inser��o de base inferior deve ocorrer antes de chamar
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
            if (pessoa is Entidades.Pessoa.PessoaF�sica ||
                (pessoa is Entidades.Pessoa.PessoaCPFCNPJRG && ((PessoaCPFCNPJRG) pessoa).CPF != null))
                baseAtendimento.Preparar(Entidades.Pessoa.PessoaF�sica.ObterPessoaSemCache(pessoa.C�digo));
            else
                baseAtendimento.Preparar(Entidades.Pessoa.PessoaJur�dica.ObterPessoaSemCache(pessoa.C�digo));

			SubstituirBaseAtual(baseAtendimento);
			MostrarBaseFormul�rio(baseAtendimento);
		}

        /// <summary>
        /// Mostra sele��o de cliente.
        /// </summary>
        public void ExibirSele��oCliente()
        {
            MostrarBaseFormul�rio(baseSele��oClienteSetor);
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