using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO
{
    public interface IMercadoriaDAO : IDAO<IMercadoria, Referencia>
    {
        /// <summary>
        /// Inclui uma foto.
        /// </summary>
        /// <param name="foto">Foto a ser incluída.</param>
        void IncluirFoto(IFoto foto);

        /// <summary>
        /// Cria uma foto vazia para uma mercadoria.
        /// </summary>
        /// <param name="mercadoria">Mercadoria cuja foto será criada.</param>
        /// <returns>Foto vazia criada.</returns>
        IFoto CriarFoto(IMercadoria mercadoria);

        /// <summary>
        /// Remove um índice de uma mercadoria.
        /// </summary>
        /// <param name="indice">Índice da mercadoria.</param>
        void Remover(IMercadoria mercadoria, IIndice indice);

        long[] ObterFotos(Referencia referencia);

        /// <summary>
        /// Exclui todas as fotos de uma mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        void RemoverFotos(Referencia referencia);

        /// <summary>
        /// Conta a quantidade de fotos.
        /// </summary>
        int ContarFotos(Referencia referencia);

        /// <summary>
        /// Lista as mercadorias por parte da referência.
        /// </summary>
        /// <param name="parteReferencia">Parte da referência a ser procurada.</param>
        /// <returns>Lista de mercadorias.</returns>
        List<IMercadoria> ListarMercadorias(Referencia parteReferencia);

        /// <summary>
        /// Incrementa a contagem de hits na miniatura da mercadoria.
        /// </summary>
        /// <param name="referencia">Referência cuja contagem de hits será incrementada.</param>
        void IncrementarHitMiniaturaMercadoria(Referencia referencia, ulong incremento);

        /// <summary>
        /// Incrementa a contagem de hits na mercadoria.
        /// </summary>
        /// <param name="referencia">Referência cuja contagem de hits na miniatura será incrementada.</param>
        void IncrementarVisualizacaoMercadoria(Referencia referencia, ulong incremento);

        /// <summary>
        /// Obtém data da última atualização.
        /// </summary>
        /// <returns>Data da última atualização.</returns>
        DateTime? ObterDataUltimaAtualizacao();

        /// <summary>
        /// Obtém mercadorias a partir de uma data.
        /// </summary>
        /// <param name="data">Data de referência cujas mercadorias cadastradas após esta deverão ser retornadas.</param>
        /// <returns>Lista de mercadorias cadastradas após a data especificada.</returns>
        IList<IMercadoria> ObterMercadoriasAPartirDe(DateTime data);

        /// <summary>
        /// Conta a quantidade de mercadorias a partir de uma data.
        /// </summary>
        /// <param name="data">Data de referência.</param>
        /// <returns>Quantidade de mercadorias.</returns>
        int ContarMercadoriasAPartirDe(DateTime data);
    }
}
