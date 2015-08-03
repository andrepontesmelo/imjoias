namespace Apresenta��o.�lbum.Edi��o.�lbuns.Desenhista
{
	[System.Flags]
	public enum ItensImpress�o
	{
		Foto			    = 0x001,
		Refer�ncia		    = 0x002,
		Descri��o		    = 0x004,
		Fornecedor		    = 0x008,
        FornecedorRefer�ncia = 0x010,
        Descri��oMercadoria = 0x020,
        FaixaGrupo          = 0x040,
        �ndice              = 0x080,
        Peso                = 0x100,
        Logotipo            = 0x200,
        ForaDeLinha         = 0x400,
        
        RequerMercadoria    = Descri��oMercadoria | FaixaGrupo | �ndice | Peso
	}
}