using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.Servico.Catalogo.TO
{
    [Serializable]
    public struct IndiceTO : IIndice
    {
        public int IDTabela { get; set; }
        public decimal Valor { get; set; }
    }
}
