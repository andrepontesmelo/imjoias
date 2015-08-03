namespace Apresentação.Álbum.Edição.Álbuns.Desenhista
{
	[System.Flags]
	public enum ItensImpressão
	{
		Foto			    = 0x001,
		Referência		    = 0x002,
		Descrição		    = 0x004,
		Fornecedor		    = 0x008,
        FornecedorReferência = 0x010,
        DescriçãoMercadoria = 0x020,
        FaixaGrupo          = 0x040,
        Índice              = 0x080,
        Peso                = 0x100,
        Logotipo            = 0x200,
        ForaDeLinha         = 0x400,
        
        RequerMercadoria    = DescriçãoMercadoria | FaixaGrupo | Índice | Peso
	}
}