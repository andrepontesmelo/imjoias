namespace Negócio.Estoque
{
	public interface ISujeitoImposto
	{
		/// <summary>
		/// Adiciona um imposto
		/// </summary>
		/// <param name="imposto">Imposto a ser adicionado</param>
		void AdicionarImposto(Imposto imposto);

		/// <summary>
		/// Remove um imposto
		/// </summary>
		/// <param name="imposto">Imposto a ser removido</param>
		void RemoverImposto(Imposto imposto);

		/// <summary>
		/// Obtém vetor de impostos
		/// </summary>
		Imposto[] Impostos { get; }
	}
}