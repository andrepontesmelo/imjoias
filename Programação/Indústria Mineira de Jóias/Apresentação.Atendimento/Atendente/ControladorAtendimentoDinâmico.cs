using System;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

using Apresentação.Formulários;

[assembly: ExporBotão(
    0,
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
		protected override void AoCarregarCompletamente(Splash splash)
		{
			// Obter funcionário atual.
            funcionário = Entidades.Pessoa.Funcionário.FuncionárioAtual;

            if (funcionário == null || funcionário.Setor == null)
                throw new ExceçãoBotãoNãoSuportado("É necessário um funcionário atribuído a um setor.");

            if (funcionário.Setor.Atendimento)
            {
                baseListaAtendimentos = new BaseListaAtendimentos();
                baseListaAtendimentos.Escolhida += new Apresentação.Atendimento.Clientes.BaseSeleçãoCliente.EscolhaPessoa(IniciarAtendimento);

                InserirBaseInferior(baseListaAtendimentos);
            }

            Botão.Imagem = Properties.Resources.ApertoMão;

			base.AoCarregarCompletamente(splash);
		}
	}
}
