namespace Neg�cio.Estoque
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
		/// Obt�m vetor de impostos
		/// </summary>
		Imposto[] Impostos { get; }
	}
}