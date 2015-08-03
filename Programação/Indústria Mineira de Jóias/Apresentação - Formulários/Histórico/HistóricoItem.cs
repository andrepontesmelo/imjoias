using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Apresentação.Formulários.Histórico
{
    /// <summary>
    /// Classe para exibição de um item de histórico.
    /// </summary>
    public class HistóricoItem : HistóricoItemBase
    {
        /// <summary>
        /// Momento de registro do item do histórico.
        /// </summary>
        private DateTime registro;

        /// <summary>
        /// Autoria do item.
        /// </summary>
        private string autor;

        /// <summary>
        /// Texto do histórico.
        /// </summary>
        private string texto;

        #region Propriedades

        public override DateTime Registro
        {
            get { return registro; }
        }

        public override string Autor
        {
            get { return autor; }
        }

        public override string Texto
        {
            get { return texto; }
        }

        #endregion

        public HistóricoItem(DateTime registro, string autor, string texto)
        {
            this.registro = registro;
            this.autor = autor;
            this.texto = texto;
        }
   }
}