using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO.Db4o
{
    public class ControleMercadoria
    {
        public Referencia Referencia { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
