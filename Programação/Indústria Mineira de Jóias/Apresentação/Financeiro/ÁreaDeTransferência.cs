using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apresentação.Financeiro
{
    /// <summary>
    /// Área de transferência (clipboard)
    /// Para copiar/colar de referências em uma bandeja.
    /// </summary>
    public class ÁreaDeTransferência
    {
        #region Singleton
        private static ÁreaDeTransferência instância = null;

        private ÁreaDeTransferência()
        {
        }

        public static ÁreaDeTransferência Instância 
        {
            get
            {
                if (instância == null)
                    instância = new ÁreaDeTransferência();

                return instância;
            }
        }
        #endregion

        public List<ISaquinho> Lista
        {
            get 
            {
                if (lista == null) lista = new List<ISaquinho>();
                return lista;  
            }
        }

        private List<ISaquinho> lista;

        internal void Copiar(List<ISaquinho> lista)
        {
            this.lista = lista;
        }
    }
}
