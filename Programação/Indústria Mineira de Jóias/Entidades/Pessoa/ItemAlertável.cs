using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Pessoa
{
    public abstract class ItemAlertável : DbManipulaçãoAutomática
    {
        /// <summary>
        /// Determina se deve alertar sobre esta
        /// classificação durante a venda.
        /// </summary>
        protected bool alertarVenda;

        /// <summary>
        /// Determina se deve alertar sobre esta
        /// classificação durante uma saída de consignação.
        /// </summary>
        [DbColuna("alertarSaida")]
        protected bool alertarSaída;

        /// <summary>
        /// Determina se deve alertar sobre esta
        /// classificação durante uma saída para correio.
        /// </summary>
        protected bool alertarCorreio;

        /// <summary>
        /// Determina se deve alertar ao iniciar um conserto.
        /// </summary>
        protected bool alertarPedido;

        ///// <summary>
        ///// Fica em vermelho no relatório.
        ///// </summary>
        //protected bool alertarRelatorio;

        public enum TipoAlerta
        {
            Venda, Saída, Correio, Pedido
        }

        #region Propriedades

        /// <summary>
        /// Determina se deve alertar sobre esta
        /// classificação durante a venda.
        /// </summary>
        public bool AlertarVenda
        {
            get { return alertarVenda; }
            set
            {
                alertarVenda = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Determina se deve alertar sobre esta
        /// classificação durante uma saída de consignação.
        /// </summary>
        public bool AlertarSaída
        {
            get { return alertarSaída; }
            set
            {
                alertarSaída = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Determina se deve alertar sobre esta
        /// classificação durante uma saída para correio.
        /// </summary>
        public bool AlertarCorreio
        {
            get { return alertarCorreio; }
            set
            {
                alertarCorreio = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Determina se deve alertar ao iniciar um conserto.
        /// </summary>
        public bool AlertarPedido
        {
            get { return alertarPedido; }
            set
            {
                alertarPedido = value;
                DefinirDesatualizado();
            }
        }

        ///// <summary>
        ///// Determina se deve alertar ao iniciar um conserto.
        ///// </summary>
        //public bool AlertarRelatório
        //{
        //    get { return alertarRelatorio; }
        //    set
        //    {
        //        alertarRelatorio = value;
        //        DefinirDesatualizado();
        //    }
        //}
        #endregion
    }
}
