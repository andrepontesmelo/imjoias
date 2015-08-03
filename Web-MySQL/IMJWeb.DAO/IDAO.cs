using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.DAO
{
    /// <summary>
    /// DAO genérico de entidades.
    /// </summary>
    /// <typeparam name="Entidade">Tipo da entidade.</typeparam>
    /// <typeparam name="ID">Tipo do identificador.</typeparam>
    public interface IDAO<Entidade, ID> : IDisposable
    {
        /// <summary>
        /// Inclui a entidade.
        /// </summary>
        /// <typeparam name="entidade">Entidade a ser incluída.</typeparam>
        Entidade Incluir(Entidade entidade);

        /// <summary>
        /// Atualiza a entidade.
        /// </summary>
        /// <typeparam name="entidade">Entidade a ser atualizada.</typeparam>
        void Atualizar(Entidade entidade);

        /// <summary>
        /// Remove a entidade.
        /// </summary>
        /// <typeparam name="entidade">Entidade a ser removida.</typeparam>
        void Remover(Entidade entidade);

        /// <summary>
        /// Obtém a entidade por meio de seu identificador.
        /// </summary>
        /// <param name="identificador">Identificador da entidade.</param>
        /// <returns>Entidade, se existente, ou nulo.</returns>
        Entidade Obter(ID identificador);

        /// <summary>
        /// Libera a entidade, removendo qualquer referência.
        /// </summary>
        /// <param name="entidade">Entidade a ser liberada.</param>
        void Liberar(Entidade entidade);

        /// <summary>
        /// Associa um DAO a outro, de forma a compartilhar objetos.
        /// </summary>
        void AssociarSe<Entidade2, ID2>(IDAO<Entidade2, ID2> dao);
    }
}
