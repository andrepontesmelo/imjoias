using System;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

using Apresenta��o.Formul�rios;

[assembly: ExporBot�o(
    0,
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
		protected override void AoCarregarCompletamente(Splash splash)
		{
			// Obter funcion�rio atual.
            funcion�rio = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual;

            if (funcion�rio == null || funcion�rio.Setor == null)
                throw new Exce��oBot�oN�oSuportado("� necess�rio um funcion�rio atribu�do a um setor.");

            if (funcion�rio.Setor.Atendimento)
            {
                baseListaAtendimentos = new BaseListaAtendimentos();
                baseListaAtendimentos.Escolhida += new Apresenta��o.Atendimento.Clientes.BaseSele��oCliente.EscolhaPessoa(IniciarAtendimento);

                InserirBaseInferior(baseListaAtendimentos);
            }

            Bot�o.Imagem = Properties.Resources.ApertoM�o;

			base.AoCarregarCompletamente(splash);
		}
	}
}
