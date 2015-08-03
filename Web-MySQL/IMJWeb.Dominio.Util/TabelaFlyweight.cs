using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.Dominio.Util
{
    /// <summary>
    /// Objeto do tipo "Flyweight" para representar uma tabela
    /// como objeto do domínio.
    /// </summary>
    public class TabelaFlyweight : ITabela
    {
        /// <summary>
        /// ID da tabela.
        /// </summary>
        public int IDTabela { get; private set; }

        /// <summary>
        /// Constrói o objeto flyweight.
        /// </summary>
        /// <param name="tabela">Identificador da tabela.</param>
        /// <remarks>
        /// Por ser um objeto flyweight, somente a fábrica pode
        /// criar este objeto.
        /// <see cref="IMJWeb.Dominio.Util.TabelaFlyweight.ObterRegiao"/>
        /// </remarks>
        private TabelaFlyweight(int tabela)
        {
            this.IDTabela = tabela;
        }

        #region Parte estática

        /// <summary>
        /// Repositório de objetos flyweight.
        /// </summary>
        private static Dictionary<long, TabelaFlyweight> tabelas = new Dictionary<long, TabelaFlyweight>();

        /// <summary>
        /// Obtém a região para determinado identificador.
        /// </summary>
        /// <param name="tabela">Identificador da tabela.</param>
        /// <returns>Objeto flyweight da região.</returns>
        public static TabelaFlyweight ObterTabela(int tabela)
        {
            TabelaFlyweight flyweight;

            lock (tabelas)
            {
                if (!tabelas.TryGetValue(tabela, out flyweight))
                {
                    flyweight = new TabelaFlyweight(tabela);
                    tabelas.Add(tabela, flyweight);
                }
            }

            return flyweight;
        }

        #endregion
    }
}
