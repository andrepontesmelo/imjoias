
using Apresenta��o.Formul�rios;

[assembly: ExporBot�o(
    4,
    typeof(Apresenta��o.Atendimento.Atendente.ControladorAtendimentoDin�mico),
    Entidades.Privil�gio.Permiss�o.Nenhuma,
    "Atendimento",
    false)]

namespace Apresenta��o.Atendimento.Atendente
{
    /// <summary>
    /// Controlador de atendimentos para bases inferiores.
    /// </summary>
    public class ControladorAtendimentoDin�mico : ControladorAtendimentoGen�rico
	{
		#region Atributos

		/// <summary>
		/// Funcion�rio atual.
		/// </summary>
		private Entidades.Pessoa.Funcion�rio funcion�rio;

        private BaseListaAtendimentos baseListaAtendimentos;

		#endregion

		#region Construtora

		/// <summary>
		/// Constr�i o controlador para atendimentos.
		/// </summary>
		public ControladorAtendimentoDin�mico()
		{
		}

		#endregion

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
        protected internal override void AoCarregarCompletamente(Splash splash)
		{
            baseListaAtendimentos = new BaseListaAtendimentos();
            baseListaAtendimentos.Escolhida += new Apresenta��o.Atendimento.Clientes.BaseSele��oCliente.EscolhaPessoa(IniciarAtendimento);

            InserirBaseInferior(baseListaAtendimentos);

            Bot�o.Imagem = Resource.ApertoM�o;

			base.AoCarregarCompletamente(splash);
		}
	}
}
