using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO.Db4o.Entidades
{
    public class Indice : IIndice
    {
        public int IDTabela { get; set; }

        public decimal Valor { get; set; }

        public override bool Equals(object obj)
        {
            IIndice outro = obj as IIndice;

            if (outro == null)
                return false;

            return outro.IDTabela == this.IDTabela && outro.Valor == this.Valor;
        }

        public override int GetHashCode()
        {
            return IDTabela.GetHashCode() ^ Valor.GetHashCode();
        }
    }
}
