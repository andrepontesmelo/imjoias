using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO.Db4o
{
    public class EstatisticaMercadoria
    {
        public Referencia Referencia { get; set; }
        public ulong Hits { get; set; }
        public ulong Visualizacoes { get; set; }
    }
}
