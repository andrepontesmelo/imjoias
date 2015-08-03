using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Pessoa.Histórico
{
    /// <summary>
    /// Item do histórico da interface gráfica.
    /// </summary>
    class HistóricoPessoaItem : Apresentação.Formulários.Histórico.HistóricoItemBase
    {
        /// <summary>
        /// Entidade que contém os dados.
        /// </summary>
        private Entidades.Pessoa.Histórico entidade;


        /// <summary>
        /// Constrói o item de histórico da pessoa.
        /// </summary>
        /// <param name="entidade">Entidade do histórico.</param>
        public HistóricoPessoaItem(Entidades.Pessoa.Histórico entidade)
        {
            this.entidade = entidade;
        }

        /// <summary>
        /// Item de histórico digitado por...
        /// </summary>
        public override string Autor
        {
            get { return entidade.DigitadoPor != null ? entidade.DigitadoPor.Nome : "(sem autoria)"; }
        }

        /// <summary>
        /// Data de registro do item de histórico.
        /// </summary>
        public override DateTime Registro
        {
            get { return entidade.Data; }
        }

        /// <summary>
        /// Texto do item do histórico.
        /// </summary>
        public override string Texto
        {
            get { return entidade.Texto; }
        }
    }
}
