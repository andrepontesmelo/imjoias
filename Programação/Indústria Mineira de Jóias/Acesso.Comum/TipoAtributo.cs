namespace Acesso.Comum
{
	/// <summary>
	/// Tipo de atributo de banco de dados.
	/// (Bitwise)
	/// </summary>
	[System.Flags]
	public enum TipoAtributo
	{
		Normal         = 0,
		Ignorar        = 1,
		ChavePrimária  = 2,
		AutoIncremento = 4,
		Relacionamento = 8
	}
}