using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Privilégio
{
    /// <summary>
    /// Determina se usuário atual possui permissão para
    /// determinada funcionalidade.
    /// </summary>
    [Flags]
    public enum Permissão : uint
    {
        /* * * ATENÇÃO * * *
         * Os valores aqui devem bater com o banco de dados!
         * Não alterar valores. Ao acrescentar novas FLAGS
         * utilizar novos valores, mantendo todos os outros
         * antigos inalterados!
         */

        Nenhuma                 = 0,

        /* Cadastro de cliente */
        CadastroAcesso             = 0x00000001,
        CadastroEditar             = 0x00000002,
        CadastroRemover            = 0x00000004,
        CadastroAdicionarHistórico = 0x00000008,


        /* Consignado */
        /// <summary>
        /// Atribuído automaticamente para quem tem qualquer
        /// permissão de consignado.
        /// </summary>
        Consignado              = 0x00000010,
        ConsignadoSaída         = 0x00000020,
        ConsignadoRetorno       = 0x00000040,
        /// <summary>
        /// Permite que destranque tanto saídas quanto retornos para modificação após impressão.
        /// </summary>
        ConsignadoDestravar     = 0x00000080,       /* Representante/Atacado/Alto-atacado */


        /* Financeiro */
        EditarCotação           = 0x00000100,

        /// <summary>
        /// Atribuído automaticamente para quem tem qualquer
        /// permissão de vendas.
        /// </summary>
        Vendas                  = 0x00000200,
        VendasLeitura           = 0x00000400,
        VendasEditar            = 0x00000800,
        VendasDestravar         = 0x00001000,
        VendasVerificar         = 0x00002000,
        ZerarAcerto             = 0x00004000,
        PagarComissãoObsoleto           = 0x00008000,

        VendasRemoverControle   = VendasEditar,
        
        /// <summary>
        /// Permite a escolha de qualquer tabela, independente
        /// do setor em que trabalha.
        /// </summary>
        EscolherQualquerTabela  = 0x00010000,
        AlterarDataAcerto       = 0x00020000,
        EscolherDocumentosAcerto= 0x00040000,
        
        /// <summary>
        /// Permite que documentos de consignado sejam atribuídos
        /// em outros acertos.
        /// </summary>
        MoverDocumentoAcerto    = EscolherDocumentosAcerto,

        /// <summary>
        /// Permite acesso a documentos antigos.
        /// </summary>
        VisualizarDocumentosAntigos = 0x00080000,

        /// <summary>
        /// Gera tabela, altera as mercadorias.
        /// </summary>
        EditarMercadorias       = 0x00100000,

        /// <summary>
        /// Permite que o funcionário escolha o vendedor, cliente,
        /// tabela e outras informações da venda.
        /// </summary>
        PersonalizarVenda       = 0x00200000,

        EditarPedidosConsertos  = 0x00400000,

        Álbum                   = 0x00800000,
        ManipularComissão       = 0x01000000,
        Técnico                 = 0x02000000
    }
}
