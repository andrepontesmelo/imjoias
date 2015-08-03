using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio
{
    public interface IIndice
    {
        int IDTabela { get; set; }
        decimal Valor { get; set; }
    }
}
