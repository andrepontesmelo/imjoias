using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace Acesso.Comum
{
    /// <summary>
    /// Classe abstrata utilizada pelo atributo DbConversão.
    /// </summary>
    public abstract class DbConversor
    {
        /// <summary>
        /// Converte um dado lido do banco de dados para o objeto.
        /// </summary>
        /// <param name="valor">Valor lido do banco de dados.</param>
        /// <returns>Valor do objeto.</returns>
        public abstract object ConverterDeDB(object valor);

        /// <summary>
        /// Covnerte um dado de um objeto para o banco de dados.
        /// </summary>
        /// <param name="valor">Valor do objeto a ser convertido.</param>
        /// <returns>Valor para escrever no banco de dados.</returns>
        public abstract object ConverterParaDB(object valor);

        /// <summary>
        /// Mapeia um campo do objeto com o a coluna do banco de dados,
        /// realizando conversão.
        /// </summary>
        internal void MapearCampo(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
        {
            campo.SetValue(destino, ConverterDeDB(leitor.GetValue(iColuna)));
        }
    }
}
