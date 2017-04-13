
using Apresentação.Formulários;

[assembly: ExporBotão(
    4,
    typeof(Apresentação.Atendimento.Atendente.ControladorAtendimentoDinâmico),
    Entidades.Privilégio.Permissão.Nenhuma,
    "Atendimento",
    false)]

namespace Apresentação.Atendimento.Atendente
{
    /// <summary>
    /// Controlador de atendimentos para bases inferiores.
    /// </summary>
    public class ControladorAtendimentoDinâmico : ControladorAtendimentoGenérico
	{
		#region Atributos

		/// <summary>
		/// Funcionário atual.
		/// </summary>
		private Entidades.Pessoa.Funcionário funcionário;

        private BaseListaAtendimentos baseListaAtendimentos;

		#endregion

		#region Construtora

		/// <summary>
		/// Constrói o controlador para atendimentos.
		/// </summary>
		public ControladorAtendimentoDinâmico()
		{
		}

		#endregion

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
        protected internal override void AoCarregarCompletamente(Splash splash)
		{
            baseListaAtendimentos = new BaseListaAtendimentos();
            baseListaAtendimentos.Escolhida += new Apresentação.Atendimento.Clientes.BaseSeleçãoCliente.EscolhaPessoa(IniciarAtendimento);

            InserirBaseInferior(baseListaAtendimentos);

            Botão.Imagem = Resource.ApertoMão;

			base.AoCarregarCompletamente(splash);
		}
	}
}
